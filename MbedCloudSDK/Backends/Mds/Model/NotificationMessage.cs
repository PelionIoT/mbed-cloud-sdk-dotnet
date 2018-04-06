/* 
 * <auto-generated>
 * Connect API
 *
 * Mbed Cloud Connect API allows web applications to communicate with devices. You can subscribe to device resources and read/write values to them. Mbed Cloud Connect makes connectivity to devices easy by queuing requests and caching resource values.
 *
 * OpenAPI spec version: 2
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
using SwaggerDateConverter = mds.Client.SwaggerDateConverter;

namespace mds.Model
{
    /// <summary>
    /// NotificationMessage
    /// </summary>
    [DataContract]
    public partial class NotificationMessage :  IEquatable<NotificationMessage>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationMessage" /> class.
        /// </summary>
        /// <param name="AsyncResponses">AsyncResponses.</param>
        /// <param name="DeRegistrations">DeRegistrations.</param>
        /// <param name="Notifications">Notifications.</param>
        /// <param name="RegUpdates">RegUpdates.</param>
        /// <param name="Registrations">Registrations.</param>
        /// <param name="RegistrationsExpired">RegistrationsExpired.</param>
        public NotificationMessage(List<AsyncIDResponse> AsyncResponses = default(List<AsyncIDResponse>), List<string> DeRegistrations = default(List<string>), List<NotificationData> Notifications = default(List<NotificationData>), List<EndpointData> RegUpdates = default(List<EndpointData>), List<EndpointData> Registrations = default(List<EndpointData>), List<string> RegistrationsExpired = default(List<string>))
        {
            this.AsyncResponses = AsyncResponses;
            this.DeRegistrations = DeRegistrations;
            this.Notifications = Notifications;
            this.RegUpdates = RegUpdates;
            this.Registrations = Registrations;
            this.RegistrationsExpired = RegistrationsExpired;
        }
        
        /// <summary>
        /// Gets or Sets AsyncResponses
        /// </summary>
        [DataMember(Name="async-responses", EmitDefaultValue=false)]
        public List<AsyncIDResponse> AsyncResponses { get; set; }

        /// <summary>
        /// Gets or Sets DeRegistrations
        /// </summary>
        [DataMember(Name="de-registrations", EmitDefaultValue=false)]
        public List<string> DeRegistrations { get; set; }

        /// <summary>
        /// Gets or Sets Notifications
        /// </summary>
        [DataMember(Name="notifications", EmitDefaultValue=false)]
        public List<NotificationData> Notifications { get; set; }

        /// <summary>
        /// Gets or Sets RegUpdates
        /// </summary>
        [DataMember(Name="reg-updates", EmitDefaultValue=false)]
        public List<EndpointData> RegUpdates { get; set; }

        /// <summary>
        /// Gets or Sets Registrations
        /// </summary>
        [DataMember(Name="registrations", EmitDefaultValue=false)]
        public List<EndpointData> Registrations { get; set; }

        /// <summary>
        /// Gets or Sets RegistrationsExpired
        /// </summary>
        [DataMember(Name="registrations-expired", EmitDefaultValue=false)]
        public List<string> RegistrationsExpired { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NotificationMessage {\n");
            sb.Append("  AsyncResponses: ").Append(AsyncResponses).Append("\n");
            sb.Append("  DeRegistrations: ").Append(DeRegistrations).Append("\n");
            sb.Append("  Notifications: ").Append(Notifications).Append("\n");
            sb.Append("  RegUpdates: ").Append(RegUpdates).Append("\n");
            sb.Append("  Registrations: ").Append(Registrations).Append("\n");
            sb.Append("  RegistrationsExpired: ").Append(RegistrationsExpired).Append("\n");
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
            return this.Equals(input as NotificationMessage);
        }

        /// <summary>
        /// Returns true if NotificationMessage instances are equal
        /// </summary>
        /// <param name="input">Instance of NotificationMessage to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NotificationMessage input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AsyncResponses == input.AsyncResponses ||
                    this.AsyncResponses != null &&
                    this.AsyncResponses.SequenceEqual(input.AsyncResponses)
                ) && 
                (
                    this.DeRegistrations == input.DeRegistrations ||
                    this.DeRegistrations != null &&
                    this.DeRegistrations.SequenceEqual(input.DeRegistrations)
                ) && 
                (
                    this.Notifications == input.Notifications ||
                    this.Notifications != null &&
                    this.Notifications.SequenceEqual(input.Notifications)
                ) && 
                (
                    this.RegUpdates == input.RegUpdates ||
                    this.RegUpdates != null &&
                    this.RegUpdates.SequenceEqual(input.RegUpdates)
                ) && 
                (
                    this.Registrations == input.Registrations ||
                    this.Registrations != null &&
                    this.Registrations.SequenceEqual(input.Registrations)
                ) && 
                (
                    this.RegistrationsExpired == input.RegistrationsExpired ||
                    this.RegistrationsExpired != null &&
                    this.RegistrationsExpired.SequenceEqual(input.RegistrationsExpired)
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
                if (this.AsyncResponses != null)
                    hashCode = hashCode * 59 + this.AsyncResponses.GetHashCode();
                if (this.DeRegistrations != null)
                    hashCode = hashCode * 59 + this.DeRegistrations.GetHashCode();
                if (this.Notifications != null)
                    hashCode = hashCode * 59 + this.Notifications.GetHashCode();
                if (this.RegUpdates != null)
                    hashCode = hashCode * 59 + this.RegUpdates.GetHashCode();
                if (this.Registrations != null)
                    hashCode = hashCode * 59 + this.Registrations.GetHashCode();
                if (this.RegistrationsExpired != null)
                    hashCode = hashCode * 59 + this.RegistrationsExpired.GetHashCode();
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
            yield break;
        }
    }

}
