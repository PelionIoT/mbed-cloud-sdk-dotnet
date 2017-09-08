using MbedCloudSDK.Common;
using MbedCloudSDK.Update.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamples.Examples.Update
{
    /// @example
    public class ListFirmwareManifests
    {
        private Config config;

        public ListFirmwareManifests(Config config)
        {
            this.config = config;
        }

        public void ListManifests()
        {
            UpdateApi api = new UpdateApi(config);
            var manifests = api.ListFirmwareManifests();
            var enumerator = manifests.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
    }
}
