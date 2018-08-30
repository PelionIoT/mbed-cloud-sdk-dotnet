// <copyright file="BaseModel.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common
{
    using Newtonsoft.Json;

    /// <summary>
    /// BaseModel
    /// </summary>
    public abstract class BaseModel
    {
        [JsonIgnore]
        private Config _config;

        [JsonIgnore]
        public Config Config
        {
            get => _config ?? MbedCloudSDKClient.Config;
            set => _config = value;
        }

        /// <summary>
        /// Gets or sets gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty]
        public string Id { get; set; }
    }
}