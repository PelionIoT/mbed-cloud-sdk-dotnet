// <copyright file="DeviceEvent.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.DeviceDirectory.Model.Logging
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using device_directory.Model;
    using Mbed.Cloud.Common;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Device Event object from Device Catalog API.
    /// </summary>
    public class DeviceEvent : Entity
    {
        /// <summary>
        /// Gets EventType
        /// </summary>
        [JsonProperty]
        public string Type { get; private set; }

        /// <summary>
        /// Gets EventDate
        /// </summary>
        [JsonProperty]
        public DateTime? EventDate { get; private set; }

        /// <summary>
        /// Gets StateChanged
        /// </summary>
        [JsonProperty]
        public bool? StateChanged { get; private set; }

        /// <summary>
        /// Gets Description
        /// </summary>
        [JsonProperty]
        public string Description { get; private set; }

        /// <summary>
        /// Gets Changes
        /// </summary>
        [JsonProperty]
        public object Changes { get; private set; }

        /// <summary>
        /// Gets TypeDescription
        /// </summary>
        [JsonProperty]
        public string TypeDescription { get; private set; }

        /// <summary>
        /// Gets Data
        /// </summary>
        [JsonProperty]
        public object Data { get; private set; }

        /// <summary>
        /// Gets DeviceId
        /// </summary>
        [JsonProperty]
        public string DeviceId { get; private set; }

        /// <summary>
        /// Map to DeviceLog object.
        /// </summary>
        /// <param name="deviceLogSerializer">device event data</param>
        /// <returns>Device log</returns>
        public static DeviceEvent Map(DeviceEventData deviceLogSerializer)
        {
            var deviceLog = new DeviceEvent
            {
                Changes = deviceLogSerializer.Changes,
                Data = deviceLogSerializer.Data,
                EventDate = deviceLogSerializer.DateTime.ToNullableUniversalTime(),
                Description = deviceLogSerializer.Description,
                DeviceId = deviceLogSerializer.DeviceId,
                Id = deviceLogSerializer.Id,
                TypeDescription = deviceLogSerializer.EventTypeDescription,
                StateChanged = deviceLogSerializer.StateChange,
                Type = deviceLogSerializer.EventType,
            };

            return deviceLog;
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();
    }
}
