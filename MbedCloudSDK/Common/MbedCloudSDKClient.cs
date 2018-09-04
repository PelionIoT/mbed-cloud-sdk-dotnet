// <copyright file="MbedCloudSDKClient.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common
{
    /// <summary>
    /// Client
    /// </summary>
    public static class MbedCloudSDKClient
    {
        private static Config config;

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

        /// <summary>
        /// Initializes the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Init(Config config)
        {
            MbedCloudSDKClient.config = config;
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public static void Reset()
        {
            config = null;
        }
    }
}