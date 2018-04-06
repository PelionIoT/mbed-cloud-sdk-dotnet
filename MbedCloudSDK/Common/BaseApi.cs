// <copyright file="BaseApi.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common
{
    /// <summary>
    /// Base API.
    /// </summary>
    public class BaseApi
    {
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
        /// Gets or sets config
        /// </summary>
        protected Config Config { get => config; set => config = value; }

        /// <summary>
        /// Gets UserAgent
        /// </summary>
        /// <returns></returns>
        public static string UserAgent = $"mbed-cloud-sdk-dotnet/{Version.version}";
    }
}
