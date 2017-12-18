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
    using MbedCloudSDK.Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// This object represents an API key in Mbed Cloud.
    /// </summary>
    public class ApiKey
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiKey"/> class.
        /// Create new instance of API key class.
        /// </summary>
        /// <param name="options">Dictionary containing properties.</param>
        public ApiKey(IDictionary<string, object> options = null)
        {
            if (options != null)
            {
                foreach (KeyValuePair<string, object> item in options)
                {
                    var property = GetType().GetProperty(item.Key);
                    if (property != null)
                    {
                        property.SetValue(this, item.Value, null);
                    }
                }
            }
        }

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
        /// Gets or sets the UUID of the API key.
        /// </summary>
        public string Id { get; set; }

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
            var apiKeyStatus = Utils.ParseEnum<ApiKeyStatus>(apiKeyInfo.Status);
            var apiKey = new ApiKey
            {
                Status = apiKeyStatus,
                Key = apiKeyInfo.Key,
                Name = apiKeyInfo.Name,
                CreatedAt = apiKeyInfo.CreatedAt,
                CreationTime = apiKeyInfo.CreationTime,
                Groups = apiKeyInfo.Groups != null ? apiKeyInfo.Groups : Enumerable.Empty<string>().ToList(),
                OwnerId = apiKeyInfo.Owner,
                Id = apiKeyInfo.Id,
                LastLoginTime = apiKeyInfo.LastLoginTime
            };
            return apiKey;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:MbedCloudSDK.AccountManagement.Model.ApiKey.ApiKey"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:MbedCloudSDK.AccountManagement.Model.ApiKey.ApiKey"/>.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApiKey {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Apikey: ").Append(Key).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  CreationTime: ").Append(CreationTime).Append("\n");
            sb.Append("  Groups: ").Append(Groups.Any() ? string.Join(", ", Groups) : string.Empty).Append("\n");
            sb.Append("  Owner: ").Append(OwnerId).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LastLoginTime: ").Append(LastLoginTime).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// create post request
        /// </summary>
        /// <returns>Api key info</returns>
        public ApiKeyInfoReq CreatePostRequest()
        {
            var request = new ApiKeyInfoReq(Owner: OwnerId, Status: Utils.ParseEnum<ApiKeyInfoReq.StatusEnum>(Status), Name: Name);
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
