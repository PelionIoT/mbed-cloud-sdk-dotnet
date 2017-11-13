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
    public class ListLogs
    {
        private Config config;
        
        public ListLogs(Config config)
        {
            this.config = config;
        }

        /// <summary>
        /// List all devicse logs.
        /// </summary>
        public List<DeviceEvent> ListDevicesLogs()
        {
            DeviceDirectoryApi api = new DeviceDirectoryApi(config);
            QueryOptions options = new QueryOptions()
            {
                Limit = 5
            };
            var logs = api.ListDeviceEvents(options).Data;
            foreach (var log in logs)
            {
                //Console.WriteLine(log.ToString());
            }
            return logs;
        }
    }
}
