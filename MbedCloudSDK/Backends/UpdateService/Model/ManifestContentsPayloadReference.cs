/* 
 * <auto-generated>
 * Update Service API
 *
 * This is the API documentation for the Mbed deployment service, which is part of the update service.
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

namespace update_service.Model
{
    /// <summary>
    /// ManifestContentsPayloadReference
    /// </summary>
    [DataContract]
    public partial class ManifestContentsPayloadReference :  IEquatable<ManifestContentsPayloadReference>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManifestContentsPayloadReference" /> class.
        /// </summary>
        /// <param name="Hash">Hex representation of the SHA-256 hash of the payload.</param>
        /// <param name="Uri">The payload URI.</param>
        /// <param name="Size">Size of the payload in bytes.</param>
        public ManifestContentsPayloadReference(string Hash = default(string), string Uri = default(string), int? Size = default(int?))
        {
            this.Hash = Hash;
            this.Uri = Uri;
            this.Size = Size;
        }
        
        /// <summary>
        /// Hex representation of the SHA-256 hash of the payload
        /// </summary>
        /// <value>Hex representation of the SHA-256 hash of the payload</value>
        [DataMember(Name="hash", EmitDefaultValue=false)]
        public string Hash { get; set; }
        /// <summary>
        /// The payload URI
        /// </summary>
        /// <value>The payload URI</value>
        [DataMember(Name="uri", EmitDefaultValue=false)]
        public string Uri { get; set; }
        /// <summary>
        /// Size of the payload in bytes
        /// </summary>
        /// <value>Size of the payload in bytes</value>
        [DataMember(Name="size", EmitDefaultValue=false)]
        public int? Size { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ManifestContentsPayloadReference {\n");
            sb.Append("  Hash: ").Append(Hash).Append("\n");
            sb.Append("  Uri: ").Append(Uri).Append("\n");
            sb.Append("  Size: ").Append(Size).Append("\n");
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
            return this.Equals(obj as ManifestContentsPayloadReference);
        }

        /// <summary>
        /// Returns true if ManifestContentsPayloadReference instances are equal
        /// </summary>
        /// <param name="other">Instance of ManifestContentsPayloadReference to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ManifestContentsPayloadReference other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Hash == other.Hash ||
                    this.Hash != null &&
                    this.Hash.Equals(other.Hash)
                ) && 
                (
                    this.Uri == other.Uri ||
                    this.Uri != null &&
                    this.Uri.Equals(other.Uri)
                ) && 
                (
                    this.Size == other.Size ||
                    this.Size != null &&
                    this.Size.Equals(other.Size)
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
                if (this.Hash != null)
                    hash = hash * 59 + this.Hash.GetHashCode();
                if (this.Uri != null)
                    hash = hash * 59 + this.Uri.GetHashCode();
                if (this.Size != null)
                    hash = hash * 59 + this.Size.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
