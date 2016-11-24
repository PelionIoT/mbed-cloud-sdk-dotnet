using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iam.Api;
using iam.Client;
using iam.Model;

namespace mbed_cloud_sdk.Access
{
    public class Accounts: BaseAPI
    {
        public Accounts(Config config): base(config)
        {
            if (config.Host != string.Empty)
            {
                Configuration.Default.ApiClient = new ApiClient(config.Host);
            }
            Configuration.Default.ApiKey["Authorization"] = config.ApiKey;
            Configuration.Default.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
        }

        /// <summary>
        /// Get All API keys Endpoints, optionally filtered by owner
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public List<ApiKeyInfoResp> ListApiKeys(string owner = null)
        {
            var api = new DeveloperApi();
            try
            {
                return api.GetAllApiKeys(owner).Data;
            }
            catch (ApiException e)
            {
                Console.Error.WriteLine(e);
            }
            return null;
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
            catch(ApiException e)
            {
                Console.Error.WriteLine(e);
            }
            return null;
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
                Console.Error.WriteLine(e);
            }
            return success;
        }

        /// <summary>
        /// List groups
        /// </summary>
        /// <returns></returns>
        public List<GroupSummary> ListGroups()
        {
            var api = new DeveloperApi();
            return api.GetAllGroups().Data;
        }

        /// <summary>
        /// List users
        /// </summary>
        /// <returns></returns>
        public List<UserInfoResp> ListUsers()
        {
            var api = new AccountAdminApi();
            try
            {
                return api.GetAllUsers().Data;
            }
            catch (ApiException e)
            {
                Console.Error.WriteLine(e);
            }
            return null;
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
                Console.Error.WriteLine(e);
            }
            return null;
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
                Console.Error.WriteLine(e);
            }
            return null;
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
                Console.Error.WriteLine(e);
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
                Console.Error.WriteLine(e);
            }
            return null;
        }
    }
}
