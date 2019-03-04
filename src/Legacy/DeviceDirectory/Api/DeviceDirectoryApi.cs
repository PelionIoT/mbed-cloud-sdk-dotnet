// <copyright file="DeviceDirectoryApi.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.DeviceDirectory.Api
{
    using System;
    using System.Linq;
    using device_directory.Api;
    using device_directory.Client;
    using Mbed.Cloud.Common;
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
    public partial class DeviceDirectoryApi : Api
    {
        private DefaultApi api;

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
            SetUpApi(config);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceDirectoryApi" /> class.
        /// </summary>
        /// <param name="config">Config.</param>
        /// <param name="deviceConfig">The device configuration.</param>
        /// <example>
        /// This API is intialized with a <see cref="Config" /> object.
        /// <code>
        /// using MbedCloudSDK.Common;
        /// var config = new config(apiKey);
        /// var deviceApi = new DeviceDirectoryApi(config);
        /// </code></example>
        internal DeviceDirectoryApi(Config config, device_directory.Client.Configuration deviceConfig = null)
            : base(config)
        {
            SetUpApi(config, deviceConfig);
        }

        /// <summary>
        /// Gets or sets the API.
        /// </summary>
        /// <value>
        /// The API.
        /// </value>
        internal DefaultApi Api { get => api; set => api = value; }

        /// <summary>
        /// Get meta data for the last Mbed Cloud API call
        /// </summary>
        /// <returns><see cref="ApiMetadata"/></returns>
        public static ApiMetadata GetLastApiMetadata()
        {
            return ApiMetadata.Map(Configuration.Default.ApiClient.LastApiResponse.LastOrDefault());
        }

        private void SetUpApi(Config config, Configuration deviceConfig = null)
        {
            if (deviceConfig == null)
            {
                deviceConfig = new Configuration
                {
                    BasePath = config.Host,
                    DateTimeFormat = "yyyy-MM-dd",
                    UserAgent = UserAgent,
                };
                deviceConfig.AddApiKey("Authorization", config.ApiKey);
                deviceConfig.AddApiKeyPrefix("Authorization", config.AuthorizationPrefix);
                deviceConfig.CreateApiClient();
            }

            Api = new DefaultApi(deviceConfig);
        }
    }
}
