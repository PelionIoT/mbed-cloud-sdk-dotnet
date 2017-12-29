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
        /// <param name="forceClear">Auto start notifications. If true, notifications will start automatically when required.</param>
        /// <param name="setSecurity">If true, SecurityProtocol will be set. Required for .NET 4.6 but depreciated in .NET Core. If using .NET Core, set to false.</param>
        public Config(string apiKey, string host = "https://api.us-east-1.mbedcloud.com", bool setSecurity = true, bool forceClear = false, string authorizationPrefix = "Bearer")
        {
            if (setSecurity)
            {
                try
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                }
                catch (Exception e)
                {
                    Console.WriteLine("ServicePointManager depreciated in .NET Core");
                    Console.WriteLine(e);
                }
            }

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
