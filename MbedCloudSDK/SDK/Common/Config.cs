// <copyright file="Config.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace Mbed.Cloud.Foundation.Common
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
                var envDirectory = FindDotEnv(Directory.GetCurrentDirectory());
                if (string.IsNullOrEmpty(envDirectory))
                {
                    DotNetEnv.Env.Load();
                }
                else
                {
                    DotNetEnv.Env.Load(envDirectory);
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("No .env file provided.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Can't load .env from this directory");
            }
            finally
            {
                ApiKey = apiKey ?? DotNetEnv.Env.GetString(API_KEY, Environment.GetEnvironmentVariable(API_KEY));
                if (string.IsNullOrEmpty(ApiKey))
                {
                    ApiKey = "default";
                }

                Host = host ?? DotNetEnv.Env.GetString(HOST, Environment.GetEnvironmentVariable(HOST) ?? "https://api.us-east-1.mbedcloud.com");
                ForceClear = forceClear;
                AutostartNotifications = autostartNotifications;
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
        /// Gets a value indicating whether to auto start notifications
        /// </summary>
        public bool AutostartNotifications { get; }

        /// <summary>
        /// Gets a value indicating whether to clear any existing notification channels
        /// </summary>
        /// <value>If true, notifications will start automaticaly</value>
        public bool ForceClear { get; }

        /// <summary>
        /// Gets the host.
        /// </summary>
        /// <value>The host.</value>
        public string Host { get; }

        private string FindDotEnv(string currentDirectory)
        {
            try
            {
                // search current directory for .env
                var envFile = Directory.GetFiles(currentDirectory, ".env");
                if (envFile.Length == 0)
                {
                    // no env found so check parent directory
                    var parentDirectory = Directory.GetParent(currentDirectory);
                    if (parentDirectory == null)
                    {
                        // reached top of file directory
                        return null;
                    }

                    // search the parent directory
                    return FindDotEnv(parentDirectory.FullName);
                }

                // found an env
                Console.WriteLine($"found .env in {envFile.FirstOrDefault()}");
                return envFile.FirstOrDefault();
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("no .env found in directory");
                return null;
            }
        }
    }
}