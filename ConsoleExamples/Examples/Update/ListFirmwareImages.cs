using mbedCloudSDK.Common;
using mbedCloudSDK.Update.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamples.Examples.Update
{
    /// @example
    public class ListFirmwareImages
    {
        private Config config;

        public ListFirmwareImages(Config config)
        {
            this.config = config;
        }

        public void ListImages()
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
