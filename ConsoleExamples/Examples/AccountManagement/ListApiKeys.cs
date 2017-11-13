using MbedCloudSDK.AccountManagement.Api;
using MbedCloudSDK.AccountManagement.Model.ApiKey;
using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamples.Examples.AccountManagement
{
    /// @example
    public class ListApiKeys
    {
        private Config config;

        /// <summary>
        /// List all Api keys.
        /// </summary>
        public ListApiKeys(Config config)
        {
            this.config = config;
        }

        public void GetApiKeys()
        {
            AccountManagementApi access = new AccountManagementApi(config);
            var options = new QueryOptions()
            {
                Limit = 5
            };
            var keys = access.ListApiKeys(options).Data;
            foreach (var key in keys)
            {
                Console.WriteLine(key);
            }
            Console.WriteLine(keys.Count());
        }

        public async void ListApiKeysAsync()
        {
            AccountManagementApi access = new AccountManagementApi(config);
            //List Api Keys asynchronously
            var options = new QueryOptions()
            {
                Limit = 5
            };
            var keys = await access.ListApiKeysAsync(options);;
            foreach (var key in keys)
            {
                Console.WriteLine(key);
            }
            Console.WriteLine(keys.Count());
        }
    }
}
