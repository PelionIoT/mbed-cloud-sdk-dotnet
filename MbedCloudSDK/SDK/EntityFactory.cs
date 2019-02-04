// <copyright file="EntityFactory.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace Mbed.Cloud
{
    using Mbed.Cloud.Foundation.Common;
    using Mbed.Cloud.Foundation.RestClient;

    /// <summary>
    /// Entity Factory
    /// </summary>
    public partial class EntityFactory
    {
        private Client client;

        private Config config;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityFactory"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="client">The client.</param>
        public EntityFactory(Config config, Client client)
        {
            this.config = config;
            this.client = client;
        }
    }
}