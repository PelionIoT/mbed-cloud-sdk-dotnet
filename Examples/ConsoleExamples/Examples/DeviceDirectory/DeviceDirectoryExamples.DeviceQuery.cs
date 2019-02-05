// <copyright file="DeviceDirectoryExamples.DeviceQuery.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.DeviceDirectory
{
    using System;
    using Mbed.Cloud.Foundation.Common;
    using MbedCloudSDK.DeviceDirectory.Model.Query;

    /// <summary>
    /// Device directory examples
    /// </summary>
    public partial class DeviceDirectoryExamples
    {
        /// <summary>
        /// Create new Query.
        /// </summary>
        /// <returns>Query</returns>
        public Query AddQuery()
        {
            var options = new QueryOptions
            {
                Limit = 5,
            };

            // list the current queries
            var queries = api.ListQueries(options);
            foreach (var item in queries)
            {
                Console.WriteLine(item.Id);
            }

            // create a new query
            var query = new Query
            {
                Name = $"test-{GetHashCode()}",
            };
            query.Filter.Add("auto_update", "true");

            // add the query
            var addedQuery = api.AddQuery(query);
            Console.WriteLine($"Adding query: {addedQuery}");

            // get the query we just created
            var tQuery = api.GetQuery(addedQuery.Id);
            if (tQuery.Id == addedQuery.Id)
            {
                Console.WriteLine($"Query found with id {addedQuery.Id}");
            }

            var deviceOptions = new QueryOptions
            {
                Limit = 5,
                Filter = tQuery.Filter,
            };

            // run the query and print the matching devices
            var matchingDevices = api.ListDevices(options);
            Console.WriteLine("printing matching devices");
            foreach (var item in matchingDevices)
            {
                Console.WriteLine(item.Id);
            }

            api.DeleteQuery(tQuery.Id);

            return tQuery;
        }
    }
}
