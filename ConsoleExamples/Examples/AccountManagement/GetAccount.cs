using MbedCloudSDK.AccountManagement.Api;
using MbedCloudSDK.AccountManagement.Model.ApiKey;
using MbedCloudSDK.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbedCloudSDK.AccountManagement.Model.Account;

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

        public Account GetAccountDetails()
        {
            AccountManagementApi access = new AccountManagementApi(config);
            var account = access.GetAccount();
            Console.WriteLine(account);
            return account;
        }

        public async Task<Account> GetAccountDetailsAsync()
        {
            AccountManagementApi access = new AccountManagementApi(config);
            var account = await access.GetAccountAsync();
            Console.WriteLine(account);
            return account;
        }
    }
}
