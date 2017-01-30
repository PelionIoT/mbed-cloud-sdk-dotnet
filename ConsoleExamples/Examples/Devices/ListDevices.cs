using mbedCloudSDK.Common;
using mbedCloudSDK.Common.Query;
using mbedCloudSDK.Devices.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamples.Examples.Devices
{
    public class ListDevices
    {
        private Config config;

        public ListDevices(Config config)
        {
            this.config = config;
        }

        /// <summary>
        /// List Connected devices.
        /// </summary>
        public void ListConnectedDevices()
        {
            DevicesApi devices = new DevicesApi(config);
            foreach (var endpoint in devices.ListConnectedDevices())
            {
                Console.WriteLine(endpoint);
            }
        }

        /// <summary>
        /// List Devices.
        /// </summary>
        public void ListAllDevices()
        {
            DevicesApi devices = new DevicesApi(config);
            DeviceQueryOptions options = new DeviceQueryOptions();
            options.Limit = 10;
            foreach (var device in devices.ListDevices(options))
            {
                Console.WriteLine(device.ToString());
            }
        }
    }
}
