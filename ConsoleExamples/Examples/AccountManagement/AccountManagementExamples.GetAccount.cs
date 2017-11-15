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
    public partial class AccountManagementExamples
    {
        private Config config;
        private AccountManagementApi api;

        /// <summary>
        /// List all Api keys.
        /// </summary>
        public AccountManagementExamples(Config _config)
        {
            config = _config;
            api = new AccountManagementApi(config);
        }

        public Account GetAccountDetails()
        {
            var account = api.GetAccount();
            Console.WriteLine(account);
            return account;
        }

        public async Task<Account> GetAccountDetailsAsync()
        {
            var account = await api.GetAccountAsync();
            Console.WriteLine(account);
            return account;
        }
    }
}
