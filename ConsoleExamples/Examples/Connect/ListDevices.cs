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
            var options = new QueryOptions
            {
                Limit = 1
            };
            var deviceList = devices.ListConnectedDevices(options).Data;
            foreach (var endpoint in deviceList)
            {
                Console.WriteLine(endpoint);
            }
            Console.WriteLine(deviceList.Count());
        }

        /// <summary>
        /// List DeviceDirectory.
        /// </summary>
        public void ListAllDevices()
        {
            DeviceDirectoryApi devices = new DeviceDirectoryApi(config);
            QueryOptions options = new QueryOptions()
            {
                Limit = 10
            };
            var deviceList = devices.ListDevices(options).Data;
            foreach (var device in deviceList)
            {
                Console.WriteLine(device.ToString());
            }
            Console.WriteLine(deviceList.Count());
        }
    }
}
