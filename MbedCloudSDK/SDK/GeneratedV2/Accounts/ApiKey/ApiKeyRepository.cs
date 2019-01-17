using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MbedCloud.SDK.Client;
using MbedCloud.SDK.Common;
using MbedCloudSDK.Exceptions;

namespace MbedCloud.SDK.GeneratedV2.Accounts.ApiKey
{
    public class ApiKeyRepository : Repository
    {
        public async Task<ApiKey> Create(ApiKey request)
        {
            try
            {
                var bodyParams = new ApiKey { Name = request.Name, Owner = request.Owner, Status = request.Status, };
                return await Client.CallApi<ApiKey>(path: "/v3/api-keys", bodyParams: bodyParams, method: HttpMethods.POST, objectToUnpack: request);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async void Delete(string id)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "apikey_id", id }, };
                await Client.CallApi<ApiKey>(path: "/v3/api-keys/{apikey_id}", pathParams: pathParams, method: HttpMethods.DELETE);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<ApiKey> Get(string id)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "apikey_id", id }, };
                return await Client.CallApi<ApiKey>(path: "/v3/api-keys/{apikey_id}", pathParams: pathParams, method: HttpMethods.GET);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public PaginatedResponse<QueryOptions, ApiKey> List(QueryOptions options = null)
        {
            try
            {
                if (options == null)
                {
                    options = new QueryOptions();
                }

                Func<QueryOptions, ResponsePage<ApiKey>> paginatedFunc = (QueryOptions _options) => AsyncHelper.RunSync<ResponsePage<ApiKey>>(() => { var queryParams = new Dictionary<string, object> { { "after", _options.After }, { "include", _options.Include }, { "limit", _options.Limit }, { "order", _options.Order }, }; return Client.CallApi<ResponsePage<ApiKey>>(path: "/v3/api-keys", queryParams: queryParams, method: HttpMethods.GET); });
                return new PaginatedResponse<QueryOptions, ApiKey>(paginatedFunc, options);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<ApiKey> Me()
        {
            try
            {
                return await Client.CallApi<ApiKey>(path: "/v3/api-keys/me", method: HttpMethods.GET);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<ApiKey> Update(string id, ApiKey request)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "apikey_id", id }, };
                var bodyParams = new ApiKey { Name = request.Name, Owner = request.Owner, Status = request.Status, };
                return await Client.CallApi<ApiKey>(path: "/v3/api-keys/{apikey_id}", pathParams: pathParams, bodyParams: bodyParams, method: HttpMethods.PUT, objectToUnpack: request);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}