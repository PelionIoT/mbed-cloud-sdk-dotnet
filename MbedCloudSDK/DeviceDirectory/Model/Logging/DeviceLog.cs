// <copyright file="DeviceLog.cs" company="Arm">
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
    /// Device log object from Device Catalog API.
    /// </summary>
    public class DeviceLog
    {
        /// <summary>
        /// Gets or sets gets or Sets EventType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public EventType EventType { get; set; }

        /// <summary>
        /// Gets or sets gets or Sets DateTime
        /// </summary>
        public DateTime? DateTime { get; set; }

        /// <summary>
        /// Gets or sets gets or Sets StateChange
        /// </summary>
        public bool? StateChange { get; set; }

        /// <summary>
        /// Gets or sets gets or Sets Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets gets or Sets Changes
        /// </summary>
        public object Changes { get; set; }

        /// <summary>
        /// Gets or sets gets or Sets EventTypeDescription
        /// </summary>
        public string EventTypeDescription { get; set; }

        /// <summary>
        /// Gets or sets gets or Sets DeviceLogId
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets gets or Sets Data
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets gets or Sets DeviceId
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceLog"/> class.
        /// Create new instance of DeviceLog class.
        /// </summary>
        /// <param name="options"></param>
        public DeviceLog(IDictionary<string, object> options = null)
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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeviceLog {\n");
            sb.Append("  DateTime: ").Append(DateTime).Append("\n");
            sb.Append("  StateChange: ").Append(StateChange).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Changes: ").Append(Changes).Append("\n");
            sb.Append("  EventTypeDescription: ").Append(EventTypeDescription).Append("\n");
            sb.Append("  DeviceLogId: ").Append(Id).Append("\n");
            sb.Append("  EventType: ").Append(EventType).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  DeviceId: ").Append(DeviceId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Map to DeviceLog object.
        /// </summary>
        /// <param name="deviceLogSerializer"></param>
        /// <returns></returns>
        public static DeviceLog Map(DeviceEventData deviceLogSerializer)
        {
            var deviceLog = new DeviceLog
            {
                Changes = deviceLogSerializer.Changes,
                Data = deviceLogSerializer.Data,
                DateTime = deviceLogSerializer.DateTime,
                Description = deviceLogSerializer.Description,
                DeviceId = deviceLogSerializer.DeviceId,
                Id = deviceLogSerializer.Id,
                EventTypeDescription = deviceLogSerializer.EventTypeDescription,
                StateChange = deviceLogSerializer.StateChange
            };
            if (Enum.TryParse<EventType>(deviceLogSerializer.EventType.ToString(), out EventType eventType))
            {
                deviceLog.EventType = eventType;
            }

            return deviceLog;
        }
    }
}
