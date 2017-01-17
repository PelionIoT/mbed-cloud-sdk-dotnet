using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iam.Api;
using iam.Client;
using iam.Model;
using mbedCloudSDK.Access.Model;
using mbedCloudSDK.Access.Model.ApiKey;
using mbedCloudSDK.Common;
using mbedCloudSDK.Exceptions;
using mbedCloudSDK.Access.Model.Account;
using static iam.Model.AccountInfo;
using mbedCloudSDK.Access.Model.Group;
using mbedCloudSDK.Access.Model.User;

namespace mbedCloudSDK.Access.Api
{
    /// <summary>
    /// Exposing functionality from IAM.
    /// </summary>
	public class AccessApi: BaseApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.Access.Access"/> class.
        /// Exposing functionality from the following underlying services:
        /// - IAM
        /// </summary>
        /// <param name="config">Config.</param>
		public AccessApi(Config config): base(config)
        {
            if (config.Host != string.Empty)
            {
                Configuration.Default.ApiClient = new ApiClient(config.Host);
            }
            Configuration.Default.ApiKey["Authorization"] = config.ApiKey;
            Configuration.Default.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
        }

        #region Account
        
        /// <summary>
        /// Get account info.
        /// </summary>
        /// <returns></returns>
        public Account GetAccount()
        {
            var api = new DeveloperApi();
            try
            {
                var account = api.GetMyAccountInfo();
                return Account.Map(account);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get account info asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task<Account> GetAccountAsync()
        {
            var api = new DeveloperApi();
            try
            {
                var account = await api.GetMyAccountInfoAsync();
                return Account.Map(account);
            }
            catch(ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Update account.
        /// </summary>
        /// <param name="account">Updated account info.</param>
        /// <returns></returns>
        public Account UpdateAccount(Account account)
        {
            var api = new AccountAdminApi();
            AccountUpdateReq req = new AccountUpdateReq(account.AddressLine2, account.City, account.AddressLine1, account.DisplayName,
                account.Country, account.Company, account.TemplateId, account.Status.ToString(), account.State, account.Contact, account.PostalCode,
                account.IsProvisioningAllowed, null, account.Tier, account.PhoneNumber, account.Email, account.Aliases);

            try
            {
                var accountInfo = api.UpdateMyAccount(req);
                return Account.Map(accountInfo);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Update account asynchronously.
        /// </summary>
        /// <param name="account">Updated account info.</param>
        /// <returns></returns>
        public async Task<Account> UpdateAccountAsync(Account account)
        {
            var api = new AccountAdminApi();
            AccountUpdateReq req = new AccountUpdateReq(account.AddressLine2, account.City, account.AddressLine1, account.DisplayName,
                account.Country, account.Company, account.TemplateId, account.Status.ToString(), account.State, account.Contact, account.PostalCode,
                account.IsProvisioningAllowed, null, account.Tier, account.PhoneNumber, account.Email, account.Aliases);

            try
            {
                var accountInfo = await api.UpdateMyAccountAsync(req);
                return Account.Map(accountInfo);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }


        #endregion

        #region ApiKey
        /// <summary>
        /// Lists API keys.
        /// </summary>
        /// <returns>The API keys.</returns>
        /// <param name="listParams">List parameters.</param>
        public List<ApiKey> ListApiKeys(ListParams listParams = null)
        {
			if (listParams != null)
			{
				throw new NotImplementedException();
			}
			var api = new DeveloperApi();
            try
            {
                var apiKeysInfo = api.GetAllApiKeys().Data;
                List<ApiKey> apiKeys = new List<ApiKey>();
                foreach (var key in apiKeysInfo)
                {
                    apiKeys.Add(ApiKey.Map(key));
                }
                return apiKeys;
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
        
        /// <summary>
        /// List API keys asynchronously.
        /// </summary>
        /// <param name="listParams"></param>
        /// <returns></returns>
        public async Task<List<ApiKey>> ListApiKeysAsync(ListParams listParams = null)
        {
            if (listParams != null)
            {
                throw new NotImplementedException();
            }
            var api = new DeveloperApi();
            try
            {
                var apiKeysInfo = await api.GetAllApiKeysAsync();
                List<ApiKey> apiKeys = new List<ApiKey>();
                foreach (var key in apiKeysInfo.Data)
                {
                    apiKeys.Add(ApiKey.Map(key));
                }
                return apiKeys;
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get API key details. Returns currently used key for empty argument.
        /// </summary>
        /// <param name="keyId">API key ID</param>
        public ApiKey GetApiKey(string keyId = null)
        {
            var api = new DeveloperApi();
			try
			{
                if (keyId != null)
                {
                    return ApiKey.Map(api.GetApiKey(keyId));
                }
                //return currently used api key for empty keyId
                else 
                {
                    return ApiKey.Map(api.GetMyApiKey());
                }
                
			}
			catch (ApiException e)
			{
				throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
			}
        }

        /// <summary>
        /// Get API key details asynchronously. Returns currently used key for empty argument.
        /// </summary>
        /// <param name="keyId"></param>
        /// <returns></returns>
        public async Task<ApiKey> GetApiKeyAsync(string keyId = null)
        {
            var api = new DeveloperApi();
            try
            {
                if (keyId != null)
                {
                    return ApiKey.Map(await api.GetApiKeyAsync(keyId));
                }
                //return currently used api key for empty keyId
                else
                {
                    return ApiKey.Map(await api.GetMyApiKeyAsync());
                }
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Create new Api key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ApiKey AddApiKey(ApiKey key)
        {
            var api = new DeveloperApi();
            try
            {
                var keyBody = new ApiKeyInfoReq(key.Owner, key.Name, key.Groups);
                return ApiKey.Map(api.CreateApiKey(keyBody));
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Create new Api key asynchronously.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<ApiKey> AddApiKeyAsync(ApiKey key)
        {
            var api = new DeveloperApi();
            try
            {
                var keyBody = new ApiKeyInfoReq(key.Owner, key.Name, key.Groups);
                return ApiKey.Map(await api.CreateApiKeyAsync(keyBody));
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Update API key.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public ApiKey UpdateApiKey(string apiKey, ApiKey key)
        {
            var api = new DeveloperApi();
            try
            {
                ApiKeyUpdateReq req = new ApiKeyUpdateReq(key.Owner, key.Name);
                return ApiKey.Map(api.UpdateApiKey(apiKey, req));
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Update API key asynchronously.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<ApiKey> UpdateApiKeyAsync(string apiKey, ApiKey key)
        {
            var api = new DeveloperApi();
            try
            {
                ApiKeyUpdateReq req = new ApiKeyUpdateReq(key.Owner, key.Name);
                return ApiKey.Map(await api.UpdateApiKeyAsync(apiKey, req));
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Delete API key.
        /// </summary>
        /// <param name="keyId">API key ID</param>
        public void DeleteApiKey(string keyId)
        {
            var api = new DeveloperApi();
            try
            {
                api.DeleteApiKey(keyId);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Delete API key asynchronously.
        /// </summary>
        /// <param name="keyId">API key ID</param>
        public async Task DeleteApiKeyAsync(string keyId)
        {
            var api = new DeveloperApi();
            try
            {
                await api.DeleteApiKeyAsync(keyId);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        #endregion

        #region Group

        /// <summary>
        /// List groups.
        /// </summary>
        /// <returns></returns>
        public List<Group> ListGroups(ListParams listParams = null)
        {
            if (listParams != null)
			{
				throw new NotImplementedException();
			}
			var api = new DeveloperApi();
			try
			{
                List<Group> groups = new List<Group>();
                foreach (var group in api.GetAllGroups().Data)
                {
                    groups.Add(Group.Map(group));
                }
                return groups;
			}
			catch (ApiException e)
			{
				throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
			}
        }

        /// <summary>
        /// List groups.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Group>> ListGroupsAsync(ListParams listParams = null)
        {
            if (listParams != null)
            {
                throw new NotImplementedException();
            }
            var api = new DeveloperApi();
            try
            {
                var groupsInfo = await api.GetAllGroupsAsync();
                List<Group> groups = new List<Group>();
                foreach (var group in groupsInfo.Data)
                {
                    groups.Add(Group.Map(group));
                }
                return groups;
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        #endregion

        #region User

        /// <summary>
        /// List users.
        /// </summary>
        /// <returns></returns>
        public List<User> ListUsers(ListParams listParams = null)
        {
            if (listParams != null)
			{
				throw new NotImplementedException();
			}
			var api = new AccountAdminApi();
			try
			{
                List<User> users = new List<User>();
                foreach (var user in api.GetAllUsers().Data)
                {
                    users.Add(User.Map(user));
                }
                return users;
			}
			catch (ApiException e)
			{
				throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
			}
        }

        /// <summary>
        /// List users asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> ListUsersAsynchronously(ListParams listParams = null)
        {
            if (listParams != null)
            {
                throw new NotImplementedException();
            }
            var api = new AccountAdminApi();
            try
            {
                List<User> users = new List<User>();
                var usersInfo = await api.GetAllUsersAsync();
                foreach (var user in usersInfo.Data)
                {
                    users.Add(User.Map(user));
                }
                return users;
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUser(String userId)
        {
            var api = new AccountAdminApi();
            try
            {
                return User.Map(api.GetUser(userId));
            }
            catch(ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get user asynchronously.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<User> GetUserAsync(String userId)
        {
            var api = new AccountAdminApi();
            try
            {
                var user = await api.GetUserAsync(userId);
                return User.Map(user);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public User AddUser(User body)
        {
            var api = new AccountAdminApi();
            try
            {
                UserInfoReq req = new UserInfoReq(body.Username, body.PhoneNumber, body.IsMarketingAccepted, body.Groups, body.IsGtcAccepted,
                    body.FullName, body.Address, body.Password, body.Email);
                return User.Map(api.CreateUser(req));
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<User> AddUserAsync(User body)
        {
            var api = new AccountAdminApi();
            try
            {
                UserInfoReq req = new UserInfoReq(body.Username, body.PhoneNumber, body.IsMarketingAccepted, body.Groups, body.IsGtcAccepted,
                    body.FullName, body.Address, body.Password, body.Email);
                return User.Map(await api.CreateUserAsync(req));
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public User UpdateUser(User body)
        {
            var api = new AccountAdminApi();
			try
			{
                UserUpdateReq req = new UserUpdateReq(body.Username, body.PhoneNumber, body.IsMarketingAccepted, body.IsGtcAccepted,
                    body.FullName, body.Address, body.Password, body.Email);
                return User.Map(api.UpdateUser(body.Id, req));
			}
			catch (ApiException e)
			{
				throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
			}
        }

        /// <summary>
        /// Update user asynchronously.
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<User> UpdateUserAsync(User body)
        {
            var api = new AccountAdminApi();
            try
            {
                UserUpdateReq req = new UserUpdateReq(body.Username, body.PhoneNumber, body.IsMarketingAccepted, body.IsGtcAccepted,
                    body.FullName, body.Address, body.Password, body.Email);
                var user = await api.UpdateUserAsync(body.Id, req);
                return User.Map(user);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Delete user.
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteUser(String userId)
        {
            var api = new AccountAdminApi();
            try
            {
                api.DeleteUser(userId);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Delete user asynchronously.
        /// </summary>
        /// <param name="userId"></param>
        public async Task DeleteUserAsync(String userId)
        {
            var api = new AccountAdminApi();
            try
            {
                await api.DeleteUserAsync(userId);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        #endregion
    }
}
