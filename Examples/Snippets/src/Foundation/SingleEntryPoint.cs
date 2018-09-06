using System.Collections.Generic;
using System.Threading.Tasks;
using MbedCloudSDK.Entities.User;
using MbedCloudSDK.Common;
using MbedCloudSDK;

namespace Snippets.src.Foundation
{
    public class SingleEntryPoint
    {
        public async Task CustomConfig()
        {
            // an example: using multiple api keys
            var allUsers = new List<User>();
            new List<string> { "ak_1", "ak_2" }.ForEach(k => allUsers.AddRange(new SDK(k).User().List()));
            // end of example
        }

        public async Task ReallyCustomConfig()
        {
            // an example: using custom hosts
            var config = new Config(apiKey: "ak_1", host: "https://example");
            var allUsers = new SDK(config).User().List();
            // end of example
        }
    }
}