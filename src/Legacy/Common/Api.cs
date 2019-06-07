// <copyright file="Api.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common
{
    using log4net;
    using Mbed.Cloud;
    using Mbed.Cloud.Common;

    /// <summary>
    /// Base API.
    /// </summary>
    public abstract class Api
    {
        /// <summary>
        /// The log
        /// </summary>
        protected static readonly ILog Log = LogManager.GetLogger(typeof(Api));

        /// <summary>
        /// Gets UserAgent
        /// </summary>
        /// <returns>UserAgent</returns>
        private static string userAgent = $"mbed-cloud-sdk-dotnet/{Version.VersionValue}";

        /// <summary>
        /// Initializes a new instance of the <see cref="Api"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
        protected Api(Config config)
        {
            Config = config;
            Logger.Setup(config.LogLevel);
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
    }
}
