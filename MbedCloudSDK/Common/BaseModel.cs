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
        private static MbedCloudSDK.Client.Configuration config;

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        [JsonIgnore]
        public static MbedCloudSDK.Client.Configuration Config
        {
            get
            {
                if (config != null)
                {
                    return config;
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
                config = value;
            }
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