// <copyright file="SDK.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloud.SDK
{
    using MbedCloud.SDK;
    using MbedCloud.SDK.Common;

    /// <summary>
    /// Client
    /// </summary>
    public partial class SDK
    {
        private static Config config;

        private readonly Config instanceConfig;

        public EntityFactory Entities { get; }

        public MbedCloud.SDK.Client.Client Client { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SDK"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public SDK(Config config = null)
        {
            if (config != null)
            {
                instanceConfig = config;
            }

            Entities = new EntityFactory(GetConfig());
            Client = new MbedCloud.SDK.Client.Client(GetConfig());
        }

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
        /// Gets the configuration.
        /// </summary>
        /// <returns>The current SDK Config</returns>
        public Config GetConfig()
        {
            return instanceConfig ?? Config;
        }
    }
}