using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mbedCloudSDK.Common.Query;

namespace mbedCloudSDK.Common
{
    /// <summary>
    /// Paginated reponse object wrapper.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaginatedResponse<T> : IEnumerable<T>
    {
        private Func<QueryOptions, ResponsePage<T>> getDataFunc;

        /// <summary>
        /// Whether there are more results to display
        /// </summary>
        /// <value>Whether there are more results to display</value>
        public bool? HasMore { get; private set; }
        
        /// <summary>
        /// Total number of records
        /// </summary>
        /// <value>Total number of records</value>
        public int? TotalCount { get; set; }

        private QueryOptions ListParams { get; set; }

        private List<T> Data { get; set; }

        /// <summary>
        /// Create new instance of paginated reponse.
        /// </summary>
        /// <param name="getDataFunc">function to call to get next page.</param>
        /// <param name="listParams">Page params</param>
        /// <param name="initData">Data</param>
        public PaginatedResponse(Func<QueryOptions, ResponsePage<T>> getDataFunc, QueryOptions listParams, List<T> initData = null)
        {
            this.getDataFunc = getDataFunc;
            this.Data = initData;
            this.ListParams = listParams;
            if (initData != null)
            {
                this.TotalCount = initData.Count;
            }
            else
            {
                GetPage();
            }
        }

        /// <summary>
        /// Return the paginated response as a list containing all elements.
        /// </summary>
        /// <returns></returns>
        public List<T> ToList()
        {
            List<T> list = new List<T>();
            IEnumerator<T> enumerator = this.GetEnumerator();
            while(enumerator.MoveNext())
            {
                list.Add(enumerator.Current);
            }
            return list;
        }

        private void GetPage()
        {
            ResponsePage<T> resp = this.getDataFunc(this.ListParams);
            this.HasMore = resp.HasMore;
            this.TotalCount = resp.TotalCount;
            this.Data = resp.Data;
            if (resp.Data.Count > 0 )
            {
                object last = resp.Data.Last();
                var propertyInfo = last.GetType().GetProperty("Id");
                if (propertyInfo != null)
                {
                    var after = (string) propertyInfo.GetValue(last);
                    this.ListParams.After = after;
                }
            }
            else if (this.ListParams.After != null)
            {
                this.ListParams.After = null;
            }
        }

        /// <summary>
        /// Return total count of items
        /// </summary>
        /// <returns></returns>
        public int? GetTotalCount()
        {
            QueryOptions listParams = new QueryOptions();
            listParams.Include = "total_count";
            listParams.Limit = 2;
            ResponsePage<T> resp = this.getDataFunc(listParams);
            return resp.TotalCount;
        }

        /// <summary>
        /// Get items enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            while (true)
            {
                foreach (var obj in this.Data)
                {
                    yield return obj;
                }
                if (this.HasMore != true)
                {
                    yield break;
                }
                GetPage();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
