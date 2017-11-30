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

        /// <summary>
        /// Get an api key
        /// </summary>
        /// <returns>Api key</returns>
        public ApiKey GetApiKey()
        {
            var key = api.GetApiKey();
            Console.WriteLine(key);
            return key;
        }

        /// <summary>
        /// Get an api key async
        /// </summary>
        /// <returns>Api key</returns>
        public async Task<ApiKey> GetApiKeyAsync()
        {
            var key = await api.GetApiKeyAsync();
            Console.WriteLine(key);
            return key;
        }

        /// <summary>
        /// Add an api key
        /// </summary>
        /// <returns>ApiKey</returns>
        public ApiKey AddApiKey()
        {
            var key = new ApiKey
            {
                Name = "Example api Key",
            };
            var newKey = api.AddApiKey(key);
            Console.WriteLine(newKey);

            newKey.Name = "updated example key";
            var updatedKey = api.UpdateApiKey(newKey.Id, newKey);
            Console.WriteLine(updatedKey);

            api.DeleteApiKey(updatedKey.Id);

            return updatedKey;
        }

        /// <summary>
        /// Add an api key async
        /// </summary>
        /// <returns>ApiKey</returns>
        public async Task<ApiKey> AddApiKeyAsync()
        {
            var key = new ApiKey
            {
                Name = "Example api Key",
            };
            var newKey = await api.AddApiKeyAsync(key);
            Console.WriteLine(newKey);

            newKey.Name = "updated example key";
            var updatedKey = await api.UpdateApiKeyAsync(newKey.Id, newKey);
            Console.WriteLine(updatedKey);

            await api.DeleteApiKeyAsync(updatedKey.Id);

            return updatedKey;
        }
    }
}