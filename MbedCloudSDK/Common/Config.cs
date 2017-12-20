// <copyright file="Config.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common
{
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
        /// <param name="forceClear">Auto start notifications. If true, notifications will start automatically when required.</param>
        public Config(string apiKey, string host = "https://api.us-east-1.mbedcloud.com", bool forceClear = false, string authorizationPrefix = "Bearer")
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            AuthorizationPrefix = authorizationPrefix;
            ApiKey = apiKey;
            Host = host;
            ForceClear = forceClear;
        }

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>The host.</value>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to clear any existing notification channels
        /// </summary>
        /// <value>If true, notifications will start automaticaly</value>
        public bool ForceClear { get; set; }

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
