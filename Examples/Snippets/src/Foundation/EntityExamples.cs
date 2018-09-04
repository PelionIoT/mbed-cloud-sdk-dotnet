using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MbedCloudSDK.Accounts.ApiKey;
using MbedCloudSDK.Accounts.MyAccount;
using MbedCloudSDK.Accounts.User;
using MbedCloudSDK.Common;

namespace Snippets.src.Foundation
{
    public class EntityExamples
    {
        public async Task Quick()
        {
            // an example: checking account status
            var myAccount = await new MyAccount().Get();
            var isActive = myAccount.Status == MyAccountStatusEnum.ACTIVE;
            // end of example
        }

        public async Task Listing()
        {
            // an example: listing api keys
            var allKeys = new ApiKey().List();
            var allKeyNames = allKeys.Select(k => k.Name);
            // end of example
        }

        public async Task CustomConfig()
        {
            // an example: using multiple api keys
            var allUsers = new List<User>();
            new List<string>{ "ak_1", "ak_2" }.ForEach(k => allUsers.AddRange(new User(new Config(k)).List()));
            // end of example
        }

        public async Task ReallyCustomConfig()
        {
            // an example: using custom hosts
            var config = new Config(apiKey: "ak_1", host: "https://example");
            var allUsers = new User(config).List();
            // end of example
        }
    }
}