// <copyright file="AccountManagementApi.ApiKey.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.AccountManagement.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MbedCloudSDK.AccountManagement.Model.ApiKey;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Query;
    using MbedCloudSDK.Exceptions;

    /// <summary>
    /// Account Management api
    /// </summary>
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
            catch (CloudApiException)
            {
                throw;
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
                var resp = developerApi.GetAllApiKeys(options.Limit, options.After, options.Order, options.Include, options.Filter.FilterString);
                var respKeys = new ResponsePage<ApiKey>(resp.After, resp.HasMore, resp.Limit, resp.Order.ToString(), resp.TotalCount);
                foreach (var key in resp.Data)
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
        /// <param name="options">Query options</param>
        /// <returns>Task with list of api keys</returns>
        public async Task<List<ApiKey>> ListApiKeysAsync(QueryOptions options = null)
        {
            if (options != null)
            {
                options = new QueryOptions();
            }

            try
            {
                var apiKeysInfo = await developerApi.GetAllApiKeysAsync(options.Limit, options.After, options.Order, options.Include, options.Filter.FilterString);
                var apiKeys = new List<ApiKey>();
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
        /// <returns>ApiKey</returns>
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
        /// <param name="apiKeyId">Id of Api Key</param>
        /// <returns>Task with ApiKey</returns>
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
        /// <param name="key">Api Key</param>
        /// <returns>Api Key</returns>
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
        /// <param name="key">Api Key</param>
        /// <returns>Task with Api Key</returns>
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
        /// <param name="apiKeyId">Id of api key</param>
        /// <param name="key">Api Key</param>
        /// <returns>Api Key</returns>
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
        /// <param name="apiKeyId">Id of Api Key</param>
        /// <param name="key">Api Key</param>
        /// <returns>Task with Api Key</returns>
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
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
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
