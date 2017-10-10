/* 
 * <auto-generated>
 * Account Management API
 *
 * API for managing accounts, users, creating API keys, uploading trusted certificates
 *
 * OpenAPI spec version: v3
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

namespace iam.Model
{
    /// <summary>
    /// This object represents an account creation request.
    /// </summary>
    [DataContract]
    public partial class AccountUpdateReq :  IEquatable<AccountUpdateReq>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountUpdateReq" /> class.
        /// </summary>
        /// <param name="AddressLine2">Postal address line 2, not longer than 100 characters..</param>
        /// <param name="City">The city part of the postal address, not longer than 100 characters. Required for commercial accounts only..</param>
        /// <param name="AddressLine1">Postal address line 1, not longer than 100 characters. Required for commercial accounts only..</param>
        /// <param name="DisplayName">The display name for the account, not longer than 100 characters..</param>
        /// <param name="Country">The country part of the postal address, not longer than 100 characters. Required for commercial accounts only..</param>
        /// <param name="Company">The name of the company, not longer than 100 characters. Required for commercial accounts only..</param>
        /// <param name="IdleTimeout">The reference token expiration time in minutes for this account. Between 1 and 120 minutes..</param>
        /// <param name="State">The state part of the postal address, not longer than 100 characters..</param>
        /// <param name="Contact">The name of the contact person for this account, not longer than 100 characters. Required for commercial accounts only..</param>
        /// <param name="PostalCode">The postal code part of the postal address, not longer than 100 characters..</param>
        /// <param name="PasswordPolicy">Password policy for this account..</param>
        /// <param name="EndMarket">The end market for this account, not longer than 100 characters..</param>
        /// <param name="PhoneNumber">The phone number of the company, not longer than 100 characters..</param>
        /// <param name="Email">The company email address for this account, not longer than 254 characters. Required for commercial accounts only..</param>
        /// <param name="Aliases">An array of aliases, not more than 10. An alias is not shorter than 8 and not longer than 100 characters..</param>
        public AccountUpdateReq(string AddressLine2 = default(string), string City = default(string), string AddressLine1 = default(string), string DisplayName = default(string), string Country = default(string), string Company = default(string), string IdleTimeout = default(string), string State = default(string), string Contact = default(string), string PostalCode = default(string), PasswordPolicy PasswordPolicy = default(PasswordPolicy), string EndMarket = default(string), string PhoneNumber = default(string), string Email = default(string), List<string> Aliases = default(List<string>))
        {
            this.AddressLine2 = AddressLine2;
            this.City = City;
            this.AddressLine1 = AddressLine1;
            this.DisplayName = DisplayName;
            this.Country = Country;
            this.Company = Company;
            this.IdleTimeout = IdleTimeout;
            this.State = State;
            this.Contact = Contact;
            this.PostalCode = PostalCode;
            this.PasswordPolicy = PasswordPolicy;
            this.EndMarket = EndMarket;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.Aliases = Aliases;
        }
        
        /// <summary>
        /// Postal address line 2, not longer than 100 characters.
        /// </summary>
        /// <value>Postal address line 2, not longer than 100 characters.</value>
        [DataMember(Name="address_line2", EmitDefaultValue=false)]
        public string AddressLine2 { get; set; }
        /// <summary>
        /// The city part of the postal address, not longer than 100 characters. Required for commercial accounts only.
        /// </summary>
        /// <value>The city part of the postal address, not longer than 100 characters. Required for commercial accounts only.</value>
        [DataMember(Name="city", EmitDefaultValue=false)]
        public string City { get; set; }
        /// <summary>
        /// Postal address line 1, not longer than 100 characters. Required for commercial accounts only.
        /// </summary>
        /// <value>Postal address line 1, not longer than 100 characters. Required for commercial accounts only.</value>
        [DataMember(Name="address_line1", EmitDefaultValue=false)]
        public string AddressLine1 { get; set; }
        /// <summary>
        /// The display name for the account, not longer than 100 characters.
        /// </summary>
        /// <value>The display name for the account, not longer than 100 characters.</value>
        [DataMember(Name="display_name", EmitDefaultValue=false)]
        public string DisplayName { get; set; }
        /// <summary>
        /// The country part of the postal address, not longer than 100 characters. Required for commercial accounts only.
        /// </summary>
        /// <value>The country part of the postal address, not longer than 100 characters. Required for commercial accounts only.</value>
        [DataMember(Name="country", EmitDefaultValue=false)]
        public string Country { get; set; }
        /// <summary>
        /// The name of the company, not longer than 100 characters. Required for commercial accounts only.
        /// </summary>
        /// <value>The name of the company, not longer than 100 characters. Required for commercial accounts only.</value>
        [DataMember(Name="company", EmitDefaultValue=false)]
        public string Company { get; set; }
        /// <summary>
        /// The reference token expiration time in minutes for this account. Between 1 and 120 minutes.
        /// </summary>
        /// <value>The reference token expiration time in minutes for this account. Between 1 and 120 minutes.</value>
        [DataMember(Name="idle_timeout", EmitDefaultValue=false)]
        public string IdleTimeout { get; set; }
        /// <summary>
        /// The state part of the postal address, not longer than 100 characters.
        /// </summary>
        /// <value>The state part of the postal address, not longer than 100 characters.</value>
        [DataMember(Name="state", EmitDefaultValue=false)]
        public string State { get; set; }
        /// <summary>
        /// The name of the contact person for this account, not longer than 100 characters. Required for commercial accounts only.
        /// </summary>
        /// <value>The name of the contact person for this account, not longer than 100 characters. Required for commercial accounts only.</value>
        [DataMember(Name="contact", EmitDefaultValue=false)]
        public string Contact { get; set; }
        /// <summary>
        /// The postal code part of the postal address, not longer than 100 characters.
        /// </summary>
        /// <value>The postal code part of the postal address, not longer than 100 characters.</value>
        [DataMember(Name="postal_code", EmitDefaultValue=false)]
        public string PostalCode { get; set; }
        /// <summary>
        /// Password policy for this account.
        /// </summary>
        /// <value>Password policy for this account.</value>
        [DataMember(Name="password_policy", EmitDefaultValue=false)]
        public PasswordPolicy PasswordPolicy { get; set; }
        /// <summary>
        /// The end market for this account, not longer than 100 characters.
        /// </summary>
        /// <value>The end market for this account, not longer than 100 characters.</value>
        [DataMember(Name="end_market", EmitDefaultValue=false)]
        public string EndMarket { get; set; }
        /// <summary>
        /// The phone number of the company, not longer than 100 characters.
        /// </summary>
        /// <value>The phone number of the company, not longer than 100 characters.</value>
        [DataMember(Name="phone_number", EmitDefaultValue=false)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// The company email address for this account, not longer than 254 characters. Required for commercial accounts only.
        /// </summary>
        /// <value>The company email address for this account, not longer than 254 characters. Required for commercial accounts only.</value>
        [DataMember(Name="email", EmitDefaultValue=false)]
        public string Email { get; set; }
        /// <summary>
        /// An array of aliases, not more than 10. An alias is not shorter than 8 and not longer than 100 characters.
        /// </summary>
        /// <value>An array of aliases, not more than 10. An alias is not shorter than 8 and not longer than 100 characters.</value>
        [DataMember(Name="aliases", EmitDefaultValue=false)]
        public List<string> Aliases { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AccountUpdateReq {\n");
            sb.Append("  AddressLine2: ").Append(AddressLine2).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  AddressLine1: ").Append(AddressLine1).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
            sb.Append("  Company: ").Append(Company).Append("\n");
            sb.Append("  IdleTimeout: ").Append(IdleTimeout).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  Contact: ").Append(Contact).Append("\n");
            sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
            sb.Append("  PasswordPolicy: ").Append(PasswordPolicy).Append("\n");
            sb.Append("  EndMarket: ").Append(EndMarket).Append("\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Aliases: ").Append(Aliases).Append("\n");
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
            return this.Equals(obj as AccountUpdateReq);
        }

        /// <summary>
        /// Returns true if AccountUpdateReq instances are equal
        /// </summary>
        /// <param name="other">Instance of AccountUpdateReq to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccountUpdateReq other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.AddressLine2 == other.AddressLine2 ||
                    this.AddressLine2 != null &&
                    this.AddressLine2.Equals(other.AddressLine2)
                ) && 
                (
                    this.City == other.City ||
                    this.City != null &&
                    this.City.Equals(other.City)
                ) && 
                (
                    this.AddressLine1 == other.AddressLine1 ||
                    this.AddressLine1 != null &&
                    this.AddressLine1.Equals(other.AddressLine1)
                ) && 
                (
                    this.DisplayName == other.DisplayName ||
                    this.DisplayName != null &&
                    this.DisplayName.Equals(other.DisplayName)
                ) && 
                (
                    this.Country == other.Country ||
                    this.Country != null &&
                    this.Country.Equals(other.Country)
                ) && 
                (
                    this.Company == other.Company ||
                    this.Company != null &&
                    this.Company.Equals(other.Company)
                ) && 
                (
                    this.IdleTimeout == other.IdleTimeout ||
                    this.IdleTimeout != null &&
                    this.IdleTimeout.Equals(other.IdleTimeout)
                ) && 
                (
                    this.State == other.State ||
                    this.State != null &&
                    this.State.Equals(other.State)
                ) && 
                (
                    this.Contact == other.Contact ||
                    this.Contact != null &&
                    this.Contact.Equals(other.Contact)
                ) && 
                (
                    this.PostalCode == other.PostalCode ||
                    this.PostalCode != null &&
                    this.PostalCode.Equals(other.PostalCode)
                ) && 
                (
                    this.PasswordPolicy == other.PasswordPolicy ||
                    this.PasswordPolicy != null &&
                    this.PasswordPolicy.Equals(other.PasswordPolicy)
                ) && 
                (
                    this.EndMarket == other.EndMarket ||
                    this.EndMarket != null &&
                    this.EndMarket.Equals(other.EndMarket)
                ) && 
                (
                    this.PhoneNumber == other.PhoneNumber ||
                    this.PhoneNumber != null &&
                    this.PhoneNumber.Equals(other.PhoneNumber)
                ) && 
                (
                    this.Email == other.Email ||
                    this.Email != null &&
                    this.Email.Equals(other.Email)
                ) && 
                (
                    this.Aliases == other.Aliases ||
                    this.Aliases != null &&
                    this.Aliases.SequenceEqual(other.Aliases)
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
                if (this.AddressLine2 != null)
                    hash = hash * 59 + this.AddressLine2.GetHashCode();
                if (this.City != null)
                    hash = hash * 59 + this.City.GetHashCode();
                if (this.AddressLine1 != null)
                    hash = hash * 59 + this.AddressLine1.GetHashCode();
                if (this.DisplayName != null)
                    hash = hash * 59 + this.DisplayName.GetHashCode();
                if (this.Country != null)
                    hash = hash * 59 + this.Country.GetHashCode();
                if (this.Company != null)
                    hash = hash * 59 + this.Company.GetHashCode();
                if (this.IdleTimeout != null)
                    hash = hash * 59 + this.IdleTimeout.GetHashCode();
                if (this.State != null)
                    hash = hash * 59 + this.State.GetHashCode();
                if (this.Contact != null)
                    hash = hash * 59 + this.Contact.GetHashCode();
                if (this.PostalCode != null)
                    hash = hash * 59 + this.PostalCode.GetHashCode();
                if (this.PasswordPolicy != null)
                    hash = hash * 59 + this.PasswordPolicy.GetHashCode();
                if (this.EndMarket != null)
                    hash = hash * 59 + this.EndMarket.GetHashCode();
                if (this.PhoneNumber != null)
                    hash = hash * 59 + this.PhoneNumber.GetHashCode();
                if (this.Email != null)
                    hash = hash * 59 + this.Email.GetHashCode();
                if (this.Aliases != null)
                    hash = hash * 59 + this.Aliases.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
