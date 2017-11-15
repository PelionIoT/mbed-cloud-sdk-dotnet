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
    public partial class AccountManagementExamples
    {
        public List<ApiKey> ListApiKeys()
        {
            var options = new QueryOptions()
            {
                Limit = 5
            };
            var keys = api.ListApiKeys(options).Data;
            foreach (var key in keys)
            {
                Console.WriteLine(key);
            }
            return keys;
        }

        public async Task<List<ApiKey>> ListApiKeysAsync()
        {
            var options = new QueryOptions
            {
                Limit = 5
            };
            var keys = await api.ListApiKeysAsync(options);
            foreach (var key in keys)
            {
                Console.WriteLine(key);
            }
            return keys;
        }
    }
}
