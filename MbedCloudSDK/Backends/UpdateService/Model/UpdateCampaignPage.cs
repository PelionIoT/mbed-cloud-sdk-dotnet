/* 
 * <auto-generated>
 * Update Service API
 *
 * This is the API documentation for the Device Management deployment service, which is part of the Update service.
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
using SwaggerDateConverter = update_service.Client.SwaggerDateConverter;

namespace update_service.Model
{
    /// <summary>
    /// UpdateCampaignPage
    /// </summary>
    [DataContract]
    public partial class UpdateCampaignPage :  IEquatable<UpdateCampaignPage>, IValidatableObject
    {
        /// <summary>
        /// The order of the records to return. Acceptable values: ASC, DESC. Default: ASC
        /// </summary>
        /// <value>The order of the records to return. Acceptable values: ASC, DESC. Default: ASC</value>
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
        /// The order of the records to return. Acceptable values: ASC, DESC. Default: ASC
        /// </summary>
        /// <value>The order of the records to return. Acceptable values: ASC, DESC. Default: ASC</value>
        [DataMember(Name="order", EmitDefaultValue=false)]
        public OrderEnum? Order { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCampaignPage" /> class.
        /// </summary>
        /// <param name="After">After.</param>
        /// <param name="Data">Data.</param>
        /// <param name="HasMore">HasMore.</param>
        /// <param name="Limit">Limit.</param>
        /// <param name="_Object">_Object.</param>
        /// <param name="Order">The order of the records to return. Acceptable values: ASC, DESC. Default: ASC.</param>
        /// <param name="TotalCount">TotalCount.</param>
        public UpdateCampaignPage(string After = default(string), List<UpdateCampaign> Data = default(List<UpdateCampaign>), bool? HasMore = default(bool?), int? Limit = default(int?), string _Object = default(string), OrderEnum? Order = default(OrderEnum?), int? TotalCount = default(int?))
        {
            this.After = After;
            this.Data = Data;
            this.HasMore = HasMore;
            this.Limit = Limit;
            this._Object = _Object;
            this.Order = Order;
            this.TotalCount = TotalCount;
        }
        
        /// <summary>
        /// Gets or Sets After
        /// </summary>
        [DataMember(Name="after", EmitDefaultValue=false)]
        public string After { get; set; }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name="data", EmitDefaultValue=false)]
        public List<UpdateCampaign> Data { get; set; }

        /// <summary>
        /// Gets or Sets HasMore
        /// </summary>
        [DataMember(Name="has_more", EmitDefaultValue=false)]
        public bool? HasMore { get; set; }

        /// <summary>
        /// Gets or Sets Limit
        /// </summary>
        [DataMember(Name="limit", EmitDefaultValue=false)]
        public int? Limit { get; set; }

        /// <summary>
        /// Gets or Sets _Object
        /// </summary>
        [DataMember(Name="object", EmitDefaultValue=false)]
        public string _Object { get; set; }


        /// <summary>
        /// Gets or Sets TotalCount
        /// </summary>
        [DataMember(Name="total_count", EmitDefaultValue=false)]
        public int? TotalCount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UpdateCampaignPage {\n");
            sb.Append("  After: ").Append(After).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  HasMore: ").Append(HasMore).Append("\n");
            sb.Append("  Limit: ").Append(Limit).Append("\n");
            sb.Append("  _Object: ").Append(_Object).Append("\n");
            sb.Append("  Order: ").Append(Order).Append("\n");
            sb.Append("  TotalCount: ").Append(TotalCount).Append("\n");
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
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as UpdateCampaignPage);
        }

        /// <summary>
        /// Returns true if UpdateCampaignPage instances are equal
        /// </summary>
        /// <param name="input">Instance of UpdateCampaignPage to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpdateCampaignPage input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.After == input.After ||
                    (this.After != null &&
                    this.After.Equals(input.After))
                ) && 
                (
                    this.Data == input.Data ||
                    this.Data != null &&
                    this.Data.SequenceEqual(input.Data)
                ) && 
                (
                    this.HasMore == input.HasMore ||
                    (this.HasMore != null &&
                    this.HasMore.Equals(input.HasMore))
                ) && 
                (
                    this.Limit == input.Limit ||
                    (this.Limit != null &&
                    this.Limit.Equals(input.Limit))
                ) && 
                (
                    this._Object == input._Object ||
                    (this._Object != null &&
                    this._Object.Equals(input._Object))
                ) && 
                (
                    this.Order == input.Order ||
                    (this.Order != null &&
                    this.Order.Equals(input.Order))
                ) && 
                (
                    this.TotalCount == input.TotalCount ||
                    (this.TotalCount != null &&
                    this.TotalCount.Equals(input.TotalCount))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.After != null)
                    hashCode = hashCode * 59 + this.After.GetHashCode();
                if (this.Data != null)
                    hashCode = hashCode * 59 + this.Data.GetHashCode();
                if (this.HasMore != null)
                    hashCode = hashCode * 59 + this.HasMore.GetHashCode();
                if (this.Limit != null)
                    hashCode = hashCode * 59 + this.Limit.GetHashCode();
                if (this._Object != null)
                    hashCode = hashCode * 59 + this._Object.GetHashCode();
                if (this.Order != null)
                    hashCode = hashCode * 59 + this.Order.GetHashCode();
                if (this.TotalCount != null)
                    hashCode = hashCode * 59 + this.TotalCount.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
