/* 
 * <auto-generated>
 * billing REST API documentation
 *
 * This document contains the public REST API definitions of the mbed-billing service.
 *
 * OpenAPI spec version: 1.4.4
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
using SwaggerDateConverter = billing.Client.SwaggerDateConverter;

namespace billing.Model
{
    /// <summary>
    /// An active service package.
    /// </summary>
    [DataContract]
    public partial class ActiveServicePackage :  IEquatable<ActiveServicePackage>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActiveServicePackage" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ActiveServicePackage() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ActiveServicePackage" /> class.
        /// </summary>
        /// <param name="Created">Service package creation time in RFC3339 date-time with millisecond accuracy and UTC time zone. (required).</param>
        /// <param name="Expires">Service package expiration time in RFC3339 date-time with millisecond accuracy and UTC time zone. (required).</param>
        /// <param name="FirmwareUpdateCount">Size of firmware update quota of this service package. (required).</param>
        /// <param name="GracePeriod">Is this service package on grace period or not? (required).</param>
        /// <param name="Id">ID of this service package. (required).</param>
        /// <param name="Modified">Service package latest modified time in RFC3339 date-time with millisecond accuracy and UTC time zone. (required).</param>
        /// <param name="NextId">Next service package ID if this service package has a pending renewal or null..</param>
        /// <param name="PreviousId">Previous service package ID or null..</param>
        /// <param name="StartTime">Service package start time in RFC3339 date-time with millisecond accuracy and UTC time zone. (required).</param>
        public ActiveServicePackage(DateTime? Created = default(DateTime?), DateTime? Expires = default(DateTime?), int? FirmwareUpdateCount = default(int?), bool? GracePeriod = default(bool?), string Id = default(string), DateTime? Modified = default(DateTime?), string NextId = default(string), string PreviousId = default(string), DateTime? StartTime = default(DateTime?))
        {
            // to ensure "Created" is required (not null)
            if (Created == null)
            {
                throw new InvalidDataException("Created is a required property for ActiveServicePackage and cannot be null");
            }
            else
            {
                this.Created = Created;
            }
            // to ensure "Expires" is required (not null)
            if (Expires == null)
            {
                throw new InvalidDataException("Expires is a required property for ActiveServicePackage and cannot be null");
            }
            else
            {
                this.Expires = Expires;
            }
            // to ensure "FirmwareUpdateCount" is required (not null)
            if (FirmwareUpdateCount == null)
            {
                throw new InvalidDataException("FirmwareUpdateCount is a required property for ActiveServicePackage and cannot be null");
            }
            else
            {
                this.FirmwareUpdateCount = FirmwareUpdateCount;
            }
            // to ensure "GracePeriod" is required (not null)
            if (GracePeriod == null)
            {
                throw new InvalidDataException("GracePeriod is a required property for ActiveServicePackage and cannot be null");
            }
            else
            {
                this.GracePeriod = GracePeriod;
            }
            // to ensure "Id" is required (not null)
            if (Id == null)
            {
                throw new InvalidDataException("Id is a required property for ActiveServicePackage and cannot be null");
            }
            else
            {
                this.Id = Id;
            }
            // to ensure "Modified" is required (not null)
            if (Modified == null)
            {
                throw new InvalidDataException("Modified is a required property for ActiveServicePackage and cannot be null");
            }
            else
            {
                this.Modified = Modified;
            }
            // to ensure "StartTime" is required (not null)
            if (StartTime == null)
            {
                throw new InvalidDataException("StartTime is a required property for ActiveServicePackage and cannot be null");
            }
            else
            {
                this.StartTime = StartTime;
            }
            this.NextId = NextId;
            this.PreviousId = PreviousId;
        }
        
        /// <summary>
        /// Service package creation time in RFC3339 date-time with millisecond accuracy and UTC time zone.
        /// </summary>
        /// <value>Service package creation time in RFC3339 date-time with millisecond accuracy and UTC time zone.</value>
        [DataMember(Name="created", EmitDefaultValue=false)]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Service package expiration time in RFC3339 date-time with millisecond accuracy and UTC time zone.
        /// </summary>
        /// <value>Service package expiration time in RFC3339 date-time with millisecond accuracy and UTC time zone.</value>
        [DataMember(Name="expires", EmitDefaultValue=false)]
        public DateTime? Expires { get; set; }

        /// <summary>
        /// Size of firmware update quota of this service package.
        /// </summary>
        /// <value>Size of firmware update quota of this service package.</value>
        [DataMember(Name="firmware_update_count", EmitDefaultValue=false)]
        public int? FirmwareUpdateCount { get; set; }

        /// <summary>
        /// Is this service package on grace period or not?
        /// </summary>
        /// <value>Is this service package on grace period or not?</value>
        [DataMember(Name="grace_period", EmitDefaultValue=false)]
        public bool? GracePeriod { get; set; }

        /// <summary>
        /// ID of this service package.
        /// </summary>
        /// <value>ID of this service package.</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Service package latest modified time in RFC3339 date-time with millisecond accuracy and UTC time zone.
        /// </summary>
        /// <value>Service package latest modified time in RFC3339 date-time with millisecond accuracy and UTC time zone.</value>
        [DataMember(Name="modified", EmitDefaultValue=false)]
        public DateTime? Modified { get; set; }

        /// <summary>
        /// Next service package ID if this service package has a pending renewal or null.
        /// </summary>
        /// <value>Next service package ID if this service package has a pending renewal or null.</value>
        [DataMember(Name="next_id", EmitDefaultValue=false)]
        public string NextId { get; set; }

        /// <summary>
        /// Previous service package ID or null.
        /// </summary>
        /// <value>Previous service package ID or null.</value>
        [DataMember(Name="previous_id", EmitDefaultValue=false)]
        public string PreviousId { get; set; }

        /// <summary>
        /// Service package start time in RFC3339 date-time with millisecond accuracy and UTC time zone.
        /// </summary>
        /// <value>Service package start time in RFC3339 date-time with millisecond accuracy and UTC time zone.</value>
        [DataMember(Name="start_time", EmitDefaultValue=false)]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ActiveServicePackage {\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  Expires: ").Append(Expires).Append("\n");
            sb.Append("  FirmwareUpdateCount: ").Append(FirmwareUpdateCount).Append("\n");
            sb.Append("  GracePeriod: ").Append(GracePeriod).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Modified: ").Append(Modified).Append("\n");
            sb.Append("  NextId: ").Append(NextId).Append("\n");
            sb.Append("  PreviousId: ").Append(PreviousId).Append("\n");
            sb.Append("  StartTime: ").Append(StartTime).Append("\n");
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
            return this.Equals(input as ActiveServicePackage);
        }

        /// <summary>
        /// Returns true if ActiveServicePackage instances are equal
        /// </summary>
        /// <param name="input">Instance of ActiveServicePackage to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ActiveServicePackage input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Created == input.Created ||
                    (this.Created != null &&
                    this.Created.Equals(input.Created))
                ) && 
                (
                    this.Expires == input.Expires ||
                    (this.Expires != null &&
                    this.Expires.Equals(input.Expires))
                ) && 
                (
                    this.FirmwareUpdateCount == input.FirmwareUpdateCount ||
                    (this.FirmwareUpdateCount != null &&
                    this.FirmwareUpdateCount.Equals(input.FirmwareUpdateCount))
                ) && 
                (
                    this.GracePeriod == input.GracePeriod ||
                    (this.GracePeriod != null &&
                    this.GracePeriod.Equals(input.GracePeriod))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Modified == input.Modified ||
                    (this.Modified != null &&
                    this.Modified.Equals(input.Modified))
                ) && 
                (
                    this.NextId == input.NextId ||
                    (this.NextId != null &&
                    this.NextId.Equals(input.NextId))
                ) && 
                (
                    this.PreviousId == input.PreviousId ||
                    (this.PreviousId != null &&
                    this.PreviousId.Equals(input.PreviousId))
                ) && 
                (
                    this.StartTime == input.StartTime ||
                    (this.StartTime != null &&
                    this.StartTime.Equals(input.StartTime))
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
                if (this.Created != null)
                    hashCode = hashCode * 59 + this.Created.GetHashCode();
                if (this.Expires != null)
                    hashCode = hashCode * 59 + this.Expires.GetHashCode();
                if (this.FirmwareUpdateCount != null)
                    hashCode = hashCode * 59 + this.FirmwareUpdateCount.GetHashCode();
                if (this.GracePeriod != null)
                    hashCode = hashCode * 59 + this.GracePeriod.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Modified != null)
                    hashCode = hashCode * 59 + this.Modified.GetHashCode();
                if (this.NextId != null)
                    hashCode = hashCode * 59 + this.NextId.GetHashCode();
                if (this.PreviousId != null)
                    hashCode = hashCode * 59 + this.PreviousId.GetHashCode();
                if (this.StartTime != null)
                    hashCode = hashCode * 59 + this.StartTime.GetHashCode();
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
