// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 1.0.0
//
// <copyright file="AccountManagementApi.Account.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace MbedCloudSDK.Accounts.SubtenantAccount
{
    using MbedCloudSDK.Common;
    using System.Collections.Generic;
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using MbedCloudSDK.Accounts.SubtenantAccount;
    using MbedCloudSDK.Common.Query;
    using MbedCloudSDK.Accounts.ApiKey;
    using System.Threading.Tasks;
    using MbedCloudSDK.Client;
    using MbedCloudSDK.Exceptions;
    using RestSharp;
    using MbedCloudSDK.Accounts.Account;
    using MbedCloudSDK.Accounts.User;
    using MbedCloudSDK.Common.Extensions;

    /// <summary>
    /// SubtenantAccount
    /// </summary>
    public partial class SubtenantAccount : BaseModel
    {
        /// <summary>
        /// Postal address line 1.
        /// </summary>
        public string AddressLine1
        {
            get;
            set;
        }

        /// <summary>
        /// Postal address line 2.
        /// </summary>
        public string AddressLine2
        {
            get;
            set;
        }

        /// <summary>
        /// The email address of the account admin, not longer than 254 characters.
        /// </summary>
        public string AdminEmail
        {
            get;
            set;
        }

        /// <summary>
        /// The full name of the admin user to be created.
        /// </summary>
        public string AdminFullName
        {
            get;
            set;
        }

        /// <summary>
        /// The ID of the admin user created.
        /// </summary>
        public string AdminId
        {
            get;
            set;
        }

        /// <summary>
        /// The admin API key created for the account.
        /// </summary>
        public string AdminKey
        {
            get;
            set;
        }

        /// <summary>
        /// The username of the admin user to be created, containing alphanumerical letters and -,._@+= characters. It must be at least 4 but not more than 30 character long.
        /// </summary>
        public string AdminName
        {
            get;
            set;
        }

        /// <summary>
        /// The password when creating a new user. It will be generated when not present in the request.
        /// </summary>
        public string AdminPassword
        {
            get;
            set;
        }

        /// <summary>
        /// An array of aliases.
        /// </summary>
        public List<string> Aliases
        {
            get;
            set;
        }

        /// <summary>
        /// The city part of the postal address.
        /// </summary>
        public string City
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the company.
        /// </summary>
        public string Company
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the contact person for this account.
        /// </summary>
        public string Contact
        {
            get;
            set;
        }

        /// <summary>
        /// Contract number of the customer.
        /// </summary>
        public string ContractNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The country part of the postal address.
        /// </summary>
        public string Country
        {
            get;
            set;
        }

        /// <summary>
        /// Creation UTC time RFC3339.
        /// </summary>
        public DateTime? CreatedAt
        {
            get;
            set;
        }

        /// <summary>
        /// Account's custom properties as key-value pairs.
        /// </summary>
        public Dictionary<string, object> CustomFields
        {
            get;
            set;
        }

        /// <summary>
        /// Customer number of the customer.
        /// </summary>
        public string CustomerNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The display name for the account.
        /// </summary>
        public string DisplayName
        {
            get;
            set;
        }

        /// <summary>
        /// The company email address for this account.
        /// </summary>
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Account end market.
        /// </summary>
        public string EndMarket
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates how many days (1-180) before account expiration a notification email should be sent.
        /// </summary>
        public string ExpirationWarningThreshold
        {
            get;
            set;
        }

        /// <summary>
        /// The reference token expiration time in minutes for this account.
        /// </summary>
        public string IdleTimeout
        {
            get;
            set;
        }

        /// <summary>
        /// List of limits as key-value pairs if requested.
        /// </summary>
        public Dictionary<string, object> Limits
        {
            get;
            set;
        }

        /// <summary>
        /// The enforcement status of the multi-factor authentication, either 'enforced' or 'optional'.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SubtenantAccountMfaStatusEnum MfaStatus
        {
            get;
            set;
        }

        /// <summary>
        /// A list of notification email addresses.
        /// </summary>
        public List<string> NotificationEmails
        {
            get;
            set;
        }

        /// <summary>
        /// The ID of the parent account, if it has any.
        /// </summary>
        public string ParentId
        {
            get;
            set;
        }
        public Dictionary<string, object> PasswordPolicy
        {
            get;
            set;
        }

        /// <summary>
        /// The phone number of a representative of the company.
        /// </summary>
        public string PhoneNumber
        {
            get;
            set;
        }

        /// <summary>
        /// List of policies if requested.
        /// </summary>
        public List<Dictionary<string, object>> Policies
        {
            get;
            set;
        }

        /// <summary>
        /// The postal code part of the postal address.
        /// </summary>
        public string PostalCode
        {
            get;
            set;
        }

        /// <summary>
        /// A reason note for updating the status of the account
        /// </summary>
        public string Reason
        {
            get;
            set;
        }

        /// <summary>
        /// A reference note for updating the status of the account
        /// </summary>
        public string ReferenceNote
        {
            get;
            set;
        }

        /// <summary>
        /// Email address of the sales contact.
        /// </summary>
        public string SalesContact
        {
            get;
            set;
        }

        /// <summary>
        /// The state part of the postal address.
        /// </summary>
        public string State
        {
            get;
            set;
        }

        /// <summary>
        /// The status of the account.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SubtenantAccountStatusEnum Status
        {
            get;
            set;
        }

        /// <summary>
        /// List of sub accounts. Not available for developer users.
        /// </summary>
        public List<SubtenantAccount> SubAccounts
        {
            get;
            set;
        }

        /// <summary>
        /// Account template ID.
        /// </summary>
        public string TemplateId
        {
            get;
            set;
        }

        /// <summary>
        /// The tier level of the account; '0': free tier, '1': commercial account, '2': partner tier. Other values are reserved for the future.
        /// </summary>
        public string Tier
        {
            get;
            set;
        }

        /// <summary>
        /// Last update UTC time RFC3339.
        /// </summary>
        public DateTime? UpdatedAt
        {
            get;
            set;
        }

        /// <summary>
        /// Time when upgraded to commercial account in UTC format RFC3339.
        /// </summary>
        public DateTime? UpgradedAt
        {
            get;
            set;
        }

        public PaginatedResponse<QueryOptions, ApiKey> ApiKeys(string accountID, string groupID, string after = null, string include = null, int? limit = null, string order = null)
        {
            var renames = new Dictionary<string, string>();
            object data = null;
            var options = new QueryOptions { After = after, Include = include, Limit = limit, Order = order, };
            try
            {
                Func<QueryOptions, ResponsePage<ApiKey>> paginatedFunc = (QueryOptions _options) => { return AsyncHelper.RunSync<ResponsePage<ApiKey>>(() => MbedCloudSDK.Client.ApiCall.CallApi<ResponsePage<ApiKey>>(path: "/v3/accounts/{accountID}/policy-groups/{groupID}/api-keys", method: Method.GET, settings: SerializationSettings.GetSettings(renames), accepts: new string[] { "application/json" }, contentTypes: new string[] { "application/json" }, body: data, pathParams: new Dictionary<string, object>() { { "accountID", accountID }, { "groupID", groupID }, }, queryParams: new Dictionary<string, object>() { { "after", after }, { "include", include }, { "limit", limit }, { "order", order }, }, configuration: Config)); };
                return new PaginatedResponse<QueryOptions, ApiKey>(paginatedFunc, options);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<SubtenantAccount> Create(string action = null)
        {
            var renames = new Dictionary<string, string>();
            var data = new
            {
                AddressLine1 = AddressLine1,
                AddressLine2 = AddressLine2,
                AdminEmail = AdminEmail,
                AdminFullName = AdminFullName,
                AdminName = AdminName,
                AdminPassword = AdminPassword,
                Aliases = Aliases,
                City = City,
                Company = Company,
                Contact = Contact,
                ContractNumber = ContractNumber,
                Country = Country,
                CustomerNumber = CustomerNumber,
                DisplayName = DisplayName,
                Email = Email,
                EndMarket = EndMarket,
                PhoneNumber = PhoneNumber,
                PostalCode = PostalCode,
                State = State,
            };
            try
            {
                return await MbedCloudSDK.Client.ApiCall.CallApi<SubtenantAccount>(path: "/v3/accounts", method: Method.POST, settings: SerializationSettings.GetSettings(renames), populateObject: true, objectToPopulate: this, accepts: new string[] { "application/json" }, contentTypes: new string[] { "application/json" }, body: data, queryParams: new Dictionary<string, object>() { { "action", action }, }, configuration: Config);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<SubtenantAccount> Get(string accountID, string include = null, string properties = null)
        {
            var renames = new Dictionary<string, string>();
            object data = null;
            try
            {
                return await MbedCloudSDK.Client.ApiCall.CallApi<SubtenantAccount>(path: "/v3/accounts/{accountID}", method: Method.GET, settings: SerializationSettings.GetSettings(renames), populateObject: true, objectToPopulate: this, accepts: new string[] { "application/json" }, contentTypes: new string[] { "application/json" }, body: data, pathParams: new Dictionary<string, object>() { { "accountID", accountID }, }, queryParams: new Dictionary<string, object>() { { "include", include }, { "properties", properties }, }, configuration: Config);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public PaginatedResponse<QueryOptions, Account> List(string after = null, string countryLike = null, string endMarketEq = null, string format = null, string include = null, int? limit = null, string order = null, string parentEq = null, string properties = null, string tierEq = null)
        {
            var renames = new Dictionary<string, string>();
            object data = null;
            var options = new QueryOptions { After = after, Include = include, Limit = limit, Order = order, };
            try
            {
                Func<QueryOptions, ResponsePage<Account>> paginatedFunc = (QueryOptions _options) => { return AsyncHelper.RunSync<ResponsePage<Account>>(() => MbedCloudSDK.Client.ApiCall.CallApi<ResponsePage<Account>>(path: "/v3/accounts", method: Method.GET, settings: SerializationSettings.GetSettings(renames), accepts: new string[] { "application/json" }, contentTypes: new string[] { "application/json" }, body: data, queryParams: new Dictionary<string, object>() { { "after", after }, { "countryLike", countryLike }, { "endMarketEq", endMarketEq }, { "format", format }, { "include", include }, { "limit", limit }, { "order", order }, { "parentEq", parentEq }, { "properties", properties }, { "tierEq", tierEq }, }, configuration: Config)); };
                return new PaginatedResponse<QueryOptions, Account>(paginatedFunc, options);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<SubtenantAccount> Update(string accountID)
        {
            var renames = new Dictionary<string, string>();
            var data = new
            {
                AddressLine1 = AddressLine1,
                AddressLine2 = AddressLine2,
                Aliases = Aliases,
                City = City,
                Company = Company,
                Contact = Contact,
                ContractNumber = ContractNumber,
                Country = Country,
                CustomFields = CustomFields,
                CustomerNumber = CustomerNumber,
                DisplayName = DisplayName,
                Email = Email,
                EndMarket = EndMarket,
                ExpirationWarningThreshold = ExpirationWarningThreshold,
                IdleTimeout = IdleTimeout,
                MfaStatus = MfaStatus,
                NotificationEmails = NotificationEmails,
                PasswordPolicy = PasswordPolicy,
                PhoneNumber = PhoneNumber,
                PostalCode = PostalCode,
                SalesContact = SalesContact,
                State = State,
            };
            try
            {
                return await MbedCloudSDK.Client.ApiCall.CallApi<SubtenantAccount>(path: "/v3/accounts/{accountID}", method: Method.PUT, settings: SerializationSettings.GetSettings(renames), populateObject: true, objectToPopulate: this, accepts: new string[] { "application/json" }, contentTypes: new string[] { "application/json" }, body: data, pathParams: new Dictionary<string, object>() { { "accountID", accountID }, }, configuration: Config);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public PaginatedResponse<QueryOptions, User> Users(string accountID, string groupID, string after = null, string include = null, int? limit = null, string order = null)
        {
            var renames = new Dictionary<string, string>();
            object data = null;
            var options = new QueryOptions { After = after, Include = include, Limit = limit, Order = order, };
            try
            {
                Func<QueryOptions, ResponsePage<User>> paginatedFunc = (QueryOptions _options) => { return AsyncHelper.RunSync<ResponsePage<User>>(() => MbedCloudSDK.Client.ApiCall.CallApi<ResponsePage<User>>(path: "/v3/accounts/{accountID}/policy-groups/{groupID}/users", method: Method.GET, settings: SerializationSettings.GetSettings(renames), accepts: new string[] { "application/json" }, contentTypes: new string[] { "application/json" }, body: data, pathParams: new Dictionary<string, object>() { { "accountID", accountID }, { "groupID", groupID }, }, queryParams: new Dictionary<string, object>() { { "after", after }, { "include", include }, { "limit", limit }, { "order", order }, }, configuration: Config)); };
                return new PaginatedResponse<QueryOptions, User>(paginatedFunc, options);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get human readable string of this object
        /// </summary>
        /// <returns>Serialized string of object</returns>
        public override string ToString()
            => this.DebugDump();
    }
}