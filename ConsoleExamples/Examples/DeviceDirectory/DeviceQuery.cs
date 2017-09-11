using MbedCloudSDK.Common;
using MbedCloudSDK.DeviceDirectory.Api;
using MbedCloudSDK.DeviceDirectory.Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamples.Examples.DeviceDirectory
{
    /// @example
    public class DeviceQuery
    {
        private Config config;
        public DeviceQuery(Config config)
        {
            this.config = config;
        }

        /// <summary>
        /// Create new Query.
        /// </summary>
        public void AddQuery()
        {
            DeviceDirectoryApi devices = new DeviceDirectoryApi(config);
            Query query = new Query();
            //query.Attributes.Add("auto_update", "true");
            query.Name = "test";
            devices.AddQuery(query);
        }
    }
}
