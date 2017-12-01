// <copyright file="ConnectApi.Notifications.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api
{
    using System;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Tlv;

    /// <summary>
    /// Connect Api
    /// </summary>
    public partial class ConnectApi
    {
        private TlvDecoder tlvDecoder = new TlvDecoder();

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

                    if (resp.AsyncResponses != null)
                    {
                        foreach (var asyncReponse in resp.AsyncResponses)
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

                    if (resp.Notifications != null)
                    {
                        foreach (var notification in resp.Notifications)
                        {
                            var payload = Utils.DecodeBase64(notification);

                            var resourceSubs = notification.Ep + notification.Path;
                            if (ResourceSubscribtions.ContainsKey(resourceSubs))
                            {
                                ResourceSubscribtions[resourceSubs].Queue.Add(payload);
                            }
                        }
                    }
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
                notificationTask.Start();
            }
            catch (Exception)
            {
                Console.WriteLine("Notifications already started.");
                throw;
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
                cancellationToken.Cancel();
                notificationsApi.V2NotificationPullDelete();
            }
            catch (Exception)
            {
                Console.WriteLine("Notifications not started yet.");
                throw;
            }
        }
    }
}