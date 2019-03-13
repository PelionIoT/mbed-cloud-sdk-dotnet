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

            if (!string.IsNullOrEmpty(setkey))
            {
                ApiKey = setkey;
            }

            if (!string.IsNullOrEmpty(setHost))
            {
                Host = setHost;
            }

            // if either is still null then look in .env file
            if (string.IsNullOrEmpty(setkey) || string.IsNullOrEmpty(setHost))
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
                    ApiKey = DotNetEnv.Env.GetString(API_KEY, setkey);
                    if (string.IsNullOrEmpty(ApiKey))
                    {
                        ApiKey = "default";
                    }

                    Host = DotNetEnv.Env.GetString(HOST, setHost ?? "https://api.us-east-1.mbedcloud.com");
                }
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