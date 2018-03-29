// <copyright file="DeviceStateFilter.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe.Observers.DeviceState
{
    using System.Linq;
    using MbedCloudSDK.Connect.Api.Subscribe.Filters;
    using MbedCloudSDK.Connect.Api.Subscribe.Models;

    /// <summary>
    /// Device state filter
    /// </summary>
    public class DeviceStateFilter : Filter<DeviceStateFilterAttribute>
    {
        /// <summary>
        /// Device id key
        /// </summary>
        public const string DEVICE_ID_KEY = "DEVICE_ID_KEY";

        /// <summary>
        /// Device state key
        /// </summary>
        public const string DEVICE_STATE_KEY = "DEVICE_STATE_KEY";

        /// <summary>
        /// Add a device Id to the filter
        /// </summary>
        /// <example>
        /// <code>
        ///  var subscription = connect.Subscribe.DeviceState();
        /// // subscribe to events from devices with id "1" and "2"
        /// subscription.Filter.Add("1")
        ///                    .Add("2");
        /// </code>
        /// </example>
        /// <param name="deviceId">The device Id to filter on</param>
        /// <returns>The filter</returns>
        public DeviceStateFilter Add(string deviceId)
        {
            base.Add(DEVICE_ID_KEY, new DeviceStateFilterAttribute(deviceId));
            return this;
        }

        /// <summary>
        /// Add a device state to the filter
        /// </summary>
        /// <example>
        /// <code>
        /// var subscription = connect.Subscribe.DeviceState();
        /// // subscribe to Deregistration and Registration events
        /// subscription.Filter.Add(DeviceStateEnum.DeRegistrations)
        ///                    .Add(DeviceStateEnum.Registrations);
        /// </code>
        /// </example>
        /// <param name="deviceState">Device state to add</param>
        /// <returns>The filter</returns>
        public DeviceStateFilter Add(DeviceStateEnum deviceState)
        {
            base.Add(DEVICE_STATE_KEY, new DeviceStateFilterAttribute(deviceState.ToString()));
            return this;
        }

        /// <summary>
        /// Returns true if filter contains the key
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns>bool</returns>
        public bool ContainsKey(string key)
        {
            return !string.IsNullOrEmpty(base.Contains(key)?.LastOrDefault()?.Value);
        }

        /// <summary>
        /// Returns true if the filter contains the deviceId
        /// </summary>
        /// <param name="deviceId">The device Id</param>
        /// <returns>bool</returns>
        public new bool Contains(string deviceId)
        {
            var attrs = base.Contains(DEVICE_ID_KEY);
            foreach (var item in attrs)
            {
                if (item.Value == deviceId)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns true if the filter contains the device state
        /// </summary>
        /// <param name="state">device state</param>
        /// <returns>bool</returns>
        public bool Contains(DeviceStateEnum state)
        {
            var attrs = base.Contains(DEVICE_STATE_KEY);
            foreach (var item in attrs)
            {
                if (item.Value == state.ToString())
                {
                    return true;
                }
            }

            return false;
        }
    }
}