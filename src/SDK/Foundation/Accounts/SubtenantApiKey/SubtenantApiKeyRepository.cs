// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="SubtenantApiKeyRepository.cs" company="Arm">
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
    /// SubtenantApiKeyRepository
    /// </summary>
    public class SubtenantApiKeyRepository : Repository, ISubtenantApiKeyRepository
    {
        public SubtenantApiKeyRepository()
        {
        }

        public SubtenantApiKeyRepository(Config config, Client client = null) : base(config, client)
        {
        }

        public async Task<SubtenantApiKey> Create(string accountId, SubtenantApiKey request)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "account_id", accountId }, };
                var bodyParams = new SubtenantApiKey { Name = request.Name, Owner = request.Owner, Status = request.Status, };
                return await Client.CallApi<SubtenantApiKey>(path: "/v3/accounts/{account_id}/api-keys", pathParams: pathParams, bodyParams: bodyParams, method: HttpMethods.POST, objectToUnpack: request);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task Delete(string accountId, string id)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "account_id", accountId }, { "apikey_id", id }, };
                await Client.CallApi<SubtenantApiKey>(path: "/v3/accounts/{account_id}/api-keys/{apikey_id}", pathParams: pathParams, method: HttpMethods.DELETE);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<SubtenantApiKey> Read(string accountId, string id)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "account_id", accountId }, { "apikey_id", id }, };
                return await Client.CallApi<SubtenantApiKey>(path: "/v3/accounts/{account_id}/api-keys/{apikey_id}", pathParams: pathParams, method: HttpMethods.GET);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<SubtenantApiKey> Update(string accountId, string id, SubtenantApiKey request)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "account_id", accountId }, { "apikey_id", id }, };
                var bodyParams = new SubtenantApiKey { Name = request.Name, Owner = request.Owner, Status = request.Status, };
                return await Client.CallApi<SubtenantApiKey>(path: "/v3/accounts/{account_id}/api-keys/{apikey_id}", pathParams: pathParams, bodyParams: bodyParams, method: HttpMethods.PUT, objectToUnpack: request);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}