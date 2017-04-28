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
    /// MetricGauge
    /// </summary>
    [DataContract]
    public partial class MetricGauge :  IEquatable<MetricGauge>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricGauge" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected MetricGauge() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricGauge" /> class.
        /// </summary>
        /// <param name="Value">Value (required).</param>
        public MetricGauge(decimal? Value = default(decimal?))
        {
            // to ensure "Value" is required (not null)
            if (Value == null)
            {
                throw new InvalidDataException("Value is a required property for MetricGauge and cannot be null");
            }
            else
            {
                this.Value = Value;
            }
        }
        
        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public decimal? Value { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MetricGauge {\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
            return this.Equals(obj as MetricGauge);
        }

        /// <summary>
        /// Returns true if MetricGauge instances are equal
        /// </summary>
        /// <param name="other">Instance of MetricGauge to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MetricGauge other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Value == other.Value ||
                    this.Value != null &&
                    this.Value.Equals(other.Value)
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
                if (this.Value != null)
                    hash = hash * 59 + this.Value.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
