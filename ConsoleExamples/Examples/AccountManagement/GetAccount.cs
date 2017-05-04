using mbedCloudSDK.AccountManagement.Api;
using mbedCloudSDK.AccountManagement.Model.ApiKey;
using mbedCloudSDK.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamples.Examples.AccountManagement
{
    /// @example
    public class GetAccount
    {
        private Config config;

        /// <summary>
        /// List all Api keys.
        /// </summary>
        public GetAccount(Config config)
        {
            this.config = config;
        }

        public void GetAccountDetails()
        {
            AccountManagementApi access = new AccountManagementApi(config);
            Console.WriteLine(access.GetAccount());
        }
    }
}
