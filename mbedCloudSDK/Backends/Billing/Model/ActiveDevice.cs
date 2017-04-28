/* 
 * mbed-billing REST API documentation for API-server
 *
 * This document contains the public REST API definitions of the mbed-billing service's API server component.
 *
 * OpenAPI spec version: 1.3.6-SNAPSHOT
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
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

namespace billing.Model
{
    /// <summary>
    /// ActiveDevice
    /// </summary>
    [DataContract]
    public partial class ActiveDevice :  IEquatable<ActiveDevice>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActiveDevice" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ActiveDevice() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ActiveDevice" /> class.
        /// </summary>
        /// <param name="Timestamp">Timestamp (required).</param>
        /// <param name="DeviceId">DeviceId (required).</param>
        public ActiveDevice(long? Timestamp = default(long?), string DeviceId = default(string))
        {
            // to ensure "Timestamp" is required (not null)
            if (Timestamp == null)
            {
                throw new InvalidDataException("Timestamp is a required property for ActiveDevice and cannot be null");
            }
            else
            {
                this.Timestamp = Timestamp;
            }
            // to ensure "DeviceId" is required (not null)
            if (DeviceId == null)
            {
                throw new InvalidDataException("DeviceId is a required property for ActiveDevice and cannot be null");
            }
            else
            {
                this.DeviceId = DeviceId;
            }
        }
        
        /// <summary>
        /// Gets or Sets Timestamp
        /// </summary>
        [DataMember(Name="timestamp", EmitDefaultValue=false)]
        public long? Timestamp { get; set; }
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
            sb.Append("class ActiveDevice {\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
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
            return this.Equals(obj as ActiveDevice);
        }

        /// <summary>
        /// Returns true if ActiveDevice instances are equal
        /// </summary>
        /// <param name="other">Instance of ActiveDevice to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ActiveDevice other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Timestamp == other.Timestamp ||
                    this.Timestamp != null &&
                    this.Timestamp.Equals(other.Timestamp)
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
                if (this.Timestamp != null)
                    hash = hash * 59 + this.Timestamp.GetHashCode();
                if (this.DeviceId != null)
                    hash = hash * 59 + this.DeviceId.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
