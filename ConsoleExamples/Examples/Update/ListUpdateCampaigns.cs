using MbedCloudSDK.Common;
using MbedCloudSDK.Update.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbedCloudSDK.Common.Query;
using MbedCloudSDK.Update.Model.Campaign;

namespace ConsoleExamples.Examples.Update
{
    /// @example
    public class ListUpdateCampaigns
    {
        private Config config;

        public ListUpdateCampaigns(Config config)
        {
            this.config = config;
        }

        public List<Campaign> listCampaigns()
        {
            UpdateApi api = new UpdateApi(config);
            var options = new QueryOptions()
            {
                Limit = 3
            };
            var updateCampaigns = api.ListCampaigns(options).Data;
            foreach (var item in updateCampaigns)
            {
                Console.WriteLine(item);
            }
            return updateCampaigns;
        }
    }
}
