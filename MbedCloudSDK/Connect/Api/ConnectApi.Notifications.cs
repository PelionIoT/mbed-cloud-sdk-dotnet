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
    using MbedCloudSDK.Exceptions;
    using MbedCloudSDK.Connect.Model;
    using Newtonsoft.Json;
    using Polly;
    using Mbed.Cloud.Foundation.Common;
    using System.Text;

    /// <summary>
    /// Connect Api
    /// </summary>
    public partial class ConnectApi
    {
        private static string WebsocketUrl = "wss://api-ns-websocket.mbedcloudintegration.net/v2/notification/websocket-connect";
        private Task notificationTask;
        private CancellationTokenSource cancellationToken;
        private ClientWebSocket webSocketClient;
        private byte[] receivedBytes;
        private ArraySegment<byte> receivedBuffer;
        private readonly TlvDecoder tlvDecoder = new TlvDecoder();
        private Policy retryPolicy;
        private bool websocketRunning = false;
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
        private int bufferLength = 2048;

        /// <summary>
        /// Notify
        /// </summary>
        /// <param name="notification">The Notification Message as a <see cref="NotificationMessage"/></param>
        public void Notify(NotificationMessage notification)
        {
            if (DeliveryMethod == DeliveryMethod.CLIENT_INITIATED)
            {
                log.Warn("Cannot call Notify when delivery method is Client Initiated");
            }
            else
            {
                NotifyFunc(notification);
            }
        }

        /// <summary>
        /// Notify
        /// </summary>
        /// <param name="notification">The Notification Message as a string.</param>
        public void Notify(string notification)
        {
            if (DeliveryMethod == DeliveryMethod.CLIENT_INITIATED)
            {
                log.Warn("Cannot call Notify when delivery method is Client Initiated");
            }
            else
            {
                var message = JsonConvert.DeserializeObject<NotificationMessage>(notification);
                NotifyFunc(message);
            }
        }

        private void NotifyFunc(NotificationMessage notification)
        {
            log.Info(notification.DebugDump());
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
            log.Info($"is cancellation requested? - {cancellationToken.IsCancellationRequested}");
            while (!cancellationToken.IsCancellationRequested)
            {
                if (webSocketClient?.State != WebSocketState.Aborted)
                {
                    log.Info("pre call receive");
                    try
                    {
                        // can't have an async method in a task action because it will return immediatley
                        var message = AsyncHelper.RunSync(() => webSocketClient.ReceiveAsync(receivedBuffer, CancellationToken.None));
                        log.Info($"Received message - {message.DebugDump()}");
                        AsyncHelper.RunSync(() => handleMessageAsync(message));
                    }
                    catch (Exception e)
                    {
                        log.Error(e.Message, e);
                    }
                }
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
            if (DeliveryMethod == DeliveryMethod.SERVER_INITIATED)
            {
                // don't call start notifications because i'm server initiated
                log.Warn("Cannot call Start Notifications when delivery method is Server Initiated");
            }
            else
            {
                try
                {
                    log.Info(notificationTask?.Status);
                    log.Info(notificationTask?.GetHashCode());
                    if (notificationTask?.Status != TaskStatus.Running )
                    {
                        if (Config.ForceClear)
                        {
                            log.Info("Force clear if a webhook exists");
                            ForceClear();
                        }

                        log.Info("starting notifications...");

                        // dispose of old cancellation token if instance hasn't been torn down
                        log.Info("disposing any old cancellation token");
                        cancellationToken?.Dispose();
                        cancellationToken = new CancellationTokenSource();

                        log.Info("initiate websocket");
                        await InitiateWebsocket();

                        log.Info("start task");
                        notificationTask = new Task(Notifications, cancellationToken.Token, TaskCreationOptions.LongRunning);
                        notificationTask.Start();

                        websocketRunning = true;
                    }
                    else
                    {
                        log.Info("StartNotifications - notifications already started");
                    }
                }
                catch (InvalidOperationException e)
                {
                    log.Error(e.Message, e);
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
            if (DeliveryMethod == DeliveryMethod.SERVER_INITIATED)
            {
                // don't call stop notifications because i'm server initiated
                log.Warn("Cannot call Stop Notifications when delivery method is Server Initiated");
            }
            else
            {
                log.Info("Stopping notificztions...");

                if (notificationTask?.Status != TaskStatus.Running)
                {
                    log.Info("Nothing to stop...");
                }
                else
                {
                    if (cancellationToken != null)
                    {
                        log.Info("dispose cancellation token");
                        try
                        {
                            cancellationToken.Cancel();
                        }
                        catch (InvalidOperationException e)
                        {
                            log.Error(e.Message, e);
                        }
                        finally
                        {
                            cancellationToken.Dispose();
                        }
                    }

                    log.Info("stopping the websocket");
                    await StopWebsocket();

                    if (notificationTask != null)
                    {
                        if (notificationTask.IsCanceled || notificationTask.IsFaulted)
                        {
                            log.Info("disposing the task");
                            notificationTask.Dispose();
                        }
                    }

                    websocketRunning = false;
                }
            }
        }

        private async Task InitiateWebsocket()
        {
            try
            {
                await WebsocketApi.GetWebsocketAsync();
            }
            catch (mds.Client.ApiException getException) when (getException.ErrorCode == 404)
            {
                log.Info("GetWebsocket - no channel found so need to register a websocket");
                await RegisterWebhook();
            }
            catch (mds.Client.ApiException e)
            {
                log.Error(e.Message, e);
                throw;
            }
            finally
            {
                log.Info("InitiateWebsocket - Channel now exists so start websocket");
                await StartWebsocket();
            }
        }

        private async Task RegisterWebhook()
        {
            try
            {
                await WebsocketApi.RegisterWebsocketAsync();
            }
            catch (mds.Client.ApiException putException) when (putException.ErrorCode == 400)
            {
                log.Info("RegisterWebhook - another channel already exists so force clear and re-register webhook");
                ForceClear();
                await RegisterWebhook();
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

        private async Task StartWebsocket()
        {
            if (webSocketClient == null)
            {
                log.Info("create the websocket client");
                webSocketClient = new ClientWebSocket();
                // set subprotocals e.g. pelion_ak_123, wss
                webSocketClient.Options.AddSubProtocol($"pelion_{Config.ApiKey}");
                webSocketClient.Options.AddSubProtocol("wss");
            }

            receivedBytes = new byte[bufferLength];
            receivedBuffer = new ArraySegment<byte>(receivedBytes);

            log.Info($"websocket status {webSocketClient.State}");
            // connect to url
            if (webSocketClient.State != WebSocketState.Open && webSocketClient.State != WebSocketState.CloseReceived)
            {
                log.Info("connect the websocket");
                await webSocketClient.ConnectAsync(new Uri(WebsocketUrl), CancellationToken.None);
            }
        }

        private async Task StopWebsocket()
        {
            // we are closing now so set isClosing to true so we expect a 1000 normal closure
            IsClosing = true;
            // close the websocket
            if (webSocketClient.State == WebSocketState.Open || webSocketClient.State == WebSocketState.CloseReceived || webSocketClient.State == WebSocketState.CloseSent)
            {
                log.Info("close the websocket");
                AsyncHelper.RunSync(() => webSocketClient.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None));
            }
            log.Info("dispose the websocket");
            webSocketClient.Dispose();
            webSocketClient = null;
            // delete the channel
            try
            {
                await WebsocketApi.DeleteWebsocketAsync();
            }
            catch(mds.Client.ApiException e)
            {
                if (e.ErrorCode != 404)
                {
                    log.Error(e.Message, e);
                }
            }

            // now finished closing
            IsClosing = false;
        }

        private async Task handleMessageAsync(WebSocketReceiveResult message)
        {
            if (message.MessageType == WebSocketMessageType.Close)
            {
                if (message.CloseStatus == WebSocketCloseStatus.InternalServerError || message.CloseStatus == WebSocketCloseStatus.EndpointUnavailable)
                {
                    log.Info("1011 or 1001 - re-register and restart webhook");
                    // 1011 no channel or 1001 going away
                    // first re-register the websocket
                    await RegisterWebhook();
                    // then re initiate the websocket
                    // await InitiateWebsocket();
                }
                else if (message.CloseStatus == WebSocketCloseStatus.NormalClosure)
                {
                    if (IsClosing)
                    {
                        log.Info("we are closing so this on close is expected");
                    }
                    else
                    {
                        log.Info("Attempting to restart websocket");
                        await StartWebsocket();
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
                    log.Error($"Some other error - {message.CloseStatus}");
                    await StopNotificationsAsync();
                }
            }
            else
            {
                // we recieved a message
                // decode to notification message
                try
                {
                    // using (MemoryStream ms = new MemoryStream(receivedBytes))
                    // {
                    //     log.Info("Decoding message...");
                    //     IFormatter br = new BinaryFormatter();
                    //     Notify(NotificationMessage.Map((mds.Model.NotificationMessage)br.Deserialize(ms)));
                    //     Array.Clear(receivedBytes, 0, receivedBytes.Length);
                    // }
                    var messageBytes = receivedBuffer.Skip(receivedBuffer.Offset).Take(message.Count).ToArray();
                    var messageString = Encoding.UTF8.GetString(messageBytes);
                    log.Info($"message - {messageString}");
                    var notification = NotificationMessage.Map(JsonConvert.DeserializeObject<mds.Model.NotificationMessage>(messageString));
                    NotifyFunc(notification);
                }
                catch (Exception e)
                {
                    // exception decoding message from websocket
                    log.Error(e.Message, e);
                    throw;
                }
            }
        }

        /// <summary>
        /// Check if  notifications have been started
        /// </summary>
        /// <returns>True if started</returns>
        public bool IsNotificationsStarted()
        {
            return websocketRunning;
        }
    }
}