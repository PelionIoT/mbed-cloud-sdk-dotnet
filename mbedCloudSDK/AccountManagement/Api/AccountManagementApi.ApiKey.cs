using iam.Api;
using iam.Model;
using mbedCloudSDK.AccountManagement.Model.ApiKey;
using mbedCloudSDK.Common;
using mbedCloudSDK.Common.Query;
using mbedCloudSDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.AccountManagement.Api
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
            if (options != null)
            {
                options = new QueryOptions();
            }
            try
            {
                var resp = developerApi.GetAllApiKeys(options.Limit, options.After, options.Order, options.Include, options.QueryString);
                ResponsePage<ApiKey> respKeys = new ResponsePage<ApiKey>(resp.After, resp.HasMore, resp.Limit, resp.Order.ToString(), resp.TotalCount);
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
        /// <param name="keyId">API key ID</param>
        public ApiKey GetApiKey(string keyId = null)
        {
            try
            {
                if (keyId != null)
                {
                    return ApiKey.Map(developerApi.GetApiKey(keyId));
                }
                //return currently used api key for empty keyId
                else
                {
                    return ApiKey.Map(developerApi.GetMyApiKey());
                }

            }
            catch (iam.Client.ApiException e)
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
            try
            {
                if (keyId != null)
                {
                    return ApiKey.Map(await developerApi.GetApiKeyAsync(keyId));
                }
                //return currently used api key for empty keyId
                else
                {
                    return ApiKey.Map(await developerApi.GetMyApiKeyAsync());
                }
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
        /// <param name="apiKey"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public ApiKey UpdateApiKey(string apiKey, ApiKey key)
        {
            try
            {
                ApiKeyUpdateReq req = key.CreatePutRequest();
                return ApiKey.Map(developerApi.UpdateApiKey(apiKey, req));
            }
            catch (iam.Client.ApiException e)
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
            try
            {
                ApiKeyUpdateReq req = key.CreatePutRequest();
                return ApiKey.Map(await developerApi.UpdateApiKeyAsync(apiKey, req));
            }
            catch (iam.Client.ApiException e)
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
            try
            {
                developerApi.DeleteApiKey(keyId);
            }
            catch (iam.Client.ApiException e)
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
            try
            {
                await developerApi.DeleteApiKeyAsync(keyId);
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
