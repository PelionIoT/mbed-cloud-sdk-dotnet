using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Query;
using MbedCloudSDK.DeviceDirectory.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbedCloudSDK.DeviceDirectory.Model.Logging;

namespace ConsoleExamples.Examples.DeviceDirectory
{
    /// @example
    public partial class DeviceDirectoryExamples
    {
        /// <summary>
        /// List all devicse logs.
        /// </summary>
        public List<DeviceEvent> ListDevicesLogs()
        {
            var options = new QueryOptions()
            {
                Limit = 5
            };
            var logs = api.ListDeviceEvents(options).Data;
            foreach (var log in logs)
            {
                Console.WriteLine(log.ToString());
            }
            return logs;
        }

        public List<DeviceEvent> ListDeviceEvents()
        {
            var options = new QueryOptions()
            {
                Limit = 5
            };
            var events = api.ListDeviceEvents(options).Data;
            foreach (var item in events)
            {
                Console.WriteLine(item);
            }
            return events;
        }
    }
}
