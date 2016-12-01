using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace device_catalog.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class WriteDeviceLogSerializer :  IEquatable<WriteDeviceLogSerializer>
    { 
    
        /// <summary>
        /// Gets or Sets EventType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum EventTypeEnum {
           	
            [EnumMember(Value = "update.device.device-created")]
            Updatedevicedevicecreated,
            
            [EnumMember(Value = "update.device.device-updated")]
            Updatedevicedeviceupdated,
            
            [EnumMember(Value = "update.deployment.campaign-device-metadata-created")]
            Updatedeploymentcampaigndevicemetadatacreated,
            
            [EnumMember(Value = "update.deployment.campaign-device-metadata-updated")]
            Updatedeploymentcampaigndevicemetadataupdated,
            
            [EnumMember(Value = "update.deployment.campaign-device-metadata-removed")]
            Updatedeploymentcampaigndevicemetadataremoved,
            
            [EnumMember(Value = "update.connector.connector-device.firmware-update.state")]
            Updateconnectorconnectordevicefirmwareupdatestate,
            
            [EnumMember(Value = "update.connector.connector-device.firmware-update.result")]
            Updateconnectorconnectordevicefirmwareupdateresult
        }

    
        /// <summary>
        /// Gets or Sets EventType
        /// </summary>
        [DataMember(Name="event_type", EmitDefaultValue=false)]
        public EventTypeEnum? EventType { get; set; }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="WriteDeviceLogSerializer" /> class.
        /// Initializes a new instance of the <see cref="WriteDeviceLogSerializer" />class.
        /// </summary>
        /// <param name="StateChange">StateChange.</param>
        /// <param name="DateTime">DateTime (required).</param>
        /// <param name="DeviceLogId">DeviceLogId.</param>
        /// <param name="EventType">EventType.</param>

        public WriteDeviceLogSerializer(bool? StateChange = null, DateTime? DateTime = null, string DeviceLogId = null, EventTypeEnum? EventType = null)
        {
            // to ensure "DateTime" is required (not null)
            if (DateTime == null)
            {
                throw new InvalidDataException("DateTime is a required property for WriteDeviceLogSerializer and cannot be null");
            }
            else
            {
                this.DateTime = DateTime;
            }
            this.StateChange = StateChange;
            this.DeviceLogId = DeviceLogId;
            this.EventType = EventType;
            
        }
        
    
        /// <summary>
        /// Gets or Sets StateChange
        /// </summary>
        [DataMember(Name="state_change", EmitDefaultValue=false)]
        public bool? StateChange { get; set; }
    
        /// <summary>
        /// Gets or Sets DateTime
        /// </summary>
        [DataMember(Name="date_time", EmitDefaultValue=false)]
        public DateTime? DateTime { get; set; }
    
        /// <summary>
        /// Gets or Sets DeviceLogId
        /// </summary>
        [DataMember(Name="device_log_id", EmitDefaultValue=false)]
        public string DeviceLogId { get; set; }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WriteDeviceLogSerializer {\n");
            sb.Append("  StateChange: ").Append(StateChange).Append("\n");
            sb.Append("  DateTime: ").Append(DateTime).Append("\n");
            sb.Append("  DeviceLogId: ").Append(DeviceLogId).Append("\n");
            sb.Append("  EventType: ").Append(EventType).Append("\n");
            
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as WriteDeviceLogSerializer);
        }

        /// <summary>
        /// Returns true if WriteDeviceLogSerializer instances are equal
        /// </summary>
        /// <param name="other">Instance of WriteDeviceLogSerializer to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WriteDeviceLogSerializer other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.StateChange == other.StateChange ||
                    this.StateChange != null &&
                    this.StateChange.Equals(other.StateChange)
                ) && 
                (
                    this.DateTime == other.DateTime ||
                    this.DateTime != null &&
                    this.DateTime.Equals(other.DateTime)
                ) && 
                (
                    this.DeviceLogId == other.DeviceLogId ||
                    this.DeviceLogId != null &&
                    this.DeviceLogId.Equals(other.DeviceLogId)
                ) && 
                (
                    this.EventType == other.EventType ||
                    this.EventType != null &&
                    this.EventType.Equals(other.EventType)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                
                if (this.StateChange != null)
                    hash = hash * 59 + this.StateChange.GetHashCode();
                
                if (this.DateTime != null)
                    hash = hash * 59 + this.DateTime.GetHashCode();
                
                if (this.DeviceLogId != null)
                    hash = hash * 59 + this.DeviceLogId.GetHashCode();
                
                if (this.EventType != null)
                    hash = hash * 59 + this.EventType.GetHashCode();
                
                return hash;
            }
        }

    }
}
