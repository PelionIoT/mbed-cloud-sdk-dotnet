// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="SubtenantDarkThemeColorRepository.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation
{
    using Mbed.Cloud.Common;
    using Mbed.Cloud.Foundation;
    using System.Threading.Tasks;
    using MbedCloudSDK.Exceptions;
    using System.Collections.Generic;
    using System;
    using Mbed.Cloud.RestClient;

    /// <summary>
    /// SubtenantDarkThemeColorRepository
    /// </summary>
    public class SubtenantDarkThemeColorRepository : Repository, ISubtenantDarkThemeColorRepository
    {
        public SubtenantDarkThemeColorRepository()
        {
        }

        public SubtenantDarkThemeColorRepository(Config config, Client client = null) : base(config, client)
        {
        }

        public async Task Delete(string accountId, string reference)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "account_id", accountId }, { "reference", reference }, };
                await Client.CallApi<SubtenantDarkThemeColor>(path: "/v3/accounts/{account_id}/branding-colors/dark/{reference}", pathParams: pathParams, method: HttpMethods.DELETE);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public PaginatedResponse<ISubtenantDarkThemeColorSubtenantDarkThemeColorListOptions, SubtenantDarkThemeColor> List(string accountId, ISubtenantDarkThemeColorSubtenantDarkThemeColorListOptions options = null)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "account_id", accountId }, };
                if (options == null)
                {
                    options = new SubtenantDarkThemeColorSubtenantDarkThemeColorListOptions();
                }

                Func<ISubtenantDarkThemeColorSubtenantDarkThemeColorListOptions, Task<ResponsePage<SubtenantDarkThemeColor>>> paginatedFunc = async (ISubtenantDarkThemeColorSubtenantDarkThemeColorListOptions _options) => { return await Client.CallApi<ResponsePage<SubtenantDarkThemeColor>>(path: "/v3/accounts/{account_id}/branding-colors/dark", pathParams: pathParams, method: HttpMethods.GET); };
                return new PaginatedResponse<ISubtenantDarkThemeColorSubtenantDarkThemeColorListOptions, SubtenantDarkThemeColor>(paginatedFunc, options);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<SubtenantDarkThemeColor> Read(string accountId, string reference)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "account_id", accountId }, { "reference", reference }, };
                return await Client.CallApi<SubtenantDarkThemeColor>(path: "/v3/accounts/{account_id}/branding-colors/dark/{reference}", pathParams: pathParams, method: HttpMethods.GET);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<SubtenantDarkThemeColor> Update(string accountId, string reference, SubtenantDarkThemeColor request)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "account_id", accountId }, { "reference", reference }, };
                var bodyParams = new SubtenantDarkThemeColor { Color = request.Color, UpdatedAt = request.UpdatedAt, };
                return await Client.CallApi<SubtenantDarkThemeColor>(path: "/v3/accounts/{account_id}/branding-colors/dark/{reference}", pathParams: pathParams, bodyParams: bodyParams, objectToUnpack: request, method: HttpMethods.PUT);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}