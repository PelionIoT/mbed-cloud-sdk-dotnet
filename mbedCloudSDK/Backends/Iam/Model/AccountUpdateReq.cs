/* 
 * IAM Identities REST API
 *
 * REST API to manage accounts, groups, users and API keys
 *
 * OpenAPI spec version: v3
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

namespace iam.Model
{
    /// <summary>
    /// This object represents an account update request.
    /// </summary>
    [DataContract]
    public partial class AccountUpdateReq :  IEquatable<AccountUpdateReq>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountUpdateReq" /> class.
        /// </summary>
        /// <param name="AddressLine2">Postal address line 2..</param>
        /// <param name="City">The city part of the postal address..</param>
        /// <param name="AddressLine1">Postal address line 1..</param>
        /// <param name="DisplayName">The display name for the account..</param>
        /// <param name="Country">The country part of the postal address..</param>
        /// <param name="Company">The name of the company..</param>
        /// <param name="TemplateId">Account template ID. Manageable by the root admin only..</param>
        /// <param name="Status">The status of the account. Manageable by the root admin only..</param>
        /// <param name="State">The state part of the postal address..</param>
        /// <param name="Contact">The name of the contact person for this account..</param>
        /// <param name="PostalCode">The postal code part of the postal address..</param>
        /// <param name="IsProvisioningAllowed">Flag (true/false) indicating whether Factory Tool is allowed to download or not. Manageable by the root admin only. (default to false).</param>
        /// <param name="ParentID">The ID of the parent account, if it has any..</param>
        /// <param name="Tier">The tier level of the account; &#39;0&#39;: free tier, &#39;1&#39;: commercial account. Other values are reserved for the future. Manageable by the root admin only..</param>
        /// <param name="PhoneNumber">The phone number of the company..</param>
        /// <param name="Email">The company email address for this account..</param>
        /// <param name="Aliases">An array of aliases..</param>
        public AccountUpdateReq(string AddressLine2 = default(string), string City = default(string), string AddressLine1 = default(string), string DisplayName = default(string), string Country = default(string), string Company = default(string), string TemplateId = default(string), string Status = default(string), string State = default(string), string Contact = default(string), string PostalCode = default(string), bool? IsProvisioningAllowed = false, string ParentID = default(string), string Tier = default(string), string PhoneNumber = default(string), string Email = default(string), List<string> Aliases = default(List<string>))
        {
            this.AddressLine2 = AddressLine2;
            this.City = City;
            this.AddressLine1 = AddressLine1;
            this.DisplayName = DisplayName;
            this.Country = Country;
            this.Company = Company;
            this.TemplateId = TemplateId;
            this.Status = Status;
            this.State = State;
            this.Contact = Contact;
            this.PostalCode = PostalCode;
            // use default value if no "IsProvisioningAllowed" provided
            if (IsProvisioningAllowed == null)
            {
                this.IsProvisioningAllowed = false;
            }
            else
            {
                this.IsProvisioningAllowed = IsProvisioningAllowed;
            }
            this.ParentID = ParentID;
            this.Tier = Tier;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.Aliases = Aliases;
        }
        
        /// <summary>
        /// Postal address line 2.
        /// </summary>
        /// <value>Postal address line 2.</value>
        [DataMember(Name="address_line2", EmitDefaultValue=false)]
        public string AddressLine2 { get; set; }
        /// <summary>
        /// The city part of the postal address.
        /// </summary>
        /// <value>The city part of the postal address.</value>
        [DataMember(Name="city", EmitDefaultValue=false)]
        public string City { get; set; }
        /// <summary>
        /// Postal address line 1.
        /// </summary>
        /// <value>Postal address line 1.</value>
        [DataMember(Name="address_line1", EmitDefaultValue=false)]
        public string AddressLine1 { get; set; }
        /// <summary>
        /// The display name for the account.
        /// </summary>
        /// <value>The display name for the account.</value>
        [DataMember(Name="display_name", EmitDefaultValue=false)]
        public string DisplayName { get; set; }
        /// <summary>
        /// The country part of the postal address.
        /// </summary>
        /// <value>The country part of the postal address.</value>
        [DataMember(Name="country", EmitDefaultValue=false)]
        public string Country { get; set; }
        /// <summary>
        /// The name of the company.
        /// </summary>
        /// <value>The name of the company.</value>
        [DataMember(Name="company", EmitDefaultValue=false)]
        public string Company { get; set; }
        /// <summary>
        /// Account template ID. Manageable by the root admin only.
        /// </summary>
        /// <value>Account template ID. Manageable by the root admin only.</value>
        [DataMember(Name="template_id", EmitDefaultValue=false)]
        public string TemplateId { get; set; }
        /// <summary>
        /// The status of the account. Manageable by the root admin only.
        /// </summary>
        /// <value>The status of the account. Manageable by the root admin only.</value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public string Status { get; set; }
        /// <summary>
        /// The state part of the postal address.
        /// </summary>
        /// <value>The state part of the postal address.</value>
        [DataMember(Name="state", EmitDefaultValue=false)]
        public string State { get; set; }
        /// <summary>
        /// The name of the contact person for this account.
        /// </summary>
        /// <value>The name of the contact person for this account.</value>
        [DataMember(Name="contact", EmitDefaultValue=false)]
        public string Contact { get; set; }
        /// <summary>
        /// The postal code part of the postal address.
        /// </summary>
        /// <value>The postal code part of the postal address.</value>
        [DataMember(Name="postal_code", EmitDefaultValue=false)]
        public string PostalCode { get; set; }
        /// <summary>
        /// Flag (true/false) indicating whether Factory Tool is allowed to download or not. Manageable by the root admin only.
        /// </summary>
        /// <value>Flag (true/false) indicating whether Factory Tool is allowed to download or not. Manageable by the root admin only.</value>
        [DataMember(Name="is_provisioning_allowed", EmitDefaultValue=false)]
        public bool? IsProvisioningAllowed { get; set; }
        /// <summary>
        /// The ID of the parent account, if it has any.
        /// </summary>
        /// <value>The ID of the parent account, if it has any.</value>
        [DataMember(Name="parentID", EmitDefaultValue=false)]
        public string ParentID { get; set; }
        /// <summary>
        /// The tier level of the account; &#39;0&#39;: free tier, &#39;1&#39;: commercial account. Other values are reserved for the future. Manageable by the root admin only.
        /// </summary>
        /// <value>The tier level of the account; &#39;0&#39;: free tier, &#39;1&#39;: commercial account. Other values are reserved for the future. Manageable by the root admin only.</value>
        [DataMember(Name="tier", EmitDefaultValue=false)]
        public string Tier { get; set; }
        /// <summary>
        /// The phone number of the company.
        /// </summary>
        /// <value>The phone number of the company.</value>
        [DataMember(Name="phone_number", EmitDefaultValue=false)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// The company email address for this account.
        /// </summary>
        /// <value>The company email address for this account.</value>
        [DataMember(Name="email", EmitDefaultValue=false)]
        public string Email { get; set; }
        /// <summary>
        /// An array of aliases.
        /// </summary>
        /// <value>An array of aliases.</value>
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
            sb.Append("  TemplateId: ").Append(TemplateId).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  Contact: ").Append(Contact).Append("\n");
            sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
            sb.Append("  IsProvisioningAllowed: ").Append(IsProvisioningAllowed).Append("\n");
            sb.Append("  ParentID: ").Append(ParentID).Append("\n");
            sb.Append("  Tier: ").Append(Tier).Append("\n");
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
                    this.TemplateId == other.TemplateId ||
                    this.TemplateId != null &&
                    this.TemplateId.Equals(other.TemplateId)
                ) && 
                (
                    this.Status == other.Status ||
                    this.Status != null &&
                    this.Status.Equals(other.Status)
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
                    this.IsProvisioningAllowed == other.IsProvisioningAllowed ||
                    this.IsProvisioningAllowed != null &&
                    this.IsProvisioningAllowed.Equals(other.IsProvisioningAllowed)
                ) && 
                (
                    this.ParentID == other.ParentID ||
                    this.ParentID != null &&
                    this.ParentID.Equals(other.ParentID)
                ) && 
                (
                    this.Tier == other.Tier ||
                    this.Tier != null &&
                    this.Tier.Equals(other.Tier)
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
                if (this.TemplateId != null)
                    hash = hash * 59 + this.TemplateId.GetHashCode();
                if (this.Status != null)
                    hash = hash * 59 + this.Status.GetHashCode();
                if (this.State != null)
                    hash = hash * 59 + this.State.GetHashCode();
                if (this.Contact != null)
                    hash = hash * 59 + this.Contact.GetHashCode();
                if (this.PostalCode != null)
                    hash = hash * 59 + this.PostalCode.GetHashCode();
                if (this.IsProvisioningAllowed != null)
                    hash = hash * 59 + this.IsProvisioningAllowed.GetHashCode();
                if (this.ParentID != null)
                    hash = hash * 59 + this.ParentID.GetHashCode();
                if (this.Tier != null)
                    hash = hash * 59 + this.Tier.GetHashCode();
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
