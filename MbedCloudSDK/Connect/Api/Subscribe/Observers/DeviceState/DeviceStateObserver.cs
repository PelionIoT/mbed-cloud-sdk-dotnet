// <copyright file="DeviceStateObserver.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe.Observers.DeviceState
{
    using System;
    using MbedCloudSDK.Connect.Api.Subscribe.Models;
    using MbedCloudSDK.Connect.Model.Notifications;

    /// <summary>
    /// Device Stae Observer
    /// </summary>
    public class DeviceStateObserver : Observer<DeviceEventData>
    {
        private Subscribe subscribe;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceStateObserver"/> class.
        /// Device State Observer
        /// </summary>
        /// <example>
        /// This example shows how you can use the DeviceStateObserver. For more examples, see the Examples project.
        /// <code>
        /// var observer = connect.Subscribe.DeviceState();
        /// // subscribe to Deregistration and Registration events
        /// observer.Filter.Add(DeviceStateEnum.DeRegistration)
        ///                    .Add(DeviceStateEnum.Registration);
        /// // add a callback to print message when recieved
        /// observer.AddCallback((res) => Console.WriteLine(res));
        ///     // take two values
        /// var firstValue = observer.Take();
        /// var secondValue = observer.Take();
        /// </code>
        /// </example>
        /// <param name="subscribe">The parent subscribe instance</param>
        public DeviceStateObserver(Subscribe subscribe = null)
        {
            Id = Guid.NewGuid().ToString();
            this.subscribe = subscribe;
        }

        /// <summary>
        /// Gets the filter
        /// </summary>
        public DeviceStateFilter Filter { get; } = new DeviceStateFilter();

        /// <summary>
        /// Gets the observer Id
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Unsubscribe the observer
        /// </summary>
        public new void Unsubscribe()
        {
            base.RemoveCallback();
            subscribe.DeviceStateObservers.Remove(this);
        }

        /// <summary>
        /// Notify this observer
        /// </summary>
        /// <param name="data">The device event data</param>
        public new void Notify(DeviceEventData data)
        {
            // if the filter is blank, give me everything
            if (!Filter.ContainsKey(DeviceStateFilter.DEVICE_ID_KEY) && !Filter.ContainsKey(DeviceStateFilter.DEVICE_STATE_KEY))
            {
                base.Notify(data);
                return;
            }

            // filter for deviceID and state
            if (Filter.Contains(data.State) && Filter.Contains(data.DeviceId))
            {
                base.Notify(data);
                return;
            }

            // not state filters so check deviceId
            if (!Filter.ContainsKey(DeviceStateFilter.DEVICE_STATE_KEY))
            {
                if (Filter.Contains(data.DeviceId))
                {
                    base.Notify(data);
                    return;
                }
            }

            // no deviceId filters so check state
            if (!Filter.ContainsKey(DeviceStateFilter.DEVICE_ID_KEY))
            {
                if (Filter.Contains(data.State))
                {
                    base.Notify(data);
                    return;
                }
            }
        }
    }
}