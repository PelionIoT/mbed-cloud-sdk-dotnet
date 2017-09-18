// <copyright file="ApiKey.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.AccountManagement.Model.ApiKey
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using iam.Model;
    using MbedCloudSDK.Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// This object represents an API key in mbed Cloud.
    /// </summary>
    public class ApiKey
    {
        /// <summary>
        /// Gets the status of the API key.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ApiKeyStatus? Status { get; private set; }

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
        public string Key { get; private set; }

        /// <summary>
        /// Gets creation UTC time RFC3339.
        /// </summary>
        /// <value>Creation UTC time RFC3339.</value>
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// Gets the timestamp of the API key creation in the storage, in milliseconds.
        /// </summary>
        public long? CreationTime { get; private set; }

        /// <summary>
        /// Gets a list of group IDs this API key belongs to.
        /// </summary>
        public List<string> Groups { get; private set; }

        /// <summary>
        /// Gets the UUID of the API key.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the timestamp of the latest API key usage, in milliseconds.
        /// </summary>
        public long? LastLoginTime { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiKey"/> class.
        /// Create new instance of api key class.
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
            sb.Append("  Groups: ").Append(Groups).Append("\n");
            sb.Append("  Owner: ").Append(OwnerId).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LastLoginTime: ").Append(LastLoginTime).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Map to ApiKey object.
        /// </summary>
        /// <param name="apiKeyInfo"></param>
        /// <returns></returns>
        public static ApiKey Map(ApiKeyInfoResp apiKeyInfo)
        {
            ApiKeyStatus apiKeyStatus = Utils.ParseEnum<ApiKeyStatus>(apiKeyInfo.Status);
            var apiKey = new ApiKey();
            apiKey.Status = apiKeyStatus;
            apiKey.Key = apiKeyInfo.Key;
            apiKey.Name = apiKeyInfo.Name;
            apiKey.CreatedAt = apiKeyInfo.CreatedAt;
            apiKey.CreationTime = apiKeyInfo.CreationTime;
            apiKey.Groups = apiKeyInfo.Groups;
            apiKey.OwnerId = apiKeyInfo.Owner;
            apiKey.Id = apiKeyInfo.Id;
            apiKey.LastLoginTime = apiKeyInfo.LastLoginTime;
            return apiKey;
        }

        public ApiKeyInfoReq CreatePostRequest()
        {
            ApiKeyInfoReq request = new ApiKeyInfoReq(Owner: OwnerId, Status: Utils.ParseEnum<ApiKeyInfoReq.StatusEnum>(Status), Name: Name);
            return request;
        }

        public ApiKeyUpdateReq CreatePutRequest()
        {
            var x = Status;
            ApiKeyUpdateReq request = new ApiKeyUpdateReq(Owner: OwnerId, Name: Name);
            return request;
        }
    }
}
