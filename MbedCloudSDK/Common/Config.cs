// <copyright file="Config.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common
{
    using System;
    using System.Net;

    /// <summary>
    /// Config for cloud API.
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Config"/> class.
        /// </summary>
        /// <param name="apiKey"><see cref="ApiKey"/></param>
        /// <param name="host">Host url</param>
        /// <param name="authorizationPrefix">Authorization prefix</param>
        /// <param name="forceClear">Force clear notification channel. If true, when adding a webhook, notifications will be stopped.</param>
        /// <param name="autostartNotifications">Auto start notifications. If true, notifications will start automatically when required.</param>
        public Config(string apiKey, string host = "https://api.us-east-1.mbedcloud.com", bool forceClear = false, bool autostartNotifications = false, string authorizationPrefix = "Bearer")
        {
            AuthorizationPrefix = authorizationPrefix;
            ApiKey = apiKey;
            Host = host;
            ForceClear = forceClear;
            AutostartNotifications = autostartNotifications;
        }

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>The host.</value>
        public string Host { get; set; }

        /// <summary>
        /// Gets a value indicating whether to clear any existing notification channels
        /// </summary>
        /// <value>If true, notifications will start automaticaly</value>
        public bool ForceClear { get; }

        /// <summary>
        /// Gets or sets a value indicating whether to auto start notifications
        /// </summary>
        public bool AutostartNotifications { get; set; }

        /// <summary>
        /// Gets the API key.
        /// </summary>
        /// <value>The API key.</value>
        public string ApiKey { get; }

        /// <summary>
        /// Gets the authorization prefix.
        /// </summary>
        /// <value>The authorization prefix.</value>
        public string AuthorizationPrefix { get; }
    }
}
