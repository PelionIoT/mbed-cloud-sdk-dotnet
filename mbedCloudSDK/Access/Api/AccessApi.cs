using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iam.Api;
using iam.Client;
using iam.Model;
using mbedCloudSDK.Access.Model;
using mbedCloudSDK.Access.Model.ApiKey;
using mbedCloudSDK.Common;
using mbedCloudSDK.Exceptions;
using mbedCloudSDK.Access.Model.Account;
using mbedCloudSDK.Access.Model.Group;
using mbedCloudSDK.Access.Model.User;

namespace mbedCloudSDK.Access.Api
{
    /// <summary>
    /// Exposing functionality from IAM.
    /// </summary>
	public partial class AccessApi: BaseApi
    {
        private DeveloperApi developerApi;
        private AccountAdminApi adminApi;
        private DefaultApi defaultApi;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.Access.Access"/> class.
        /// Exposing functionality from the following underlying services:
        /// - IAM
        /// </summary>
        /// <param name="config">Config.</param>
		public AccessApi(Config config): base(config)
        {
            if (config.Host != string.Empty)
            {
                Configuration.Default.ApiClient = new ApiClient(config.Host);
            }
            Configuration.Default.ApiKey["Authorization"] = config.ApiKey;
            Configuration.Default.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            developerApi = new DeveloperApi();
            adminApi = new AccountAdminApi();
            defaultApi = new DefaultApi();
        }
    }
}
