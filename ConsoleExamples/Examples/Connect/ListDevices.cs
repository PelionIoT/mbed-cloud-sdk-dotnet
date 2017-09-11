using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Query;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.DeviceDirectory.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamples.Examples.Connect
{
    /// @example
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
            ConnectApi devices = new ConnectApi(config);
            foreach (var endpoint in devices.ListConnectedDevices())
            {
                Console.WriteLine(endpoint);
            }
        }

        /// <summary>
        /// List DeviceDirectory.
        /// </summary>
        public void ListAllDevices()
        {
            DeviceDirectoryApi devices = new DeviceDirectoryApi(config);
            DeviceQueryOptions options = new DeviceQueryOptions();
            options.Limit = 10;
            foreach (var device in devices.ListDevices(options))
            {
                Console.WriteLine(device.ToString());
            }
        }
    }
}
