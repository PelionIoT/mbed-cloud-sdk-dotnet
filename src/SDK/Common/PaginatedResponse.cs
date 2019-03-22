// <copyright file="PaginatedResponse.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace Mbed.Cloud.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Mbed.Cloud.RestClient;
    using MbedCloudSDK.Exceptions;

    /// <summary>
    /// Paginated Response
    /// </summary>
    /// <typeparam name="TOptions">Options</typeparam>
    /// <typeparam name="TData">Data</typeparam>
    [JsonObject]
    public class PaginatedResponse<TOptions, TData> : IEnumerable<TData>
        where TData : Entity
        where TOptions : IQueryOptions
    {
        private readonly List<TData> cache = new List<TData>();
        private readonly Func<TOptions, Task<ResponsePage<TData>>> apiCallFunction;
        private readonly TOptions options;
        private readonly long pageLimit;
        private long pages;
        private long totalItems;
        private bool hasMore = true;
        private IEnumerator<TData> iterator;
        private ResponsePage<TData> page;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedResponse{TOptions, TData}"/> class.
        /// </summary>
        /// <param name="apiCallFunction">The get data function.</param>
        /// <param name="options">The options.</param>
        public PaginatedResponse(Func<TOptions, Task<ResponsePage<TData>>> apiCallFunction, TOptions options)
        {
            this.apiCallFunction = apiCallFunction;
            this.options = options;

            totalItems = 0;
            pages = 0;
            pageLimit = long.MaxValue;

            // limit has been used instead of maxResults
            if (this.options.Limit.HasValue)
            {
                this.options.MaxResults = this.options.Limit;
            }

            if (this.options.MaxResults.HasValue)
            {
                this.options.Limit = this.options.MaxResults;
                var pageSize = this.options.PageSize ?? this.options.Limit;
                this.options.PageSize = pageSize;
                pageLimit = (long)Math.Ceiling((double)this.options.MaxResults.Value / (pageSize ?? 1));
            }
        }

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
        /// Get Enumerator
        /// </summary>
        /// <returns>Data</returns>
        public IEnumerator<TData> GetEnumerator()
        {
            if (page == null && hasMore)
            {
                try
                {
                    // first run of paginator
                    AsyncHelper.RunSync(() => FetchNextPageAsync());
                }
                catch(ApiException e)
                {
                    throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
                }
            }
            else if (page == null && !hasMore)
            {
                // data is in the cache so just return that
                foreach (var item in cache)
                {
                    yield return item;
                }
            }

            while (page != null)
            {
                while (iterator.MoveNext())
                {
                    if (options.PageSize != null && totalItems > options.MaxResults)
                    {
                        yield break;
                    }

                    totalItems++;
                    yield return iterator.Current;
                }

                try
                {
                    AsyncHelper.RunSync(() => FetchNextPageAsync());
                }
                catch (ApiException e)
                {
                    throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
                }
            }
        }

        private async Task FetchNextPageAsync()
        {
            if (page != null && (!page.HasMore || pages >= pageLimit))
            {
                page = null;
                iterator = null;
                hasMore = false;
                return;
            }

            pages++;
            page = await GetPageAsync();
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

        private async Task<ResponsePage<TData>> GetPageAsync()
        {
            var page = await apiCallFunction.Invoke(options);
            options.After = page.Data.LastOrDefault()?.Id;
            return page;
        }
    }
}