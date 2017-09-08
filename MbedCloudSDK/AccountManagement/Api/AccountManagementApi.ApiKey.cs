using iam.Api;
using iam.Model;
using MbedCloudSDK.AccountManagement.Model.ApiKey;
using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Query;
using MbedCloudSDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MbedCloudSDK.AccountManagement.Api
{
    public partial class AccountManagementApi
    {
        /// <summary>
        /// Lists API keys.
        /// </summary>
        /// <returns>The API keys.</returns>
        /// <param name="options">Query options.</param>
        public PaginatedResponse<ApiKey> ListApiKeys(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }
            try
            {
                return new PaginatedResponse<ApiKey>(ListApiKeysFunc, options);
            }
            catch (CloudApiException e)
            {
                throw e;
            }
        }

        private ResponsePage<ApiKey> ListApiKeysFunc(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }
            try
            {
                var resp = developerApi.GetAllApiKeys(options.Limit, options.After, options.Order, options.Include, options.QueryString);
                var respKeys = new ResponsePage<ApiKey>(resp.After, resp.HasMore, resp.Limit, resp.Order.ToString(), resp.TotalCount);
                foreach(var key in resp.Data)
                {
                    respKeys.Data.Add(ApiKey.Map(key));
                }
                return respKeys;
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// List API keys asynchronously.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<List<ApiKey>> ListApiKeysAsync(QueryOptions options = null)
        {
            if (options != null)
            {
                options = new QueryOptions();
            }
            try
            {
                var apiKeysInfo = await developerApi.GetAllApiKeysAsync(options.Limit, options.After, options.Order, options.Include, options.QueryString);
                List<ApiKey> apiKeys = new List<ApiKey>();
                foreach (var key in apiKeysInfo.Data)
                {
                    apiKeys.Add(ApiKey.Map(key));
                }
                return apiKeys;
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get API key details. Returns currently used key for empty argument.
        /// </summary>
        /// <param name="apiKeyId">API key ID</param>
        public ApiKey GetApiKey(string apiKeyId)
        {
            try
            {
                return ApiKey.Map(developerApi.GetApiKey(apiKeyId));
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get API key details asynchronously. Returns currently used key for empty argument.
        /// </summary>
        /// <param name="apiKeyId"></param>
        /// <returns></returns>
        public async Task<ApiKey> GetApiKeyAsync(string apiKeyId)
        {
            try
            {
                return ApiKey.Map(await developerApi.GetApiKeyAsync(apiKeyId));
            }
            catch (iam.Client.ApiException e)
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
            try
            {
                var keyBody = key.CreatePostRequest();
                return ApiKey.Map(developerApi.CreateApiKey(keyBody));
            }
            catch (iam.Client.ApiException e)
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
            try
            {
                var keyBody = key.CreatePostRequest();
                return ApiKey.Map(await developerApi.CreateApiKeyAsync(keyBody));
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Update API key.
        /// </summary>
        /// <param name="apiKeyId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public ApiKey UpdateApiKey(string apiKeyId, ApiKey key)
        {
            try
            {
                var req = key.CreatePutRequest();
                return ApiKey.Map(developerApi.UpdateApiKey(apiKeyId, req));
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Update API key asynchronously.
        /// </summary>
        /// <param name="apiKeyId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<ApiKey> UpdateApiKeyAsync(string apiKeyId, ApiKey key)
        {
            try
            {
                var req = key.CreatePutRequest();
                return ApiKey.Map(await developerApi.UpdateApiKeyAsync(apiKeyId, req));
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Delete API key.
        /// </summary>
        /// <param name="apiKeyId">API key ID</param>
        public void DeleteApiKey(string apiKeyId)
        {
            try
            {
                developerApi.DeleteApiKey(apiKeyId);
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Delete API key asynchronously.
        /// </summary>
        /// <param name="apiKeyId">API key ID</param>
        public async Task DeleteApiKeyAsync(string apiKeyId)
        {
            try
            {
                await developerApi.DeleteApiKeyAsync(apiKeyId);
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
