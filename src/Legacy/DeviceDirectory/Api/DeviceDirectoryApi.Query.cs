// <copyright file="DeviceDirectoryApi.Query.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.DeviceDirectory.Api
{
    using System.Threading.Tasks;
    using device_directory.Model;
    using Mbed.Cloud.Common;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
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
        /// <param name="options"><see cref="QueryOptions"/></param>
        /// <returns>Paginated Response of <see cref="Query"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var options = new QueryOptions()
        ///     {
        ///         Limit = 5,
        ///     };
        ///     var queries = deviceApi.ListQueries(options).Data;
        ///     foreach (var item in queries)
        ///     {
        ///         Console.WriteLine(item);
        ///     }
        ///     return queries;
        /// }
        /// catch (CloudApiExeption)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public PaginatedResponse<QueryOptions, Query> ListQueries(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                return new PaginatedResponse<QueryOptions, Query>(ListDeviceQueriesFunc, options);
            }
            catch (CloudApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        private async Task<ResponsePage<Query>> ListDeviceQueriesFunc(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                var resp = await Api.DeviceQueryListAsync(limit: options.Limit, order: options.Order, after: options.After, filter: options.Filter?.FilterString, include: options.Include);
                var responsePage = new ResponsePage<Query>(after: resp.After, hasMore: resp.HasMore, totalCount: resp.TotalCount);
                responsePage.MapData<DeviceQuery>(resp.Data, Query.Map);
                return responsePage;
            }
            catch (device_directory.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get query in device query service.
        /// </summary>
        /// <param name="queryId">Id</param>
        /// <returns><see cref="Query"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var query = deviceApi.GetQuery("015c45eb321700000000000100100155");
        ///     return query;
        /// }
        /// catch (CloudApiExeption)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public Query GetQuery(string queryId)
        {
            try
            {
                var response = Api.DeviceQueryRetrieve(queryId);
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
        /// <param name="query"><see cref="Query"/></param>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var query = new Query
        ///     {
        ///         Name = "newQuery",
        ///     };
        ///     query.Filter.Add("state", "bootstrapped");
        ///     var newQuery = api.AddQuery(query);
        ///     return newQuery;
        /// }
        /// catch (CloudApiExeption)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public Query AddQuery(Query query)
        {
            var deviceQueryPostPutRequest = new device_directory.Model.DeviceQueryPostPutRequest(query.Name, query.Filter.FilterString);

            try
            {
                var response = Api.DeviceQueryCreate(deviceQueryPostPutRequest);
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
        /// <param name="queryId">Id</param>
        /// <param name="queryToUpdate"><see cref="Query"/> to update</param>
        /// <returns><see cref="Query"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var query = deviceApi.GetQuery("015c45eb321700000000000100100155");
        ///     var fieldsToUpdate = new Query
        ///     {
        ///         Name = "updatedQuery",
        ///     };
        ///     var updatedQuery = deviceApi.UpdateQuery(query.Id, fieldsToUpdate);
        ///     return updatedQuery;
        /// }
        /// catch (CloudApiExeption)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public Query UpdateQuery(string queryId, Query queryToUpdate)
        {
            var originalQuery = GetQuery(queryId);
            var query = originalQuery.MapToUpdate(queryToUpdate) as Query;
            var deviceQueryPostPutRequest = new device_directory.Model.DeviceQueryPostPutRequest(query.Name, query.Filter.FilterString);

            try
            {
                var response = Api.DeviceQueryUpdate(queryId, deviceQueryPostPutRequest);
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
        /// <param name="queryId">Id</param>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     deviceApi.DeleteQuery("015c45eb321700000000000100100155");
        /// }
        /// catch (CloudApiExeption)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public void DeleteQuery(string queryId)
        {
            try
            {
                Api.DeviceQueryDestroy(queryId);
            }
            catch (device_directory.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }
    }
}
