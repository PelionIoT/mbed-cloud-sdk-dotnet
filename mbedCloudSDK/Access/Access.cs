using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iam.Api;
using iam.Client;
using iam.Model;
using mbedCloudSDK.Common;
using mbedCloudSDK.Exceptions;

namespace mbedCloudSDK.Access
{
    /// <summary>
    /// Exposing functionality from IAM.
    /// </summary>
	public class Access: BaseAPI
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.Access.Access"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
		public Access(Config config): base(config)
        {
            if (config.Host != string.Empty)
            {
                Configuration.Default.ApiClient = new ApiClient(config.Host);
            }
            Configuration.Default.ApiKey["Authorization"] = config.ApiKey;
            Configuration.Default.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
        }

        /// <summary>
        /// Lists the API keys.
        /// </summary>
        /// <returns>The API keys.</returns>
        /// <param name="listParams">List parameters.</param>
        public List<ApiKeyInfoResp> ListApiKeys(ListParams listParams = null)
        {
			if (listParams != null)
			{
				throw new NotImplementedException();
			}
			var api = new DeveloperApi();
            try
            {
                return api.GetAllApiKeys().Data;
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get API key details
        /// </summary>
        /// <param name="keyId">API key ID</param>
        public ApiKeyInfoResp GetApiKey(string keyId)
        {
            var api = new DeveloperApi();
			try
			{
				return api.GetApiKey(keyId);
			}
			catch (ApiException e)
			{
				throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
			}
        }

        /// <summary>
        /// Delete API key
        /// </summary>
        /// <param name="keyId">API key ID</param>
        public bool DeleteApiKey(string keyId)
        {
            var api = new DeveloperApi();
            bool success = false;
            try
            {
                api.DeleteApiKey(keyId);
                success = true;
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
            return success;
        }

        /// <summary>
        /// List groups
        /// </summary>
        /// <returns></returns>
        public List<GroupSummary> ListGroups(ListParams listParams = null)
        {
            if (listParams != null)
			{
				throw new NotImplementedException();
			}
			var api = new DeveloperApi();
			try
			{
				return api.GetAllGroups().Data;
			}
			catch (ApiException e)
			{
				throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
			}
        }

        /// <summary>
        /// List users
        /// </summary>
        /// <returns></returns>
        public List<UserInfoResp> ListUsers(ListParams listParams = null)
        {
            if (listParams != null)
			{
				throw new NotImplementedException();
			}
			var api = new AccountAdminApi();
			try
			{
				return api.GetAllUsers().Data;
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
        public UserInfoResp GetUser(String userId)
        {
            var api = new AccountAdminApi();
            try
            {
                return api.GetUser(userId);
            }
            catch(ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public UserInfoResp UpdateUser(String userId, UserInfoReq body)
        {
            var api = new AccountAdminApi();
			try
			{
				return api.UpdateUser(userId, body);
			}
			catch (ApiException e)
			{
				throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
			}
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="userId"></param>
        public bool DeleteUser(String userId)
        {
            var api = new AccountAdminApi();
            bool success = false;
            try
            {
                api.DeleteUser(userId);
                success = true;
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
            return success;
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public UserInfoResp CreateUser(UserInfoReq body)
		{
			var api = new AccountAdminApi();
            try
            {
                return api.CreateUser(body);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
