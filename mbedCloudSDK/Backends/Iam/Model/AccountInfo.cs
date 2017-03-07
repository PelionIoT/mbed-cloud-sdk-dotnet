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
    /// This object represents an account in requests and responses.
    /// </summary>
    [DataContract]
    public partial class AccountInfo :  IEquatable<AccountInfo>, IValidatableObject
    {
        /// <summary>
        /// Entity name: always 'account'
        /// </summary>
        /// <value>Entity name: always 'account'</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ObjectEnum
        {
            
            /// <summary>
            /// Enum User for "user"
            /// </summary>
            [EnumMember(Value = "user")]
            User,
            
            /// <summary>
            /// Enum Apikey for "api-key"
            /// </summary>
            [EnumMember(Value = "api-key")]
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
            /// Enum Accounttemplate for "account-template"
            /// </summary>
            [EnumMember(Value = "account-template")]
            Accounttemplate,
            
            /// <summary>
            /// Enum Trustedcert for "trusted-cert"
            /// </summary>
            [EnumMember(Value = "trusted-cert")]
            Trustedcert,
            
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
        /// Entity name: always 'account'
        /// </summary>
        /// <value>Entity name: always 'account'</value>
        [DataMember(Name="object", EmitDefaultValue=false)]
        public ObjectEnum? _Object { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountInfo" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AccountInfo() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountInfo" /> class.
        /// </summary>
        /// <param name="Status">The status of the account. (required).</param>
        /// <param name="PostalCode">The postal code part of the postal address..</param>
        /// <param name="Id">Account ID. (required).</param>
        /// <param name="Aliases">An array of aliases. (required).</param>
        /// <param name="AddressLine2">Postal address line 2..</param>
        /// <param name="City">The city part of the postal address..</param>
        /// <param name="AddressLine1">Postal address line 1..</param>
        /// <param name="DisplayName">The display name for the account..</param>
        /// <param name="ParentId">The ID of the parent account, if it has any..</param>
        /// <param name="State">The state part of the postal address..</param>
        /// <param name="Etag">API resource entity version. (required).</param>
        /// <param name="IsProvisioningAllowed">Flag (true/false) indicating whether Factory Tool is allowed to download or not. (required) (default to false).</param>
        /// <param name="CreationTimeMillis">CreationTimeMillis.</param>
        /// <param name="Email">The company email address for this account..</param>
        /// <param name="PhoneNumber">The phone number of the company..</param>
        /// <param name="Company">The name of the company..</param>
        /// <param name="_Object">Entity name: always &#39;account&#39; (required).</param>
        /// <param name="UpgradedAt">Time when upgraded to commercial account in UTC format RFC3339..</param>
        /// <param name="Tier">The tier level of the account; &#39;0&#39;: free tier, &#39;1&#39;: commercial account. Other values are reserved for the future. (required).</param>
        /// <param name="SubAccounts">List of sub accounts..</param>
        /// <param name="Limits">List of limits as key-value pairs if requested..</param>
        /// <param name="Country">The country part of the postal address..</param>
        /// <param name="CreatedAt">Creation UTC time RFC3339..</param>
        /// <param name="Contact">The name of the contact person for this account..</param>
        /// <param name="Policies">List of policies if requested..</param>
        /// <param name="TemplateId">Account template ID..</param>
        public AccountInfo(string Status = default(string), string PostalCode = default(string), string Id = default(string), List<string> Aliases = default(List<string>), string AddressLine2 = default(string), string City = default(string), string AddressLine1 = default(string), string DisplayName = default(string), string ParentId = default(string), string State = default(string), string Etag = default(string), bool? IsProvisioningAllowed = false, long? CreationTimeMillis = default(long?), string Email = default(string), string PhoneNumber = default(string), string Company = default(string), ObjectEnum? _Object = default(ObjectEnum?), string UpgradedAt = default(string), string Tier = default(string), List<AccountInfo> SubAccounts = default(List<AccountInfo>), Dictionary<string, string> Limits = default(Dictionary<string, string>), string Country = default(string), string CreatedAt = default(string), string Contact = default(string), List<Policy> Policies = default(List<Policy>), string TemplateId = default(string))
        {
            // to ensure "Status" is required (not null)
            if (Status == null)
            {
                throw new InvalidDataException("Status is a required property for AccountInfo and cannot be null");
            }
            else
            {
                this.Status = Status;
            }
            // to ensure "Id" is required (not null)
            if (Id == null)
            {
                throw new InvalidDataException("Id is a required property for AccountInfo and cannot be null");
            }
            else
            {
                this.Id = Id;
            }
            // to ensure "Aliases" is required (not null)
            if (Aliases == null)
            {
                throw new InvalidDataException("Aliases is a required property for AccountInfo and cannot be null");
            }
            else
            {
                this.Aliases = Aliases;
            }
            // to ensure "Etag" is required (not null)
            if (Etag == null)
            {
                throw new InvalidDataException("Etag is a required property for AccountInfo and cannot be null");
            }
            else
            {
                this.Etag = Etag;
            }
            // to ensure "IsProvisioningAllowed" is required (not null)
            if (IsProvisioningAllowed == null)
            {
                throw new InvalidDataException("IsProvisioningAllowed is a required property for AccountInfo and cannot be null");
            }
            else
            {
                this.IsProvisioningAllowed = IsProvisioningAllowed;
            }
            // to ensure "_Object" is required (not null)
            if (_Object == null)
            {
                throw new InvalidDataException("_Object is a required property for AccountInfo and cannot be null");
            }
            else
            {
                this._Object = _Object;
            }
            // to ensure "Tier" is required (not null)
            if (Tier == null)
            {
                throw new InvalidDataException("Tier is a required property for AccountInfo and cannot be null");
            }
            else
            {
                this.Tier = Tier;
            }
            this.PostalCode = PostalCode;
            this.AddressLine2 = AddressLine2;
            this.City = City;
            this.AddressLine1 = AddressLine1;
            this.DisplayName = DisplayName;
            this.ParentId = ParentId;
            this.State = State;
            this.CreationTimeMillis = CreationTimeMillis;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.Company = Company;
            this.UpgradedAt = UpgradedAt;
            this.SubAccounts = SubAccounts;
            this.Limits = Limits;
            this.Country = Country;
            this.CreatedAt = CreatedAt;
            this.Contact = Contact;
            this.Policies = Policies;
            this.TemplateId = TemplateId;
        }
        
        /// <summary>
        /// The status of the account.
        /// </summary>
        /// <value>The status of the account.</value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public string Status { get; set; }
        /// <summary>
        /// The postal code part of the postal address.
        /// </summary>
        /// <value>The postal code part of the postal address.</value>
        [DataMember(Name="postal_code", EmitDefaultValue=false)]
        public string PostalCode { get; set; }
        /// <summary>
        /// Account ID.
        /// </summary>
        /// <value>Account ID.</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }
        /// <summary>
        /// An array of aliases.
        /// </summary>
        /// <value>An array of aliases.</value>
        [DataMember(Name="aliases", EmitDefaultValue=false)]
        public List<string> Aliases { get; set; }
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
        /// The ID of the parent account, if it has any.
        /// </summary>
        /// <value>The ID of the parent account, if it has any.</value>
        [DataMember(Name="parent_id", EmitDefaultValue=false)]
        public string ParentId { get; set; }
        /// <summary>
        /// The state part of the postal address.
        /// </summary>
        /// <value>The state part of the postal address.</value>
        [DataMember(Name="state", EmitDefaultValue=false)]
        public string State { get; set; }
        /// <summary>
        /// API resource entity version.
        /// </summary>
        /// <value>API resource entity version.</value>
        [DataMember(Name="etag", EmitDefaultValue=false)]
        public string Etag { get; set; }
        /// <summary>
        /// Flag (true/false) indicating whether Factory Tool is allowed to download or not.
        /// </summary>
        /// <value>Flag (true/false) indicating whether Factory Tool is allowed to download or not.</value>
        [DataMember(Name="is_provisioning_allowed", EmitDefaultValue=false)]
        public bool? IsProvisioningAllowed { get; set; }
        /// <summary>
        /// Gets or Sets CreationTimeMillis
        /// </summary>
        [DataMember(Name="creationTimeMillis", EmitDefaultValue=false)]
        public long? CreationTimeMillis { get; set; }
        /// <summary>
        /// The company email address for this account.
        /// </summary>
        /// <value>The company email address for this account.</value>
        [DataMember(Name="email", EmitDefaultValue=false)]
        public string Email { get; set; }
        /// <summary>
        /// The phone number of the company.
        /// </summary>
        /// <value>The phone number of the company.</value>
        [DataMember(Name="phone_number", EmitDefaultValue=false)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// The name of the company.
        /// </summary>
        /// <value>The name of the company.</value>
        [DataMember(Name="company", EmitDefaultValue=false)]
        public string Company { get; set; }
        /// <summary>
        /// Time when upgraded to commercial account in UTC format RFC3339.
        /// </summary>
        /// <value>Time when upgraded to commercial account in UTC format RFC3339.</value>
        [DataMember(Name="upgraded_at", EmitDefaultValue=false)]
        public string UpgradedAt { get; set; }
        /// <summary>
        /// The tier level of the account; &#39;0&#39;: free tier, &#39;1&#39;: commercial account. Other values are reserved for the future.
        /// </summary>
        /// <value>The tier level of the account; &#39;0&#39;: free tier, &#39;1&#39;: commercial account. Other values are reserved for the future.</value>
        [DataMember(Name="tier", EmitDefaultValue=false)]
        public string Tier { get; set; }
        /// <summary>
        /// List of sub accounts.
        /// </summary>
        /// <value>List of sub accounts.</value>
        [DataMember(Name="sub_accounts", EmitDefaultValue=false)]
        public List<AccountInfo> SubAccounts { get; set; }
        /// <summary>
        /// List of limits as key-value pairs if requested.
        /// </summary>
        /// <value>List of limits as key-value pairs if requested.</value>
        [DataMember(Name="limits", EmitDefaultValue=false)]
        public Dictionary<string, string> Limits { get; set; }
        /// <summary>
        /// The country part of the postal address.
        /// </summary>
        /// <value>The country part of the postal address.</value>
        [DataMember(Name="country", EmitDefaultValue=false)]
        public string Country { get; set; }
        /// <summary>
        /// Creation UTC time RFC3339.
        /// </summary>
        /// <value>Creation UTC time RFC3339.</value>
        [DataMember(Name="created_at", EmitDefaultValue=false)]
        public string CreatedAt { get; set; }
        /// <summary>
        /// The name of the contact person for this account.
        /// </summary>
        /// <value>The name of the contact person for this account.</value>
        [DataMember(Name="contact", EmitDefaultValue=false)]
        public string Contact { get; set; }
        /// <summary>
        /// List of policies if requested.
        /// </summary>
        /// <value>List of policies if requested.</value>
        [DataMember(Name="policies", EmitDefaultValue=false)]
        public List<Policy> Policies { get; set; }
        /// <summary>
        /// Account template ID.
        /// </summary>
        /// <value>Account template ID.</value>
        [DataMember(Name="template_id", EmitDefaultValue=false)]
        public string TemplateId { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AccountInfo {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Aliases: ").Append(Aliases).Append("\n");
            sb.Append("  AddressLine2: ").Append(AddressLine2).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  AddressLine1: ").Append(AddressLine1).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  ParentId: ").Append(ParentId).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  Etag: ").Append(Etag).Append("\n");
            sb.Append("  IsProvisioningAllowed: ").Append(IsProvisioningAllowed).Append("\n");
            sb.Append("  CreationTimeMillis: ").Append(CreationTimeMillis).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
            sb.Append("  Company: ").Append(Company).Append("\n");
            sb.Append("  _Object: ").Append(_Object).Append("\n");
            sb.Append("  UpgradedAt: ").Append(UpgradedAt).Append("\n");
            sb.Append("  Tier: ").Append(Tier).Append("\n");
            sb.Append("  SubAccounts: ").Append(SubAccounts).Append("\n");
            sb.Append("  Limits: ").Append(Limits).Append("\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  Contact: ").Append(Contact).Append("\n");
            sb.Append("  Policies: ").Append(Policies).Append("\n");
            sb.Append("  TemplateId: ").Append(TemplateId).Append("\n");
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
            return this.Equals(obj as AccountInfo);
        }

        /// <summary>
        /// Returns true if AccountInfo instances are equal
        /// </summary>
        /// <param name="other">Instance of AccountInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccountInfo other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Status == other.Status ||
                    this.Status != null &&
                    this.Status.Equals(other.Status)
                ) && 
                (
                    this.PostalCode == other.PostalCode ||
                    this.PostalCode != null &&
                    this.PostalCode.Equals(other.PostalCode)
                ) && 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.Aliases == other.Aliases ||
                    this.Aliases != null &&
                    this.Aliases.SequenceEqual(other.Aliases)
                ) && 
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
                    this.ParentId == other.ParentId ||
                    this.ParentId != null &&
                    this.ParentId.Equals(other.ParentId)
                ) && 
                (
                    this.State == other.State ||
                    this.State != null &&
                    this.State.Equals(other.State)
                ) && 
                (
                    this.Etag == other.Etag ||
                    this.Etag != null &&
                    this.Etag.Equals(other.Etag)
                ) && 
                (
                    this.IsProvisioningAllowed == other.IsProvisioningAllowed ||
                    this.IsProvisioningAllowed != null &&
                    this.IsProvisioningAllowed.Equals(other.IsProvisioningAllowed)
                ) && 
                (
                    this.CreationTimeMillis == other.CreationTimeMillis ||
                    this.CreationTimeMillis != null &&
                    this.CreationTimeMillis.Equals(other.CreationTimeMillis)
                ) && 
                (
                    this.Email == other.Email ||
                    this.Email != null &&
                    this.Email.Equals(other.Email)
                ) && 
                (
                    this.PhoneNumber == other.PhoneNumber ||
                    this.PhoneNumber != null &&
                    this.PhoneNumber.Equals(other.PhoneNumber)
                ) && 
                (
                    this.Company == other.Company ||
                    this.Company != null &&
                    this.Company.Equals(other.Company)
                ) && 
                (
                    this._Object == other._Object ||
                    this._Object != null &&
                    this._Object.Equals(other._Object)
                ) && 
                (
                    this.UpgradedAt == other.UpgradedAt ||
                    this.UpgradedAt != null &&
                    this.UpgradedAt.Equals(other.UpgradedAt)
                ) && 
                (
                    this.Tier == other.Tier ||
                    this.Tier != null &&
                    this.Tier.Equals(other.Tier)
                ) && 
                (
                    this.SubAccounts == other.SubAccounts ||
                    this.SubAccounts != null &&
                    this.SubAccounts.SequenceEqual(other.SubAccounts)
                ) && 
                (
                    this.Limits == other.Limits ||
                    this.Limits != null &&
                    this.Limits.SequenceEqual(other.Limits)
                ) && 
                (
                    this.Country == other.Country ||
                    this.Country != null &&
                    this.Country.Equals(other.Country)
                ) && 
                (
                    this.CreatedAt == other.CreatedAt ||
                    this.CreatedAt != null &&
                    this.CreatedAt.Equals(other.CreatedAt)
                ) && 
                (
                    this.Contact == other.Contact ||
                    this.Contact != null &&
                    this.Contact.Equals(other.Contact)
                ) && 
                (
                    this.Policies == other.Policies ||
                    this.Policies != null &&
                    this.Policies.SequenceEqual(other.Policies)
                ) && 
                (
                    this.TemplateId == other.TemplateId ||
                    this.TemplateId != null &&
                    this.TemplateId.Equals(other.TemplateId)
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
                if (this.Status != null)
                    hash = hash * 59 + this.Status.GetHashCode();
                if (this.PostalCode != null)
                    hash = hash * 59 + this.PostalCode.GetHashCode();
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.Aliases != null)
                    hash = hash * 59 + this.Aliases.GetHashCode();
                if (this.AddressLine2 != null)
                    hash = hash * 59 + this.AddressLine2.GetHashCode();
                if (this.City != null)
                    hash = hash * 59 + this.City.GetHashCode();
                if (this.AddressLine1 != null)
                    hash = hash * 59 + this.AddressLine1.GetHashCode();
                if (this.DisplayName != null)
                    hash = hash * 59 + this.DisplayName.GetHashCode();
                if (this.ParentId != null)
                    hash = hash * 59 + this.ParentId.GetHashCode();
                if (this.State != null)
                    hash = hash * 59 + this.State.GetHashCode();
                if (this.Etag != null)
                    hash = hash * 59 + this.Etag.GetHashCode();
                if (this.IsProvisioningAllowed != null)
                    hash = hash * 59 + this.IsProvisioningAllowed.GetHashCode();
                if (this.CreationTimeMillis != null)
                    hash = hash * 59 + this.CreationTimeMillis.GetHashCode();
                if (this.Email != null)
                    hash = hash * 59 + this.Email.GetHashCode();
                if (this.PhoneNumber != null)
                    hash = hash * 59 + this.PhoneNumber.GetHashCode();
                if (this.Company != null)
                    hash = hash * 59 + this.Company.GetHashCode();
                if (this._Object != null)
                    hash = hash * 59 + this._Object.GetHashCode();
                if (this.UpgradedAt != null)
                    hash = hash * 59 + this.UpgradedAt.GetHashCode();
                if (this.Tier != null)
                    hash = hash * 59 + this.Tier.GetHashCode();
                if (this.SubAccounts != null)
                    hash = hash * 59 + this.SubAccounts.GetHashCode();
                if (this.Limits != null)
                    hash = hash * 59 + this.Limits.GetHashCode();
                if (this.Country != null)
                    hash = hash * 59 + this.Country.GetHashCode();
                if (this.CreatedAt != null)
                    hash = hash * 59 + this.CreatedAt.GetHashCode();
                if (this.Contact != null)
                    hash = hash * 59 + this.Contact.GetHashCode();
                if (this.Policies != null)
                    hash = hash * 59 + this.Policies.GetHashCode();
                if (this.TemplateId != null)
                    hash = hash * 59 + this.TemplateId.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
