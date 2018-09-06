using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MbedCloudSDK.Entities.ApiKey;
using MbedCloudSDK.Entities.MyAccount;
using MbedCloudSDK.Entities.User;
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
    }
}