// <copyright file="DeviceDirectoryApi.Query.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.DeviceDirectory.Api
{
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Query;
    using MbedCloudSDK.DeviceDirectory.Model.Query;
    using MbedCloudSDK.Exceptions;

    /// <summary>
    /// Device Directory Api
    /// </summary>
    public partial class DeviceDirectoryApi
    {
        /// <summary>
        /// List all queries.
        /// </summary>
        /// <param name="options">Query Options</param>
        /// <returns>Paginated Response of Queries</returns>
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
                var resp = api.DeviceQueryList(options.Limit, options.Order, options.After, options.Include);
                ResponsePage<Query> respDevices = new ResponsePage<Query>(resp.After, resp.HasMore, (int?)resp.Limit, resp.Order, (int?)resp.TotalCount);
                foreach (var deviceQuery in resp.Data)
                {
                    respDevices.Data.Add(Query.Map(deviceQuery));
                }

                return respDevices;
            }
            catch (device_directory.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get query in device query service.
        /// </summary>
        /// <param name="queryId">Query Id</param>
        /// <returns>Query</returns>
        public Query GetQuery(string queryId)
        {
            try
            {
                var response = api.DeviceQueryRetrieve(queryId);
                return Query.Map(response);
            }
            catch (device_directory.Client.ApiException ex)
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
            var deviceQueryPostPutRequest = new device_directory.Model.DeviceQueryPostPutRequest(query.Filter.FilterString, query.Name);

            try
            {
                var response = api.DeviceQueryCreate(deviceQueryPostPutRequest);
                return Query.Map(response);
            }
            catch (device_directory.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Update existing query in device query service.
        /// </summary>
        /// <param name="queryId">Query Id</param>
        /// <param name="queryToUpdate">Query to update</param>
        /// <returns>Query</returns>
        public Query UpdateQuery(string queryId, Query queryToUpdate)
        {
            var originalQuery = GetQuery(queryId);
            var query = Utils.MapToUpdate(originalQuery, queryToUpdate) as Query;
            var deviceQueryPostPutRequest = new device_directory.Model.DeviceQueryPostPutRequest(query.Filter.FilterString, query.Name);

            try
            {
                var response = api.DeviceQueryUpdate(queryId, deviceQueryPostPutRequest);
                return Query.Map(response);
            }
            catch (device_directory.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Deletes the query.
        /// </summary>
        /// <param name="queryId">Query identifier.</param>
        public void DeleteQuery(string queryId)
        {
            try
            {
                api.DeviceQueryDestroy(queryId);
            }
            catch (device_directory.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }
    }
}
