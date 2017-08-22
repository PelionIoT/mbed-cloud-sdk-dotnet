using mbedCloudSDK.Common;
using mbedCloudSDK.Common.Query;
using mbedCloudSDK.DeviceDirectory.Model.Query;
using mbedCloudSDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.DeviceDirectory.Api
{
    public partial class DeviceDirectoryApi
    {
        /// <summary>
        /// List all queries.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public PaginatedResponse<Query> ListQueries(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }
            try
            {
                return new PaginatedResponse<Query>(ListDeviceQueriesFunc, options);
            }
            catch (CloudApiException e)
            {
                throw e;
            }
        }

        private ResponsePage<Query> ListDeviceQueriesFunc(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }
            try
            {
                var resp = this.queryApi.DeviceQueryList(options.Limit, options.Order, options.After, options.Include);
                ResponsePage<Query> respDevices = new ResponsePage<Query>(resp.After, resp.HasMore, (int?)resp.Limit, resp.Order, (int?)resp.TotalCount);
                foreach (var deviceQuery in resp.Data)
                {
                    respDevices.Data.Add(Query.Map(deviceQuery));
                }
                return respDevices;
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public Query GetQuery(string queryId)
        {
            try
            {
                var response = queryApi.DeviceQueryRetrieve(queryId);
                return Query.Map(response);
            }
            catch(device_query_service.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Creates new query.
        /// </summary>
        /// <returns>The query.</returns>
        /// <param name="query">Query object to create</param>
        public Query AddQuery(Query query)
        {
            var deviceQueryPostPutRequest = new device_query_service.Model.DeviceQueryPostPutRequest(query.QueryString, query.Name);

            try
            {
                var response = queryApi.DeviceQueryCreate(deviceQueryPostPutRequest);
                return Query.Map(response);
            }
            catch(device_query_service.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        public Query UpdateQuery(string queryId, Query queryToUpdate)
        {
            var originalQuery = GetQuery(queryId);
            var query = Utils.MapToUpdate(originalQuery, queryToUpdate) as Query;
            var deviceQueryPostPutRequest = new device_query_service.Model.DeviceQueryPostPutRequest(query.QueryString, query.Name);

            try
            {
                var response = queryApi.DeviceQueryUpdate(queryId, deviceQueryPostPutRequest);
                return Query.Map(response);
            }
            catch (device_query_service.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Deletes the query.
        /// </summary>
        /// <returns>The query.</returns>
        /// <param name="queryID">Query identifier.</param>
        public void DeleteQuery(string queryID)
        {
            try
            {
                queryApi.DeviceQueryDestroy(queryID);
            }
            catch (device_query_service.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }
    }
}
