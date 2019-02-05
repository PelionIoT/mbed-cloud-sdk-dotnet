// <copyright file="UpdateApi.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Api
{
    using System;
    using System.Linq;
    using Mbed.Cloud.Foundation.Common;
    using MbedCloudSDK.Common;
    using update_service.Api;
    using update_service.Client;

    /// <summary>
    /// Exposing functionality from: Update service, Update campaigns and Manifest management
    /// </summary>
    public partial class UpdateApi : BaseApi
    {
        private DefaultApi api;

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
            SetUpApi(config);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateApi"/> class.
        /// </summary>
        /// <param name="config"><see cref="Config"/></param>
        /// <param name="updateConfig">The update config</param>
        /// <example>
        /// This API is intialized with a <see cref="Config"/> object.
        /// <code>
        /// using MbedCloudSDK.Common;
        /// var config = new config(apiKey);
        /// var updateApi = new UpdateApi(config);
        /// </code>
        /// </example>
        internal UpdateApi(Config config, Configuration updateConfig = null)
            : base(config)
        {
            SetUpApi(config, updateConfig);
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

        private void SetUpApi(Config config, Configuration updateConfig = null)
        {
            if (updateConfig == null)
            {
                updateConfig = new Configuration
                {
                    BasePath = config.Host,
                    DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.ffffffZ",
                    UserAgent = UserAgent,
                };
                updateConfig.AddApiKey("Authorization", config.ApiKey);
                updateConfig.AddApiKeyPrefix("Authorization", config.AuthorizationPrefix);
                updateConfig.CreateApiClient();
            }

            Api = new update_service.Api.DefaultApi(updateConfig);
        }
    }
}
