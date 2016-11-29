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
    public partial class DeviceLogSerializer :  IEquatable<DeviceLogSerializer>
    { 
    
        /// <summary>
        /// Gets or Sets EventType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum EventTypeEnum {
            
            [EnumMember(Value = "")]
            ,
            
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
        /// Initializes a new instance of the <see cref="DeviceLogSerializer" /> class.
        /// Initializes a new instance of the <see cref="DeviceLogSerializer" />class.
        /// </summary>
        /// <param name="DateTime">DateTime (required).</param>
        /// <param name="StateChange">StateChange (required).</param>
        /// <param name="Description">Description (required).</param>
        /// <param name="Changes">Changes (required).</param>
        /// <param name="EventTypeDescription">EventTypeDescription (required).</param>
        /// <param name="DeviceLogId">DeviceLogId (required).</param>
        /// <param name="EventType">EventType (required).</param>
        /// <param name="Data">Data (required).</param>
        /// <param name="DeviceId">DeviceId (required).</param>

        public DeviceLogSerializer(DateTime? DateTime = null, bool? StateChange = null, string Description = null, string Changes = null, string EventTypeDescription = null, string DeviceLogId = null, EventTypeEnum? EventType = null, string Data = null, string DeviceId = null)
        {
            // to ensure "DateTime" is required (not null)
            if (DateTime == null)
            {
                throw new InvalidDataException("DateTime is a required property for DeviceLogSerializer and cannot be null");
            }
            else
            {
                this.DateTime = DateTime;
            }
            // to ensure "StateChange" is required (not null)
            if (StateChange == null)
            {
                throw new InvalidDataException("StateChange is a required property for DeviceLogSerializer and cannot be null");
            }
            else
            {
                this.StateChange = StateChange;
            }
            // to ensure "Description" is required (not null)
            if (Description == null)
            {
                throw new InvalidDataException("Description is a required property for DeviceLogSerializer and cannot be null");
            }
            else
            {
                this.Description = Description;
            }
            // to ensure "Changes" is required (not null)
            if (Changes == null)
            {
                throw new InvalidDataException("Changes is a required property for DeviceLogSerializer and cannot be null");
            }
            else
            {
                this.Changes = Changes;
            }
            // to ensure "EventTypeDescription" is required (not null)
            if (EventTypeDescription == null)
            {
                throw new InvalidDataException("EventTypeDescription is a required property for DeviceLogSerializer and cannot be null");
            }
            else
            {
                this.EventTypeDescription = EventTypeDescription;
            }
            // to ensure "DeviceLogId" is required (not null)
            if (DeviceLogId == null)
            {
                throw new InvalidDataException("DeviceLogId is a required property for DeviceLogSerializer and cannot be null");
            }
            else
            {
                this.DeviceLogId = DeviceLogId;
            }
            // to ensure "EventType" is required (not null)
            if (EventType == null)
            {
                throw new InvalidDataException("EventType is a required property for DeviceLogSerializer and cannot be null");
            }
            else
            {
                this.EventType = EventType;
            }
            // to ensure "Data" is required (not null)
            if (Data == null)
            {
                throw new InvalidDataException("Data is a required property for DeviceLogSerializer and cannot be null");
            }
            else
            {
                this.Data = Data;
            }
            // to ensure "DeviceId" is required (not null)
            if (DeviceId == null)
            {
                throw new InvalidDataException("DeviceId is a required property for DeviceLogSerializer and cannot be null");
            }
            else
            {
                this.DeviceId = DeviceId;
            }
            
        }
        
    
        /// <summary>
        /// Gets or Sets DateTime
        /// </summary>
        [DataMember(Name="date_time", EmitDefaultValue=false)]
        public DateTime? DateTime { get; set; }
    
        /// <summary>
        /// Gets or Sets StateChange
        /// </summary>
        [DataMember(Name="state_change", EmitDefaultValue=false)]
        public bool? StateChange { get; set; }
    
        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
    
        /// <summary>
        /// Gets or Sets Changes
        /// </summary>
        [DataMember(Name="changes", EmitDefaultValue=false)]
        public string Changes { get; set; }
    
        /// <summary>
        /// Gets or Sets EventTypeDescription
        /// </summary>
        [DataMember(Name="event_type_description", EmitDefaultValue=false)]
        public string EventTypeDescription { get; set; }
    
        /// <summary>
        /// Gets or Sets DeviceLogId
        /// </summary>
        [DataMember(Name="device_log_id", EmitDefaultValue=false)]
        public string DeviceLogId { get; set; }
    
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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeviceLogSerializer {\n");
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
            return this.Equals(obj as DeviceLogSerializer);
        }

        /// <summary>
        /// Returns true if DeviceLogSerializer instances are equal
        /// </summary>
        /// <param name="other">Instance of DeviceLogSerializer to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DeviceLogSerializer other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.DateTime == other.DateTime ||
                    this.DateTime != null &&
                    this.DateTime.Equals(other.DateTime)
                ) && 
                (
                    this.StateChange == other.StateChange ||
                    this.StateChange != null &&
                    this.StateChange.Equals(other.StateChange)
                ) && 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
                ) && 
                (
                    this.Changes == other.Changes ||
                    this.Changes != null &&
                    this.Changes.Equals(other.Changes)
                ) && 
                (
                    this.EventTypeDescription == other.EventTypeDescription ||
                    this.EventTypeDescription != null &&
                    this.EventTypeDescription.Equals(other.EventTypeDescription)
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
                
                if (this.DateTime != null)
                    hash = hash * 59 + this.DateTime.GetHashCode();
                
                if (this.StateChange != null)
                    hash = hash * 59 + this.StateChange.GetHashCode();
                
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                
                if (this.Changes != null)
                    hash = hash * 59 + this.Changes.GetHashCode();
                
                if (this.EventTypeDescription != null)
                    hash = hash * 59 + this.EventTypeDescription.GetHashCode();
                
                if (this.DeviceLogId != null)
                    hash = hash * 59 + this.DeviceLogId.GetHashCode();
                
                if (this.EventType != null)
                    hash = hash * 59 + this.EventType.GetHashCode();
                
                if (this.Data != null)
                    hash = hash * 59 + this.Data.GetHashCode();
                
                if (this.DeviceId != null)
                    hash = hash * 59 + this.DeviceId.GetHashCode();
                
                return hash;
            }
        }

    }
}
