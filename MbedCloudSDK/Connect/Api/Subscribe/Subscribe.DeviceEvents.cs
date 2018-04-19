// <copyright file="Subscribe.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe
{
    using System.Collections.Generic;
    using System.Linq;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Connect.Api;
    using MbedCloudSDK.Connect.Api.Subscribe.Models;
    using MbedCloudSDK.Connect.Api.Subscribe.Observers;
    using MbedCloudSDK.Connect.Api.Subscribe.Observers.DeviceEvent;
    using MbedCloudSDK.Connect.Api.Subscribe.Observers.Subscriptions;
    using MbedCloudSDK.Connect.Model.Notifications;
    using MbedCloudSDK.Connect.Model.Subscription;
    using MbedCloudSDK.Exceptions;

    /// <summary>
    /// Subscribe
    /// </summary>
    public partial class Subscribe
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Subscribe"/> class.
        /// </summary>
        /// <param name="connect">The connect.</param>
        public Subscribe(ConnectApi connect = null)
        {
            ConnectApi = connect;
        }

        /// <summary>
        /// Gets the connect API.
        /// </summary>
        /// <value>
        /// The connect API.
        /// </value>
        public ConnectApi ConnectApi { get; }

        /// <summary>
        /// Gets or sets the device state observers.
        /// </summary>
        /// <value>
        /// The device state observers.
        /// </value>
        public List<DeviceEventObserver> DeviceEventObservers { get; set; } = new List<DeviceEventObserver>();

        /// <summary>
        /// Devices the state.
        /// </summary>
        /// <returns>An observer</returns>
        public DeviceEventObserver DeviceEvents()
        {
            var observer = new DeviceEventObserver();
            DeviceEventObservers.Add(observer);
            observer.OnUnsubscribed += (Id) => UnsubscribeDeviceEvents(Id);
            StartNotifications();

            return observer;
        }

        /// <summary>
        /// Notifies the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Notify(DeviceEventData data)
        {
            DeviceEventObservers.ForEach(o =>
            {
                o.Notify(data);
            });
        }

        private void UnsubscribeDeviceEvents(string Id)
        {
            DeviceEventObservers.RemoveAll(d => d.Id == Id);
        }

        private void StartNotifications()
        {
            if (ConnectApi != null)
            {
                if (!ConnectApi.IsNotificationsStarted())
                {
                    ConnectApi.StartNotifications();
                }
            }
        }
    }
}