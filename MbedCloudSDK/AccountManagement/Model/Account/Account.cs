// <copyright file="Account.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.AccountManagement.Model.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MbedCloudSDK.Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Account" /> class.
        /// </summary>
        /// <param name="options">options for query</param>
        public Account(IDictionary<string, object> options = null)
        {
            if (options != null)
            {
                foreach (KeyValuePair<string, object> item in options)
                {
                    var property = GetType().GetProperty(item.Key);
                    if (property != null)
                    {
                        property.SetValue(this, item.Value, null);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the status of the account.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountStatus? Status { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the company.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the postal code part of the postal address.
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// Gets or sets account ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets an array of aliases.
        /// </summary>
        public List<string> Aliases { get; set; }

        /// <summary>
        /// Gets or sets postal address line 2.
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the city part of the postal address.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets postal address line 1.
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the display name for the account.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the state part of the postal address.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets flag (true/false) indicating whether Factory Tool is allowed to download or not.
        /// </summary>
        public bool? ProvisisioningAllowed { get; set; }

        /// <summary>
        /// Gets or sets the company email address for this account.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets time when upgraded to commercial account in UTC format RFC3339.
        /// </summary>
        public DateTime? UpgradedAt { get; set; }

        /// <summary>
        /// Gets or sets the tier level of the account; &#39;0&#39;: free tier, commercial account. Other values are reserved for the future.
        /// </summary>
        public string Tier { get; set; }

        /// <summary>
        /// Gets or sets list of limits as key-value pairs if requested.
        /// </summary>
        public Dictionary<string, string> Limits { get; set; }

        /// <summary>
        /// Gets or sets the country part of the postal address.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets creation UTC time RFC3339.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the name of the contact person for this account.
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// Gets or sets account template ID.
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        /// Gets or sets list of policies.
        /// </summary>
        /// <value>List of policies.</value>
        public List<Policy.Policy> Policies { get; set; }

        /// <summary>
        /// Gets or sets a reason note for updating the status of the account
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Map to Account object.
        /// </summary>
        /// <param name="accountInfo">Iam account</param>
        /// <returns>Account</returns>
        public static Account Map(iam.Model.AccountInfo accountInfo)
        {
            var accountStatus = Utils.ParseEnum<AccountStatus>(accountInfo.Status);
            var account = new Account
            {
                PhoneNumber = accountInfo.PhoneNumber,
                Postcode = accountInfo.PostalCode,
                Id = accountInfo.Id,
                Aliases = accountInfo.Aliases,
                AddressLine2 = accountInfo.AddressLine2,
                City = accountInfo.City,
                AddressLine1 = accountInfo.AddressLine1,
                DisplayName = accountInfo.DisplayName,
                State = accountInfo.State,
                ProvisisioningAllowed = accountInfo.IsProvisioningAllowed,
                Email = accountInfo.Email,
                Status = accountStatus,
                Company = accountInfo.Company,
                UpgradedAt = accountInfo.UpgradedAt,
                Tier = accountInfo.Tier,
                Limits = accountInfo.Limits,
                Country = accountInfo.Country,
                CreatedAt = accountInfo.CreatedAt
            };
            account.Contact = account.Contact;
            account.TemplateId = accountInfo.TemplateId;
            account.Policies = accountInfo?.Policies?.Select(p => { return Policy.Policy.Map(p); }).ToList();
            account.Reason = accountInfo.Reason;
            return account;
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
            sb.Append("  Postcode: ").Append(Postcode).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Aliases: ").Append(Aliases).Append("\n");
            sb.Append("  AddressLine2: ").Append(AddressLine2).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  AddressLine1: ").Append(AddressLine1).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  ProvisisioningAllowed: ").Append(ProvisisioningAllowed).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Company: ").Append(Company).Append("\n");
            sb.Append("  UpgradedAt: ").Append(UpgradedAt).Append("\n");
            sb.Append("  Tier: ").Append(Tier).Append("\n");
            sb.Append("  Limits: ").Append(string.Join(", ", Limits)).Append("\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  Contact: ").Append(Contact).Append("\n");
            sb.Append("  TemplateId: ").Append(TemplateId).Append("\n");
            sb.Append("  Policies: ").Append(string.Join(", ", Policies.Select(p => { return p.ToString(); }))).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Create an Update Request
        /// </summary>
        /// <returns>Account update request</returns>
        public iam.Model.AccountUpdateReq CreateUpdateRequest()
        {
            iam.Model.AccountUpdateReq request = new iam.Model.AccountUpdateReq
            {
                PhoneNumber = PhoneNumber,
                PostalCode = Postcode,
                Aliases = Aliases,
                AddressLine2 = AddressLine2,
                City = City,
                AddressLine1 = AddressLine1,
                DisplayName = DisplayName,
                State = State,
                Email = Email,
                Company = Company,
                Country = Country,
                Contact = Contact
            };
            return request;
        }
    }
}
