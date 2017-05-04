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
            var keys = access.ListApiKeys();
            foreach (var key in keys)
            {
                Console.WriteLine(key);
            }
        }

        public void ListApiKeysAsync()
        {
            AccountManagementApi access = new AccountManagementApi(config);
            //List Api Keys asynchronously
            var keysTask = access.ListApiKeysAsync();
            Console.WriteLine("Print without waiting for response");
            List<ApiKey> keys = keysTask.Result;
            foreach (var key in keys)
            {
                Console.WriteLine(key);
            }
        }
    }
}
