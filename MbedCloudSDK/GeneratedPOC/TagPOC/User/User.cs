

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MbedCloudSDK.AccountManagement.Model.User;
using MbedCloudSDK.Client;
using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Extensions;
using MbedCloudSDK.Common.Filter;
using MbedCloudSDK.Common.Query;
using MbedCloudSDK.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;

namespace MbedCloudSDK.TagPOC.User
{
    /// <summary>
    /// This object represents a user in Mbed Cloud.
    /// </summary>
    public partial class User : BaseModel
    {
        /// <summary>
        /// Gets the status of the user. INVITED means that the user has not accepted the invitation request. RESET means that the password must be changed immediately.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public UserStatus? Status { get; set; }

        /// <summary>
        /// Gets or sets a username containing alphanumerical letters and -,._@+&#x3D; characters.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets a flag indicating whether the user&#39;s email address has been verified or not.
        /// </summary>
        public bool? EmailVerified { get; set; }

        /// <summary>
        /// Gets the UUID of the account.
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Gets a timestamp of the latest change of the user password, in milliseconds.
        /// </summary>
        public long? PasswordChangedTime { get; set; }

        /// <summary>
        /// Gets a list of IDs of the groups this user belongs to.
        /// </summary>
        public List<string> Groups { get; set; }

        /// <summary>
        /// Gets creation UTC time RFC3339.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating that the General Terms and Conditions has been accepted.
        /// </summary>
        public bool? TermsAccepted { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating that receiving marketing information has been accepted.
        /// </summary>
        public bool? MarketingAccepted { get; set; }

        /// <summary>
        /// Gets or sets the full name of the user.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets a timestamp of the user creation in the storage, in milliseconds.
        /// </summary>
        public long? CreationTime { get; private set; }

        /// <summary>
        /// Gets or sets the password when creating a new user. It will be generated when not present in the request.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets a timestamp of the latest login of the user, in milliseconds.
        /// </summary>
        public long? LastLoginTime { get; private set; }

        /// <summary>
        /// Gets whether two factor authentication has been enabled for this user.
        /// </summary>
        public bool? TwoFactorAuthentication { get; set; }

        /// <summary>
        /// Gets history of logins for this user.
        /// </summary>
        public List<LoginHistory> LoginHistory { get; private set; }

        // public List<MbedCloudSDK.Accounts.SubtenantAccount.SubtenantAccount> SubAccounts { get; set; }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();

        public static PaginatedResponse<QueryOptions, User> List(string after = null, string include = null, int? limit = null, string order = null)
        {
            var renames = new Dictionary<string, string>
            {
                {"TwoFactorAuthentication", "is_totp_enabled"},
                {"TermsAccepted", "is_gtc_accepted"},
                {"MarketingAccepted", "is_marketing_accepted"},
            };

            var options = new QueryOptions
            {
                After = after,
                Include = include,
                Limit = limit,
                Order = order,
            };

            try
            {
                Func<QueryOptions, ResponsePage<User>> paginatedFunc = (QueryOptions _options) =>
                {
                    return AsyncHelper.RunSync<ResponsePage<User>>(() => MbedCloudSDK.Client.ApiCall.CallApi<ResponsePage<User>>(path: "/v3/users", queryParams: new Dictionary<string, object>() { { "limit", _options.Limit }, { "after", _options.After }, { "order", _options.Order }, { "include", _options.Include } }, configuration: Config, settings: SerializationSettings.GetSettings(renames), method: Method.GET));
                };

                return new PaginatedResponse<QueryOptions, User>(paginatedFunc, options);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<User> Get()
        {
            var renames = new Dictionary<string, string>
            {
                {"TwoFactorAuthentication", "is_totp_enabled"},
                {"TermsAccepted", "is_gtc_accepted"},
                {"MarketingAccepted", "is_marketing_accepted"},
            };

            try
            {
                return await MbedCloudSDK.Client.ApiCall.CallApi<User>(
                    path: "/v3/users/{user-id}",
                    pathParams: new Dictionary<string, object>() { { "user-id", Id }, },
                    accepts: new string[] { "application/json" },
                    configuration: Config,
                    settings: SerializationSettings.GetSettings(renames),
                    method: Method.GET,
                    populateObject: true,
                    objectToPopulate: this
                );
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public static async Task<User> Get(string userId)
        {
            var renames = new Dictionary<string, string>
            {
                {"TwoFactorAuthentication", "is_totp_enabled"},
                {"TermsAccepted", "is_gtc_accepted"},
                {"MarketingAccepted", "is_marketing_accepted"},
            };

            var res = await MbedCloudSDK.Client.ApiCall.CallApi<User>(
                path: "/v3/users/{user-id}",
                pathParams: new Dictionary<string, object>() { { "user-id", userId } },
                accepts: new string[] { "application/json" },
                configuration: Config,
                settings: SerializationSettings.GetSettings(renames),
                method: Method.GET
            );
            return res;
        }

        public async Task<User> Create()
        {
            var renames = new Dictionary<string, string>
            {
                {"TwoFactorAuthentication", "is_totp_enabled"},
                {"TermsAccepted", "is_gtc_accepted"},
                {"MarketingAccepted", "is_marketing_accepted"},
            };

            var data = new
            {
                Address = Address,
                Email = Email,
                FullName = FullName,
                Groups = Groups,
                TermsAccepted = TermsAccepted,
                MarketingAccepted = MarketingAccepted,
                Password = Password,
                PhoneNumber = PhoneNumber,
                Username = Username,
            };

            var res = await MbedCloudSDK.Client.ApiCall.CallApi<User>
            (
                path: "/v3/users",
                accepts: new string[] { "application/json" },
                contentTypes: new string[] { "application/json" },
                body: data,
                settings: SerializationSettings.GetSettings(renames),
                configuration: Config,
                method: Method.POST,
                populateObject: true,
                objectToPopulate: this
            );

            return res;
        }

        public async Task<User> Update()
        {
            var renames = new Dictionary<string, string>
            {
                {"TwoFactorAuthentication", "is_totp_enabled"},
                {"TermsAccepted", "is_gtc_accepted"},
                {"MarketingAccepted", "is_marketing_accepted"},
            };

            var data = new User
            {
                Address = Address,
                //Email = Email,
                FullName = FullName,
                Groups = Groups,
                TermsAccepted = TermsAccepted,
                MarketingAccepted = MarketingAccepted,
                TwoFactorAuthentication = TwoFactorAuthentication,
                PhoneNumber = PhoneNumber,
                //Status = Status,
                Username = Username,
            };

            var res = await MbedCloudSDK.Client.ApiCall.CallApi<User>
            (
                path: "/v3/users/{user-id}",
                accepts: new string[] { "application/json" },
                contentTypes: new string[] { "application/json" },
                body: data,
                pathParams: new Dictionary<string, object> { { "user-id", Id } },
                settings: SerializationSettings.GetSettings(renames),
                configuration: Config,
                method: Method.PUT,
                populateObject: true,
                objectToPopulate: this
            );

            return res;
        }

        public async Task Delete()
        {
            await MbedCloudSDK.Client.ApiCall.CallApi<object>
            (
                path: "/v3/users/{user-id}",
                contentTypes: new string[] { "application/json" },
                pathParams: new Dictionary<string, object> { { "user-id", Id } },
                settings: SerializationSettings.GetDefaultSettings(),
                configuration: Config,
                method: Method.DELETE
            );
        }
    }
}