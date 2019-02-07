// <copyright file="BaseApi.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common
{
    using System;
    using log4net;
    using Mbed.Cloud.Foundation.Common;

    /// <summary>
    /// Base API.
    /// </summary>
    public abstract class Api
    {
        /// <summary>
        /// Gets UserAgent
        /// </summary>
        /// <returns>UserAgent</returns>
        private static string userAgent = $"mbed-cloud-sdk-dotnet/{Version.VersionValue}";

        /// <summary>
        /// Initializes a new instance of the <see cref="Api"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
        public Api(Config config)
        {
            Config = config;

            Console.WriteLine(config.LogLevel);
            Logger.Setup(config.LogLevel);
        }

        /// <summary>
        /// Gets or sets the user agent.
        /// </summary>
        /// <value>
        /// The user agent.
        /// </value>
        public static string UserAgent { get => userAgent; set => userAgent = value; }

        /// <summary>
        /// Gets config
        /// </summary>
        public Config Config { get; }

        protected static readonly ILog log = LogManager.GetLogger(typeof(Api));
    }
}
