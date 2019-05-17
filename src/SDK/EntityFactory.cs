// <copyright file="EntityFactory.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace Mbed.Cloud.Foundation.Factories
{
    using Mbed.Cloud.Common;
    using Mbed.Cloud.RestClient;

    /// <summary>
    /// Entity Factory
    /// </summary>
    public partial class FoundationFactory
    {
        private Client client;

        private Config config;

        /// <summary>
        /// Initializes a new instance of the <see cref="FoundationFactory"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="client">The client.</param>
        public FoundationFactory(Config config, Client client)
        {
            this.config = config;
            this.client = client;
        }
    }
}