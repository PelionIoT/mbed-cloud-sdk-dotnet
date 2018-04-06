/* 
 * <auto-generated>
 * Device Directory API
 *
 * This is the API Documentation for the Mbed Device Directory service.
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
using SwaggerDateConverter = device_directory.Client.SwaggerDateConverter;

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
        /// <param name="Changes">Changes.</param>
        /// <param name="Data">Data.</param>
        /// <param name="DateTime">DateTime (required).</param>
        /// <param name="Description">Description.</param>
        /// <param name="DeviceId">DeviceId.</param>
        /// <param name="EventType">EventType.</param>
        /// <param name="EventTypeDescription">EventTypeDescription.</param>
        /// <param name="Id">Id (required).</param>
        /// <param name="StateChange">StateChange.</param>
        public DeviceEventData(Object Changes = default(Object), Object Data = default(Object), DateTime? DateTime = default(DateTime?), string Description = default(string), string DeviceId = default(string), string EventType = default(string), string EventTypeDescription = default(string), string Id = default(string), bool? StateChange = default(bool?))
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
            // to ensure "Id" is required (not null)
            if (Id == null)
            {
                throw new InvalidDataException("Id is a required property for DeviceEventData and cannot be null");
            }
            else
            {
                this.Id = Id;
            }
            this.Changes = Changes;
            this.Data = Data;
            this.Description = Description;
            this.DeviceId = DeviceId;
            this.EventType = EventType;
            this.EventTypeDescription = EventTypeDescription;
            this.StateChange = StateChange;
        }
        
        /// <summary>
        /// Gets or Sets Changes
        /// </summary>
        [DataMember(Name="changes", EmitDefaultValue=false)]
        public Object Changes { get; set; }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name="data", EmitDefaultValue=false)]
        public Object Data { get; set; }

        /// <summary>
        /// Gets or Sets DateTime
        /// </summary>
        [DataMember(Name="date_time", EmitDefaultValue=false)]
        public DateTime? DateTime { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets DeviceId
        /// </summary>
        [DataMember(Name="device_id", EmitDefaultValue=false)]
        public string DeviceId { get; set; }

        /// <summary>
        /// Gets or Sets EventType
        /// </summary>
        [DataMember(Name="event_type", EmitDefaultValue=false)]
        public string EventType { get; set; }

        /// <summary>
        /// Gets or Sets EventTypeDescription
        /// </summary>
        [DataMember(Name="event_type_description", EmitDefaultValue=false)]
        public string EventTypeDescription { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets StateChange
        /// </summary>
        [DataMember(Name="state_change", EmitDefaultValue=false)]
        public bool? StateChange { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeviceEventData {\n");
            sb.Append("  Changes: ").Append(Changes).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  DateTime: ").Append(DateTime).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DeviceId: ").Append(DeviceId).Append("\n");
            sb.Append("  EventType: ").Append(EventType).Append("\n");
            sb.Append("  EventTypeDescription: ").Append(EventTypeDescription).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  StateChange: ").Append(StateChange).Append("\n");
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
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as DeviceEventData);
        }

        /// <summary>
        /// Returns true if DeviceEventData instances are equal
        /// </summary>
        /// <param name="input">Instance of DeviceEventData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DeviceEventData input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Changes == input.Changes ||
                    (this.Changes != null &&
                    this.Changes.Equals(input.Changes))
                ) && 
                (
                    this.Data == input.Data ||
                    (this.Data != null &&
                    this.Data.Equals(input.Data))
                ) && 
                (
                    this.DateTime == input.DateTime ||
                    (this.DateTime != null &&
                    this.DateTime.Equals(input.DateTime))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.DeviceId == input.DeviceId ||
                    (this.DeviceId != null &&
                    this.DeviceId.Equals(input.DeviceId))
                ) && 
                (
                    this.EventType == input.EventType ||
                    (this.EventType != null &&
                    this.EventType.Equals(input.EventType))
                ) && 
                (
                    this.EventTypeDescription == input.EventTypeDescription ||
                    (this.EventTypeDescription != null &&
                    this.EventTypeDescription.Equals(input.EventTypeDescription))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.StateChange == input.StateChange ||
                    (this.StateChange != null &&
                    this.StateChange.Equals(input.StateChange))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Changes != null)
                    hashCode = hashCode * 59 + this.Changes.GetHashCode();
                if (this.Data != null)
                    hashCode = hashCode * 59 + this.Data.GetHashCode();
                if (this.DateTime != null)
                    hashCode = hashCode * 59 + this.DateTime.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.DeviceId != null)
                    hashCode = hashCode * 59 + this.DeviceId.GetHashCode();
                if (this.EventType != null)
                    hashCode = hashCode * 59 + this.EventType.GetHashCode();
                if (this.EventTypeDescription != null)
                    hashCode = hashCode * 59 + this.EventTypeDescription.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.StateChange != null)
                    hashCode = hashCode * 59 + this.StateChange.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            // EventType (string) maxLength
            if(this.EventType != null && this.EventType.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for EventType, length must be less than 100.", new [] { "EventType" });
            }

            yield break;
        }
    }

}
