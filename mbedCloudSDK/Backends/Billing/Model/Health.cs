/* 
 * mbed-billing REST API documentation for API-server
 *
 * This document contains the public REST API definitions of the mbed-billing service's API server component.
 *
 * OpenAPI spec version: 1.3.4-SNAPSHOT
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
    /// Health
    /// </summary>
    [DataContract]
    public partial class Health :  IEquatable<Health>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Health" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Health() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Health" /> class.
        /// </summary>
        /// <param name="Iam">Iam (required).</param>
        /// <param name="Psql">Psql (required).</param>
        /// <param name="All">All (required).</param>
        /// <param name="LastUpdated">LastUpdated (required).</param>
        public Health(bool? Iam = default(bool?), bool? Psql = default(bool?), bool? All = default(bool?), DateTime? LastUpdated = default(DateTime?))
        {
            // to ensure "Iam" is required (not null)
            if (Iam == null)
            {
                throw new InvalidDataException("Iam is a required property for Health and cannot be null");
            }
            else
            {
                this.Iam = Iam;
            }
            // to ensure "Psql" is required (not null)
            if (Psql == null)
            {
                throw new InvalidDataException("Psql is a required property for Health and cannot be null");
            }
            else
            {
                this.Psql = Psql;
            }
            // to ensure "All" is required (not null)
            if (All == null)
            {
                throw new InvalidDataException("All is a required property for Health and cannot be null");
            }
            else
            {
                this.All = All;
            }
            // to ensure "LastUpdated" is required (not null)
            if (LastUpdated == null)
            {
                throw new InvalidDataException("LastUpdated is a required property for Health and cannot be null");
            }
            else
            {
                this.LastUpdated = LastUpdated;
            }
        }
        
        /// <summary>
        /// Gets or Sets Iam
        /// </summary>
        [DataMember(Name="iam", EmitDefaultValue=false)]
        public bool? Iam { get; set; }
        /// <summary>
        /// Gets or Sets Psql
        /// </summary>
        [DataMember(Name="psql", EmitDefaultValue=false)]
        public bool? Psql { get; set; }
        /// <summary>
        /// Gets or Sets All
        /// </summary>
        [DataMember(Name="all", EmitDefaultValue=false)]
        public bool? All { get; set; }
        /// <summary>
        /// Gets or Sets LastUpdated
        /// </summary>
        [DataMember(Name="last_updated", EmitDefaultValue=false)]
        public DateTime? LastUpdated { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Health {\n");
            sb.Append("  Iam: ").Append(Iam).Append("\n");
            sb.Append("  Psql: ").Append(Psql).Append("\n");
            sb.Append("  All: ").Append(All).Append("\n");
            sb.Append("  LastUpdated: ").Append(LastUpdated).Append("\n");
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
            return this.Equals(obj as Health);
        }

        /// <summary>
        /// Returns true if Health instances are equal
        /// </summary>
        /// <param name="other">Instance of Health to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Health other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Iam == other.Iam ||
                    this.Iam != null &&
                    this.Iam.Equals(other.Iam)
                ) && 
                (
                    this.Psql == other.Psql ||
                    this.Psql != null &&
                    this.Psql.Equals(other.Psql)
                ) && 
                (
                    this.All == other.All ||
                    this.All != null &&
                    this.All.Equals(other.All)
                ) && 
                (
                    this.LastUpdated == other.LastUpdated ||
                    this.LastUpdated != null &&
                    this.LastUpdated.Equals(other.LastUpdated)
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
                if (this.Iam != null)
                    hash = hash * 59 + this.Iam.GetHashCode();
                if (this.Psql != null)
                    hash = hash * 59 + this.Psql.GetHashCode();
                if (this.All != null)
                    hash = hash * 59 + this.All.GetHashCode();
                if (this.LastUpdated != null)
                    hash = hash * 59 + this.LastUpdated.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
