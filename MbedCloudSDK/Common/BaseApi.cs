// <copyright file="BaseApi.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common
{
    using Mbed.Cloud.Foundation.Common;

    /// <summary>
    /// Base API.
    /// </summary>
    public class BaseApi
    {
        /// <summary>
        /// Gets UserAgent
        /// </summary>
        /// <returns>UserAgent</returns>
        private static string userAgent = $"mbed-cloud-sdk-dotnet/{Version.VersionValue}";

        /// <summary>
        /// Config used to initialize APIs. It stores host and API key information.
        /// </summary>
        private Config config;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseApi"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
        public BaseApi(Config config)
        {
            this.config = config;
        }

        /// <summary>
        /// Gets or sets the user agent.
        /// </summary>
        /// <value>
        /// The user agent.
        /// </value>
        public static string UserAgent { get => userAgent; set => userAgent = value; }

        /// <summary>
        /// Gets or sets config
        /// </summary>
        public Config Config { get => config; set => config = value; }
    }
}
