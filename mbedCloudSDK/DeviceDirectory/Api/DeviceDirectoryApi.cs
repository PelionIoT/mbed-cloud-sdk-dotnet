using System;
using mbedCloudSDK.Common;


namespace mbedCloudSDK.DeviceDirectory.Api
{
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
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.DeviceDirectory.DeviceDirectory"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
        public DeviceDirectoryApi(Config config) : base(config)
        {
            api = new device_directory.Api.DefaultApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
        }
        private string FixedPath(string path)
        {
            if (path.StartsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                path = path.Substring(1);
            }
            return path;
        }
    }
}
