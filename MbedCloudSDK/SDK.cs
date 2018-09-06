// <copyright file="MbedCloudSDKClient.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using MbedCloudSDK.Common;
using MbedCloudSDK.Entities.User;

namespace MbedCloudSDK
{
    /// <summary>
    /// Client
    /// </summary>
    public partial class SDK
    {
        private static Config config;

        private Config instanceConfig;

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public static Config Config
        {
            get
            {
                if (config != null)
                {
                    return config;
                }

                var sdkConfig = new Config();
                config = sdkConfig;

                return sdkConfig;
            }
        }

        public SDK(string apiKey)
        {
            instanceConfig = new Config(apiKey);
        }

        public SDK(Config config = null)
        {
            if (config != null)
            {
                instanceConfig = config;
            }
        }

        public Config GetConfig()
        {
            return instanceConfig ?? Config;
        }

        public User User() => new User(instanceConfig ?? Config);
    }
}