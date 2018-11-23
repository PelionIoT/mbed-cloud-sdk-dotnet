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
        private readonly Config _config;

        public EntityFactory Entities { get; }

        public MbedCloud.SDK.Client.Client Client { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SDK"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public SDK(Config config = null)
        {
            _config = config ?? new Config();

            Entities = new EntityFactory(GetConfig());
            Client = new MbedCloud.SDK.Client.Client(GetConfig());
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public Config Config
        {
            get
            {
                return _config;
            }
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <returns>The current SDK Config</returns>
        public Config GetConfig()
        {
            return _config;
        }
    }
}