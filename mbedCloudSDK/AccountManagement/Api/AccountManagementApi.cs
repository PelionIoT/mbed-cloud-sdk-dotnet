using System;
using System.Collections.Generic;
using System.Linq;
using iam.Api;
using iam.Client;
using mbedCloudSDK.Common;
using RestSharp;

namespace mbedCloudSDK.AccountManagement.Api
{
    /// <summary>
    /// Exposing functionality from IAM.
    /// </summary>
	public partial class AccountManagementApi: BaseApi
    {
        private DeveloperApi developerApi;
        private AccountAdminApi adminApi;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.AccountManagement.AccountManagement"/> class.
        /// Exposing functionality from the following underlying services:
        /// - IAM
        /// </summary>
        /// <param name="config">Config.</param>
		public AccountManagementApi(Config config): base(config)
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

        public ApiMetadata GetLastApiMetadata()
        {
            return ApiMetadata.Map(Configuration.Default.ApiClient.LastApiResponse.LastOrDefault());
        }
    }
}
