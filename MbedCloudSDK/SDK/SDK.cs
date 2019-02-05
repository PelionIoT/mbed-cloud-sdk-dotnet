// <copyright file="SDK.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace Mbed.Cloud
{
    using Mbed.Cloud.Foundation.Common;
    using Mbed.Cloud.Foundation.RestClient;

    /// <summary>
    /// Client
    /// </summary>
    public partial class SDK
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SDK" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="client">The client.</param>
        public SDK(Config config = null, Client client = null)
        {
            Config = config ?? new Config();
            Client = client ?? new Client(Config);
        }

        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <value>
        /// The client.
        /// </value>
        public Client Client { get; }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public Config Config { get; }

        /// <summary>
        /// Entitieses this instance.
        /// </summary>
        /// <returns>Entity Factory</returns>
        public EntityFactory Entities()
        {
            return new EntityFactory(Config, Client);
        }
    }
}