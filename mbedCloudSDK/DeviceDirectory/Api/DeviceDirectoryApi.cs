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
        private device_catalog.Api.DefaultApi api;
        private device_query_service.Api.DefaultApi queryApi;

        #region Contructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.DeviceDirectory.DeviceDirectory"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
        public DeviceDirectoryApi(Config config) : base(config)
        {
            this.api = new device_catalog.Api.DefaultApi(config.Host);
            this.api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            this.api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;

            this.queryApi = new device_query_service.Api.DefaultApi();
            this.queryApi.Configuration.ApiKey["Authorization"] = config.ApiKey;
            this.queryApi.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
        }

        #endregion

        #region Utils

        private string FixedPath(string path)
        {
            if (path.StartsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                path = path.Substring(1);
            }
            return path;
        }

        #endregion
    }
}
