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

namespace iam.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class GroupSummaryList :  IEquatable<GroupSummaryList>
    { 
    
        /// <summary>
        /// entity name: always 'list'
        /// </summary>
        /// <value>entity name: always 'list'</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum _ObjectEnum {
            
            [EnumMember(Value = "user")]
            User,
            
            [EnumMember(Value = "apikey")]
            Apikey,
            
            [EnumMember(Value = "group")]
            Group,
            
            [EnumMember(Value = "account")]
            Account,
            
            [EnumMember(Value = "list")]
            List,
            
            [EnumMember(Value = "error")]
            Error
        }

    
        /// <summary>
        /// The order of the records to return. Available values: ASC, DESC. Default value is ASC
        /// </summary>
        /// <value>The order of the records to return. Available values: ASC, DESC. Default value is ASC</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OrderEnum {
            
            [EnumMember(Value = "ASC")]
            Asc,
            
            [EnumMember(Value = "DESC")]
            Desc
        }

    
        /// <summary>
        /// entity name: always 'list'
        /// </summary>
        /// <value>entity name: always 'list'</value>
        [DataMember(Name="object", EmitDefaultValue=false)]
        public _ObjectEnum? _Object { get; set; }
    
        /// <summary>
        /// The order of the records to return. Available values: ASC, DESC. Default value is ASC
        /// </summary>
        /// <value>The order of the records to return. Available values: ASC, DESC. Default value is ASC</value>
        [DataMember(Name="order", EmitDefaultValue=false)]
        public OrderEnum? Order { get; set; }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupSummaryList" /> class.
        /// Initializes a new instance of the <see cref="GroupSummaryList" />class.
        /// </summary>
        /// <param name="After">The entity id to fetch after it..</param>
        /// <param name="_Object">entity name: always &#39;list&#39; (required).</param>
        /// <param name="TotalCount">The total number or records, if requested  (required).</param>
        /// <param name="Limit">The number of results to return, (range: 2-1000), or equals to total_count (required).</param>
        /// <param name="Data">List of entities. (required).</param>
        /// <param name="Order">The order of the records to return. Available values: ASC, DESC. Default value is ASC.</param>

        public GroupSummaryList(string After = null, _ObjectEnum? _Object = null, int? TotalCount = null, int? Limit = null, List<GroupSummary> Data = null, OrderEnum? Order = null)
        {
            // to ensure "_Object" is required (not null)
            if (_Object == null)
            {
                throw new InvalidDataException("_Object is a required property for GroupSummaryList and cannot be null");
            }
            else
            {
                this._Object = _Object;
            }
            // to ensure "TotalCount" is required (not null)
            if (TotalCount == null)
            {
                throw new InvalidDataException("TotalCount is a required property for GroupSummaryList and cannot be null");
            }
            else
            {
                this.TotalCount = TotalCount;
            }
            // to ensure "Limit" is required (not null)
            if (Limit == null)
            {
                throw new InvalidDataException("Limit is a required property for GroupSummaryList and cannot be null");
            }
            else
            {
                this.Limit = Limit;
            }
            // to ensure "Data" is required (not null)
            if (Data == null)
            {
                throw new InvalidDataException("Data is a required property for GroupSummaryList and cannot be null");
            }
            else
            {
                this.Data = Data;
            }
            this.After = After;
            this.Order = Order;
            
        }
        
    
        /// <summary>
        /// The entity id to fetch after it.
        /// </summary>
        /// <value>The entity id to fetch after it.</value>
        [DataMember(Name="after", EmitDefaultValue=false)]
        public string After { get; set; }
    
        /// <summary>
        /// The total number or records, if requested 
        /// </summary>
        /// <value>The total number or records, if requested </value>
        [DataMember(Name="totalCount", EmitDefaultValue=false)]
        public int? TotalCount { get; set; }
    
        /// <summary>
        /// The number of results to return, (range: 2-1000), or equals to total_count
        /// </summary>
        /// <value>The number of results to return, (range: 2-1000), or equals to total_count</value>
        [DataMember(Name="limit", EmitDefaultValue=false)]
        public int? Limit { get; set; }
    
        /// <summary>
        /// List of entities.
        /// </summary>
        /// <value>List of entities.</value>
        [DataMember(Name="data", EmitDefaultValue=false)]
        public List<GroupSummary> Data { get; set; }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GroupSummaryList {\n");
            sb.Append("  After: ").Append(After).Append("\n");
            sb.Append("  _Object: ").Append(_Object).Append("\n");
            sb.Append("  TotalCount: ").Append(TotalCount).Append("\n");
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
            return this.Equals(obj as GroupSummaryList);
        }

        /// <summary>
        /// Returns true if GroupSummaryList instances are equal
        /// </summary>
        /// <param name="other">Instance of GroupSummaryList to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GroupSummaryList other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
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
                
                if (this.After != null)
                    hash = hash * 59 + this.After.GetHashCode();
                
                if (this._Object != null)
                    hash = hash * 59 + this._Object.GetHashCode();
                
                if (this.TotalCount != null)
                    hash = hash * 59 + this.TotalCount.GetHashCode();
                
                if (this.Limit != null)
                    hash = hash * 59 + this.Limit.GetHashCode();
                
                if (this.Data != null)
                    hash = hash * 59 + this.Data.GetHashCode();
                
                if (this.Order != null)
                    hash = hash * 59 + this.Order.GetHashCode();
                
                return hash;
            }
        }

    }
}
