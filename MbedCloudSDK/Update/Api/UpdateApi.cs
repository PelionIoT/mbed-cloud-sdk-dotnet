// <copyright file="UpdateApi.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Api
{
    using System;
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
        /// <param name="config"><see cref="Config"/></param>
        /// <example>
        /// This API is intialized with a <see cref="Config"/> object.
        /// <code>
        /// using MbedCloudSDK.Common;
        /// var config = new config(apiKey);
        /// var updateApi = new UpdateApi(config);
        /// </code>
        /// </example>
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
            api.Configuration.DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.ffffffZ";
        }

        /// <summary>
        /// Get meta data for the last Mbed Cloud API call
        /// </summary>
        /// <returns><see cref="ApiMetadata"/></returns>
        public static ApiMetadata GetLastApiMetadata()
        {
            return ApiMetadata.Map(update_service.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault());
        }
    }
}
