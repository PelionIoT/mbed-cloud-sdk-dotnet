/* 
 * IAM Identities REST API
 *
 * REST API to manage accounts, groups, users and API keys
 *
 * OpenAPI spec version: v3
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

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
    /// GroupSummaryList
    /// </summary>
    [DataContract]
    public partial class GroupSummaryList :  IEquatable<GroupSummaryList>
    {
        /// <summary>
        /// Entity name: always 'list'
        /// </summary>
        /// <value>Entity name: always 'list'</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ObjectEnum
        {
            
            /// <summary>
            /// Enum User for "user"
            /// </summary>
            [EnumMember(Value = "user")]
            User,
            
            /// <summary>
            /// Enum Apikey for "apikey"
            /// </summary>
            [EnumMember(Value = "apikey")]
            Apikey,
            
            /// <summary>
            /// Enum Group for "group"
            /// </summary>
            [EnumMember(Value = "group")]
            Group,
            
            /// <summary>
            /// Enum Account for "account"
            /// </summary>
            [EnumMember(Value = "account")]
            Account,
            
            /// <summary>
            /// Enum Accounttemplate for "account_template"
            /// </summary>
            [EnumMember(Value = "account_template")]
            Accounttemplate,
            
            /// <summary>
            /// Enum Cacert for "ca_cert"
            /// </summary>
            [EnumMember(Value = "ca_cert")]
            Cacert,
            
            /// <summary>
            /// Enum List for "list"
            /// </summary>
            [EnumMember(Value = "list")]
            List,
            
            /// <summary>
            /// Enum Error for "error"
            /// </summary>
            [EnumMember(Value = "error")]
            Error
        }

        /// <summary>
        /// The order of the records to return. Available values: ASC, DESC; by default ASC.
        /// </summary>
        /// <value>The order of the records to return. Available values: ASC, DESC; by default ASC.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OrderEnum
        {
            
            /// <summary>
            /// Enum ASC for "ASC"
            /// </summary>
            [EnumMember(Value = "ASC")]
            ASC,
            
            /// <summary>
            /// Enum DESC for "DESC"
            /// </summary>
            [EnumMember(Value = "DESC")]
            DESC
        }

        /// <summary>
        /// Entity name: always 'list'
        /// </summary>
        /// <value>Entity name: always 'list'</value>
        [DataMember(Name="object", EmitDefaultValue=false)]
        public ObjectEnum? _Object { get; set; }
        /// <summary>
        /// The order of the records to return. Available values: ASC, DESC; by default ASC.
        /// </summary>
        /// <value>The order of the records to return. Available values: ASC, DESC; by default ASC.</value>
        [DataMember(Name="order", EmitDefaultValue=false)]
        public OrderEnum? Order { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupSummaryList" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GroupSummaryList() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupSummaryList" /> class.
        /// </summary>
        /// <param name="After">The entity ID to fetch after the given one..</param>
        /// <param name="HasMore">Flag indicating whether there is more results. (default to false).</param>
        /// <param name="TotalCount">The total number or records, if requested. It might be returned also for small lists. (required).</param>
        /// <param name="_Object">Entity name: always &#39;list&#39; (required).</param>
        /// <param name="Limit">The number of results to return, (range: 2-1000), or equals to &#x60;total_count&#x60; (required).</param>
        /// <param name="Data">A list of entities. (required).</param>
        /// <param name="Order">The order of the records to return. Available values: ASC, DESC; by default ASC..</param>
        public GroupSummaryList(string After = null, bool? HasMore = null, int? TotalCount = null, ObjectEnum? _Object = null, int? Limit = null, List<GroupSummary> Data = null, OrderEnum? Order = null)
        {
            // to ensure "TotalCount" is required (not null)
            if (TotalCount == null)
            {
                throw new InvalidDataException("TotalCount is a required property for GroupSummaryList and cannot be null");
            }
            else
            {
                this.TotalCount = TotalCount;
            }
            // to ensure "_Object" is required (not null)
            if (_Object == null)
            {
                throw new InvalidDataException("_Object is a required property for GroupSummaryList and cannot be null");
            }
            else
            {
                this._Object = _Object;
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
            // use default value if no "HasMore" provided
            if (HasMore == null)
            {
                this.HasMore = false;
            }
            else
            {
                this.HasMore = HasMore;
            }
            this.Order = Order;
        }
        
        /// <summary>
        /// The entity ID to fetch after the given one.
        /// </summary>
        /// <value>The entity ID to fetch after the given one.</value>
        [DataMember(Name="after", EmitDefaultValue=false)]
        public string After { get; set; }
        /// <summary>
        /// Flag indicating whether there is more results.
        /// </summary>
        /// <value>Flag indicating whether there is more results.</value>
        [DataMember(Name="has_more", EmitDefaultValue=false)]
        public bool? HasMore { get; set; }
        /// <summary>
        /// The total number or records, if requested. It might be returned also for small lists.
        /// </summary>
        /// <value>The total number or records, if requested. It might be returned also for small lists.</value>
        [DataMember(Name="total_count", EmitDefaultValue=false)]
        public int? TotalCount { get; set; }
        /// <summary>
        /// The number of results to return, (range: 2-1000), or equals to &#x60;total_count&#x60;
        /// </summary>
        /// <value>The number of results to return, (range: 2-1000), or equals to &#x60;total_count&#x60;</value>
        [DataMember(Name="limit", EmitDefaultValue=false)]
        public int? Limit { get; set; }
        /// <summary>
        /// A list of entities.
        /// </summary>
        /// <value>A list of entities.</value>
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
            sb.Append("  HasMore: ").Append(HasMore).Append("\n");
            sb.Append("  TotalCount: ").Append(TotalCount).Append("\n");
            sb.Append("  _Object: ").Append(_Object).Append("\n");
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
                    this.HasMore == other.HasMore ||
                    this.HasMore != null &&
                    this.HasMore.Equals(other.HasMore)
                ) && 
                (
                    this.TotalCount == other.TotalCount ||
                    this.TotalCount != null &&
                    this.TotalCount.Equals(other.TotalCount)
                ) && 
                (
                    this._Object == other._Object ||
                    this._Object != null &&
                    this._Object.Equals(other._Object)
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
                if (this.HasMore != null)
                    hash = hash * 59 + this.HasMore.GetHashCode();
                if (this.TotalCount != null)
                    hash = hash * 59 + this.TotalCount.GetHashCode();
                if (this._Object != null)
                    hash = hash * 59 + this._Object.GetHashCode();
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
