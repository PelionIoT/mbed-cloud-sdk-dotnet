using MbedCloudSDK.Common;
using MbedCloudSDK.Update.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbedCloudSDK.Update.Model.FirmwareManifest;
using MbedCloudSDK.Common.Query;

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

        public List<FirmwareManifest> ListManifests()
        {
            UpdateApi api = new UpdateApi(config);
            var options = new QueryOptions()
            {
                Limit = 5
            };
            var manifests = api.ListFirmwareManifests(options).Data;
            foreach (var item in manifests)
            {
                Console.WriteLine(item);
            }
            return manifests;
        }
    }
}
