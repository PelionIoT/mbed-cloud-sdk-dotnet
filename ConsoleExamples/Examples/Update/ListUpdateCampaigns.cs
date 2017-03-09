using mbedCloudSDK.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void listCampaigns()
        {
            /*
            UpdateApi api = new UpdateApi(config);
            var updateCampaigns = api.ListUpdateCampaigns();
            var enumerator = updateCampaigns.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }*/
        }
    }
}
