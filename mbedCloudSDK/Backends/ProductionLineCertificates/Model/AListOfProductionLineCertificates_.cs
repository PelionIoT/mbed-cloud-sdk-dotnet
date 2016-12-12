/* 
 * Provisioning endpoints - production line certificates.
 *
 * A producton line certificate is used to associate a specific installation of the Factory Tool with an mbed Cloud account.  The production line certificate is generated by the Factory Tool, and needs to be uploaded using these APIs. 
 *
 * OpenAPI spec version: 0.8
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

namespace production_line_certificates.
{
    /// <summary>
    /// AListOfProductionLineCertificates_
    /// </summary>
    [DataContract]
    public partial class AListOfProductionLineCertificates_ :  IEquatable<AListOfProductionLineCertificates_>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AListOfProductionLineCertificates_" /> class.
        /// </summary>
        /// <param name="_Object">\&quot;list\&quot;.</param>
        /// <param name="TotalCount">Currently not used..</param>
        /// <param name="After">Currently not used..</param>
        /// <param name="Limit">Currently not used..</param>
        /// <param name="Data">Production line certificates..</param>
        /// <param name="Order">Currently not used..</param>
        public AListOfProductionLineCertificates_(string _Object = null, int? TotalCount = null, string After = null, int? Limit = null, List<ProductionLineCertificate> Data = null, string Order = null)
        {
            this._Object = _Object;
            this.TotalCount = TotalCount;
            this.After = After;
            this.Limit = Limit;
            this.Data = Data;
            this.Order = Order;
        }
        
        /// <summary>
        /// \&quot;list\&quot;
        /// </summary>
        /// <value>\&quot;list\&quot;</value>
        [DataMember(Name="object", EmitDefaultValue=false)]
        public string _Object { get; set; }
        /// <summary>
        /// Currently not used.
        /// </summary>
        /// <value>Currently not used.</value>
        [DataMember(Name="total_count", EmitDefaultValue=false)]
        public int? TotalCount { get; set; }
        /// <summary>
        /// Currently not used.
        /// </summary>
        /// <value>Currently not used.</value>
        [DataMember(Name="after", EmitDefaultValue=false)]
        public string After { get; set; }
        /// <summary>
        /// Currently not used.
        /// </summary>
        /// <value>Currently not used.</value>
        [DataMember(Name="limit", EmitDefaultValue=false)]
        public int? Limit { get; set; }
        /// <summary>
        /// Production line certificates.
        /// </summary>
        /// <value>Production line certificates.</value>
        [DataMember(Name="data", EmitDefaultValue=false)]
        public List<ProductionLineCertificate> Data { get; set; }
        /// <summary>
        /// Currently not used.
        /// </summary>
        /// <value>Currently not used.</value>
        [DataMember(Name="order", EmitDefaultValue=false)]
        public string Order { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AListOfProductionLineCertificates_ {\n");
            sb.Append("  _Object: ").Append(_Object).Append("\n");
            sb.Append("  TotalCount: ").Append(TotalCount).Append("\n");
            sb.Append("  After: ").Append(After).Append("\n");
            sb.Append("  Limit: ").Append(Limit).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  Order: ").Append(Order).Append("\n");
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
            return this.Equals(obj as AListOfProductionLineCertificates_);
        }

        /// <summary>
        /// Returns true if AListOfProductionLineCertificates_ instances are equal
        /// </summary>
        /// <param name="other">Instance of AListOfProductionLineCertificates_ to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AListOfProductionLineCertificates_ other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this._Object == other._Object ||
                    this._Object != null &&
                    this._Object.Equals(other._Object)
                ) && 
                (
                    this.TotalCount == other.TotalCount ||
                    this.TotalCount != null &&
                    this.TotalCount.Equals(other.TotalCount)
                ) && 
                (
                    this.After == other.After ||
                    this.After != null &&
                    this.After.Equals(other.After)
                ) && 
                (
                    this.Limit == other.Limit ||
                    this.Limit != null &&
                    this.Limit.Equals(other.Limit)
                ) && 
                (
                    this.Data == other.Data ||
                    this.Data != null &&
                    this.Data.SequenceEqual(other.Data)
                ) && 
                (
                    this.Order == other.Order ||
                    this.Order != null &&
                    this.Order.Equals(other.Order)
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
                if (this._Object != null)
                    hash = hash * 59 + this._Object.GetHashCode();
                if (this.TotalCount != null)
                    hash = hash * 59 + this.TotalCount.GetHashCode();
                if (this.After != null)
                    hash = hash * 59 + this.After.GetHashCode();
                if (this.Limit != null)
                    hash = hash * 59 + this.Limit.GetHashCode();
                if (this.Data != null)
                    hash = hash * 59 + this.Data.GetHashCode();
                if (this.Order != null)
                    hash = hash * 59 + this.Order.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
