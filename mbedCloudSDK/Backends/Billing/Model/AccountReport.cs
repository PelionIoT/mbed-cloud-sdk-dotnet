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
    /// AccountReport
    /// </summary>
    [DataContract]
    public partial class AccountReport :  IEquatable<AccountReport>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountReport" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AccountReport() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountReport" /> class.
        /// </summary>
        /// <param name="BillingData">BillingData (required).</param>
        /// <param name="Account">Account (required).</param>
        /// <param name="Children">Children (required).</param>
        /// <param name="Aggregated">Aggregated (required).</param>
        public AccountReport(BillingData BillingData = default(BillingData), Account Account = default(Account), List<ChildAccountReport> Children = default(List<ChildAccountReport>), BillingData Aggregated = default(BillingData))
        {
            // to ensure "BillingData" is required (not null)
            if (BillingData == null)
            {
                throw new InvalidDataException("BillingData is a required property for AccountReport and cannot be null");
            }
            else
            {
                this.BillingData = BillingData;
            }
            // to ensure "Account" is required (not null)
            if (Account == null)
            {
                throw new InvalidDataException("Account is a required property for AccountReport and cannot be null");
            }
            else
            {
                this.Account = Account;
            }
            // to ensure "Children" is required (not null)
            if (Children == null)
            {
                throw new InvalidDataException("Children is a required property for AccountReport and cannot be null");
            }
            else
            {
                this.Children = Children;
            }
            // to ensure "Aggregated" is required (not null)
            if (Aggregated == null)
            {
                throw new InvalidDataException("Aggregated is a required property for AccountReport and cannot be null");
            }
            else
            {
                this.Aggregated = Aggregated;
            }
        }
        
        /// <summary>
        /// Gets or Sets BillingData
        /// </summary>
        [DataMember(Name="billing_data", EmitDefaultValue=false)]
        public BillingData BillingData { get; set; }
        /// <summary>
        /// Gets or Sets Account
        /// </summary>
        [DataMember(Name="account", EmitDefaultValue=false)]
        public Account Account { get; set; }
        /// <summary>
        /// Gets or Sets Children
        /// </summary>
        [DataMember(Name="children", EmitDefaultValue=false)]
        public List<ChildAccountReport> Children { get; set; }
        /// <summary>
        /// Gets or Sets Aggregated
        /// </summary>
        [DataMember(Name="aggregated", EmitDefaultValue=false)]
        public BillingData Aggregated { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AccountReport {\n");
            sb.Append("  BillingData: ").Append(BillingData).Append("\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
            sb.Append("  Children: ").Append(Children).Append("\n");
            sb.Append("  Aggregated: ").Append(Aggregated).Append("\n");
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
            return this.Equals(obj as AccountReport);
        }

        /// <summary>
        /// Returns true if AccountReport instances are equal
        /// </summary>
        /// <param name="other">Instance of AccountReport to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccountReport other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.BillingData == other.BillingData ||
                    this.BillingData != null &&
                    this.BillingData.Equals(other.BillingData)
                ) && 
                (
                    this.Account == other.Account ||
                    this.Account != null &&
                    this.Account.Equals(other.Account)
                ) && 
                (
                    this.Children == other.Children ||
                    this.Children != null &&
                    this.Children.SequenceEqual(other.Children)
                ) && 
                (
                    this.Aggregated == other.Aggregated ||
                    this.Aggregated != null &&
                    this.Aggregated.Equals(other.Aggregated)
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
                if (this.BillingData != null)
                    hash = hash * 59 + this.BillingData.GetHashCode();
                if (this.Account != null)
                    hash = hash * 59 + this.Account.GetHashCode();
                if (this.Children != null)
                    hash = hash * 59 + this.Children.GetHashCode();
                if (this.Aggregated != null)
                    hash = hash * 59 + this.Aggregated.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
