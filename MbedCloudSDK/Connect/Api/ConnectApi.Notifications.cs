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

    /// <summary>
    /// Connect Api
    /// </summary>
    public partial class ConnectApi
    {
        private static string WebsocketUrl = "wss://api-ns-websocket.mbedcloudintegration.net/v2/notification/websocket-connect";
        private Task notificationTask;
        private CancellationTokenSource cancellationToken;
        private ClientWebSocket webSocketClient;
        private byte[] buffer;
        private readonly TlvDecoder tlvDecoder = new TlvDecoder();
        private Policy retryPolicy;
        private bool websocketRunning = false;
        private bool isClosing = false;
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

        private async void Notifications()
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var message = await webSocketClient.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken.Token);

                log.Info($"Received message - {message.DebugDump()}");

                if (message.MessageType == WebSocketMessageType.Close) {
                    if (message.CloseStatus == WebSocketCloseStatus.InternalServerError || message.CloseStatus == WebSocketCloseStatus.EndpointUnavailable)
                    {
                        // 1011 no channel or 1001 going away
                        // first re-register the websocket
                        await RegisterWebhook();
                        // then re initiate the websocket
                        await InitiateWebsocket();
                    }
                    else if (message.CloseStatus == WebSocketCloseStatus.NormalClosure)
                    {
                        if (isClosing)
                        {
                            log.Info("Closing so this as on close is expected");
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
                } else {
                    // we recieved a message
                    // decode to notification message
                    try
                    {
                        using (MemoryStream ms = new MemoryStream(buffer))
                        {
                            IFormatter br = new BinaryFormatter();
                            Notify(NotificationMessage.Map((mds.Model.NotificationMessage)br.Deserialize(ms)));
                            Array.Clear(buffer, 0, buffer.Length);
                        }
                    }
                    catch (Exception e)
                    {
                        // exception decoding message from websocket
                        log.Error(e.Message, e);
                        throw;
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
                    if (notificationTask?.Status != TaskStatus.Running)
                    {
                        if (Config.ForceClear)
                        {
                            ForceClear();
                        }

                        log.Info("starting notifications...");

                        await InitiateWebsocket();

                        // dispose of old cancellation token if instance hasn't been torn down
                        cancellationToken?.Dispose();

                        cancellationToken = new CancellationTokenSource();
                        notificationTask = new Task(Notifications, cancellationToken.Token, TaskCreationOptions.LongRunning);
                        notificationTask.Start();

                        websocketRunning = true;
                    }
                    else
                    {
                        log.Info("Notifications already started.");
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

                if (cancellationToken != null)
                {
                    try
                    {
                        cancellationToken.Cancel();
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        cancellationToken.Dispose();
                    }
                }

                await StopWebsocket();

                if (notificationTask != null)
                {
                    if (notificationTask.IsCanceled || notificationTask.IsFaulted)
                    {
                        notificationTask.Dispose();
                    }
                }

                websocketRunning = false;
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
                log.Info("No channel found so need to register a websocket");
                await RegisterWebhook();
            }
            catch (mds.Client.ApiException e)
            {
                log.Error(e.Message, e);
                throw;
            }
            finally
            {
                log.Info("websocket channel found so start websocket");
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
                log.Info("another channel already exists so force clear as retry");
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
                webSocketClient = new ClientWebSocket();
                // set subprotocals e.g. pelion_ak_123, wss
                webSocketClient.Options.AddSubProtocol($"pelion_{Config.ApiKey}");
                webSocketClient.Options.AddSubProtocol("wss");
            }

            if (buffer == null)
            {
                buffer = new byte[bufferLength];
            }

            // connect to url
            await webSocketClient.ConnectAsync(new Uri(WebsocketUrl), CancellationToken.None);
        }

        private async Task StopWebsocket()
        {
            // we are closing now so set isClosing to true so we expect a 1000 normal closure
            isClosing = true;
            // close the websocket
            await webSocketClient.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
            // clear the buffer
            buffer = null;
            // delete the channel
            await WebsocketApi.DeleteWebsocketAsync();
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