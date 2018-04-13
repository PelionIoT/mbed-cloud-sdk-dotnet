// <copyright file="DeviceEventFilter.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe.Observers.DeviceEvent
{
    using MbedCloudSDK.Connect.Api.Subscribe.Models;

    /// <summary>
    /// DeviceStateFilter
    /// </summary>
    public class DeviceEventFilter
    {
        /// <summary>
        /// Gets or sets the the Device Event Id to filter on
        /// </summary>
        /// <returns>The Id</returns>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Device Event Type to filter on
        /// </summary>
        /// <returns>The Event</returns>
        public DeviceEventEnum Event { get; set; }
    }
}