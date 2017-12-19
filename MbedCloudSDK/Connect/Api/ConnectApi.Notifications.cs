// <copyright file="ConnectApi.Notifications.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Tlv;
    using MbedCloudSDK.Connect.Model.Notifications;
    using MbedCloudSDK.Connect.Model.Webhook;
    using MbedCloudSDK.Exceptions;
    using Newtonsoft.Json;

    /// <summary>
    /// Connect Api
    /// </summary>
    public partial class ConnectApi
    {
        private TlvDecoder tlvDecoder = new TlvDecoder();
        private bool handleNotifications = false;

        /// <summary>
        /// Notify
        /// </summary>
        /// <param name="notification">The Notification Message as a <see cref="NotificationMessage"/></param>
        public static void Notify(NotificationMessage notification)
        {
            NotifyFunc(notification);
        }

        /// <summary>
        /// Notify
        /// </summary>
        /// <param name="notification">The Notification Message as a string.</param>
        public static void Notify(string notification)
        {
            var message = JsonConvert.DeserializeObject<NotificationMessage>(notification);
            NotifyFunc(message);
        }

        private static void NotifyFunc(NotificationMessage notification)
        {
            if (notification.AsyncResponses.Any())
            {
                foreach (var asyncReponse in notification.AsyncResponses)
                {
                    if (asyncReponse.Payload != null)
                    {
                        var payload = Utils.DecodeBase64(asyncReponse);
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
                    var payload = Utils.DecodeBase64(item);

                    var resourceSubs = item.DeviceId + item.Path;
                    if (ResourceSubscribtions.ContainsKey(resourceSubs))
                    {
                        ResourceSubscribtions[resourceSubs].NotificationQueue.Add(payload);
                    }
                }
            }

            if (notification.Registrations.Any())
            {
                notification.Registrations.ForEach(r =>
                    {
                        r.Resources.ForEach(res =>
                        {
                            var key = r.DeviceId + res.Path;
                            if (ResourceSubscribtions.ContainsKey(key))
                            {
                                ResourceSubscribtions[key].RegistrationQueue.Add(r);
                            }
                        });
                    });
            }

            if (notification.RegistrationUpdates.Any())
            {
                notification.RegistrationUpdates.ForEach(r =>
                {
                    r.Resources.ForEach(res =>
                    {
                        var key = r.DeviceId + res.Path;
                        if (ResourceSubscribtions.ContainsKey(key))
                        {
                            ResourceSubscribtions[key].RegistrationUpdateQueue.Add(r);
                        }
                    });
                });
            }

            if (notification.DeRegistrations.Any())
            {
                notification.DeRegistrations.ForEach(d =>
                {
                    var matchingSubs = resourceSubscribtions.Where(s => s.Key.Contains(d)).ToDictionary(r => r.Key, r => r.Value);
                    foreach (var item in matchingSubs)
                    {
                        item.Value.DeRegistrationQueue.Add(d);
                    }
                });
            }

            if (notification.RegistrationsExpired.Any())
            {
                notification.RegistrationsExpired.ForEach(d =>
                {
                    var matchingSubs = resourceSubscribtions.Where(s => s.Key.Contains(d)).ToDictionary(r => r.Key, r => r.Value);
                    foreach (var item in matchingSubs)
                    {
                        item.Value.RegistrationExpiredQueue.Add(d);
                    }
                });
            }
        }

        private void Notifications()
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var resp = notificationsApi.V2NotificationPullGet();
                    if (resp == null)
                    {
                        continue;
                    }

                    Notify(NotificationMessage.Map(resp));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Multiple notification channels open");
                    StopNotifications();
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
        public void StartNotifications()
        {
            try
            {
                if (notificationTask?.Status != TaskStatus.Running || !handleNotifications)
                {
                    if (Config.ForceClear)
                    {
                        try
                        {
                            DeleteWebhook();
                        }
                        catch (CloudApiException e)
                        {
                            if (e.ErrorCode != 404)
                            {
                                throw;
                            }
                        }
                    }

                    var webhook = new Webhook();
                    try
                    {
                        webhook = GetWebhook();
                    }
                    catch (CloudApiException e)
                    {
                        if (e.ErrorCode != 404)
                        {
                            throw;
                        }
                    }

                    if (webhook?.Url != null)
                    {
                        Console.WriteLine($"Webhook already exists at {webhook.Url}");
                    }

                    Console.WriteLine("Starting notifications");
                    if (cancellationToken != null)
                    {
                        cancellationToken.Dispose();
                    }

                    cancellationToken = new CancellationTokenSource();
                    notificationTask = new Task(new Action(Notifications), cancellationToken.Token, TaskCreationOptions.LongRunning);
                    notificationTask.Start();
                    handleNotifications = true;
                }
                else
                {
                    Console.WriteLine("Notifications already started.");
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
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
        public void StopNotifications()
        {
            if (cancellationToken != null)
            {
                try
                {
                    cancellationToken?.Cancel();
                    cancellationToken?.Dispose();
                }
                catch (ObjectDisposedException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            try
            {
                notificationsApi.V2NotificationPullDelete();
            }
            catch (mds.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }

            if (notificationTask != null)
            {
                if (notificationTask.IsCanceled || notificationTask.IsFaulted || notificationTask.IsCanceled)
                {
                    notificationTask?.Dispose();
                }
            }

            handleNotifications = false;
        }
    }
}