﻿// <copyright file="ConnectApi.Notifications.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api
{
    using System;
    using System.Text;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Tlv;

    /// <summary>
    /// Connect Api
    /// </summary>
    public partial class ConnectApi
    {
        private TlvDecoder tlvDecoder = new TlvDecoder();
        private bool handleNotifications = false;

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
        }

        /// <summary>
        /// Starts the notifications task.
        /// </summary>
        public void StartNotifications()
        {
            try
            {
                if (!handleNotifications)
                {
                    notificationTask.Start();
                    handleNotifications = true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Notifications already started.");
            }
        }

        /// <summary>
        /// Stops the notifications task.
        /// </summary>
        public void StopNotifications()
        {
            try
            {
                if (handleNotifications)
                {
                    cancellationToken.Cancel();
                    handleNotifications = false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Notifications not started yet.");
            }
        }
    }
}