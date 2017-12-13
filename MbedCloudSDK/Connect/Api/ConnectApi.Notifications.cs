// <copyright file="ConnectApi.Notifications.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Tlv;
    using MbedCloudSDK.Connect.Model.Notifications;

    /// <summary>
    /// Connect Api
    /// </summary>
    public partial class ConnectApi
    {
        private TlvDecoder tlvDecoder = new TlvDecoder();

        /// <summary>
        /// Notify
        /// </summary>
        /// <param name="notification">The Notification Message</param>
        public static void Notify(NotificationMessage notification)
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
                        ResourceSubscribtions[resourceSubs].Queue.Add(payload);
                    }
                }
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
                catch (Exception)
                {
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
                Console.WriteLine("Starting notifications");
                cancellationToken.Dispose();
                cancellationToken = new CancellationTokenSource();
                notificationTask = new Task(new Action(Notifications), cancellationToken.Token, TaskCreationOptions.LongRunning);
                notificationTask.Start();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Notifications already started.");
            }
        }

        /// <summary>
        /// Stops the notifications task.
        /// </summary>
        /// <example>
        /// <code>
        /// try
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
            try
            {
                Console.WriteLine("Stopping notifications");
                cancellationToken.Cancel();
                notificationsApi.V2NotificationPullDelete();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Notifications not started yet.");
            }
        }
    }
}