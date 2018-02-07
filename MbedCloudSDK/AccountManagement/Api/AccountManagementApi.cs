// <copyright file="AccountManagementApi.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.AccountManagement.Api
{
    using System.Linq;
    using iam.Api;
    using iam.Client;
    using MbedCloudSDK.Common;

    /// <summary>
    /// Account Management Api. Exposing functionality from IAM.
    /// </summary>
    /// <example>
    /// This API is initalized with a <see cref="Config"/> object.
    /// <code>
    /// using MbedCloudSDK.Common;
    /// var config = new Config(apiKey);
    /// var accountApi = new AccountManagementApi(config);
    /// </code>
    /// </example>
    public partial class AccountManagementApi : BaseApi
    {
        private DeveloperApi developerApi;
        private AccountAdminApi adminApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountManagementApi"/> class.
        /// Exposing functionality from the following underlying services:
        /// - IAM
        /// </summary>
        /// <param name="config"><see cref="Config"/></param>
        public AccountManagementApi(Config config)
         : base(config)
        {
            var iamConfig = new iam.Client.Configuration
            {
                BasePath = config.Host,
                DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss.fffZ",
            };
            iamConfig.AddApiKey("Authorization", config.ApiKey);
            iamConfig.AddApiKeyPrefix("Authorization", config.AuthorizationPrefix);
            iamConfig.CreateApiClient();

            developerApi = new DeveloperApi(iamConfig);
            adminApi = new AccountAdminApi(iamConfig);
        }

        /// <summary>
        /// Get metadata for the last api call.
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.GetLastApiMetadata"/> method.
        /// <code>
        /// var metadata = accountApi.GetLastApiMetadata();
        /// </code>
        /// </example>
        /// <returns><see cref="ApiMetadata"/></returns>
        public static ApiMetadata GetLastApiMetadata()
        {
            return ApiMetadata.Map(Configuration.Default.ApiClient.LastApiResponse.LastOrDefault());
        }
    }
}