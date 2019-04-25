// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="PreSharedKeyRepository.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation
{
    using Mbed.Cloud.Common;
    using System.Threading.Tasks;
    using MbedCloudSDK.Exceptions;
    using System.Collections.Generic;
    using System;
    using Mbed.Cloud.RestClient;

    /// <summary>
    /// PreSharedKeyRepository
    /// </summary>
    public class PreSharedKeyRepository : Repository, IPreSharedKeyRepository
    {
        public PreSharedKeyRepository()
        {
        }

        public PreSharedKeyRepository(Config config, Client client = null) : base(config, client)
        {
        }

        public async Task<PreSharedKey> Create(PreSharedKey request, string secretHex)
        {
            try
            {
                var bodyParams = new
                {
                    EndpointName = request.EndpointName,
                    secretHex = secretHex,
                };
                return await Client.CallApi<PreSharedKey>(path: "/v2/device-shared-keys", bodyParams: bodyParams, method: HttpMethods.POST, objectToUnpack: request);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "endpoint_name", id }, };
                await Client.CallApi<PreSharedKey>(path: "/v2/device-shared-keys/{endpoint_name}", pathParams: pathParams, method: HttpMethods.DELETE);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public PaginatedResponse<IPreSharedKeyListOptions, PreSharedKey> List(IPreSharedKeyListOptions options = null)
        {
            try
            {
                if (options == null)
                {
                    options = new PreSharedKeyListOptions();
                }

                Func<IPreSharedKeyListOptions, Task<ResponsePage<PreSharedKey>>> paginatedFunc = async (IPreSharedKeyListOptions _options) => { var queryParams = new Dictionary<string, object> { { "after", _options.After }, { "limit", _options.Limit }, }; return await Client.CallApi<ResponsePage<PreSharedKey>>(path: "/v2/device-shared-keys", queryParams: queryParams, method: HttpMethods.GET); };
                return new PaginatedResponse<IPreSharedKeyListOptions, PreSharedKey>(paginatedFunc, options);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<PreSharedKey> Read(string id)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "endpoint_name", id }, };
                return await Client.CallApi<PreSharedKey>(path: "/v2/device-shared-keys/{endpoint_name}", pathParams: pathParams, method: HttpMethods.GET);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}