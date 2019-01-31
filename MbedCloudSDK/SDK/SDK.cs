// <copyright file="SDK.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using Mbed.Cloud.Foundation.Common;
using Mbed.Cloud.Foundation.RestClient;

namespace Mbed.Cloud
{
    /// <summary>
    /// Client
    /// </summary>
    public partial class SDK
    {
        private readonly Config _config;

        public Client Client { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SDK"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public SDK(Config config = null, Client client = null)
        {
            _config = config ?? new Config();
            Client = new Client(_config);
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

        public EntityFactory Entities()
        {
            return new EntityFactory(_config, Client);
        }
    }
}