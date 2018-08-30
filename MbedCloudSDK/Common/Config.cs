// <copyright file="Config.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common
{
    using System;
    using System.Net;
    using MbedCloudSDK.Exceptions;
    using Newtonsoft.Json;

    /// <summary>
    /// Config for MbedCloud
    /// </summary>
    public class Config
    {
        /// <summary>
        /// The API key environment key
        /// </summary>
        public const string API_KEY = "MBED_CLOUD_SDK_API_KEY";

        /// <summary>
        /// The host environment key
        /// </summary>
        public const string HOST = "MBED_CLOUD_SDK_HOST";

        /// <summary>
        /// The log level environment key
        /// </summary>
        public const string LOG_LEVEL = "MBED_CLOUD_SDK_LOG_LEVEL";

        [JsonIgnore]
        public MbedCloudSDK.Client.Configuration Configuration { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Config"/> class.
        /// </summary>
        public Config()
        : this(null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Config"/> class.
        /// </summary>
        /// <param name="forceClear">if set to <c>true</c> [force clear].</param>
        /// <param name="autostartNotifications">if set to <c>true</c> [autostart notifications].</param>
        public Config(bool forceClear = false, bool autostartNotifications = false)
        : this(null, null, forceClear, autostartNotifications)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Config"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public Config(string apiKey)
        : this(apiKey, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Config"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="host">The host.</param>
        /// <param name="forceClear">if set to <c>true</c> [force clear].</param>
        /// <param name="autostartNotifications">if set to <c>true</c> [autostart notifications].</param>
        /// <exception cref="ConfigurationException">No Api Key provided!</exception>
        public Config(string apiKey, string host, bool forceClear = false, bool autostartNotifications = false)
        {
            try
            {
                DotNetEnv.Env.Load();
            }
            catch (System.IO.FileNotFoundException)
            {
            }
            finally
            {
                ApiKey = apiKey ?? DotNetEnv.Env.GetString(API_KEY, Environment.GetEnvironmentVariable(API_KEY));
                if (string.IsNullOrEmpty(ApiKey))
                {
                    throw new ConfigurationException("No Api Key provided!");
                }

                Host = host ?? DotNetEnv.Env.GetString(HOST, Environment.GetEnvironmentVariable(HOST) ?? "https://api.us-east-1.mbedcloud.com");
                ForceClear = forceClear;
                AutostartNotifications = autostartNotifications;

                var clientConfig = new MbedCloudSDK.Client.Configuration
                {
                    BasePath = Host,
                    DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss.fffZ",
                };
                clientConfig.AddApiKey("Authorization", ApiKey);
                clientConfig.AddApiKeyPrefix("Authorization", AuthorizationPrefix);
                clientConfig.CreateApiClient();

                Configuration = clientConfig;
            }
        }

        /// <summary>
        /// Gets the host.
        /// </summary>
        /// <value>The host.</value>
        public string Host { get; }

        /// <summary>
        /// Gets a value indicating whether to clear any existing notification channels
        /// </summary>
        /// <value>If true, notifications will start automaticaly</value>
        public bool ForceClear { get; }

        /// <summary>
        /// Gets a value indicating whether to auto start notifications
        /// </summary>
        public bool AutostartNotifications { get; }

        /// <summary>
        /// Gets the API key.
        /// </summary>
        /// <value>The API key.</value>
        public string ApiKey { get; }

        /// <summary>
        /// Gets the authorization prefix.
        /// </summary>
        /// <value>The authorization prefix.</value>
        public string AuthorizationPrefix { get; } = "Bearer";
    }
}
