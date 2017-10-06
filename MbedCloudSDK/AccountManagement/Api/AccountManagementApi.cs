// <copyright file="AccountManagementApi.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.AccountManagement.Api
{
    using System.IO;
    using System.Linq;
    using iam.Api;
    using iam.Client;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Tlv;

    /// <summary>
    /// Exposing functionality from IAM.
    /// </summary>
    public partial class AccountManagementApi : BaseApi
    {
        private DeveloperApi developerApi;
        private AccountAdminApi adminApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountManagementApi"/> class.
        /// Exposing functionality from the following underlying services:
        /// - IAM
        /// </summary>
        /// <param name="config">Config.</param>
        public AccountManagementApi(Config config)
            : base(config)
        {
            if (!string.IsNullOrEmpty(config.Host))
            {
                Configuration.Default.ApiClient = new ApiClient(config.Host);
            }

            Configuration.Default.ApiKey["Authorization"] = config.ApiKey;
            Configuration.Default.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;

            developerApi = new DeveloperApi();
            adminApi = new AccountAdminApi();
        }

        /// <summary>
        /// Get metadata for last api call
        /// </summary>
        /// <returns>Api Metadata</returns>
        public static ApiMetadata GetLastApiMetadata()
        {
            return ApiMetadata.Map(Configuration.Default.ApiClient.LastApiResponse.LastOrDefault());
        }
    }
}
