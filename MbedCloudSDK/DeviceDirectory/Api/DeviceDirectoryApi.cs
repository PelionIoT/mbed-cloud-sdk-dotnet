// <copyright file="DeviceDirectoryApi.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.DeviceDirectory.Api
{
    using System;
    using System.Linq;
    using device_directory.Client;
    using MbedCloudSDK.Common;

    /// <summary>
    /// Exposing functionality from the following underlying services:
    /// - Connector / mDS
    /// - Device query service
    /// - Device catalog
    /// </summary>
    /// <example>
    /// This API is intialized with a <see cref="Config"/> object.
    /// <code>
    /// using MbedCloudSDK.Common;
    /// var config = new config(apiKey);
    /// var deviceApi = new DeviceDirectoryApi(config);
    /// </code>
    /// </example>
    public partial class DeviceDirectoryApi : BaseApi
    {
        private device_directory.Api.DefaultApi api;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceDirectoryApi"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
        /// <example>
        /// This API is intialized with a <see cref="Config"/> object.
        /// <code>
        /// using MbedCloudSDK.Common;
        /// var config = new config(apiKey);
        /// var deviceApi = new DeviceDirectoryApi(config);
        /// </code>
        /// </example>
        public DeviceDirectoryApi(Config config)
            : base(config)
        {
            var deviceConfig = new device_directory.Client.Configuration
            {
                BasePath = config.Host,
                DateTimeFormat = "yyyy-MM-dd",
            };
            deviceConfig.AddApiKey("Authorization", config.ApiKey);
            deviceConfig.AddApiKeyPrefix("Authorization", config.AuthorizationPrefix);
            deviceConfig.CreateApiClient();

            api = new device_directory.Api.DefaultApi(deviceConfig);
        }

        /// <summary>
        /// Get meta data for the last Mbed Cloud API call
        /// </summary>
        /// <returns><see cref="ApiMetadata"/></returns>
        public static ApiMetadata GetLastApiMetadata()
        {
            return ApiMetadata.Map(device_directory.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault());
        }

        private static string FixedPath(string path)
        {
            if (path.StartsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                path = path.Substring(1);
            }

            return path;
        }
    }
}
