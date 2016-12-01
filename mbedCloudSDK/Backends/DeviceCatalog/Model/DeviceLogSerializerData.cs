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
    public partial class DeviceLogSerializerData :  IEquatable<DeviceLogSerializerData>
    { 
    
        /// <summary>
        /// Gets or Sets EventType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum EventTypeEnum {
            
            [EnumMember(Value = "update.device.device-created")]
            Devicedevicecreated,
            
            [EnumMember(Value = "update.device.device-updated")]
            Devicedeviceupdated,
            
            [EnumMember(Value = "update.deployment.campaign-device-metadata-created")]
            Deploymentcampaigndevicemetadatacreated,
            
            [EnumMember(Value = "update.deployment.campaign-device-metadata-updated")]
            Deploymentcampaigndevicemetadataupdated,
            
            [EnumMember(Value = "update.deployment.campaign-device-metadata-removed")]
            Deploymentcampaigndevicemetadataremoved,
            
            [EnumMember(Value = "update.connector.connector-device.firmware-update.state")]
            Connectorconnectordevicefirmwareupdatestate,
            
            [EnumMember(Value = "update.connector.connector-device.firmware-update.result")]
            Connectorconnectordevicefirmwareupdateresult
        }

    
        /// <summary>
        /// Gets or Sets EventType
        /// </summary>
        [DataMember(Name="event_type", EmitDefaultValue=false)]
        public EventTypeEnum? EventType { get; set; }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceLogSerializerData" /> class.
        /// Initializes a new instance of the <see cref="DeviceLogSerializerData" />class.
        /// </summary>
        /// <param name="EventType">EventType.</param>
        /// <param name="DateTime">DateTime (required).</param>
        /// <param name="Data">Data.</param>
        /// <param name="DeviceId">DeviceId.</param>
        /// <param name="Changes">Changes.</param>
        /// <param name="Description">Description.</param>
        /// <param name="DeviceLogId">DeviceLogId.</param>
        /// <param name="StateChange">StateChange.</param>
        /// <param name="EventTypeDescription">EventTypeDescription.</param>

        public DeviceLogSerializerData(EventTypeEnum? EventType = null, DateTime? DateTime = null, string Data = null, string DeviceId = null, string Changes = null, string Description = null, string DeviceLogId = null, bool? StateChange = null, string EventTypeDescription = null)
        {
            // to ensure "DateTime" is required (not null)
            if (DateTime == null)
            {
                throw new InvalidDataException("DateTime is a required property for DeviceLogSerializerData and cannot be null");
            }
            else
            {
                this.DateTime = DateTime;
            }
            this.EventType = EventType;
            this.Data = Data;
            this.DeviceId = DeviceId;
            this.Changes = Changes;
            this.Description = Description;
            this.DeviceLogId = DeviceLogId;
            this.StateChange = StateChange;
            this.EventTypeDescription = EventTypeDescription;
            
        }
        
    
        /// <summary>
        /// Gets or Sets DateTime
        /// </summary>
        [DataMember(Name="date_time", EmitDefaultValue=false)]
        public DateTime? DateTime { get; set; }
    
        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name="data", EmitDefaultValue=false)]
        public string Data { get; set; }
    
        /// <summary>
        /// Gets or Sets DeviceId
        /// </summary>
        [DataMember(Name="device_id", EmitDefaultValue=false)]
        public string DeviceId { get; set; }
    
        /// <summary>
        /// Gets or Sets Changes
        /// </summary>
        [DataMember(Name="changes", EmitDefaultValue=false)]
        public string Changes { get; set; }
    
        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
    
        /// <summary>
        /// Gets or Sets DeviceLogId
        /// </summary>
        [DataMember(Name="device_log_id", EmitDefaultValue=false)]
        public string DeviceLogId { get; set; }
    
        /// <summary>
        /// Gets or Sets StateChange
        /// </summary>
        [DataMember(Name="state_change", EmitDefaultValue=false)]
        public bool? StateChange { get; set; }
    
        /// <summary>
        /// Gets or Sets EventTypeDescription
        /// </summary>
        [DataMember(Name="event_type_description", EmitDefaultValue=false)]
        public string EventTypeDescription { get; set; }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeviceLogSerializerData {\n");
            sb.Append("  EventType: ").Append(EventType).Append("\n");
            sb.Append("  DateTime: ").Append(DateTime).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  DeviceId: ").Append(DeviceId).Append("\n");
            sb.Append("  Changes: ").Append(Changes).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DeviceLogId: ").Append(DeviceLogId).Append("\n");
            sb.Append("  StateChange: ").Append(StateChange).Append("\n");
            sb.Append("  EventTypeDescription: ").Append(EventTypeDescription).Append("\n");
            
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
            return this.Equals(obj as DeviceLogSerializerData);
        }

        /// <summary>
        /// Returns true if DeviceLogSerializerData instances are equal
        /// </summary>
        /// <param name="other">Instance of DeviceLogSerializerData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DeviceLogSerializerData other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.EventType == other.EventType ||
                    this.EventType != null &&
                    this.EventType.Equals(other.EventType)
                ) && 
                (
                    this.DateTime == other.DateTime ||
                    this.DateTime != null &&
                    this.DateTime.Equals(other.DateTime)
                ) && 
                (
                    this.Data == other.Data ||
                    this.Data != null &&
                    this.Data.Equals(other.Data)
                ) && 
                (
                    this.DeviceId == other.DeviceId ||
                    this.DeviceId != null &&
                    this.DeviceId.Equals(other.DeviceId)
                ) && 
                (
                    this.Changes == other.Changes ||
                    this.Changes != null &&
                    this.Changes.Equals(other.Changes)
                ) && 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
                ) && 
                (
                    this.DeviceLogId == other.DeviceLogId ||
                    this.DeviceLogId != null &&
                    this.DeviceLogId.Equals(other.DeviceLogId)
                ) && 
                (
                    this.StateChange == other.StateChange ||
                    this.StateChange != null &&
                    this.StateChange.Equals(other.StateChange)
                ) && 
                (
                    this.EventTypeDescription == other.EventTypeDescription ||
                    this.EventTypeDescription != null &&
                    this.EventTypeDescription.Equals(other.EventTypeDescription)
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
                
                if (this.EventType != null)
                    hash = hash * 59 + this.EventType.GetHashCode();
                
                if (this.DateTime != null)
                    hash = hash * 59 + this.DateTime.GetHashCode();
                
                if (this.Data != null)
                    hash = hash * 59 + this.Data.GetHashCode();
                
                if (this.DeviceId != null)
                    hash = hash * 59 + this.DeviceId.GetHashCode();
                
                if (this.Changes != null)
                    hash = hash * 59 + this.Changes.GetHashCode();
                
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                
                if (this.DeviceLogId != null)
                    hash = hash * 59 + this.DeviceLogId.GetHashCode();
                
                if (this.StateChange != null)
                    hash = hash * 59 + this.StateChange.GetHashCode();
                
                if (this.EventTypeDescription != null)
                    hash = hash * 59 + this.EventTypeDescription.GetHashCode();
                
                return hash;
            }
        }

    }
}
