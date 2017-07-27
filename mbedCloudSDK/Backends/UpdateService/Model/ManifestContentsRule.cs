/* 
 * Update Service API
 *
 * This is the API Documentation for the mbed deployment service which is part of the update service.
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
    /// ManifestContentsRule
    /// </summary>
    [DataContract]
    public partial class ManifestContentsRule :  IEquatable<ManifestContentsRule>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManifestContentsRule" /> class.
        /// </summary>
        /// <param name="_Int">_Int.</param>
        /// <param name="Raw">Raw.</param>
        /// <param name="_Bool">_Bool.</param>
        public ManifestContentsRule(int? _Int = default(int?), string Raw = default(string), bool? _Bool = default(bool?))
        {
            this._Int = _Int;
            this.Raw = Raw;
            this._Bool = _Bool;
        }
        
        /// <summary>
        /// Gets or Sets _Int
        /// </summary>
        [DataMember(Name="int", EmitDefaultValue=false)]
        public int? _Int { get; set; }
        /// <summary>
        /// Gets or Sets Raw
        /// </summary>
        [DataMember(Name="raw", EmitDefaultValue=false)]
        public string Raw { get; set; }
        /// <summary>
        /// Gets or Sets _Bool
        /// </summary>
        [DataMember(Name="bool", EmitDefaultValue=false)]
        public bool? _Bool { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ManifestContentsRule {\n");
            sb.Append("  _Int: ").Append(_Int).Append("\n");
            sb.Append("  Raw: ").Append(Raw).Append("\n");
            sb.Append("  _Bool: ").Append(_Bool).Append("\n");
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
            return this.Equals(obj as ManifestContentsRule);
        }

        /// <summary>
        /// Returns true if ManifestContentsRule instances are equal
        /// </summary>
        /// <param name="other">Instance of ManifestContentsRule to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ManifestContentsRule other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this._Int == other._Int ||
                    this._Int != null &&
                    this._Int.Equals(other._Int)
                ) && 
                (
                    this.Raw == other.Raw ||
                    this.Raw != null &&
                    this.Raw.Equals(other.Raw)
                ) && 
                (
                    this._Bool == other._Bool ||
                    this._Bool != null &&
                    this._Bool.Equals(other._Bool)
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
                if (this._Int != null)
                    hash = hash * 59 + this._Int.GetHashCode();
                if (this.Raw != null)
                    hash = hash * 59 + this.Raw.GetHashCode();
                if (this._Bool != null)
                    hash = hash * 59 + this._Bool.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}