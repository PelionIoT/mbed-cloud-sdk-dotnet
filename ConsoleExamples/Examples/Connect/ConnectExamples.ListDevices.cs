using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Query;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.DeviceDirectory.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbedCloudSDK.Connect.Model.ConnectedDevice;
using MbedCloudSDK.DeviceDirectory.Model.Device;

namespace ConsoleExamples.Examples.Connect
{
    /// @example
    public partial class ConnectExamples
    {
        private Config config;
        private ConnectApi api;

        public ConnectExamples(Config config)
        {
            this.config = config;
            this.api = new ConnectApi(config);
        }

        /// <summary>
        /// List Connected devices.
        /// </summary>
        public List<ConnectedDevice> ListConnectedDevices()
        {
            var options = new QueryOptions
            {
                Limit = 2
            };
            var deviceList = api.ListConnectedDevices(options).Data;
            foreach (var endpoint in deviceList)
            {
                Console.WriteLine(endpoint);
            }
            return deviceList;
        }

        public List<ConnectedDevice> ListConnectedDevicesWithFilter()
        {
            var options = new QueryOptions();
            options.Filter.Add("created_at", new DateTime(2017, 10, 1).ToString());
            options.Filter.Add("created_at", new DateTime(2017, 10, 31).ToString());
            var deviceList = api.ListConnectedDevices(options).Data;
            foreach (var endpoint in deviceList)
            {
                Console.WriteLine(endpoint);
            }
            return deviceList;
        }
    }
}
