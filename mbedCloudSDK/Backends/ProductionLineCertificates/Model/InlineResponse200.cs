using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace production_line_certificates.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class InlineResponse200 :  IEquatable<InlineResponse200>
    { 
    
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse200" /> class.
        /// Initializes a new instance of the <see cref="InlineResponse200" />class.
        /// </summary>
        /// <param name="Data">Production line certificates..</param>
        /// <param name="TotalCount">Currently not used..</param>
        /// <param name="Limit">Currently not used..</param>
        /// <param name="After">Currently not used..</param>
        /// <param name="_Object">\&quot;list\&quot;.</param>
        /// <param name="Order">Currently not used..</param>

        public InlineResponse200(List<ProductionLineCertificate> Data = null, int? TotalCount = null, int? Limit = null, string After = null, string _Object = null, string Order = null)
        {
            this.Data = Data;
            this.TotalCount = TotalCount;
            this.Limit = Limit;
            this.After = After;
            this._Object = _Object;
            this.Order = Order;
            
        }
        
    
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
        [DataMember(Name="total_count", EmitDefaultValue=false)]
        public int? TotalCount { get; set; }
    
        /// <summary>
        /// Currently not used.
        /// </summary>
        /// <value>Currently not used.</value>
        [DataMember(Name="limit", EmitDefaultValue=false)]
        public int? Limit { get; set; }
    
        /// <summary>
        /// Currently not used.
        /// </summary>
        /// <value>Currently not used.</value>
        [DataMember(Name="after", EmitDefaultValue=false)]
        public string After { get; set; }
    
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
        [DataMember(Name="order", EmitDefaultValue=false)]
        public string Order { get; set; }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InlineResponse200 {\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  TotalCount: ").Append(TotalCount).Append("\n");
            sb.Append("  Limit: ").Append(Limit).Append("\n");
            sb.Append("  After: ").Append(After).Append("\n");
            sb.Append("  _Object: ").Append(_Object).Append("\n");
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
            return this.Equals(obj as InlineResponse200);
        }

        /// <summary>
        /// Returns true if InlineResponse200 instances are equal
        /// </summary>
        /// <param name="other">Instance of InlineResponse200 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse200 other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Data == other.Data ||
                    this.Data != null &&
                    this.Data.SequenceEqual(other.Data)
                ) && 
                (
                    this.TotalCount == other.TotalCount ||
                    this.TotalCount != null &&
                    this.TotalCount.Equals(other.TotalCount)
                ) && 
                (
                    this.Limit == other.Limit ||
                    this.Limit != null &&
                    this.Limit.Equals(other.Limit)
                ) && 
                (
                    this.After == other.After ||
                    this.After != null &&
                    this.After.Equals(other.After)
                ) && 
                (
                    this._Object == other._Object ||
                    this._Object != null &&
                    this._Object.Equals(other._Object)
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
                
                if (this.Data != null)
                    hash = hash * 59 + this.Data.GetHashCode();
                
                if (this.TotalCount != null)
                    hash = hash * 59 + this.TotalCount.GetHashCode();
                
                if (this.Limit != null)
                    hash = hash * 59 + this.Limit.GetHashCode();
                
                if (this.After != null)
                    hash = hash * 59 + this.After.GetHashCode();
                
                if (this._Object != null)
                    hash = hash * 59 + this._Object.GetHashCode();
                
                if (this.Order != null)
                    hash = hash * 59 + this.Order.GetHashCode();
                
                return hash;
            }
        }

    }
}
