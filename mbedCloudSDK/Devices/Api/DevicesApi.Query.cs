using mbedCloudSDK.Common;
using mbedCloudSDK.Devices.Model.Query;
using mbedCloudSDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Devices.Api
{
    public partial class DevicesApi
    {
        /// <summary>
        /// Creates new query.
        /// </summary>
        /// <returns>The query.</returns>
        /// <param name="query">Query object to create</param>
        public Query AddQuery(Query query)
        {
            var api = new device_query_service.Api.DefaultApi();
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            return Query.Map(api.DeviceQueryCreate(query.Name, query.QueryString, query.Description));
        }

        /// <summary>
        /// Deletes the query.
        /// </summary>
        /// <returns>The query.</returns>
        /// <param name="queryID">Query identifier.</param>
        public Query DeleteQuery(string queryID)
        {
            var api = new device_query_service.Api.DefaultApi();
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            return Query.Map(api.DeviceQueryDestroy(queryID));
        }

        /// <summary>
        /// List all queries.
        /// </summary>
        /// <param name="listParams"></param>
        /// <returns></returns>
        public PaginatedResponse<Query> ListQueries(ListParams listParams = null)
        {
            if (listParams == null)
            {
                listParams = new ListParams();
            }
            try
            {
                return new PaginatedResponse<Query>(ListDeviceQueriesFunc, listParams);
            }
            catch (CloudApiException e)
            {
                throw e;
            }
        }

        private ResponsePage<Query> ListDeviceQueriesFunc(ListParams listParams = null)
        {
            if (listParams == null)
            {
                listParams = new ListParams();
            }
            var api = new device_query_service.Api.DefaultApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            try
            {
                var resp = api.DeviceQueryList(listParams.Limit, listParams.Order, listParams.After, listParams.Include);
                ResponsePage<Query> respDevices = new ResponsePage<Query>(resp.After, resp.HasMore, resp.Limit, resp.Order, resp.TotalCount);
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
    }
}
