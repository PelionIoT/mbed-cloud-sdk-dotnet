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
    public partial class UpdateExamples
    {
        public List<FirmwareManifest> ListManifests()
        {
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
