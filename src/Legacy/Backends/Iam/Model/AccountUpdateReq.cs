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
using SwaggerDateConverter = iam.Client.SwaggerDateConverter;

namespace iam.Model
{
    /// <summary>
    /// This object represents an account creation request.
    /// </summary>
    [DataContract]
    public partial class AccountUpdateReq :  IEquatable<AccountUpdateReq>, IValidatableObject
    {
        /// <summary>
        /// The enforcement status of setting up the multi-factor authentication. &#39;Enforced&#39; means that setting up the MFA is required after login. &#39;Optional&#39; means that the MFA is not required.
        /// </summary>
        /// <value>The enforcement status of setting up the multi-factor authentication. &#39;Enforced&#39; means that setting up the MFA is required after login. &#39;Optional&#39; means that the MFA is not required.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MfaStatusEnum
        {
            
            /// <summary>
            /// Enum Enforced for "enforced"
            /// </summary>
            [EnumMember(Value = "enforced")]
            Enforced,
            
            /// <summary>
            /// Enum Optional for "optional"
            /// </summary>
            [EnumMember(Value = "optional")]
            Optional
        }

        /// <summary>
        /// The enforcement status of setting up the multi-factor authentication. &#39;Enforced&#39; means that setting up the MFA is required after login. &#39;Optional&#39; means that the MFA is not required.
        /// </summary>
        /// <value>The enforcement status of setting up the multi-factor authentication. &#39;Enforced&#39; means that setting up the MFA is required after login. &#39;Optional&#39; means that the MFA is not required.</value>
        [DataMember(Name="mfa_status", EmitDefaultValue=false)]
        public MfaStatusEnum? MfaStatus { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountUpdateReq" /> class.
        /// </summary>
        /// <param name="AddressLine1">Postal address line 1, not longer than 100 characters. Required for commercial accounts only..</param>
        /// <param name="AddressLine2">Postal address line 2, not longer than 100 characters..</param>
        /// <param name="Aliases">An array of aliases, not more than 10. An alias is not shorter than 8 and not longer than 100 characters..</param>
        /// <param name="City">The city part of the postal address, not longer than 100 characters. Required for commercial accounts only..</param>
        /// <param name="Company">The name of the company, not longer than 100 characters. Required for commercial accounts only..</param>
        /// <param name="Contact">The name of the contact person for this account, not longer than 100 characters. Required for commercial accounts only..</param>
        /// <param name="Country">The country part of the postal address, not longer than 100 characters. Required for commercial accounts only..</param>
        /// <param name="CustomFields">Account&#39;s custom properties as key-value pairs, with a maximum of 10 keys. The maximum length of a key is 100 characters. The values are handled as strings and the maximum length for a value is 1000 characters..</param>
        /// <param name="DisplayName">The display name for the account, not longer than 100 characters..</param>
        /// <param name="Email">The company email address for this account, not longer than 254 characters. Required for commercial accounts only..</param>
        /// <param name="EndMarket">The end market for this account, not longer than 100 characters..</param>
        /// <param name="ExpirationWarningThreshold">Indicates how many days before account expiration a notification email should be sent. Valid values are: 1-180..</param>
        /// <param name="IdleTimeout">The reference token expiration time in minutes for this account. Between 1 and 120 minutes..</param>
        /// <param name="MfaStatus">The enforcement status of setting up the multi-factor authentication. &#39;Enforced&#39; means that setting up the MFA is required after login. &#39;Optional&#39; means that the MFA is not required..</param>
        /// <param name="NotificationEmails">A list of notification email addresses..</param>
        /// <param name="PasswordPolicy">Password policy for this account..</param>
        /// <param name="PhoneNumber">The phone number of a representative of the company, not longer than 100 characters..</param>
        /// <param name="PostalCode">The postal code part of the postal address, not longer than 100 characters..</param>
        /// <param name="State">The state part of the postal address, not longer than 100 characters..</param>
        public AccountUpdateReq(string AddressLine1 = default(string), string AddressLine2 = default(string), List<string> Aliases = default(List<string>), string City = default(string), string Company = default(string), string Contact = default(string), string Country = default(string), Dictionary<string, string> CustomFields = default(Dictionary<string, string>), string DisplayName = default(string), string Email = default(string), string EndMarket = default(string), string ExpirationWarningThreshold = default(string), string IdleTimeout = default(string), MfaStatusEnum? MfaStatus = default(MfaStatusEnum?), List<string> NotificationEmails = default(List<string>), PasswordPolicy PasswordPolicy = default(PasswordPolicy), string PhoneNumber = default(string), string PostalCode = default(string), string State = default(string))
        {
            this.AddressLine1 = AddressLine1;
            this.AddressLine2 = AddressLine2;
            this.Aliases = Aliases;
            this.City = City;
            this.Company = Company;
            this.Contact = Contact;
            this.Country = Country;
            this.CustomFields = CustomFields;
            this.DisplayName = DisplayName;
            this.Email = Email;
            this.EndMarket = EndMarket;
            this.ExpirationWarningThreshold = ExpirationWarningThreshold;
            this.IdleTimeout = IdleTimeout;
            this.MfaStatus = MfaStatus;
            this.NotificationEmails = NotificationEmails;
            this.PasswordPolicy = PasswordPolicy;
            this.PhoneNumber = PhoneNumber;
            this.PostalCode = PostalCode;
            this.State = State;
        }
        
        /// <summary>
        /// Postal address line 1, not longer than 100 characters. Required for commercial accounts only.
        /// </summary>
        /// <value>Postal address line 1, not longer than 100 characters. Required for commercial accounts only.</value>
        [DataMember(Name="address_line1", EmitDefaultValue=false)]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Postal address line 2, not longer than 100 characters.
        /// </summary>
        /// <value>Postal address line 2, not longer than 100 characters.</value>
        [DataMember(Name="address_line2", EmitDefaultValue=false)]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// An array of aliases, not more than 10. An alias is not shorter than 8 and not longer than 100 characters.
        /// </summary>
        /// <value>An array of aliases, not more than 10. An alias is not shorter than 8 and not longer than 100 characters.</value>
        [DataMember(Name="aliases", EmitDefaultValue=false)]
        public List<string> Aliases { get; set; }

        /// <summary>
        /// The city part of the postal address, not longer than 100 characters. Required for commercial accounts only.
        /// </summary>
        /// <value>The city part of the postal address, not longer than 100 characters. Required for commercial accounts only.</value>
        [DataMember(Name="city", EmitDefaultValue=false)]
        public string City { get; set; }

        /// <summary>
        /// The name of the company, not longer than 100 characters. Required for commercial accounts only.
        /// </summary>
        /// <value>The name of the company, not longer than 100 characters. Required for commercial accounts only.</value>
        [DataMember(Name="company", EmitDefaultValue=false)]
        public string Company { get; set; }

        /// <summary>
        /// The name of the contact person for this account, not longer than 100 characters. Required for commercial accounts only.
        /// </summary>
        /// <value>The name of the contact person for this account, not longer than 100 characters. Required for commercial accounts only.</value>
        [DataMember(Name="contact", EmitDefaultValue=false)]
        public string Contact { get; set; }

        /// <summary>
        /// The country part of the postal address, not longer than 100 characters. Required for commercial accounts only.
        /// </summary>
        /// <value>The country part of the postal address, not longer than 100 characters. Required for commercial accounts only.</value>
        [DataMember(Name="country", EmitDefaultValue=false)]
        public string Country { get; set; }

        /// <summary>
        /// Account&#39;s custom properties as key-value pairs, with a maximum of 10 keys. The maximum length of a key is 100 characters. The values are handled as strings and the maximum length for a value is 1000 characters.
        /// </summary>
        /// <value>Account&#39;s custom properties as key-value pairs, with a maximum of 10 keys. The maximum length of a key is 100 characters. The values are handled as strings and the maximum length for a value is 1000 characters.</value>
        [DataMember(Name="custom_fields", EmitDefaultValue=false)]
        public Dictionary<string, string> CustomFields { get; set; }

        /// <summary>
        /// The display name for the account, not longer than 100 characters.
        /// </summary>
        /// <value>The display name for the account, not longer than 100 characters.</value>
        [DataMember(Name="display_name", EmitDefaultValue=false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// The company email address for this account, not longer than 254 characters. Required for commercial accounts only.
        /// </summary>
        /// <value>The company email address for this account, not longer than 254 characters. Required for commercial accounts only.</value>
        [DataMember(Name="email", EmitDefaultValue=false)]
        public string Email { get; set; }

        /// <summary>
        /// The end market for this account, not longer than 100 characters.
        /// </summary>
        /// <value>The end market for this account, not longer than 100 characters.</value>
        [DataMember(Name="end_market", EmitDefaultValue=false)]
        public string EndMarket { get; set; }

        /// <summary>
        /// Indicates how many days before account expiration a notification email should be sent. Valid values are: 1-180.
        /// </summary>
        /// <value>Indicates how many days before account expiration a notification email should be sent. Valid values are: 1-180.</value>
        [DataMember(Name="expiration_warning_threshold", EmitDefaultValue=false)]
        public string ExpirationWarningThreshold { get; set; }

        /// <summary>
        /// The reference token expiration time in minutes for this account. Between 1 and 120 minutes.
        /// </summary>
        /// <value>The reference token expiration time in minutes for this account. Between 1 and 120 minutes.</value>
        [DataMember(Name="idle_timeout", EmitDefaultValue=false)]
        public string IdleTimeout { get; set; }


        /// <summary>
        /// A list of notification email addresses.
        /// </summary>
        /// <value>A list of notification email addresses.</value>
        [DataMember(Name="notification_emails", EmitDefaultValue=false)]
        public List<string> NotificationEmails { get; set; }

        /// <summary>
        /// Password policy for this account.
        /// </summary>
        /// <value>Password policy for this account.</value>
        [DataMember(Name="password_policy", EmitDefaultValue=false)]
        public PasswordPolicy PasswordPolicy { get; set; }

        /// <summary>
        /// The phone number of a representative of the company, not longer than 100 characters.
        /// </summary>
        /// <value>The phone number of a representative of the company, not longer than 100 characters.</value>
        [DataMember(Name="phone_number", EmitDefaultValue=false)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The postal code part of the postal address, not longer than 100 characters.
        /// </summary>
        /// <value>The postal code part of the postal address, not longer than 100 characters.</value>
        [DataMember(Name="postal_code", EmitDefaultValue=false)]
        public string PostalCode { get; set; }

        /// <summary>
        /// The state part of the postal address, not longer than 100 characters.
        /// </summary>
        /// <value>The state part of the postal address, not longer than 100 characters.</value>
        [DataMember(Name="state", EmitDefaultValue=false)]
        public string State { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AccountUpdateReq {\n");
            sb.Append("  AddressLine1: ").Append(AddressLine1).Append("\n");
            sb.Append("  AddressLine2: ").Append(AddressLine2).Append("\n");
            sb.Append("  Aliases: ").Append(Aliases).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  Company: ").Append(Company).Append("\n");
            sb.Append("  Contact: ").Append(Contact).Append("\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
            sb.Append("  CustomFields: ").Append(CustomFields).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  EndMarket: ").Append(EndMarket).Append("\n");
            sb.Append("  ExpirationWarningThreshold: ").Append(ExpirationWarningThreshold).Append("\n");
            sb.Append("  IdleTimeout: ").Append(IdleTimeout).Append("\n");
            sb.Append("  MfaStatus: ").Append(MfaStatus).Append("\n");
            sb.Append("  NotificationEmails: ").Append(NotificationEmails).Append("\n");
            sb.Append("  PasswordPolicy: ").Append(PasswordPolicy).Append("\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
            sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
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
            return this.Equals(input as AccountUpdateReq);
        }

        /// <summary>
        /// Returns true if AccountUpdateReq instances are equal
        /// </summary>
        /// <param name="input">Instance of AccountUpdateReq to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccountUpdateReq input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AddressLine1 == input.AddressLine1 ||
                    (this.AddressLine1 != null &&
                    this.AddressLine1.Equals(input.AddressLine1))
                ) && 
                (
                    this.AddressLine2 == input.AddressLine2 ||
                    (this.AddressLine2 != null &&
                    this.AddressLine2.Equals(input.AddressLine2))
                ) && 
                (
                    this.Aliases == input.Aliases ||
                    this.Aliases != null &&
                    this.Aliases.SequenceEqual(input.Aliases)
                ) && 
                (
                    this.City == input.City ||
                    (this.City != null &&
                    this.City.Equals(input.City))
                ) && 
                (
                    this.Company == input.Company ||
                    (this.Company != null &&
                    this.Company.Equals(input.Company))
                ) && 
                (
                    this.Contact == input.Contact ||
                    (this.Contact != null &&
                    this.Contact.Equals(input.Contact))
                ) && 
                (
                    this.Country == input.Country ||
                    (this.Country != null &&
                    this.Country.Equals(input.Country))
                ) && 
                (
                    this.CustomFields == input.CustomFields ||
                    this.CustomFields != null &&
                    this.CustomFields.SequenceEqual(input.CustomFields)
                ) && 
                (
                    this.DisplayName == input.DisplayName ||
                    (this.DisplayName != null &&
                    this.DisplayName.Equals(input.DisplayName))
                ) && 
                (
                    this.Email == input.Email ||
                    (this.Email != null &&
                    this.Email.Equals(input.Email))
                ) && 
                (
                    this.EndMarket == input.EndMarket ||
                    (this.EndMarket != null &&
                    this.EndMarket.Equals(input.EndMarket))
                ) && 
                (
                    this.ExpirationWarningThreshold == input.ExpirationWarningThreshold ||
                    (this.ExpirationWarningThreshold != null &&
                    this.ExpirationWarningThreshold.Equals(input.ExpirationWarningThreshold))
                ) && 
                (
                    this.IdleTimeout == input.IdleTimeout ||
                    (this.IdleTimeout != null &&
                    this.IdleTimeout.Equals(input.IdleTimeout))
                ) && 
                (
                    this.MfaStatus == input.MfaStatus ||
                    (this.MfaStatus != null &&
                    this.MfaStatus.Equals(input.MfaStatus))
                ) && 
                (
                    this.NotificationEmails == input.NotificationEmails ||
                    this.NotificationEmails != null &&
                    this.NotificationEmails.SequenceEqual(input.NotificationEmails)
                ) && 
                (
                    this.PasswordPolicy == input.PasswordPolicy ||
                    (this.PasswordPolicy != null &&
                    this.PasswordPolicy.Equals(input.PasswordPolicy))
                ) && 
                (
                    this.PhoneNumber == input.PhoneNumber ||
                    (this.PhoneNumber != null &&
                    this.PhoneNumber.Equals(input.PhoneNumber))
                ) && 
                (
                    this.PostalCode == input.PostalCode ||
                    (this.PostalCode != null &&
                    this.PostalCode.Equals(input.PostalCode))
                ) && 
                (
                    this.State == input.State ||
                    (this.State != null &&
                    this.State.Equals(input.State))
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
                if (this.AddressLine1 != null)
                    hashCode = hashCode * 59 + this.AddressLine1.GetHashCode();
                if (this.AddressLine2 != null)
                    hashCode = hashCode * 59 + this.AddressLine2.GetHashCode();
                if (this.Aliases != null)
                    hashCode = hashCode * 59 + this.Aliases.GetHashCode();
                if (this.City != null)
                    hashCode = hashCode * 59 + this.City.GetHashCode();
                if (this.Company != null)
                    hashCode = hashCode * 59 + this.Company.GetHashCode();
                if (this.Contact != null)
                    hashCode = hashCode * 59 + this.Contact.GetHashCode();
                if (this.Country != null)
                    hashCode = hashCode * 59 + this.Country.GetHashCode();
                if (this.CustomFields != null)
                    hashCode = hashCode * 59 + this.CustomFields.GetHashCode();
                if (this.DisplayName != null)
                    hashCode = hashCode * 59 + this.DisplayName.GetHashCode();
                if (this.Email != null)
                    hashCode = hashCode * 59 + this.Email.GetHashCode();
                if (this.EndMarket != null)
                    hashCode = hashCode * 59 + this.EndMarket.GetHashCode();
                if (this.ExpirationWarningThreshold != null)
                    hashCode = hashCode * 59 + this.ExpirationWarningThreshold.GetHashCode();
                if (this.IdleTimeout != null)
                    hashCode = hashCode * 59 + this.IdleTimeout.GetHashCode();
                if (this.MfaStatus != null)
                    hashCode = hashCode * 59 + this.MfaStatus.GetHashCode();
                if (this.NotificationEmails != null)
                    hashCode = hashCode * 59 + this.NotificationEmails.GetHashCode();
                if (this.PasswordPolicy != null)
                    hashCode = hashCode * 59 + this.PasswordPolicy.GetHashCode();
                if (this.PhoneNumber != null)
                    hashCode = hashCode * 59 + this.PhoneNumber.GetHashCode();
                if (this.PostalCode != null)
                    hashCode = hashCode * 59 + this.PostalCode.GetHashCode();
                if (this.State != null)
                    hashCode = hashCode * 59 + this.State.GetHashCode();
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