// <copyright file="Filter.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe.Filters
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Filter
    /// </summary>
    /// <typeparam name="T">The type of filter attribute</typeparam>
    public class Filter<T>
    {
        /// <summary>
        /// Gets the filter dictionary
        /// </summary>
        public Dictionary<string, List<T>> FilterDictionary { get; } = new Dictionary<string, List<T>>();

        /// <summary>
        /// Add a new value
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="filterValue">The value</param>
        /// <returns>The filter</returns>
        public Filter<T> Add(string key, T filterValue)
        {
            if (FilterDictionary.ContainsKey(key))
            {
                FilterDictionary[key].Add(filterValue);
                return this;
            }

            FilterDictionary.Add(key, new List<T> { filterValue });
            return this;
        }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The value</returns>
        public List<T> Contains(string key)
        {
            if (FilterDictionary.ContainsKey(key))
            {
                return FilterDictionary[key];
            }

            return Enumerable.Empty<T>().ToList();
        }
    }
}