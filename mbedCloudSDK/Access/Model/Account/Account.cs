using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace mbedCloudSDK.Access.Model.Account
{
    /// <summary>
    /// 
    /// </summary>
    public class Account
    {

        /// <summary>
        /// The status of the account.
        /// </summary>
        /// <value>The status of the account.</value>
        public AccountStatus? Status { get; set; }

        /// <summary>
        /// The phone number of the company.
        /// </summary>
        /// <value>The phone number of the company.</value>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// The postal code part of the postal address.
        /// </summary>
        /// <value>The postal code part of the postal address.</value>
        public string PostalCode { get; set; }
       
        /// <summary>
        /// Account ID.
        /// </summary>
        /// <value>Account ID.</value>
        public string Id { get; set; }
       
        /// <summary>
        /// An array of aliases.
        /// </summary>
        /// <value>An array of aliases.</value>
        public List<string> Aliases { get; set; }
        
        /// <summary>
        /// Postal address line 2.
        /// </summary>
        /// <value>Postal address line 2.</value>
        public string AddressLine2 { get; set; }
        
        /// <summary>
        /// The city part of the postal address.
        /// </summary>
        /// <value>The city part of the postal address.</value>
        public string City { get; set; }
        
        /// <summary>
        /// Postal address line 1.
        /// </summary>
        /// <value>Postal address line 1.</value>
        public string AddressLine1 { get; set; }
        
        /// <summary>
        /// The display name for the account.
        /// </summary>
        /// <value>The display name for the account.</value>
        public string DisplayName { get; set; }
        
        /// <summary>
        /// The state part of the postal address.
        /// </summary>
        /// <value>The state part of the postal address.</value>
        public string State { get; set; }
        
        /// <summary>
        /// API resource entity version.
        /// </summary>
        /// <value>API resource entity version.</value>
        public string Etag { get; set; }
        
        /// <summary>
        /// Flag (true/false) indicating whether Factory Tool is allowed to download or not.
        /// </summary>
        /// <value>Flag (true/false) indicating whether Factory Tool is allowed to download or not.</value>
        public bool? IsProvisioningAllowed { get; set; }
        
        /// <summary>
        /// Gets or Sets CreationTimeMillis
        /// </summary>
        public long? CreationTimeMillis { get; set; }
        
        /// <summary>
        /// The company email address for this account.
        /// </summary>
        /// <value>The company email address for this account.</value>
        public string Email { get; set; }
        
        /// <summary>
        /// The name of the company.
        /// </summary>
        /// <value>The name of the company.</value>
        public string Company { get; set; }
        
        /// <summary>
        /// Time when upgraded to commercial account in UTC format RFC3339.
        /// </summary>
        /// <value>Time when upgraded to commercial account in UTC format RFC3339.</value>
        public string UpgradedAt { get; set; }
        
        /// <summary>
        /// The tier level of the account; &#39;0&#39;: free tier, &#39;1&#39;: commercial account. Other values are reserved for the future.
        /// </summary>
        /// <value>The tier level of the account; &#39;0&#39;: free tier, &#39;1&#39;: commercial account. Other values are reserved for the future.</value>
        public string Tier { get; set; }
        
        /// <summary>
        /// List of limits as key-value pairs if requested.
        /// </summary>
        /// <value>List of limits as key-value pairs if requested.</value>
        public Dictionary<string, string> Limits { get; set; }
        
        /// <summary>
        /// The country part of the postal address.
        /// </summary>
        /// <value>The country part of the postal address.</value>
        public string Country { get; set; }
        
        /// <summary>
        /// Creation UTC time RFC3339.
        /// </summary>
        /// <value>Creation UTC time RFC3339.</value>
        public string CreatedAt { get; set; }
        
        /// <summary>
        /// The name of the contact person for this account.
        /// </summary>
        /// <value>The name of the contact person for this account.</value>
        public string Contact { get; set; }
        
        /// <summary>
        /// Account template ID.
        /// </summary>
        /// <value>Account template ID.</value>
        public string TemplateId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Account" /> class.
        /// </summary>
        /// <param name="PhoneNumber">The phone number of the company..</param>
        /// <param name="PostalCode">The postal code part of the postal address..</param>
        /// <param name="Id">Account ID. (required).</param>
        /// <param name="Aliases">An array of aliases. (required).</param>
        /// <param name="AddressLine2">Postal address line 2..</param>
        /// <param name="City">The city part of the postal address..</param>
        /// <param name="AddressLine1">Postal address line 1..</param>
        /// <param name="DisplayName">The display name for the account..</param>
        /// <param name="State">The state part of the postal address..</param>
        /// <param name="Etag">API resource entity version. (required).</param>
        /// <param name="IsProvisioningAllowed">Flag (true/false) indicating whether Factory Tool is allowed to download or not. (required) (default to false).</param>
        /// <param name="CreationTimeMillis">CreationTimeMillis.</param>
        /// <param name="Email">The company email address for this account..</param>
        /// <param name="Status">The status of the account. (required).</param>
        /// <param name="Company">The name of the company..</param>
        /// <param name="UpgradedAt">Time when upgraded to commercial account in UTC format RFC3339..</param>
        /// <param name="Tier">The tier level of the account; &#39;0&#39;: free tier, &#39;1&#39;: commercial account. Other values are reserved for the future. (required).</param>
        /// <param name="Limits">List of limits as key-value pairs if requested..</param>
        /// <param name="Country">The country part of the postal address..</param>
        /// <param name="CreatedAt">Creation UTC time RFC3339..</param>
        /// <param name="Contact">The name of the contact person for this account..</param>
        /// <param name="TemplateId">Account template ID..</param>
        public Account(string PhoneNumber = null, string PostalCode = null, string Id = null, List<string> Aliases = null, string AddressLine2 = null, string City = null, string AddressLine1 = null, string DisplayName = null, string State = null, string Etag = null, bool? IsProvisioningAllowed = null, long? CreationTimeMillis = null, string Email = null, AccountStatus? Status = null, string Company = null, string UpgradedAt = null, string Tier = null, Dictionary<string, string> Limits = null, string Country = null, string CreatedAt = null, string Contact = null, string TemplateId = null)
        {
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
            // to ensure "Status" is required (not null)
            if (Status == null)
            {
                throw new InvalidDataException("Status is a required property for AccountInfo and cannot be null");
            }
            else
            {
                this.Status = Status;
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
            this.PhoneNumber = PhoneNumber;
            this.PostalCode = PostalCode;
            this.AddressLine2 = AddressLine2;
            this.City = City;
            this.AddressLine1 = AddressLine1;
            this.DisplayName = DisplayName;
            this.State = State;
            this.CreationTimeMillis = CreationTimeMillis;
            this.Email = Email;
            this.Company = Company;
            this.UpgradedAt = UpgradedAt;
            this.Limits = Limits;
            this.Country = Country;
            this.CreatedAt = CreatedAt;
            this.Contact = Contact;
            this.TemplateId = TemplateId;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AccountInfo {\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
            sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Aliases: ").Append(Aliases).Append("\n");
            sb.Append("  AddressLine2: ").Append(AddressLine2).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  AddressLine1: ").Append(AddressLine1).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  Etag: ").Append(Etag).Append("\n");
            sb.Append("  IsProvisioningAllowed: ").Append(IsProvisioningAllowed).Append("\n");
            sb.Append("  CreationTimeMillis: ").Append(CreationTimeMillis).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Company: ").Append(Company).Append("\n");
            sb.Append("  UpgradedAt: ").Append(UpgradedAt).Append("\n");
            sb.Append("  Tier: ").Append(Tier).Append("\n");
            sb.Append("  Limits: ").Append(Limits).Append("\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  Contact: ").Append(Contact).Append("\n");
            sb.Append("  TemplateId: ").Append(TemplateId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        public static Account Convert(iam.Model.AccountInfo accountInfo)
        {
            var accountStatus = (AccountStatus)Enum.Parse(typeof(AccountStatus), accountInfo.Status.ToString());
            return new Account(accountInfo.PhoneNumber, accountInfo.PostalCode, accountInfo.Id, accountInfo.Aliases,
                accountInfo.AddressLine2, accountInfo.City, accountInfo.AddressLine1, accountInfo.DisplayName, accountInfo.State,
                accountInfo.Etag, accountInfo.IsProvisioningAllowed, accountInfo.CreationTimeMillis, accountInfo.Email,
                accountStatus, accountInfo.Company, accountInfo.UpgradedAt, accountInfo.Tier, accountInfo.Limits, 
                accountInfo.Country, accountInfo.CreatedAt, accountInfo.Contact, accountInfo.TemplateId);
        }
    }
}
