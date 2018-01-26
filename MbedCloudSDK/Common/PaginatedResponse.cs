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
    using MbedCloudSDK.Connect.Model.Metric;
    using Newtonsoft.Json;

    /// <summary>
    /// Paginated reponse object wrapper.
    /// </summary>
    /// <typeparam name="TOptions">Type of parameter object</typeparam>
    /// <typeparam name="TData">Type contained in paginated response</typeparam>
    [JsonObject]
    public class PaginatedResponse<TOptions, TData> : IEnumerable<TData>
        where TOptions : QueryOptions
    {
        private Func<TOptions, ResponsePage<TData>> getDataFunc;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedResponse{TOne, TTwo}"/> class.
        /// Create new instance of paginated reponse.
        /// </summary>
        /// <param name="getDataFunc">function to call to get next page.</param>
        /// <param name="listParams">Page params</param>
        /// <param name="initData">Data</param>
        public PaginatedResponse(Func<TOptions, ResponsePage<TData>> getDataFunc, TOptions listParams, List<TData> initData = null)
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
        /// Gets total number of records
        /// </summary>
        /// <value>Total number of records</value>
        [JsonProperty]
        public int? TotalCount { get; private set; }

        /// <summary>
        /// Gets the data of the current page
        /// </summary>
        [JsonProperty]
        public List<TData> Data { get; private set; }

        private TOptions ListParams { get; set; }

        /// <summary>
        /// Return the paginated response as a list containing all elements.
        /// </summary>
        /// <returns>List of T</returns>
        public List<TData> ToList()
        {
            var list = new List<TData>();
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
        public List<TData> GetNextPage()
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
        /// Get items enumerator
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<TData> GetEnumerator()
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
