// <copyright file="Config.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace Mbed.Cloud.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using MbedCloudSDK.Exceptions;

    /// <summary>
    /// Config for MbedCloud
    /// </summary>
    public class Config
    {
        private bool dotEnvLoaded = false;
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
        public Config(string apiKey, string host)
        {
            // check if key and host were set in constructor or environment variables
            var setkey = apiKey ?? Environment.GetEnvironmentVariable(API_KEY);
            var setHost = host ?? Environment.GetEnvironmentVariable(HOST);

            if (string.IsNullOrEmpty(setkey))
            {
                ApiKey = LoadFromEnvironment(API_KEY, "default");
            }
            else
            {
                ApiKey = setkey;
            }

            if (string.IsNullOrEmpty(setHost))
            {
                Host = LoadFromEnvironment(HOST, "https://api.us-east-1.mbedcloud.com");
            }
            else
            {
                Host = setHost;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Config"/> class.
        /// </summary>
        /// <param name="initialParams">The initial parameters.</param>
        internal Config(Dictionary<string, object> initialParams)
            : this((string)initialParams.FirstOrDefault(p => p.Key == "api_key").Value, (string)initialParams.FirstOrDefault(p => p.Key == "host").Value)
        {
            // TODO assign other params from dict
        }

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

        /// <summary>
        /// Gets or sets a value indicating whether to auto start notifications
        /// </summary>
        /// <value>
        ///   <c>true</c> if [autostart notifications]; otherwise, <c>false</c>.
        /// </value>
        public bool AutostartNotifications { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether to clear any existing notification channels
        /// </summary>
        /// <value>
        /// If true, notifications will start automaticaly
        /// </value>
        public bool ForceClear { get; set; } = false;

        /// <summary>
        /// Gets the host.
        /// </summary>
        /// <value>The host.</value>
        public string Host { get; } = "https://api.us-east-1.mbedcloud.com";

        /// <summary>
        /// Gets or sets the log level.
        /// </summary>
        /// <value>
        /// The log level.
        /// </value>
        public LogLevel LogLevel { get; set; } = LogLevel.OFF;

        private string FindDotEnv(string currentDirectory)
        {
            try
            {
                return Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, ".env", SearchOption.AllDirectories).FirstOrDefault();
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine(".env in unreachable directory");
                return null;
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("no .env found in directory");
                return null;
            }
        }

        private void LoadDotEnv()
        {
            try
            {
                var envDirectory = FindDotEnv(Directory.GetCurrentDirectory());
                if (string.IsNullOrEmpty(envDirectory))
                {
                    DotNetEnv.Env.Load();
                }
                else
                {
                    DotNetEnv.Env.Load(envDirectory);
                }

                dotEnvLoaded = true;
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("No .env file provided.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Can't load .env from this directory");
            }
        }

        private string LoadFromEnvironment(string key, string defaultValue = null)
        {
            if (!dotEnvLoaded)
            {
                LoadDotEnv();
            }

            return DotNetEnv.Env.GetString(key, defaultValue);
        }
    }
}