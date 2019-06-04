// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="SubtenantDarkThemeImageRepository.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation
{
    using Mbed.Cloud.Common;
    using System.IO;
    using System.Threading.Tasks;
    using MbedCloudSDK.Exceptions;
    using System.Collections.Generic;
    using System;
    using Mbed.Cloud.RestClient;

    /// <summary>
    /// SubtenantDarkThemeImageRepository
    /// </summary>
    public class SubtenantDarkThemeImageRepository : Repository, ISubtenantDarkThemeImageRepository
    {
        public SubtenantDarkThemeImageRepository()
        {
        }

        public SubtenantDarkThemeImageRepository(Config config, Client client = null) : base(config, client)
        {
        }

        public async Task<SubtenantDarkThemeImage> Create(string accountId, string reference, Stream image)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "account_id", accountId }, { "reference", reference }, };
                var fileParams = new Dictionary<string, Stream> { { "image", image }, };
                return await Client.CallApi<SubtenantDarkThemeImage>(path: "/v3/accounts/{account_id}/branding-images/dark/{reference}/upload-multipart", pathParams: pathParams, fileParams: fileParams, method: HttpMethods.POST);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<SubtenantDarkThemeImage> Delete(string accountId, string reference)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "account_id", accountId }, { "reference", reference }, };
                return await Client.CallApi<SubtenantDarkThemeImage>(path: "/v3/accounts/{account_id}/branding-images/dark/{reference}/clear", pathParams: pathParams, method: HttpMethods.POST);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public PaginatedResponse<ISubtenantDarkThemeImageSubtenantDarkThemeImageListOptions, SubtenantDarkThemeImage> List(string accountId, ISubtenantDarkThemeImageSubtenantDarkThemeImageListOptions options = null)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "account_id", accountId }, };
                if (options == null)
                {
                    options = new SubtenantDarkThemeImageSubtenantDarkThemeImageListOptions();
                }

                Func<ISubtenantDarkThemeImageSubtenantDarkThemeImageListOptions, Task<ResponsePage<SubtenantDarkThemeImage>>> paginatedFunc = async (ISubtenantDarkThemeImageSubtenantDarkThemeImageListOptions _options) => { return await Client.CallApi<ResponsePage<SubtenantDarkThemeImage>>(path: "/v3/accounts/{account_id}/branding-images/dark", pathParams: pathParams, method: HttpMethods.GET); };
                return new PaginatedResponse<ISubtenantDarkThemeImageSubtenantDarkThemeImageListOptions, SubtenantDarkThemeImage>(paginatedFunc, options);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<SubtenantDarkThemeImage> Read(string accountId, string reference)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "account_id", accountId }, { "reference", reference }, };
                return await Client.CallApi<SubtenantDarkThemeImage>(path: "/v3/accounts/{account_id}/branding-images/dark/{reference}", pathParams: pathParams, method: HttpMethods.GET);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}