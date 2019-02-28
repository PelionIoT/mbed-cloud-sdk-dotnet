// <copyright file="ConnectApi.Notifications.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.WebSockets;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Threading;
    using System.Threading.Tasks;
    using connector_ca.Client;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using MbedCloudSDK.Common.Tlv;
    using MbedCloudSDK.Connect.Api.Subscribe.Models;
    using MbedCloudSDK.Connect.Model.Notifications;
    using MbedCloudSDK.Connect.Model.Webhook;
    using NotificationDeliveryMethod = MbedCloudSDK.Connect.Model.Enums;
    using MbedCloudSDK.Exceptions;
    using MbedCloudSDK.Connect.Model;
    using Newtonsoft.Json;
    using Polly;
    using Mbed.Cloud.Common;
    using System.Text;

    /// <summary>
    /// Connect Api
    /// </summary>
    public partial class ConnectApi
    {
        private Task notificationTask;
        private CancellationTokenSource cancellationToken;
        private ClientWebSocket webSocketClient;
        private byte[] receivedBytes;
        private ArraySegment<byte> receivedBuffer;
        private readonly TlvDecoder tlvDecoder = new TlvDecoder();
        private Policy retryPolicy;
        private int _isClosing = 0;
        public bool IsClosing
        {
            get
            {
                return (Interlocked.CompareExchange(ref _isClosing, 1, 1)) == 1;
            }
            set
            {
                if (value)
                {
                    Interlocked.CompareExchange(ref _isClosing, 1, 0);
                }
                else
                {
                    Interlocked.CompareExchange(ref _isClosing, 0, 1);
                }
            }
        }
        private int _notificationsStarted = 0;
        public bool NotificationsStarted
        {
            get
            {
                return (Interlocked.CompareExchange(ref _notificationsStarted, 1, 1)) == 1;
            }
            set
            {
                if (value)
                {
                    Interlocked.CompareExchange(ref _notificationsStarted, 1, 0);
                }
                else
                {
                    Interlocked.CompareExchange(ref _notificationsStarted, 0, 1);
                }
            }
        }
        private int bufferLength = 1024;
        private int count = 0;

        /// <summary>
        /// Notify
        /// </summary>
        /// <param name="notification">The Notification Message as a <see cref="NotificationMessage"/></param>
        public void Notify(NotificationMessage notification)
        {
            NotifyCore(notification);
        }

        /// <summary>
        /// Notify
        /// </summary>
        /// <param name="notification">The Notification Message as a string.</param>
        public void Notify(string notification)
        {
            var message = JsonConvert.DeserializeObject<NotificationMessage>(notification);
            NotifyCore(message);
        }

        protected virtual void NotifyCore(NotificationMessage notification)
        {
            if (notification.AsyncResponses.Any())
            {
                foreach (var asyncReponse in notification.AsyncResponses)
                {
                    if (asyncReponse.Payload != null)
                    {
                        var payload = asyncReponse.DecodeBase64();
                        if (AsyncResponses.ContainsKey(asyncReponse.Id))
                        {
                            AsyncResponses[asyncReponse.Id].Add(payload);
                        }
                    }
                }
            }

            if (notification.Notifications.Any())
            {
                foreach (var item in notification.Notifications)
                {
                    var payload = item.DecodeBase64();
                    item.Payload = payload;
                    Subscribe.Notify(item);

                    var resourceSubs = item.DeviceId + item.Path;
                    if (NotificationQueue.ContainsKey(resourceSubs))
                    {
                        NotificationQueue[resourceSubs].Add(payload);
                    }
                }
            }

            if (Subscribe != null)
            {
                if (notification.Registrations.Any())
                {
                    notification.Registrations.ForEach(r =>
                        {
                            Subscribe.Notify(r);
                        });
                }

                if (notification.RegistrationUpdates.Any())
                {
                    notification.RegistrationUpdates.ForEach(r =>
                    {
                        Subscribe.Notify(r);
                    });
                }

                if (notification.DeRegistrations.Any())
                {
                    notification.DeRegistrations.ForEach(d =>
                    {
                        Subscribe.Notify(d);
                    });
                }

                if (notification.RegistrationsExpired.Any())
                {
                    notification.RegistrationsExpired.ForEach(d =>
                    {
                        Subscribe.Notify(d);
                    });
                }
            }
        }

        private void Notifications()
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                retryPolicy.Execute(() =>
                {
                    var resp = NotificationsApi.LongPollNotifications();
                    if (resp != null)
                    {
                        Notify(NotificationMessage.Map(resp));
                    }
                });
            }
        }

        /// <summary>
        /// Starts the notifications task.
        /// </summary>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     connectApi.StartNotifications();
        /// }
        /// catch (Exception)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public async Task StartNotificationsAsync()
        {
            if (!NotificationsStarted)
            {
                if (DeliveryMethod == null)
                {
                    DeliveryMethod = NotificationDeliveryMethod.DeliveryMethod.CLIENT_INITIATED;
                }

                if (DeliveryMethod == NotificationDeliveryMethod.DeliveryMethod.SERVER_INITIATED)
                {
                    throw new CloudApiException(400, "cannot call StartNotificationsAsync when delivery method is Server Initiated");
                }

                if (GetWebhook() != null && !forceClear)
                {
                    throw new CloudApiException(400, "cannot start notifications as a webhook is already in use");
                }

                // policy handler for retries. Uses Polly (https://github.com/App-vNext/Polly#wait-and-retry)
                // it will increase the time between retries progressively until it will stop ~2 minutes
                if (retryPolicy == null)
                {
                    retryPolicy = Policy.Handle<Exception>().WaitAndRetry(
                        8,
                        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                        (exception, timeSpan, retryCount, context) =>
                            {
                            // check that is really an ApiException before doing the retry logic
                            var apiException = exception as ApiException;
                                if (apiException == null || apiException.ErrorCode != 500)
                                {
                                    StopNotifications();
                                }
                            });
                }

                try
                {
                    NotificationsStarted = true;
                    if (notificationTask?.Status != TaskStatus.Running || notificationTask?.Status != TaskStatus.WaitingToRun)
                    {
                        if (forceClear)
                        {
                            ForceClear();
                        }

                        log.Info("starting notifications...");

                        // dispose of old cancellation token if instance hasn't been torn down
                        cancellationToken?.Dispose();
                        cancellationToken = new CancellationTokenSource();

                        // start a new task
                        notificationTask = Task.Factory.StartNew(_ =>
                        {
                            Notifications();
                        }, null, cancellationToken.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
                    }
                    else
                    {
                        log.Debug("notifications already started");
                    }
                }
                catch (InvalidOperationException e)
                {
                    NotificationsStarted = false;
                    log.Error(e.Message, e);
                    throw;
                }
            }
        }

        /// <summary>
        /// Stops the notifications task.
        /// </summary>
        /// <example>
        /// <code>
        /// /// try
        /// {
        ///     connectApi.StopNotifications();
        /// }
        /// catch (Exception)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public async Task StopNotificationsAsync()
        {
            if (DeliveryMethod == NotificationDeliveryMethod.DeliveryMethod.SERVER_INITIATED)
            {
                // don't call stop notifications because i'm server initiated
                log.Warn("cannot call StopNotificationsAsync when delivery method is Server Initiated");
            }
            else
            {
                log.Info("stopping notificztions...");

                if (notificationTask?.Status != TaskStatus.Running)
                {
                    log.Debug("nothing to stop...");
                }
                else
                {
                    if (cancellationToken != null)
                    {
                        // cancel and dispose the cancellation token
                        try
                        {
                            cancellationToken.Cancel();
                        }
                        catch (InvalidOperationException e)
                        {
                            // token might already be cancelled, so just log this exception
                            log.Error(e.Message, e);
                        }
                        finally
                        {
                            cancellationToken.Dispose();
                        }
                    }

                    // await StopWebsocketAsync();

                    if (notificationTask != null)
                    {
                        if (notificationTask.IsCanceled || notificationTask.IsFaulted)
                        {
                            notificationTask.Dispose();
                        }
                    }

                    if (!skipCleanup)
                    {
                        CleanUp();
                    }

                    NotificationsStarted = false;
                }
            }
        }

        private async Task InitiateWebsocket()
        {
            try
            {
                await NotificationsApi.GetWebsocketAsync();
            }
            catch (mds.Client.ApiException getException) when (getException.ErrorCode == 404)
            {
                log.Debug("no channel found so need to register a websocket");
                await RegisterWebSocket();
            }
            catch (mds.Client.ApiException e)
            {
                log.Error(e.Message, e);
                throw;
            }

            log.Debug("websocket channel exists so connect websocket");
            await StartWebsocketAsync();
        }

        private async Task RegisterWebSocket()
        {
            try
            {
                await NotificationsApi.RegisterWebsocketAsync();
            }
            catch (mds.Client.ApiException putException) when (putException.ErrorCode == 400)
            {
                log.Debug("another channel already exists so force clear and re-register websocket");
                ForceClear();
                await RegisterWebSocket();
            }
            catch (mds.Client.ApiException e)
            {
                log.Error(e.Message, e);
                throw;
            }
        }

        private void ForceClear()
        {
            try
            {
                DeleteWebhook();
            }
            catch (CloudApiException e)
            {
                if (e.ErrorCode != 404)
                {
                    log.Error(e.Message, e);
                    throw;
                }
            }
        }

        private async Task StartWebsocketAsync()
        {
            // create a new websocket client
            webSocketClient = new ClientWebSocket();
            // set subprotocals e.g. pelion_ak_123, wss
            webSocketClient.Options.AddSubProtocol($"pelion_{Config.ApiKey}");
            webSocketClient.Options.AddSubProtocol("wss");

            // create clean buffers
            receivedBytes = new byte[bufferLength];
            receivedBuffer = new ArraySegment<byte>(receivedBytes);

            // connect to url
            if (webSocketClient.State != WebSocketState.Open && webSocketClient.State != WebSocketState.CloseReceived)
            {
                await webSocketClient.ConnectAsync(new Uri(websocketUrl), CancellationToken.None);
            }
        }

        private async Task StopWebsocketAsync()
        {
            // we are closing now so set isClosing to true so we expect a 1000 normal closure
            IsClosing = true;
            // close the websocket
            if (webSocketClient.State == WebSocketState.Open || webSocketClient.State == WebSocketState.CloseReceived || webSocketClient.State == WebSocketState.CloseSent)
            {
                try
                {
                    await webSocketClient.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                }
                catch (WebSocketException e)
                {
                    // connection was closed without completing handshake
                    log.Error(e);
                }
            }

            webSocketClient.Dispose();

            // delete the channel
            try
            {
                await NotificationsApi.DeleteWebsocketAsync();
            }
            catch(mds.Client.ApiException e)
            {
                if (e.ErrorCode != 404)
                {
                    // channel may have already gone away so just log this exception
                    log.Error(e.Message, e);
                }
            }

            // now finished closing
            IsClosing = false;
        }

        private async Task handleMessageAsync(WebSocketReceiveResult message, List<byte> dynamicBuffer = null)
        {
            if (message.MessageType == WebSocketMessageType.Close)
            {
                if (message.CloseStatus == WebSocketCloseStatus.InternalServerError || message.CloseStatus == WebSocketCloseStatus.EndpointUnavailable)
                {
                    log.Debug("1011 or 1001 - re-register and restart webhook");
                    // 1011 no channel or 1001 going away

                    // once websocket goes into close state it can't be restarted without tearing down, therefore do whole setup/teardown
                    await StopWebsocketAsync();
                    await RegisterWebSocket();
                    await StartWebsocketAsync();
                }
                else if (message.CloseStatus == WebSocketCloseStatus.NormalClosure)
                {
                    if (IsClosing)
                    {
                        log.Debug("we are closing so this on close is expected");
                    }
                    else
                    {
                        log.Warn("received close message - attempting to restart websocket");
                        await StopWebsocketAsync();
                        await StartWebsocketAsync();
                    }
                }
                else if (message.CloseStatus == WebSocketCloseStatus.PolicyViolation)
                {
                    // 1008 policy violation so invalid api key
                    log.Error("1008 policy violation, stopping notifications");
                    await StopNotificationsAsync();
                }
                else
                {
                    // some other error
                    log.Error($"unexpected error from websocket - {message.CloseStatus}");
                    await StopNotificationsAsync();
                }
            }
            else
            {
                // we recieved a message
                try
                {
                    var messageBytes = dynamicBuffer?.ToArray() ?? receivedBuffer.Skip(receivedBuffer.Offset).Take(message.Count).ToArray();
                    var messageString = Encoding.UTF8.GetString(messageBytes);
                    var notification = NotificationMessage.Map(JsonConvert.DeserializeObject<mds.Model.NotificationMessage>(messageString));
                    NotifyCore(notification);
                }
                catch (Exception e)
                {
                    // exception decoding message from websocket
                    log.Error(e.Message, e);
                    throw;
                }
            }
        }

        private void CleanUp()
        {
            try
            {
                DeleteSubscriptions();
            }
            catch (CloudApiException e)
            {
                // don't care about api exceptions here, so just log them
                log.Error(e);
            }
        }

        public void StopNotifications()
        {
            AsyncHelper.RunSync(() => StopNotificationsAsync());
        }

        public void StartNotifications()
        {
            AsyncHelper.RunSync(() => StartNotificationsAsync());
        }
    }
}