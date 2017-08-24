using System;
using mbedCloudSDK.Common;
using firmware_catalog.Client;

namespace mbedCloudSDK.Update.Api
{
    /// <summary>
    /// Exposing functionality from: Update service, Update campaigns and Manifest management
    /// </summary>
    public partial class UpdateApi : BaseApi
    {
        private deployment_service.Api.DefaultApi deploymentApi;
        private firmware_catalog.Api.DefaultApi firmwareApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.Update"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
        public UpdateApi(Config config) : base(config)
        {
            if (config.Host != string.Empty)
            {
                Configuration.Default.ApiClient = new ApiClient(config.Host);
            }
            this.deploymentApi = new deployment_service.Api.DefaultApi(config.Host);
            this.deploymentApi.Configuration.ApiKey["Authorization"] = config.ApiKey;
            this.deploymentApi.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;

            this.firmwareApi = new firmware_catalog.Api.DefaultApi(config.Host);
            this.firmwareApi.Configuration.ApiKey["Authorization"] = config.ApiKey;
            this.firmwareApi.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
        }
    }
}
