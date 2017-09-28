// <copyright file="Config.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System.Net;

namespace MbedCloudSDK.Common
{
    /// <summary>
    /// Config for cloud API.
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Config"/> class.
        /// </summary>
        /// <param name="apiKey">API key.</param>
        /// <param name="host">Host url</param>
        /// <param name="authorizationPrefix">Authorization prefix</param>
        public Config(string apiKey, string host = "https://api.us-east-1.mbedcloud.com", string authorizationPrefix = "Bearer")
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            AuthorizationPrefix = authorizationPrefix;
            ApiKey = apiKey;
            Host = host;
        }

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>The host.</value>
        public string Host { get; set; }

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
