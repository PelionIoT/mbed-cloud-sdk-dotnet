/* 
 * <auto-generated>
 * Device Directory API
 *
 * This is the API Documentation for the Mbed device directory update service.
 *
 * OpenAPI spec version: 3
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 * </auto-generated>
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace device_directory.Model
{
    /// <summary>
    /// DeviceEventData
    /// </summary>
    [DataContract]
    public partial class DeviceEventData :  IEquatable<DeviceEventData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceEventData" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DeviceEventData() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceEventData" /> class.
        /// </summary>
        /// <param name="DateTime">DateTime (required).</param>
        /// <param name="StateChange">StateChange.</param>
        /// <param name="Description">Description.</param>
        /// <param name="Changes">Changes.</param>
        /// <param name="EventTypeDescription">EventTypeDescription.</param>
        /// <param name="EventType">EventType.</param>
        /// <param name="Data">Data.</param>
        /// <param name="Id">Id.</param>
        /// <param name="DeviceId">DeviceId.</param>
        public DeviceEventData(DateTime? DateTime = default(DateTime?), bool? StateChange = default(bool?), string Description = default(string), Object Changes = default(Object), string EventTypeDescription = default(string), string EventType = default(string), Object Data = default(Object), string Id = default(string), string DeviceId = default(string))
        {
            // to ensure "DateTime" is required (not null)
            if (DateTime == null)
            {
                throw new InvalidDataException("DateTime is a required property for DeviceEventData and cannot be null");
            }
            else
            {
                this.DateTime = DateTime;
            }
            this.StateChange = StateChange;
            this.Description = Description;
            this.Changes = Changes;
            this.EventTypeDescription = EventTypeDescription;
            this.EventType = EventType;
            this.Data = Data;
            this.Id = Id;
            this.DeviceId = DeviceId;
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
        public Object Changes { get; set; }
        /// <summary>
        /// Gets or Sets EventTypeDescription
        /// </summary>
        [DataMember(Name="event_type_description", EmitDefaultValue=false)]
        public string EventTypeDescription { get; set; }
        /// <summary>
        /// Gets or Sets EventType
        /// </summary>
        [DataMember(Name="event_type", EmitDefaultValue=false)]
        public string EventType { get; set; }
        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name="data", EmitDefaultValue=false)]
        public Object Data { get; set; }
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }
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
            sb.Append("class DeviceEventData {\n");
            sb.Append("  DateTime: ").Append(DateTime).Append("\n");
            sb.Append("  StateChange: ").Append(StateChange).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Changes: ").Append(Changes).Append("\n");
            sb.Append("  EventTypeDescription: ").Append(EventTypeDescription).Append("\n");
            sb.Append("  EventType: ").Append(EventType).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
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
            return this.Equals(obj as DeviceEventData);
        }

        /// <summary>
        /// Returns true if DeviceEventData instances are equal
        /// </summary>
        /// <param name="other">Instance of DeviceEventData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DeviceEventData other)
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
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
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
                if (this.EventType != null)
                    hash = hash * 59 + this.EventType.GetHashCode();
                if (this.Data != null)
                    hash = hash * 59 + this.Data.GetHashCode();
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.DeviceId != null)
                    hash = hash * 59 + this.DeviceId.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            // EventType (string) maxLength
            if(this.EventType != null && this.EventType.Length > 100)
            {
                yield return new ValidationResult("Invalid value for EventType, length must be less than 100.", new [] { "EventType" });
            }

            yield break;
        }
    }

}
