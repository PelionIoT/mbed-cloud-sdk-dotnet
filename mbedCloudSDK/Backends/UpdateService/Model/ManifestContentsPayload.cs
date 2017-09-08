/* 
 * Update Service API
 *
 * This is the API documentation for the Mbed deployment service, which is part of the update service.
 *
 * OpenAPI spec version: 3
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

namespace update_service.Model
{
    /// <summary>
    /// ManifestContentsPayload
    /// </summary>
    [DataContract]
    public partial class ManifestContentsPayload :  IEquatable<ManifestContentsPayload>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManifestContentsPayload" /> class.
        /// </summary>
        /// <param name="Format">Format.</param>
        /// <param name="Reference">Reference.</param>
        /// <param name="StorageIdentifier">An payload storage destination identifier. The identifier specifies where to place the firmware image on the device. For example, when an IoT device has multiple microcontrollers (MCUs), the identifier determines which MCU receives the image..</param>
        public ManifestContentsPayload(ManifestContentsPayloadFormat Format = default(ManifestContentsPayloadFormat), ManifestContentsPayloadReference Reference = default(ManifestContentsPayloadReference), string StorageIdentifier = default(string))
        {
            this.Format = Format;
            this.Reference = Reference;
            this.StorageIdentifier = StorageIdentifier;
        }
        
        /// <summary>
        /// Gets or Sets Format
        /// </summary>
        [DataMember(Name="format", EmitDefaultValue=false)]
        public ManifestContentsPayloadFormat Format { get; set; }
        /// <summary>
        /// Gets or Sets Reference
        /// </summary>
        [DataMember(Name="reference", EmitDefaultValue=false)]
        public ManifestContentsPayloadReference Reference { get; set; }
        /// <summary>
        /// An payload storage destination identifier. The identifier specifies where to place the firmware image on the device. For example, when an IoT device has multiple microcontrollers (MCUs), the identifier determines which MCU receives the image.
        /// </summary>
        /// <value>An payload storage destination identifier. The identifier specifies where to place the firmware image on the device. For example, when an IoT device has multiple microcontrollers (MCUs), the identifier determines which MCU receives the image.</value>
        [DataMember(Name="storageIdentifier", EmitDefaultValue=false)]
        public string StorageIdentifier { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ManifestContentsPayload {\n");
            sb.Append("  Format: ").Append(Format).Append("\n");
            sb.Append("  Reference: ").Append(Reference).Append("\n");
            sb.Append("  StorageIdentifier: ").Append(StorageIdentifier).Append("\n");
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
            return this.Equals(obj as ManifestContentsPayload);
        }

        /// <summary>
        /// Returns true if ManifestContentsPayload instances are equal
        /// </summary>
        /// <param name="other">Instance of ManifestContentsPayload to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ManifestContentsPayload other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Format == other.Format ||
                    this.Format != null &&
                    this.Format.Equals(other.Format)
                ) && 
                (
                    this.Reference == other.Reference ||
                    this.Reference != null &&
                    this.Reference.Equals(other.Reference)
                ) && 
                (
                    this.StorageIdentifier == other.StorageIdentifier ||
                    this.StorageIdentifier != null &&
                    this.StorageIdentifier.Equals(other.StorageIdentifier)
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
                if (this.Format != null)
                    hash = hash * 59 + this.Format.GetHashCode();
                if (this.Reference != null)
                    hash = hash * 59 + this.Reference.GetHashCode();
                if (this.StorageIdentifier != null)
                    hash = hash * 59 + this.StorageIdentifier.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
