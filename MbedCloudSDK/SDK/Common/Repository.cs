// <copyright file="Repository.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace Mbed.Cloud.Foundation.Common
{
    using Mbed.Cloud.Foundation.RestClient;

    /// <summary>
    /// Repository
    /// </summary>
    public class Repository
    {
        /// <summary>
        /// The client
        /// </summary>
        protected readonly Client Client;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="client">The client.</param>
        public Repository(Config config = null, Client client = null)
        {
            Config = config ?? new Config();
            Client = client ?? new Client(Config);
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public Config Config { get; }
    }
}