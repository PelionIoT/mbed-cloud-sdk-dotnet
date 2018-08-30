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

namespace MbedCloudSDK.Accounts.User
{
    using MbedCloudSDK.Common;
    using System;
    using System.Collections.Generic;
    using MbedCloudSDK.Accounts.LoginHistory;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Threading.Tasks;
    using MbedCloudSDK.Client;
    using MbedCloudSDK.Exceptions;
    using RestSharp;
    using MbedCloudSDK.Common.Query;
    using MbedCloudSDK.Accounts.PolicyGroup;
    using MbedCloudSDK.Common.Extensions;
    using MbedCloudSDK.Common.Renames;

    /// <summary>
    /// User
    /// </summary>
    public partial class User : BaseModel
    {
        public User()
        {
        }

        public User(Config config)
        {
            Config = config;
        }

        /// <summary>
        /// The UUID of the account.
        /// </summary>
        public string AccountId
        {
            get;
            set;
        }

        /// <summary>
        /// Address.
        /// </summary>
        public string Address
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
        /// A timestamp of the user creation in the storage, in milliseconds.
        /// </summary>
        public long? CreationTime
        {
            get;
            set;
        }

        /// <summary>
        /// The email address.
        /// </summary>
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// A flag indicating whether the user's email address has been verified or not.
        /// </summary>
        public bool? EmailVerified
        {
            get;
            set;
        }

        /// <summary>
        /// The full name of the user.
        /// </summary>
        public string FullName
        {
            get;
            set;
        }

        /// <summary>
        /// A list of IDs of the groups this user belongs to.
        /// </summary>
        public List<string> GroupIds
        {
            get;
            set;
        }

        /// <summary>
        /// A timestamp of the latest login of the user, in milliseconds.
        /// </summary>
        public long? LastLoginTime
        {
            get;
            set;
        }

        /// <summary>
        /// Timestamps, succeedings, IP addresses and user agent information of the last five logins of the user, with timestamps in RFC3339 format.
        /// </summary>
        public List<LoginHistory> LoginHistory
        {
            get;
            set;
        }

        /// <summary>
        /// A flag indicating that receiving marketing information has been accepted.
        /// </summary>
        public bool? MarketingAccepted
        {
            get;
            set;
        }

        /// <summary>
        /// The password when creating a new user. It will be generated when not present in the request.
        /// </summary>
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// A timestamp of the latest change of the user password, in milliseconds.
        /// </summary>
        public long? PasswordChangedTime
        {
            get;
            set;
        }

        /// <summary>
        /// Phone number.
        /// </summary>
        public string PhoneNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The status of the user. ENROLLING state indicates that the user is in the middle of the enrollment process. INVITED means that the user has not accepted the invitation request. RESET means that the password must be changed immediately. INACTIVE users are locked out and not permitted to use the system.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public UserStatusEnum? Status
        {
            get;
            set;
        }

        /// <summary>
        /// A flag indicating that the General Terms and Conditions has been accepted.
        /// </summary>
        public bool? TermsAccepted
        {
            get;
            set;
        }

        /// <summary>
        /// A flag indicating whether 2-factor authentication (TOTP) has been enabled.
        /// </summary>
        public bool? TwoFactorAuthentication
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
        /// A username containing alphanumerical letters and -,._@+= characters.
        /// </summary>
        public string Username
        {
            get;
            set;
        }

        public async Task<User> Create(string action = null)
        {
            var data = new User { Address = Address, Email = Email, FullName = FullName, GroupIds = GroupIds, MarketingAccepted = MarketingAccepted, Password = Password, PhoneNumber = PhoneNumber, TermsAccepted = TermsAccepted, Username = Username, };
            try
            {
                return await MbedCloudSDK.Client.ApiCall.CallApi<User>(path: "/v3/users", method: Method.POST, settings: SerializationSettings.GetSettingsWithRenames(Renames.RenamesDict), populateObject: true, objectToPopulate: this, accepts: new string[] { "application/json" }, contentTypes: new string[] { "application/json" }, body: data, queryParams: new Dictionary<string, object>() { { "action", action }, }, configuration: Config);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task Delete()
        {
            object data = null;
            try
            {
                await MbedCloudSDK.Client.ApiCall.CallApi<object>(path: "/v3/users/{user-id}", method: Method.DELETE, settings: SerializationSettings.GetSettingsWithRenames(Renames.RenamesDict), accepts: new string[] { "application/json" }, contentTypes: new string[] { "application/json" }, body: data, pathParams: new Dictionary<string, object>() { { "user-id", Id }, }, configuration: Config);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<User> Get()
        {
            object data = null;
            try
            {
                return await MbedCloudSDK.Client.ApiCall.CallApi<User>(path: "/v3/users/{user-id}", method: Method.GET, settings: SerializationSettings.GetSettingsWithRenames(Renames.RenamesDict), populateObject: true, objectToPopulate: this, accepts: new string[] { "application/json" }, contentTypes: new string[] { "application/json" }, body: data, pathParams: new Dictionary<string, object>() { { "user-id", Id }, }, configuration: Config);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public PaginatedResponse<QueryOptions, PolicyGroup> Groups(string after = null, string include = null, int? limit = null, string order = null)
        {
            object data = null;
            var options = new QueryOptions { After = after, Include = include, Limit = limit, Order = order, };
            try
            {
                Func<QueryOptions, ResponsePage<PolicyGroup>> paginatedFunc = (QueryOptions _options) => { return AsyncHelper.RunSync<ResponsePage<PolicyGroup>>(() => MbedCloudSDK.Client.ApiCall.CallApi<ResponsePage<PolicyGroup>>(path: "/v3/users/{user-id}/groups", method: Method.GET, settings: SerializationSettings.GetSettingsWithRenames(Renames.RenamesDict), accepts: new string[] { "application/json" }, contentTypes: new string[] { "application/json" }, body: data, pathParams: new Dictionary<string, object>() { { "user-id", Id }, }, queryParams: new Dictionary<string, object>() { { "after", after }, { "include", include }, { "limit", limit }, { "order", order }, }, configuration: Config)); };
                return new PaginatedResponse<QueryOptions, PolicyGroup>(paginatedFunc, options);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public PaginatedResponse<QueryOptions, User> List(string after = null, string include = null, int? limit = null, string order = null)
        {
            object data = null;
            var options = new QueryOptions { After = after, Include = include, Limit = limit, Order = order, };
            try
            {
                Func<QueryOptions, ResponsePage<User>> paginatedFunc = (QueryOptions _options) => { return AsyncHelper.RunSync<ResponsePage<User>>(() => MbedCloudSDK.Client.ApiCall.CallApi<ResponsePage<User>>(path: "/v3/users", method: Method.GET, settings: SerializationSettings.GetSettingsWithRenames(Renames.RenamesDict), accepts: new string[] { "application/json" }, contentTypes: new string[] { "application/json" }, body: data, queryParams: new Dictionary<string, object>() { { "after", after }, { "include", include }, { "limit", limit }, { "order", order }, }, configuration: Config)); };
                return new PaginatedResponse<QueryOptions, User>(paginatedFunc, options);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<User> Update()
        {
            var data = new User { Address = Address, FullName = FullName, GroupIds = GroupIds, MarketingAccepted = MarketingAccepted, PhoneNumber = PhoneNumber, TermsAccepted = TermsAccepted, TwoFactorAuthentication = TwoFactorAuthentication, Username = Username, };
            try
            {
                return await MbedCloudSDK.Client.ApiCall.CallApi<User>(path: "/v3/users/{user-id}", method: Method.PUT, settings: SerializationSettings.GetSettingsWithRenames(Renames.RenamesDict), populateObject: true, objectToPopulate: this, accepts: new string[] { "application/json" }, contentTypes: new string[] { "application/json" }, body: data, pathParams: new Dictionary<string, object>() { { "user-id", Id }, }, configuration: Config);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<User> ValidateEmail()
        {
            object data = null;
            try
            {
                return await MbedCloudSDK.Client.ApiCall.CallApi<User>(path: "/v3/accounts/{accountID}/users/{user-id}/validate-email", method: Method.POST, settings: SerializationSettings.GetSettingsWithRenames(Renames.RenamesDict), populateObject: true, objectToPopulate: this, accepts: new string[] { "application/json" }, contentTypes: new string[] { "application/json" }, body: data, pathParams: new Dictionary<string, object>() { { "accountID", AccountId }, { "user-id", Id }, }, configuration: Config);
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