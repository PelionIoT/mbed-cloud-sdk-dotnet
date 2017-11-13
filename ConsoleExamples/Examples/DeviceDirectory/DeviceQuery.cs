using MbedCloudSDK.Common;
using MbedCloudSDK.DeviceDirectory.Api;
using MbedCloudSDK.DeviceDirectory.Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbedCloudSDK.Common.Filter;

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
        public Query AddQuery()
        {
            DeviceDirectoryApi devices = new DeviceDirectoryApi(config);
            Query query = new Query()
            {
                Filter = new Filter(),
                Name = $"test-{this.GetHashCode()}"
            };
            query.Filter.Add("auto_update", "true");
            var addedQuery = devices.AddQuery(query);
            //Console.WriteLine($"Adding query: {addedQuery}");
            var tQuery = devices.GetQuery(addedQuery.Id);
            if (tQuery.Id == addedQuery.Id)
            {
                //Console.WriteLine($"Query found with id {addedQuery.Id}");
            }
            return tQuery;
        }
    }
}
