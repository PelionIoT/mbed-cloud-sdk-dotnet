// <copyright file="DeviceEvent.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.DeviceDirectory.Model.Logging
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using device_directory.Model;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Device Event object from Device Catalog API.
    /// </summary>
    public class DeviceEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceEvent"/> class.
        /// Create new instance of DeviceLog class.
        /// </summary>
        /// <param name="options">options for query</param>
        public DeviceEvent(IDictionary<string, object> options = null)
        {
            if (options != null)
            {
                foreach (KeyValuePair<string, object> item in options)
                {
                    var property = GetType().GetProperty(item.Key);
                    if (property != null)
                    {
                        property.SetValue(this, item.Value, null);
                    }
                }
            }
        }

        /// <summary>
        /// Gets EventType
        /// </summary>
        [JsonConverter(typeof(EventTypeEnumConverter))]
        [JsonProperty]
        public EventType Type { get; private set; }

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
        /// Gets DeviceLogId
        /// </summary>
        [JsonProperty]
        public string Id { get; private set; }

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
                EventDate = deviceLogSerializer.DateTime,
                Description = deviceLogSerializer.Description,
                DeviceId = deviceLogSerializer.DeviceId,
                Id = deviceLogSerializer.Id,
                TypeDescription = deviceLogSerializer.EventTypeDescription,
                StateChanged = deviceLogSerializer.StateChange
            };
            if (Enum.TryParse<EventType>(deviceLogSerializer.EventType.ToString(), out EventType eventType))
            {
                deviceLog.Type = eventType;
            }

            return deviceLog;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeviceLog {\n");
            sb.Append("  DateTime: ").Append(EventDate).Append("\n");
            sb.Append("  StateChange: ").Append(StateChanged).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Changes: ").Append(Changes).Append("\n");
            sb.Append("  EventTypeDescription: ").Append(TypeDescription).Append("\n");
            sb.Append("  DeviceLogId: ").Append(Id).Append("\n");
            sb.Append("  EventType: ").Append(Type).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  DeviceId: ").Append(DeviceId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
