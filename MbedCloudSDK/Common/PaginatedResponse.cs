using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MbedCloudSDK.Common.Query;
using Newtonsoft.Json;

namespace MbedCloudSDK.Common
{
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
        private ResponsePage<TData> _page;
        private IEnumerator<TData> _iterator;
        private long _pages;
        private long _totalItems;
        private readonly long _pageLimit;
        private readonly TOptions _options;
        private Func<TOptions, ResponsePage<TData>> _getDataFunc;
        private List<TData> _cache;

        [JsonProperty]
        private List<TData> Data { get => _page.Data; }

        public PaginatedResponse(Func<TOptions, ResponsePage<TData>> getDataFunc, TOptions options, bool cache = true)
        {
            _getDataFunc = getDataFunc;
            _options = options;
            _page = getPage();
            _iterator = _page.Data.GetEnumerator();
            _totalItems = 0;
            _pages = 1;
            _pageLimit = long.MaxValue;

            if (_options.MaxResults.HasValue)
            {
                var pageSize = _options.PageSize ?? _options.Limit;
                _pageLimit = (long)(Math.Ceiling((double)_options.MaxResults.Value / (pageSize.HasValue ? _options.PageSize.Value : 1)));
            }

            if (cache)
            {
                _cache = new List<TData>();
                _cache.AddRange(_page.Data);
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
        /// The first item
        /// </summary>
        /// <returns>If no caching, then first item from current page</returns>
        public TData First()
        {
            if (_cache != null)
            {
                return _cache.FirstOrDefault();
            }

            return _page.Data.FirstOrDefault();
        }

        /// <summary>
        /// Get Enumerator
        /// </summary>
        public IEnumerator<TData> GetEnumerator()
        {
             while (_page != null)
             {
                _iterator.Reset();
                while (_iterator.MoveNext())
                {
                    if (_options.PageSize != null && _totalItems > _options.MaxResults)
                    {
                        yield break;
                    }

                    _totalItems++;
                    yield return _iterator.Current;
                }

                if (_page.HasMore)
                {
                    FetchNextPage();
                }
                else
                {
                    break;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();

        }

        private void FetchNextPage()
        {
            if (!_page.HasMore || _pages >= _pageLimit)
            {
                _page = null;
                _iterator = null;
                return;
            }

            _pages++;
            _page = getPage();
            _iterator = _page.Data.GetEnumerator();
            if (_cache != null)
            {
                _cache.AddRange(_page.Data);
            }
        }

        private ResponsePage<TData> getPage()
        {
            var page = _getDataFunc.Invoke(_options);
            _options.After = page.After ?? page.Data.LastOrDefault()?.Id;
            return page;
        }
    }
}