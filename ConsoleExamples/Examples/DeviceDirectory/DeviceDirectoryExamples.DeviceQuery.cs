using MbedCloudSDK.Common;
using MbedCloudSDK.DeviceDirectory.Api;
using MbedCloudSDK.DeviceDirectory.Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbedCloudSDK.Common.Filter;
using MbedCloudSDK.Common.Query;

namespace ConsoleExamples.Examples.DeviceDirectory
{
    /// @example
    public partial class DeviceDirectoryExamples
    {
        /// <summary>
        /// Create new Query.
        /// </summary>
        public Query AddQuery()
        {
            var options = new QueryOptions()
            {
                Limit = 5
            };
            // list the current queries
            var queries = api.ListQueries(options).Data;
            foreach (var item in queries)
            {
                Console.WriteLine(item.Id);
            }

            //create a new query
            var query = new Query()
            {
                Name = $"test-{this.GetHashCode()}"
            };
            query.Filter.Add("auto_update", "true");
            //add the query
            var addedQuery = api.AddQuery(query);
            Console.WriteLine($"Adding query: {addedQuery}");

            // get the query we just created
            var tQuery = api.GetQuery(addedQuery.Id);
            if (tQuery.Id == addedQuery.Id)
            {
                Console.WriteLine($"Query found with id {addedQuery.Id}");
            }

            var deviceOptions = new QueryOptions()
            {
                Limit = 5,
                Filter = tQuery.Filter
            };
            //run the query and print the matching devices
            var matchingDevices = api.ListDevices(options).Data;
            Console.WriteLine("printing matching devices");
            foreach (var item in matchingDevices)
            {
                Console.WriteLine(item.Id);
            }

            return tQuery;
        }
    }
}
