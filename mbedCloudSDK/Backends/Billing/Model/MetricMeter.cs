/* 
 * mbed-billing REST API documentation for API-server
 *
 * This document contains the public REST API definitions of the mbed-billing service's API server component.
 *
 * OpenAPI spec version: 1.3.5-SNAPSHOT
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
    /// A meter measures the rate of events over time. All measurements are in presented in milliseconds.
    /// </summary>
    [DataContract]
    public partial class MetricMeter :  IEquatable<MetricMeter>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricMeter" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected MetricMeter() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricMeter" /> class.
        /// </summary>
        /// <param name="Count">Count (required).</param>
        /// <param name="M1Rate">M1Rate (required).</param>
        /// <param name="M5Rate">M5Rate (required).</param>
        /// <param name="M15Rate">M15Rate (required).</param>
        /// <param name="MeanRate">MeanRate (required).</param>
        public MetricMeter(double? Count = default(double?), double? M1Rate = default(double?), double? M5Rate = default(double?), double? M15Rate = default(double?), double? MeanRate = default(double?))
        {
            // to ensure "Count" is required (not null)
            if (Count == null)
            {
                throw new InvalidDataException("Count is a required property for MetricMeter and cannot be null");
            }
            else
            {
                this.Count = Count;
            }
            // to ensure "M1Rate" is required (not null)
            if (M1Rate == null)
            {
                throw new InvalidDataException("M1Rate is a required property for MetricMeter and cannot be null");
            }
            else
            {
                this.M1Rate = M1Rate;
            }
            // to ensure "M5Rate" is required (not null)
            if (M5Rate == null)
            {
                throw new InvalidDataException("M5Rate is a required property for MetricMeter and cannot be null");
            }
            else
            {
                this.M5Rate = M5Rate;
            }
            // to ensure "M15Rate" is required (not null)
            if (M15Rate == null)
            {
                throw new InvalidDataException("M15Rate is a required property for MetricMeter and cannot be null");
            }
            else
            {
                this.M15Rate = M15Rate;
            }
            // to ensure "MeanRate" is required (not null)
            if (MeanRate == null)
            {
                throw new InvalidDataException("MeanRate is a required property for MetricMeter and cannot be null");
            }
            else
            {
                this.MeanRate = MeanRate;
            }
        }
        
        /// <summary>
        /// Gets or Sets Count
        /// </summary>
        [DataMember(Name="count", EmitDefaultValue=false)]
        public double? Count { get; set; }
        /// <summary>
        /// Gets or Sets M1Rate
        /// </summary>
        [DataMember(Name="m1_rate", EmitDefaultValue=false)]
        public double? M1Rate { get; set; }
        /// <summary>
        /// Gets or Sets M5Rate
        /// </summary>
        [DataMember(Name="m5_rate", EmitDefaultValue=false)]
        public double? M5Rate { get; set; }
        /// <summary>
        /// Gets or Sets M15Rate
        /// </summary>
        [DataMember(Name="m15_rate", EmitDefaultValue=false)]
        public double? M15Rate { get; set; }
        /// <summary>
        /// Gets or Sets MeanRate
        /// </summary>
        [DataMember(Name="mean_rate", EmitDefaultValue=false)]
        public double? MeanRate { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MetricMeter {\n");
            sb.Append("  Count: ").Append(Count).Append("\n");
            sb.Append("  M1Rate: ").Append(M1Rate).Append("\n");
            sb.Append("  M5Rate: ").Append(M5Rate).Append("\n");
            sb.Append("  M15Rate: ").Append(M15Rate).Append("\n");
            sb.Append("  MeanRate: ").Append(MeanRate).Append("\n");
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
            return this.Equals(obj as MetricMeter);
        }

        /// <summary>
        /// Returns true if MetricMeter instances are equal
        /// </summary>
        /// <param name="other">Instance of MetricMeter to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MetricMeter other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Count == other.Count ||
                    this.Count != null &&
                    this.Count.Equals(other.Count)
                ) && 
                (
                    this.M1Rate == other.M1Rate ||
                    this.M1Rate != null &&
                    this.M1Rate.Equals(other.M1Rate)
                ) && 
                (
                    this.M5Rate == other.M5Rate ||
                    this.M5Rate != null &&
                    this.M5Rate.Equals(other.M5Rate)
                ) && 
                (
                    this.M15Rate == other.M15Rate ||
                    this.M15Rate != null &&
                    this.M15Rate.Equals(other.M15Rate)
                ) && 
                (
                    this.MeanRate == other.MeanRate ||
                    this.MeanRate != null &&
                    this.MeanRate.Equals(other.MeanRate)
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
                if (this.Count != null)
                    hash = hash * 59 + this.Count.GetHashCode();
                if (this.M1Rate != null)
                    hash = hash * 59 + this.M1Rate.GetHashCode();
                if (this.M5Rate != null)
                    hash = hash * 59 + this.M5Rate.GetHashCode();
                if (this.M15Rate != null)
                    hash = hash * 59 + this.M15Rate.GetHashCode();
                if (this.MeanRate != null)
                    hash = hash * 59 + this.MeanRate.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
