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
    public partial class DeviceDirectoryApi : BaseApi
    {
        private device_directory.Api.DefaultApi api;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceDirectoryApi"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
        public DeviceDirectoryApi(Config config)
            : base(config)
        {
            device_directory.Client.Configuration.Default.ApiClient = new ApiClient(config.Host);
            device_directory.Client.Configuration.Default.ApiKey["Authorization"] = config.ApiKey;
            device_directory.Client.Configuration.Default.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;

            api = new device_directory.Api.DefaultApi();
        }

        /// <summary>
        /// Get meta data for the last Mbed Cloud API call
        /// </summary>
        /// <returns>Api Metadata</returns>
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
