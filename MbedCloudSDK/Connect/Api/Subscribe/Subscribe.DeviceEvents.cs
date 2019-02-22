// <copyright file="Subscribe.DeviceEvents.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MbedCloudSDK.Connect.Api;
    using MbedCloudSDK.Connect.Api.Subscribe.Observers.DeviceEvent;
    using MbedCloudSDK.Connect.Model.Notifications;

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
        internal ConnectApi ConnectApi { get; }

        /// <summary>
        /// Gets or sets the device state observers.
        /// </summary>
        /// <value>
        /// The device state observers.
        /// </value>
        internal List<DeviceEventObserver> DeviceEventObservers { get; set; } = new List<DeviceEventObserver>();

        /// <summary>
        /// Devices the state.
        /// </summary>
        /// <returns>An observer</returns>
        public async Task<DeviceEventObserver> DeviceEventsAsync()
        {
            var observer = new DeviceEventObserver();
            DeviceEventObservers.Add(observer);
            observer.OnUnsubscribed += (id) => UnsubscribeDeviceEvents(id);
            await StartNotificationsAsync();

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
                o.NotifyAsync(data);
            });
        }

        private void UnsubscribeDeviceEvents(string id)
        {
            DeviceEventObservers.RemoveAll(d => d.Id == id);
        }

        private async Task StartNotificationsAsync()
        {
            if (ConnectApi != null)
            {
                if (!ConnectApi.NotificationsStarted)
                {
                    await ConnectApi.StartNotificationsAsync();
                }
            }
        }
    }
}