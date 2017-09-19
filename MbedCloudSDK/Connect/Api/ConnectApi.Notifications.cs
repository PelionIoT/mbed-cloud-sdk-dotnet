// <copyright file="ConnectApi.Notifications.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System;
using System.Text;

namespace MbedCloudSDK.Connect.Api
{
    /// <summary>
    /// Connect Api
    /// </summary>
    public partial class ConnectApi
    {
        private void Notifications()
        {
            while (!cancellationToken.IsCancellationRequested)
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
                            byte[] data = Convert.FromBase64String(asyncReponse.Payload);
                            string payload = Encoding.UTF8.GetString(data);
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
                        byte[] data = Convert.FromBase64String(notification.Payload);
                        string payload = Encoding.UTF8.GetString(data);
                        string resourceSubs = notification.Ep + notification.Path;
                        if (ResourceSubscribtions.ContainsKey(resourceSubs))
                        {
                            ResourceSubscribtions[resourceSubs].Queue.Add(payload);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Starts the notifications task.
        /// </summary>
        public void StartNotifications()
        {
            notificationTask.Start();
        }

        /// <summary>
        /// Stops the notifications task.
        /// </summary>
        public void StopNotifications()
        {
            cancellationToken.Cancel();
        }
    }
}