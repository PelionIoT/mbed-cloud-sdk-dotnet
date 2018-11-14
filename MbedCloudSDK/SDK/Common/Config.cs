namespace MbedCloud.SDK.Common
{
    using System;
    using System.IO;
    using System.Linq;
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
                DotNetEnv.Env.Load(envDirectory);
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

                var clientConfig = new MbedCloud.SDK.Client.Configuration
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
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        [JsonIgnore]
        public MbedCloud.SDK.Client.Configuration Configuration { get; internal set; }

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
                var envFile = Directory.GetFiles(currentDirectory, ".env") ?? Enumerable.Empty<string>().ToArray();
                if (envFile.Length == 0)
                {
                    var parentDirectory = Directory.GetParent(currentDirectory);
                    return FindDotEnv(parentDirectory.FullName);
                }

                Console.WriteLine($"found .env in {envFile.FirstOrDefault()}");
                return envFile.FirstOrDefault();
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("no .env found in directory");
                return null;
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
    }
}