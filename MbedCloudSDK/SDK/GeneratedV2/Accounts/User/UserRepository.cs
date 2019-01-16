using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MbedCloud.SDK.Client;
using MbedCloud.SDK.Common;
using MbedCloudSDK.Exceptions;
using MbedCloudSDK.SDK.Common;

namespace MbedCloud.SDK.GeneratedV2.Accounts.User
{
    public class UserRepository : Repository
    {
        public async Task<User> Create(User request, string action = null)
        {
            try
            {
                var queryParams = new Dictionary<string, object> { { "action", action }, };
                var bodyParams = new User { Address = request.Address, Email = request.Email, FullName = request.FullName, MarketingAccepted = request.MarketingAccepted, Password = request.Password, PhoneNumber = request.PhoneNumber, TermsAccepted = request.TermsAccepted, Username = request.Username, };
                return await Client.CallApi<User>(path: "/v3/users", queryParams: queryParams, bodyParams: bodyParams, method: HttpMethods.POST, objectToUnpack: request);
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
                var pathParams = new Dictionary<string, object> { { "user_id", id }, };
                await Client.CallApi<User>(path: "/v3/users/{user_id}", pathParams: pathParams, method: HttpMethods.DELETE);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<User> Get(string id)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "user_id", id }, };
                return await Client.CallApi<User>(path: "/v3/users/{user_id}", pathParams: pathParams, method: HttpMethods.GET);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public PaginatedResponse<QueryOptions, User> List(QueryOptions options = null)
        {
            try
            {
                if (options == null)
                {
                    options = new QueryOptions();
                }

                Func<QueryOptions, ResponsePage<User>> paginatedFunc = (QueryOptions _options) => AsyncHelper.RunSync<ResponsePage<User>>(() => { var queryParams = new Dictionary<string, object> { { "after", _options.After }, { "include", _options.Include }, { "limit", _options.Limit }, { "order", _options.Order }, }; return Client.CallApi<ResponsePage<User>>(path: "/v3/users", queryParams: queryParams, method: HttpMethods.GET); });
                return new PaginatedResponse<QueryOptions, User>(paginatedFunc, options);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<User> Update(string id, User request)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "user_id", id }, };
                var bodyParams = new User { Address = request.Address, FullName = request.FullName, MarketingAccepted = request.MarketingAccepted, PhoneNumber = request.PhoneNumber, TermsAccepted = request.TermsAccepted, TwoFactorAuthentication = request.TwoFactorAuthentication, Username = request.Username, };
                return await Client.CallApi<User>(path: "/v3/users/{user_id}", pathParams: pathParams, bodyParams: bodyParams, method: HttpMethods.PUT, objectToUnpack: request);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}