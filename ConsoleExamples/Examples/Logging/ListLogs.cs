using mbedCloudSDK.Common;
using mbedCloudSDK.Common.Query;
using mbedCloudSDK.Logging.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamples.Examples.Logging
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
        public void ListDevicesLogs()
        {
            LoggingApi api = new LoggingApi(config);
            QueryOptions listParam = new QueryOptions();
            listParam.Limit = 10;
            foreach (var log in api.ListDeviceLogs(listParam))
            {
                Console.WriteLine(log.ToString());
            }
        }
    }
}
