// <copyright file="ConnectApi.Notifications.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.WebSockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using connector_ca.Client;
    using Mbed.Cloud.Common;
    using MbedCloudSDK.Common.Extensions;
    using MbedCloudSDK.Common.Tlv;
    using MbedCloudSDK.Connect.Model.Notifications;
    using MbedCloudSDK.Exceptions;
    using Newtonsoft.Json;
    using Polly;
    using NotificationDeliveryMethod = Model.Enums;

    /// <summary>
    /// Connect Api
    /// </summary>
    public partial class ConnectApi
    {
        private readonly TlvDecoder tlvDecoder = new TlvDecoder();
        private readonly int bufferLength = 1024;
        private CancellationTokenSource cancellationToken;
        private int count;
        private int isClosing;
        private int notificationsStarted;
        private Task notificationTask;
        private ArraySegment<byte> receivedBuffer;
        private byte[] receivedBytes;
        private AsyncPolicy retryPolicy;
        private ClientWebSocket webSocketClient;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is closing.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is closing; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosing
        {
            get
            {
                return Interlocked.CompareExchange(ref isClosing, 1, 1) == 1;
            }

            set
            {
                if (value)
                {
                    Interlocked.CompareExchange(ref isClosing, 1, 0);
                }
                else
                {
                    Interlocked.CompareExchange(ref isClosing, 0, 1);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [notifications started].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [notifications started]; otherwise, <c>false</c>.
        /// </value>
        public bool NotificationsStarted
        {
            get
            {
                return Interlocked.CompareExchange(ref notificationsStarted, 1, 1) == 1;
            }

            set
            {
                if (value)
                {
                    Interlocked.CompareExchange(ref notificationsStarted, 1, 0);
                }
                else
                {
                    Interlocked.CompareExchange(ref notificationsStarted, 0, 1);
                }
            }
        }

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

        /// <summary>
        /// Starts the notifications.
        /// </summary>
        public void StartNotifications()
        {
            AsyncHelper.RunSync(() => StartNotificationsAsync());
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
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
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

                try
                {
                    NotificationsStarted = true;
                    if (notificationTask?.Status != TaskStatus.Running || notificationTask?.Status != TaskStatus.WaitingToRun)
                    {
                        if (forceClear)
                        {
                            ForceClear();
                        }

                        Log.Info($"starting notifications... in {this.GetHashCode()}");

                        // dispose of old cancellation token if instance hasn't been torn down
                        cancellationToken?.Dispose();
                        cancellationToken = new CancellationTokenSource();

                        await InitiateWebsocketAsync();

                        // start a new task
                        notificationTask = Task.Factory.StartNew(
                            async _ =>
                        {
                            var dynamicBuffer = new List<byte>();
                            while (!cancellationToken.IsCancellationRequested)
                            {
                                try
                                {
                                    if (webSocketClient.State == WebSocketState.Open || webSocketClient.State == WebSocketState.CloseSent)
                                    {
                                        var message = await webSocketClient.ReceiveAsync(receivedBuffer, CancellationToken.None);
                                        if (message.EndOfMessage)
                                        {
                                            if (dynamicBuffer.Any())
                                            {
                                                // add end of message first
                                                dynamicBuffer.AddRange(receivedBuffer.Skip(receivedBuffer.Offset).Take(message.Count));
                                                // we got a big message
                                                await handleMessageAsync(message, dynamicBuffer);
                                                dynamicBuffer.Clear();
                                            }
                                            else
                                            {
                                                // can decode straight
                                                await handleMessageAsync(message);
                                            }
                                        }
                                        else
                                        {
                                            dynamicBuffer.AddRange(receivedBuffer.Skip(receivedBuffer.Offset).Take(message.Count));
                                        }

                                    }
                                    else if (webSocketClient.State == WebSocketState.Connecting)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        Log.Warn($"websocket is in an invalid state to receive - {webSocketClient.State}");
                                    }
                                }
                                catch (WebSocketException e)
                                {
                                    Log.Error(e.Message, e);
                                    throw;
                                }
                            }
                        }, null, cancellationToken.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
                    }
                    else
                    {
                        Log.Debug("notifications already started");
                    }
                }
                catch (InvalidOperationException e)
                {
                    NotificationsStarted = false;
                    Log.Error(e.Message, e);
                    throw;
                }
            }
        }

        /// <summary>
        /// Stops the notifications.
        /// </summary>
        public void StopNotifications()
        {
            AsyncHelper.RunSync(() => StopNotificationsAsync());
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
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task StopNotificationsAsync()
        {
            if (DeliveryMethod == NotificationDeliveryMethod.DeliveryMethod.SERVER_INITIATED)
            {
                // don't call stop notifications because i'm server initiated
                Log.Warn("cannot call StopNotificationsAsync when delivery method is Server Initiated");
            }
            else
            {
                Log.Info($"stopping notificztions... in {this.GetHashCode()}");

                Log.Info($"Task status - {notificationTask?.Status}");
                if (notificationTask?.Status != TaskStatus.Running && notificationTask?.Status != TaskStatus.RanToCompletion)
                {
                    Log.Debug("nothing to stop...");
                }
                else
                {
                    if (cancellationToken != null)
                    {
                        // cancel and dispose the cancellation token
                        try
                        {
                            Log.Debug("try to cancel token");
                            cancellationToken.Cancel();
                        }
                        catch (InvalidOperationException e)
                        {
                            // token might already be cancelled, so just log this exception
                            Log.Error(e.Message);
                        }
                        finally
                        {
                            Log.Debug("dispose token");
                            cancellationToken.Dispose();
                        }
                    }

                    await StopWebsocketAsync();

                    if (notificationTask != null)
                    {
                        Log.Debug($"Notification task status: cancelled - {notificationTask.IsCanceled}, faulted - {notificationTask.IsFaulted}");
                        if (notificationTask.IsCanceled || notificationTask.IsFaulted)
                        {
                            Log.Debug("dispose notification task");
                            notificationTask.Dispose();
                        }
                    }

                    if (!skipCleanup)
                    {
                        Log.Debug("Cleaning up");
                        CleanUp();
                    }

                    NotificationsStarted = false;
                }
            }
        }

        /// <summary>
        /// Notifies the core.
        /// </summary>
        /// <param name="notification">The notification.</param>
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

        private void CleanUp()
        {
            try
            {
                DeleteSubscriptions();
            }
            catch (CloudApiException e)
            {
                // don't care about api exceptions here, so just log them
                Log.Error(e);
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
                    Log.Error(e.Message, e);
                    throw;
                }
            }
        }

        private async Task HandleMessageAsync(WebSocketReceiveResult message, List<byte> dynamicBuffer = null)
        {
            // create a new websocket client
            webSocketClient = new ClientWebSocket();
            // set subprotocals e.g. pelion_ak_123, wss
            webSocketClient.Options.AddSubProtocol($"pelion_{Config.ApiKey}");
            webSocketClient.Options.AddSubProtocol("wss");
            webSocketClient.Options.KeepAliveInterval = new TimeSpan(24, 0, 0);

            // create clean buffers
            receivedBytes = new byte[bufferLength];
            receivedBuffer = new ArraySegment<byte>(receivedBytes);

            // connect to url
            if (webSocketClient.State != WebSocketState.Open && webSocketClient.State != WebSocketState.CloseReceived)
            {
                await webSocketClient.ConnectAsync(new Uri(websocketUrl), CancellationToken.None);
            }
        }

        private async Task handleMessageAsync(WebSocketReceiveResult message, List<byte> dynamicBuffer = null)
        {
            if (message.MessageType == WebSocketMessageType.Close)
            {
                if (message.CloseStatus == WebSocketCloseStatus.InternalServerError || message.CloseStatus == WebSocketCloseStatus.EndpointUnavailable)
                {
                    Log.Debug("1011 or 1001 - re-register and restart webhook");

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
                        Log.Debug("we are closing so this on close is expected");
                    }
                    else
                    {
                        Log.Warn("received close message - attempting to restart websocket");
                        await StopWebsocketAsync();
                        await StartWebsocketAsync();
                    }
                }
                else if (message.CloseStatus == WebSocketCloseStatus.PolicyViolation)
                {
                    // 1008 policy violation so invalid api key
                    Log.Error("1008 policy violation, stopping notifications");
                    await StopNotificationsAsync();
                }
                else
                {
                    // some other error
                    Log.Error($"unexpected error from websocket - {message.CloseStatus}");
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
                    Log.Error(e.Message, e);
                    throw;
                }
            }
        }

        private async Task InitiateWebsocketAsync()
        {
            try
            {
                await NotificationsApi.GetWebsocketAsync();
            }
            catch (mds.Client.ApiException getException) when (getException.ErrorCode == 404)
            {
                Log.Debug("no channel found so need to register a websocket");
                await RegisterWebSocket();
            }
            catch (mds.Client.ApiException e)
            {
                Log.Error(e.Message, e);
                throw;
            }

            Log.Debug("websocket channel exists so connect websocket");
            await StartWebsocketAsync();
        }

        private async Task Notifications()
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await retryPolicy.ExecuteAsync(async () =>
                {
                    if (!cancellationToken.IsCancellationRequested)
                    {
                        try
                        {
                            Log.Debug($"Do a longpoll from {this.GetHashCode()}, calcellation requested - {cancellationToken.IsCancellationRequested}");
                            var resp = await NotificationsApi.LongPollNotificationsAsync(cancellationToken.Token);
                            if (resp != null)
                            {
                                Notify(NotificationMessage.Map(resp));
                            }
                        }
                        catch (mds.Client.ApiException e)
                        {
                            Log.Error($"in notifictions - {e.Message} from {this.GetHashCode()}");
                            throw;
                        }
                        catch (TaskCanceledException)
                        {
                            Log.Error($"task cancelled from {this.GetHashCode()}");
                            throw;
                        }
                        catch (Exception e)
                        {
                            Log.Error(e.Message);
                            throw;
                        }
                    }
                });
            }
        }

        private async Task RegisterWebSocket()
        {
            try
            {
                await NotificationsApi.RegisterWebsocketAsync();
            }
            catch (mds.Client.ApiException putException) when (putException.ErrorCode == 400)
            {
                Log.Debug("another channel already exists so force clear and re-register websocket");
                ForceClear();
                await RegisterWebSocket();
            }
            catch (mds.Client.ApiException e)
            {
                Log.Error(e.Message, e);
                throw;
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
                    await webSocketClient.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                }
                catch (WebSocketException e)
                {
                    // connection was closed without completing handshake
                    Log.Error(e);
                }
            }

            webSocketClient.Dispose();

            // delete the channel
            try
            {
                await NotificationsApi.DeleteWebsocketAsync();
            }
            catch (mds.Client.ApiException e)
            {
                if (e.ErrorCode != 404)
                {
                    // channel may have already gone away so just log this exception
                    Log.Error(e.Message, e);
                }
            }

            // now finished closing
            IsClosing = false;
        }
    }
}