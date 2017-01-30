using mbedCloudSDK.Common;
using mbedCloudSDK.Devices.Api;
using mbedCloudSDK.Devices.Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamples.Examples.Devices
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
            DevicesApi devices = new DevicesApi(config);
            Query query = new Query();
            query.Attributes.Add("auto_update", "true");
            query.Name = "test";
            devices.AddQuery(query);
        }
    }
}
