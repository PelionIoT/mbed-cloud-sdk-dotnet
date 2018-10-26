// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 1.0.0
//
// <copyright file="ApiKey.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace MbedCloud.SDK.Entities
{
    using MbedCloud.SDK.Common;
    using MbedCloud.SDK.Client;
    using System.Collections.Generic;
    using System;
    using MbedCloud.SDK.Enums;
    using MbedCloud.SDK.Entities;
    using System.Threading.Tasks;
    using MbedCloudSDK.Exceptions;

    /// <summary>
    /// ApiKey
    /// </summary>
    public class ApiKey : BaseEntity
    {
        public ApiKey()
        {
            Client = new Client(Config);
        }

        public ApiKey(Config config)
        {
            Config = config;
            Client = new Client(Config);
        }

        internal static Dictionary<string, string> Renames = new Dictionary<string, string>() { { "GroupIds", "groups" }, };

        /// <summary>
        /// created_at
        /// </summary>
        public DateTime? CreatedAt
        {
            get;
            set;
        }

        /// <summary>
        /// creation_time
        /// </summary>
        public long? CreationTime
        {
            get;
            set;
        }

        /// <summary>
        /// group_ids
        /// </summary>
        public List<string> GroupIds
        {
            get;
            set;
        }

        /// <summary>
        /// key
        /// </summary>
        public string Key
        {
            get;
            set;
        }

        /// <summary>
        /// last_login_time
        /// </summary>
        public long? LastLoginTime
        {
            get;
            set;
        }

        /// <summary>
        /// name
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// owner
        /// </summary>
        public string Owner
        {
            get;
            set;
        }

        /// <summary>
        /// status
        /// </summary>
        public ApiKeyStatusEnum? Status
        {
            get;
            set;
        }

        /// <summary>
        /// updated_at
        /// </summary>
        public DateTime? UpdatedAt
        {
            get;
            set;
        }

        public async Task<ApiKey> Create()
        {
            try
            {
                var bodyParams = new ApiKey { GroupIds = GroupIds, Name = Name, Owner = Owner, Status = Status, };
                return await Client.CallApi<ApiKey>(path: "/v3/api-keys", bodyParams: bodyParams, method: HttpMethods.POST, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<ApiKey> Delete()
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "apiKey", Id }, };
                return await Client.CallApi<ApiKey>(path: "/v3/api-keys/{apiKey}", pathParams: pathParams, method: HttpMethods.DELETE, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<ApiKey> Get()
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "apiKey", Id }, };
                return await Client.CallApi<ApiKey>(path: "/v3/api-keys/{apiKey}", pathParams: pathParams, method: HttpMethods.GET, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public PaginatedResponse<QueryOptions, PolicyGroup> Groups(string after = null, string include = null, int limit = 25, string order = null)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "apiKey", Id }, };
                var queryParams = new Dictionary<string, object> { { "after", after }, { "include", include }, { "limit", limit }, { "order", order }, };
                var options = new QueryOptions { After = after, Include = include, Limit = limit, Order = order, };
                Func<QueryOptions, ResponsePage<PolicyGroup>> paginatedFunc = (QueryOptions _options) => AsyncHelper.RunSync<ResponsePage<PolicyGroup>>(() => Client.CallApi<ResponsePage<PolicyGroup>>(path: "/v3/api-keys/{apiKey}/groups", pathParams: pathParams, queryParams: queryParams, method: HttpMethods.GET));
                return new PaginatedResponse<QueryOptions, PolicyGroup>(paginatedFunc, options);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public PaginatedResponse<QueryOptions, ApiKey> List(string after = null, string include = null, int limit = 25, string order = null)
        {
            try
            {
                var queryParams = new Dictionary<string, object> { { "after", after }, { "include", include }, { "limit", limit }, { "order", order }, };
                var options = new QueryOptions { After = after, Include = include, Limit = limit, Order = order, };
                Func<QueryOptions, ResponsePage<ApiKey>> paginatedFunc = (QueryOptions _options) => AsyncHelper.RunSync<ResponsePage<ApiKey>>(() => Client.CallApi<ResponsePage<ApiKey>>(path: "/v3/api-keys", queryParams: queryParams, method: HttpMethods.GET));
                return new PaginatedResponse<QueryOptions, ApiKey>(paginatedFunc, options);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<ApiKey> ResetSecret(string accountId)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "accountID", accountId }, { "apiKey", Id }, };
                return await Client.CallApi<ApiKey>(path: "/v3/accounts/{accountID}/api-keys/{apiKey}/reset-secret", pathParams: pathParams, method: HttpMethods.POST, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<ApiKey> Update()
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "apiKey", Id }, };
                var bodyParams = new ApiKey { GroupIds = GroupIds, Name = Name, Owner = Owner, Status = Status, };
                return await Client.CallApi<ApiKey>(path: "/v3/api-keys/{apiKey}", pathParams: pathParams, bodyParams: bodyParams, method: HttpMethods.PUT, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}