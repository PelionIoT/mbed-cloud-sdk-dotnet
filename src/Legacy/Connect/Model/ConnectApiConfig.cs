// <copyright file="ConnectApiConfig.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api
{
    using Mbed.Cloud.Common;

    /// <summary>
    /// ConnectApiConfig
    /// </summary>
    /// <seealso cref="Mbed.Cloud.Common.Config" />
    public class ConnectApiConfig : Config
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectApiConfig"/> class.
        /// </summary>
        public ConnectApiConfig()
            : base(null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectApiConfig"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public ConnectApiConfig(string apiKey)
            : base(apiKey, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectApiConfig"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="host">The host.</param>
        public ConnectApiConfig(string apiKey, string host)
            : base(apiKey, host)
        {
        }

        /// <summary>
        /// Gets a value indicating whether [skip cleanup].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [skip cleanup]; otherwise, <c>false</c>.
        /// </value>
        public bool SkipCleanup { get; }
    }
}