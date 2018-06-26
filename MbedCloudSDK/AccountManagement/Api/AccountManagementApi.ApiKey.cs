// <copyright file="AccountManagementApi.ApiKey.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.AccountManagement.Api
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MbedCloudSDK.AccountManagement.Model.ApiKey;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Query;
    using MbedCloudSDK.Exceptions;
    using static MbedCloudSDK.Common.Utils;

    /// <summary>
    /// Account Management api
    /// </summary>
    public partial class AccountManagementApi
    {
        /// <summary>
        /// Lists API keys.
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.ListApiKeys(QueryOptions)"/> method.
        /// <code>
        /// try
        /// {
        ///     var options = new QueryOptions
        ///     {
        ///         Limit = 5,
        ///     };
        ///     var keys = accountApi.ListApiKeys(options).Data;
        ///     foreach (var key in keys)
        ///     {
        ///         Console.WriteLine(key);
        ///     }
        ///     return keys;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <returns>A paginated response containing <see cref="ApiKey"/></returns>
        /// <param name="options"><see cref="QueryOptions"/></param>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public PaginatedResponse<QueryOptions, ApiKey> ListApiKeys(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                var pag = new PaginatedResponse<QueryOptions, ApiKey>(ListApiKeysFunc, options);
                return pag;
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
                var resp = DeveloperApi.GetAllApiKeys(limit: options.Limit, after: options.After, order: options.Order, include: options.Include, ownerEq: options.Filter.GetFirstValueByKey("owner_id"));
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
        /// Get API key details. Returns currently used key for empty argument.
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.GetApiKey(string)"/> method.
        /// <code>
        /// try
        /// {
        ///     var key = accountApi.GetApiKey();
        ///     return key;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="apiKeyId"><see cref="ApiKey.Id"/></param>
        /// <returns><see cref="ApiKey"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public ApiKey GetApiKey(string apiKeyId = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(apiKeyId))
                {
                    return ApiKey.Map(DeveloperApi.GetApiKey(apiKeyId));
                }
                else
                {
                    return ApiKey.Map(DeveloperApi.GetMyApiKey());
                }
            }
            catch (iam.Client.ApiException e)
            {
                return HandleNotFound<ApiKey, iam.Client.ApiException>(e);
            }
        }

        /// <summary>
        /// Get API key details asynchronously. Returns currently used key for empty argument.
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.GetApiKeyAsync(string)"/> method.
        /// <code>
        /// try
        /// {
        ///     var key = awaut accountApi.GetApiKeyAsync();
        ///     return key;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="apiKeyId"><see cref="ApiKey.Id"/></param>
        /// <returns><see cref="Task"/> with <see cref="ApiKey"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public async Task<ApiKey> GetApiKeyAsync(string apiKeyId = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(apiKeyId))
                {
                    return ApiKey.Map(await DeveloperApi.GetApiKeyAsync(apiKeyId));
                }
                else
                {
                    return ApiKey.Map(await DeveloperApi.GetMyApiKeyAsync());
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
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.AddApiKey(ApiKey)"/> method.
        /// <code>
        /// try
        /// {
        ///     var key = new ApiKey
        ///     {
        ///         Name = "example api key",
        ///     };
        ///     var newKey = accountApi.AddApiKey(key);
        ///     return newKey;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="key"><see cref="ApiKey"/></param>
        /// <returns><see cref="ApiKey"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public ApiKey AddApiKey(ApiKey key)
        {
            try
            {
                var keyBody = key.CreatePostRequest();
                return ApiKey.Map(DeveloperApi.CreateApiKey(keyBody));
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Create new Api key asynchronously.
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.AddApiKeyAsync(ApiKey)"/> method.
        /// <code>
        /// try
        /// {
        ///     var key = new ApiKey
        ///     {
        ///         Name = "example api key",
        ///     };
        ///     var newKey = await accountApi.AddApiKeyAsync(key);
        ///     return newKey;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="key"><see cref="ApiKey"/></param>
        /// <returns><see cref="Task"/> with <see cref="ApiKey"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public async Task<ApiKey> AddApiKeyAsync(ApiKey key)
        {
            try
            {
                var keyBody = key.CreatePostRequest();
                return ApiKey.Map(await DeveloperApi.CreateApiKeyAsync(keyBody));
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Update API key.
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.UpdateApiKey(string, ApiKey)"/> method.
        /// <code>
        /// try
        /// {
        ///     var key = accountApi.GetApiKey()
        ///     key.Name = "updated api key";
        ///     var updatedApiKey = accountApi.UpdateApiKey(key.Id, key);
        ///     return updatedApiKey;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="apiKeyId"><see cref="ApiKey.Id"/></param>
        /// <param name="key"><see cref="ApiKey"/></param>
        /// <returns><see cref="ApiKey"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public ApiKey UpdateApiKey(string apiKeyId, ApiKey key)
        {
            try
            {
                var req = key.CreatePutRequest();
                return ApiKey.Map(DeveloperApi.UpdateApiKey(apiKeyId, req));
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Update API key asynchronously.
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.UpdateApiKeyAsync(string, ApiKey)"/> method.
        /// <code>
        /// try
        /// {
        ///     var key = await accountApi.GetApiKeyAsync()
        ///     key.Name = "updated api key";
        ///     var updatedApiKey = await accountApi.UpdateApiKeyAsync(key.Id, key);
        ///     return updatedApiKey;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="apiKeyId"><see cref="ApiKey.Id"/></param>
        /// <param name="key"><see cref="ApiKey"/></param>
        /// <returns><see cref="Task"/> with <see cref="ApiKey"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public async Task<ApiKey> UpdateApiKeyAsync(string apiKeyId, ApiKey key)
        {
            try
            {
                var req = key.CreatePutRequest();
                return ApiKey.Map(await DeveloperApi.UpdateApiKeyAsync(apiKeyId, req));
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Delete API key.
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.DeleteApiKey(string)"/> method.
        /// <code>
        /// try
        /// {
        ///     var key = accountApi.GetApiKey()
        ///     accountApi.DeleteApiKey(key.Id);
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="apiKeyId"><see cref="ApiKey.Id"/></param>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public void DeleteApiKey(string apiKeyId)
        {
            DeleteApiKeyAsync(apiKeyId).Wait();
        }

        /// <summary>
        /// Delete API key asynchronously.
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.DeleteApiKeyAsync(string)"/> method.
        /// <code>
        /// try
        /// {
        ///     var key = accountApi.GetApiKey()
        ///     await accountApi.DeleteApiKeyAsync(key.Id);
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="apiKeyId"><see cref="ApiKey.Id"/></param>
        /// <returns><see cref="Task"/> with <see cref="ApiKey"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public async Task DeleteApiKeyAsync(string apiKeyId)
        {
            try
            {
                await DeveloperApi.DeleteApiKeyAsync(apiKeyId);
            }
            catch (iam.Client.ApiException e)
            {
                HandleNotFound<string, iam.Client.ApiException>(e);
            }
        }
    }
}