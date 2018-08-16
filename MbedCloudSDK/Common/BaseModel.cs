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
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty]
        public string Id { get; set; }

        private static MbedCloudSDK.Client.Configuration _config;

        [JsonIgnore]
        public static MbedCloudSDK.Client.Configuration Config {
            get
            {
                if (_config != null)
                {
                    return _config;
                }

                var sdkConfig = new Config();

                var clientConfig = new MbedCloudSDK.Client.Configuration
                {
                    BasePath = sdkConfig.Host,
                    DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss.fffZ",
                };
                clientConfig.AddApiKey("Authorization", sdkConfig.ApiKey);
                clientConfig.AddApiKeyPrefix("Authorization", sdkConfig.AuthorizationPrefix);
                clientConfig.CreateApiClient();

                return clientConfig;
            }
            set
            {
                _config = value;
            }
        }
    }
}