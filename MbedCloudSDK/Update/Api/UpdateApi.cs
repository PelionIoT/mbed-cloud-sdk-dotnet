// <copyright file="UpdateApi.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Api
{
    using System.Linq;
    using MbedCloudSDK.Common;
    using update_service.Client;

    /// <summary>
    /// Exposing functionality from: Update service, Update campaigns and Manifest management
    /// </summary>
    public partial class UpdateApi : BaseApi
    {
        private update_service.Api.DefaultApi api;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateApi"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
        public UpdateApi(Config config)
            : base(config)
        {
            if (config.Host != string.Empty)
            {
                Configuration.Default.ApiClient = new ApiClient(config.Host);
            }

            api = new update_service.Api.DefaultApi();
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
        }

        /// <summary>
        /// Get meta data for the last Mbed Cloud API call
        /// </summary>
        /// <returns>Api Metadata</returns>
        public static ApiMetadata GetLastApiMetadata()
        {
            return ApiMetadata.Map(update_service.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault());
        }
    }
}
