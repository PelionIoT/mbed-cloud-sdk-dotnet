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
    /// Paginated Response
    /// </summary>
    /// <typeparam name="TOptions">Options</typeparam>
    /// <typeparam name="TData">Data</typeparam>
    [JsonObject]
    public class PaginatedResponse<TOptions, TData> : IEnumerable<TData>
        where TData : BaseModel
        where TOptions : QueryOptions
    {
        private readonly List<TData> cache;
        private readonly Func<TOptions, ResponsePage<TData>> getDataFunc;
        private readonly TOptions options;
        private readonly long pageLimit;
        private long pages;
        private long totalItems;
        private IEnumerator<TData> iterator;
        private ResponsePage<TData> page;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedResponse{TOptions, TData}"/> class.
        /// </summary>
        /// <param name="getDataFunc">The get data function.</param>
        /// <param name="options">The options.</param>
        public PaginatedResponse(Func<TOptions, ResponsePage<TData>> getDataFunc, TOptions options)
        {
            this.getDataFunc = getDataFunc;
            this.options = options;
            page = GetPage();
            iterator = page.Data.GetEnumerator();
            totalItems = 0;
            pages = 1;
            pageLimit = long.MaxValue;

            if (this.options.Limit.HasValue)
            {
                this.options.MaxResults = this.options.Limit;
            }

            if (this.options.MaxResults.HasValue)
            {
                var pageSize = this.options.PageSize ?? this.options.Limit;
                this.options.PageSize = pageSize;
                pageLimit = (long)Math.Ceiling((double)this.options.MaxResults.Value / (pageSize ?? 1));
            }

            cache = new List<TData>();
            cache.AddRange(page.Data);
        }

        [JsonProperty]
        private List<TData> Data { get => page.Data; }

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns>List of all items</returns>
        public List<TData> All()
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
        /// The first item
        /// </summary>
        /// <returns>If no caching, then first item from current page</returns>
        public TData First()
        {
            return cache.FirstOrDefault();
        }

        /// <summary>
        /// Get Enumerator
        /// </summary>
        /// <returns>Data</returns>
        public IEnumerator<TData> GetEnumerator()
        {
            if (page == null)
            {
                foreach (var item in cache)
                {
                    yield return item;
                }
            }
            else
            {
                while (page != null)
                {
                    iterator.Reset();
                    while (iterator.MoveNext())
                    {
                        if (options.PageSize != null && totalItems > options.MaxResults)
                        {
                            yield break;
                        }

                        totalItems++;
                        yield return iterator.Current;
                    }

                    if (page.HasMore)
                    {
                        FetchNextPage();
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void FetchNextPage()
        {
            if (!page.HasMore || pages >= pageLimit)
            {
                page = null;
                iterator = null;
                return;
            }

            pages++;
            page = GetPage();
            iterator = page.Data.GetEnumerator();
            cache.AddRange(page.Data);
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"></see> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private ResponsePage<TData> GetPage()
        {
            var page = getDataFunc.Invoke(options);
            options.After = page.After ?? page.Data.LastOrDefault()?.Id;
            return page;
        }
    }
}