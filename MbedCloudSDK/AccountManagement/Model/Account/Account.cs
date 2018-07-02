// <copyright file="Account.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.AccountManagement.Model.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using iam.Model;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Account
    /// </summary>
    public class Account : BaseModel
    {
        /// <summary>
        /// Gets the status of the account.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty]
        public AccountStatus? Status { get; private set; }

        /// <summary>
        /// Gets or sets the phone number of the company.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the postal code part of the postal address.
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// Gets an array of aliases.
        /// </summary>
        [JsonProperty]
        public List<string> Aliases { get; private set; }

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
        /// Gets or sets the company email address for this account.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Gets time when upgraded to commercial account in UTC format RFC3339.
        /// </summary>
        [JsonProperty]
        public DateTime? UpgradedAt { get; private set; }

        /// <summary>
        /// Gets the tier level of the account; '0': free tier, commercial account. Other values are reserved for the future.
        /// </summary>
        [JsonProperty]
        public string Tier { get; private set; }

        /// <summary>
        /// Gets list of limits as key-value pairs if requested.
        /// </summary>
        [JsonProperty]
        public Dictionary<string, string> Limits { get; private set; }

        /// <summary>
        /// Gets or sets the country part of the postal address.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets creation UTC time RFC3339.
        /// </summary>
        [JsonProperty]
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// Gets or sets the name of the contact person for this account.
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// Gets account template ID.
        /// </summary>
        [JsonProperty]
        public string TemplateId { get; private set; }

        /// <summary>
        /// Gets list of policies.
        /// </summary>
        /// <value>List of policies.</value>
        [JsonProperty]
        public List<Policy.Policy> Policies { get; private set; }

        /// <summary>
        /// Gets or sets a reason note for updating the status of the account
        /// </summary>
        [JsonProperty]
        public string Reason { get; set; }

        /// <summary>
        /// Gets the Contract number of the customer.
        /// </summary>
        [JsonProperty]
        public string ContractNumber { get; private set; }

        /// <summary>
        /// Gets the Customer number of the customer.
        /// </summary>
        [JsonProperty]
        public string CustomerNumber { get; private set; }

        /// <summary>
        /// Gets or sets the number of days before the account expiration notification email should be sent.
        /// </summary>
        public string ExpiryWarning { get; set; }

        /// <summary>
        /// Gets or sets the The enforcement status of the multi-factor authentication.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public MultifactorAuthenticationStatusEnum? MultifactorAuthenticationStatus { get; set; }

        /// <summary>
        /// Gets or sets the list of notification email addresses.
        /// </summary>
        public List<string> NotificationEmails { get; set; }

        /// <summary>
        /// Gets the reference note for updating the status of the account.
        /// </summary>
        [JsonProperty]
        public string ReferenceNote { get; private set; }

        /// <summary>
        /// Gets the last update UTC time RFC3339.
        /// </summary>
        [JsonProperty]
        public DateTime? UpdatedAt { get; private set; }

        /// <summary>
        /// Gets the sales contact email
        /// </summary>
        [JsonProperty]
        public string SalesContactEmail { get; private set; }

        /// <summary>
        /// Map to Account object.
        /// </summary>
        /// <param name="accountInfo">Identity and Account Manangement (IAM) information</param>
        /// <returns>Account</returns>
        public static Account Map(iam.Model.AccountInfo accountInfo)
        {
            var account = new Account
            {
                PhoneNumber = accountInfo.PhoneNumber,
                Postcode = accountInfo.PostalCode,
                Id = accountInfo.Id,
                Aliases = accountInfo.Aliases ?? Enumerable.Empty<string>().ToList(),
                AddressLine2 = accountInfo.AddressLine2,
                City = accountInfo.City,
                AddressLine1 = accountInfo.AddressLine1,
                DisplayName = accountInfo.DisplayName,
                State = accountInfo.State,
                Email = accountInfo.Email,
                Status = accountInfo.Status.ParseEnum<AccountStatus>(),
                Company = accountInfo.Company,
                UpgradedAt = accountInfo.UpgradedAt.ToNullableUniversalTime(),
                Tier = accountInfo.Tier,
                Limits = accountInfo.Limits ?? new Dictionary<string, string>(),
                Country = accountInfo.Country,
                CreatedAt = accountInfo.CreatedAt.ToNullableUniversalTime(),
                Contact = accountInfo.Contact,
                ContractNumber = accountInfo.ContractNumber,
                TemplateId = accountInfo.TemplateId,
                Policies = accountInfo?.Policies?.Select(p => { return Policy.Policy.Map(p); })?.ToList() ?? Enumerable.Empty<Policy.Policy>().ToList(),
                Reason = accountInfo.Reason,
                CustomerNumber = accountInfo.CustomerNumber,
                ExpiryWarning = accountInfo.ExpirationWarningThreshold,
                MultifactorAuthenticationStatus = accountInfo.MfaStatus.ParseEnum<MultifactorAuthenticationStatusEnum>(),
                NotificationEmails = accountInfo.NotificationEmails ?? Enumerable.Empty<string>().ToList(),
                ReferenceNote = accountInfo.ReferenceNote,
                UpdatedAt = accountInfo.UpdatedAt,
                SalesContactEmail = accountInfo.SalesContact,
            };
            return account;
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();

        /// <summary>
        /// Create an Update Request
        /// </summary>
        /// <returns>Account update request</returns>
        public iam.Model.AccountUpdateReq CreateUpdateRequest()
        {
            var request = new iam.Model.AccountUpdateReq
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
                Contact = Contact,
                NotificationEmails = NotificationEmails,
                ExpirationWarningThreshold = ExpiryWarning,
            };

            if (MultifactorAuthenticationStatus.HasValue)
            {
                request.MfaStatus = MultifactorAuthenticationStatus.ParseEnum<AccountUpdateReq.MfaStatusEnum>();
            }

            return request;
        }
    }
}
