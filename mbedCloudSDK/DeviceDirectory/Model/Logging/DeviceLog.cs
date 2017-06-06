using device_catalog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.DeviceDirectory.Model.Logging
{
    /// <summary>
    /// Device log object from Device Catalog API.
    /// </summary>
    public class DeviceLog
    {

        /// <summary>
        /// Gets or Sets EventType
        /// </summary>
        public EventType EventType { get; set; }
        
        /// <summary>
        /// Gets or Sets DateTime
        /// </summary>
        public DateTime? DateTime { get; set; }
        
        /// <summary>
        /// Gets or Sets StateChange
        /// </summary>
        public bool? StateChange { get; set; }
        
        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Gets or Sets Changes
        /// </summary>
        public object Changes { get; set; }
        
        /// <summary>
        /// Gets or Sets EventTypeDescription
        /// </summary>
        public string EventTypeDescription { get; set; }
        
        /// <summary>
        /// Gets or Sets DeviceLogId
        /// </summary>
        public string DeviceLogId { get; set; }
        
        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        public object Data { get; set; }
        
        /// <summary>
        /// Gets or Sets DeviceId
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// Create new instance of DeviceLog class.
        /// </summary>
        /// <param name="options"></param>
        public DeviceLog(IDictionary<string, object> options = null)
        {
            if (options != null)
            {
                foreach (KeyValuePair<string, object> item in options)
                {
                    var property = this.GetType().GetProperty(item.Key);
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
            sb.Append("  DeviceLogId: ").Append(DeviceLogId).Append("\n");
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
            var deviceLog = new DeviceLog();
            deviceLog.Changes = deviceLogSerializer.Changes;
            deviceLog.Data = deviceLogSerializer.Data;
            deviceLog.DateTime = deviceLogSerializer.DateTime;
            deviceLog.Description = deviceLogSerializer.Description;
            deviceLog.DeviceId = deviceLogSerializer.DeviceId;
            deviceLog.DeviceLogId = deviceLogSerializer.Id;
            deviceLog.EventTypeDescription = deviceLogSerializer.EventTypeDescription;
            deviceLogSerializer.StateChange = deviceLogSerializer.StateChange;
            if (deviceLogSerializer.EventType != null)
            {
                deviceLog.EventType = (EventType)Enum.Parse(typeof(EventType), deviceLogSerializer.EventType.ToString());
            }
            return deviceLog;
        }
    }
}
