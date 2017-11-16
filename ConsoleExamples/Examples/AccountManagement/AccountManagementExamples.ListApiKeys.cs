// <copyright file="AccountManagementExamples.ListApiKeys.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.AccountManagement
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MbedCloudSDK.AccountManagement.Model.ApiKey;
    using MbedCloudSDK.Common.Query;

    /// <summary>
    /// Account management examples
    /// </summary>
    public partial class AccountManagementExamples
    {
        /// <summary>
        /// List the first 5 ApiKeys
        /// </summary>
        /// <returns>List of Api keys</returns>
        public List<ApiKey> ListApiKeys()
        {
            var options = new QueryOptions
            {
                Limit = 5,
            };
            var keys = api.ListApiKeys(options).Data;
            foreach (var key in keys)
            {
                Console.WriteLine(key);
            }

            return keys;
        }

        /// <summary>
        /// Returns the first 5 api keys asyncronously
        /// </summary>
        /// <returns>Task with list of api keys</returns>
        public async Task<List<ApiKey>> ListApiKeysAsync()
        {
            var options = new QueryOptions
            {
                Limit = 5,
            };
            var keys = await api.ListApiKeysAsync(options);
            foreach (var key in keys)
            {
                Console.WriteLine(key);
            }

            return keys;
        }
    }
}
