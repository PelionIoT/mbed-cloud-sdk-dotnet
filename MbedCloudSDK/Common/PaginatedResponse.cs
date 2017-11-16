// <copyright file="PaginatedResponse.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using MbedCloudSDK.Common.Query;
    using Newtonsoft.Json;

    /// <summary>
    /// Paginated reponse object wrapper.
    /// </summary>
    /// <typeparam name="T">Type contained in paginated response</typeparam>
    [JsonObject]
    public class PaginatedResponse<T> : IEnumerable<T>
    {
        private Func<QueryOptions, ResponsePage<T>> getDataFunc;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedResponse{T}"/> class.
        /// Create new instance of paginated reponse.
        /// </summary>
        /// <param name="getDataFunc">function to call to get next page.</param>
        /// <param name="listParams">Page params</param>
        /// <param name="initData">Data</param>
        public PaginatedResponse(Func<QueryOptions, ResponsePage<T>> getDataFunc, QueryOptions listParams, List<T> initData = null)
        {
            this.getDataFunc = getDataFunc;
            Data = initData;
            ListParams = listParams;
            if (initData != null)
            {
                TotalCount = initData.Count;
            }
            else
            {
                GetPage();
            }
        }

        /// <summary>
        /// Gets whether there are more results to display
        /// </summary>
        /// <value>Whether there are more results to display</value>
        [JsonProperty]
        public bool? HasMore { get; private set; }

        /// <summary>
        /// Gets or sets total number of records
        /// </summary>
        /// <value>Total number of records</value>
        [JsonProperty]
        public int? TotalCount { get; set; }

        /// <summary>
        /// Gets the data of the current page
        /// </summary>
        [JsonProperty]
        public List<T> Data { get; private set; }

        private QueryOptions ListParams { get; set; }

        /// <summary>
        /// Return the paginated response as a list containing all elements.
        /// </summary>
        /// <returns>List of T</returns>
        public List<T> ToList()
        {
            var list = new List<T>();
            var enumerator = GetEnumerator();
            while (enumerator.MoveNext())
            {
                list.Add(enumerator.Current);
            }

            return list;
        }

        /// <summary>
        /// Return the next page of responses
        /// </summary>
        /// <returns>List of the Items in the next page</returns>
        public List<T> GetNextPage()
        {
            GetPage();
            return Data;
        }

        private void GetPage()
        {
            var resp = getDataFunc?.Invoke(ListParams);
            HasMore = resp.HasMore;
            TotalCount = resp.TotalCount;
            Data = resp.Data;
            if (resp.Data.Count > 0)
            {
                object last = resp.Data.Last();
                var propertyInfo = last.GetType().GetProperty("Id");
                if (propertyInfo != null)
                {
                    var after = (string)propertyInfo.GetValue(last);
                    ListParams.After = after;
                }
            }
            else if (ListParams.After != null)
            {
                ListParams.After = null;
            }
        }

        /// <summary>
        /// Return total count of items
        /// </summary>
        /// <returns>Count</returns>
        public int? GetTotalCount()
        {
            var listParams = new QueryOptions
            {
                Include = "total_count",
                Limit = 2
            };
            var resp = getDataFunc?.Invoke(listParams);
            return resp.TotalCount;
        }

        /// <summary>
        /// Get items enumerator
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            while (true)
            {
                foreach (var obj in Data)
                {
                    yield return obj;
                }

                if (HasMore != true)
                {
                    yield break;
                }

                GetPage();
            }
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
