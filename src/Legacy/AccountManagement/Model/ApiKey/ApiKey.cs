// <copyright file="ApiKey.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.AccountManagement.Model.ApiKey
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using iam.Model;
    using Mbed.Cloud.Common;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// This object represents an API key in Mbed Cloud.
    /// </summary>
    public class ApiKey : Entity
    {
        /// <summary>
        /// Gets or sets the status of the API key.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ApiKeyStatus? Status { get; set; }

        /// <summary>
        /// Gets or sets the display name for the API key.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the owner of this API key, who is the creator by default.
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// Gets the API key.
        /// </summary>
        [JsonProperty]
        public string Key { get; private set; }

        /// <summary>
        /// Gets creation UTC time RFC3339.
        /// </summary>
        /// <value>Creation UTC time RFC3339.</value>
        [JsonProperty]
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// Gets the timestamp of the API key creation in the storage, in milliseconds.
        /// </summary>
        [JsonProperty]
        public long? CreationTime { get; private set; }

        /// <summary>
        /// Gets a list of group IDs this API key belongs to.
        /// </summary>
        [JsonProperty]
        public List<string> Groups { get; private set; }

        /// <summary>
        /// Gets the timestamp of the latest API key usage, in milliseconds.
        /// </summary>
        [JsonProperty]
        public long? LastLoginTime { get; private set; }

        /// <summary>
        /// Map to ApiKey object.
        /// </summary>
        /// <param name="apiKeyInfo">api key info</param>
        /// <returns>api key</returns>
        public static ApiKey Map(ApiKeyInfoResp apiKeyInfo)
        {
            var apiKey = new ApiKey
            {
                Status = apiKeyInfo.Status.ParseEnum<ApiKeyStatus>(),
                Key = apiKeyInfo.Key,
                Name = apiKeyInfo.Name,
                CreatedAt = apiKeyInfo.CreatedAt.ToNullableUniversalTime(),
                CreationTime = apiKeyInfo.CreationTime,
                Groups = apiKeyInfo.Groups ?? Enumerable.Empty<string>().ToList(),
                OwnerId = apiKeyInfo.Owner,
                Id = apiKeyInfo.Id,
                LastLoginTime = apiKeyInfo.LastLoginTime
            };
            return apiKey;
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();

        /// <summary>
        /// create post request
        /// </summary>
        /// <returns>Api key info</returns>
        public ApiKeyInfoReq CreatePostRequest()
        {
            ApiKeyInfoReq.StatusEnum? status = null;
            if (Status.HasValue)
            {
                status = Status.ParseEnum<ApiKeyInfoReq.StatusEnum>();
            }

            var request = new ApiKeyInfoReq(Owner: OwnerId, Status: status, Name: Name, Groups: Groups);
            return request;
        }

        /// <summary>
        /// Create put request
        /// </summary>
        /// <returns>api key update request</returns>
        public ApiKeyUpdateReq CreatePutRequest()
        {
            var request = new ApiKeyUpdateReq(Owner: OwnerId, Name: Name);
            return request;
        }
    }
}
