// <copyright file="AccountManagementApi.Account.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
namespace MbedCloudSDK.Accounts.ApiKey
{
    using MbedCloudSDK.Common;
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Threading.Tasks;
    using MbedCloudSDK.Client;
    using MbedCloudSDK.Exceptions;
    using RestSharp;
    using MbedCloudSDK.Common.Extensions;

    /// <summary>
    /// ApiKey
    /// </summary>
    public partial class ApiKey : BaseModel
    {
        /// <summary>
        /// Creation UTC time RFC3339.
        /// </summary>
        public DateTime CreatedAt
        {
            get;
            set;
        }

        /// <summary>
        /// The timestamp of the API key creation in the storage, in milliseconds.
        /// </summary>
        public int CreationTime
        {
            get;
            set;
        }

        /// <summary>
        /// A list of group IDs this API key belongs to.
        /// </summary>
        public List<string> Groups
        {
            get;
            set;
        }

        /// <summary>
        /// The API key.
        /// </summary>
        public string Key
        {
            get;
            set;
        }

        /// <summary>
        /// The timestamp of the latest API key usage, in milliseconds.
        /// </summary>
        public int LastLoginTime
        {
            get;
            set;
        }

        /// <summary>
        /// The display name for the API key.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The owner of this API key, who is the creator by default.
        /// </summary>
        public string Owner
        {
            get;
            set;
        }

        /// <summary>
        /// The status of the API key.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ApiKeyStatusEnum Status
        {
            get;
            set;
        }

        /// <summary>
        /// Last update UTC time RFC3339.
        /// </summary>
        public DateTime UpdatedAt
        {
            get;
            set;
        }

        public async Task<ApiKey> Create()
        {
            var renames = new Dictionary<string, string>();
            try
            {
                return await MbedCloudSDK.Client.ApiCall.CallApi<ApiKey>(path: "/v3/api-keys", method: Method.POST, pathParams: new Dictionary<string, object>()
                {{"apiKey", Id}}, configuration: Config);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<ApiKey> Delete()
        {
            var renames = new Dictionary<string, string>();
            try
            {
                return await MbedCloudSDK.Client.ApiCall.CallApi<ApiKey>(path: "/v3/api-keys/{apiKey}", method: Method.DELETE, pathParams: new Dictionary<string, object>()
                {{"apiKey", Id}}, configuration: Config);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<ApiKey> GroupIds()
        {
            var renames = new Dictionary<string, string>();
            try
            {
                return await MbedCloudSDK.Client.ApiCall.CallApi<ApiKey>(path: "/v3/api-keys/me/groups", method: Method.GET, pathParams: new Dictionary<string, object>()
                {{"apiKey", Id}}, configuration: Config);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<ApiKey> List()
        {
            var renames = new Dictionary<string, string>();
            try
            {
                return await MbedCloudSDK.Client.ApiCall.CallApi<ApiKey>(path: "/v3/api-keys", method: Method.GET, pathParams: new Dictionary<string, object>()
                {{"apiKey", Id}}, configuration: Config);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<ApiKey> Read()
        {
            var renames = new Dictionary<string, string>();
            try
            {
                return await MbedCloudSDK.Client.ApiCall.CallApi<ApiKey>(path: "/v3/api-keys/{apiKey}", method: Method.GET, pathParams: new Dictionary<string, object>()
                {{"apiKey", Id}}, configuration: Config);
            }
            catch (MbedCloudSDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<ApiKey> Update()
        {
            var renames = new Dictionary<string, string>();
            try
            {
                return await MbedCloudSDK.Client.ApiCall.CallApi<ApiKey>(path: "/v3/api-keys/{apiKey}", method: Method.PUT, pathParams: new Dictionary<string, object>()
                {{"apiKey", Id}}, configuration: Config);
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
        public override string ToString() => this.DebugDump();
    }
}