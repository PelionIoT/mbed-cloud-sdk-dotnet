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
        public AccountStatus? Status { get; set; }

        /// <summary>
        /// The phone number of the company.
        /// </summary>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// The postal code part of the postal address.
        /// </summary>
        public string PostalCode { get; set; }
       
        /// <summary>
        /// Account ID.
        /// </summary>
        public string Id { get; set; }
       
        /// <summary>
        /// An array of aliases.
        /// </summary>
        public List<string> Aliases { get; set; }
        
        /// <summary>
        /// Postal address line 2.
        /// </summary>
        public string AddressLine2 { get; set; }
        
        /// <summary>
        /// The city part of the postal address.
        /// </summary>
        public string City { get; set; }
        
        /// <summary>
        /// Postal address line 1.
        /// </summary>
        public string AddressLine1 { get; set; }
        
        /// <summary>
        /// The display name for the account.
        /// </summary>
        public string DisplayName { get; set; }
        
        /// <summary>
        /// The state part of the postal address.
        /// </summary>
        public string State { get; set; }
        
        /// <summary>
        /// API resource entity version.
        /// </summary>
        public string Etag { get; set; }
        
        /// <summary>
        /// Flag (true/false) indicating whether Factory Tool is allowed to download or not.
        /// </summary>
        public bool? IsProvisioningAllowed { get; set; }
        
        /// <summary>
        /// Gets or Sets CreationTimeMillis
        /// </summary>
        public long? CreationTimeMillis { get; set; }
        
        /// <summary>
        /// The company email address for this account.
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// The name of the company.
        /// </summary>
        public string Company { get; set; }
        
        /// <summary>
        /// Time when upgraded to commercial account in UTC format RFC3339.
        /// </summary>
        public string UpgradedAt { get; set; }
        
        /// <summary>
        /// The tier level of the account; &#39;0&#39;: free tier, commercial account. Other values are reserved for the future.
        /// </summary>
        public string Tier { get; set; }
        
        /// <summary>
        /// List of limits as key-value pairs if requested.
        /// </summary>
        public Dictionary<string, string> Limits { get; set; }
        
        /// <summary>
        /// The country part of the postal address.
        /// </summary>
        public string Country { get; set; }
        
        /// <summary>
        /// Creation UTC time RFC3339.
        /// </summary>
        public string CreatedAt { get; set; }
        
        /// <summary>
        /// The name of the contact person for this account.
        /// </summary>
        public string Contact { get; set; }
        
        /// <summary>
        /// Account template ID.
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Account" /> class.
        /// </summary>
        public Account(IDictionary<string, object> options = null)
        {
            if (options != null)
            {
                foreach (KeyValuePair<string, object> item in options)
                {
                    var property = this.GetType().GetProperty(item.Key);
                    if (property != null)
                    {
                        property.SetValue(this, item.Value, null);
                    }
                }
            }
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Account {\n");
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

        /// <summary>
        /// Map to Account object.
        /// </summary>
        /// <param name="accountInfo"></param>
        /// <returns></returns>
        public static Account Map(iam.Model.AccountInfo accountInfo)
        {
            var accountStatus = (AccountStatus)Enum.Parse(typeof(AccountStatus), accountInfo.Status.ToString());
            var account = new Account();
            account.PhoneNumber = accountInfo.PhoneNumber;
            account.PostalCode = accountInfo.PostalCode;
            account.Id = accountInfo.Id;
            account.Aliases = accountInfo.Aliases;
            account.AddressLine2 = accountInfo.AddressLine2;
            account.City = accountInfo.City;
            account.AddressLine1 = accountInfo.AddressLine1;
            account.DisplayName = accountInfo.DisplayName;
            account.State = accountInfo.State;
            account.Etag = accountInfo.Etag;
            account.IsProvisioningAllowed = accountInfo.IsProvisioningAllowed;
            account.CreationTimeMillis = accountInfo.CreationTimeMillis;
            account.Email = accountInfo.Email;
            account.Status = accountStatus;
            account.Company = accountInfo.Company;
            account.UpgradedAt = accountInfo.UpgradedAt;
            account.Tier = accountInfo.Tier;
            account.Limits = accountInfo.Limits;
            account.Country = accountInfo.Country;
            account.CreatedAt = accountInfo.CreatedAt;
            account.Contact = account.Contact;
            account.TemplateId = accountInfo.TemplateId;
            return account;
        }
    }
}
