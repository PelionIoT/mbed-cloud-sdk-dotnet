using System;
using System.Linq;
using mbedCloudSDK.Common;
using update_service.Client;

namespace mbedCloudSDK.Update.Api
{
    /// <summary>
    /// Exposing functionality from: Update service, Update campaigns and Manifest management
    /// </summary>
    public partial class UpdateApi : BaseApi
    {
        private update_service.Api.DefaultApi api;

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
            api = new update_service.Api.DefaultApi();
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
        }

        public ApiMetadata GetLastApiMetadata()
        {
            return ApiMetadata.Map(update_service.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault());
        }
    }
}
