// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="DeveloperCertificateRepository.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation.Entities
{
    using Mbed.Cloud.Foundation.Common;
    using Mbed.Cloud.Foundation.Entities;
    using System.Threading.Tasks;
    using MbedCloudSDK.Exceptions;
    using System.Collections.Generic;
    using System;
    using Mbed.Cloud.Foundation.RestClient;

    /// <summary>
    /// DeveloperCertificateRepository
    /// </summary>
    public class DeveloperCertificateRepository : Repository
    {
        public DeveloperCertificateRepository()
        {
        }

        public DeveloperCertificateRepository(Config config, Client client = null) : base(config, client)
        {
        }

        public async Task<DeveloperCertificate> Create(DeveloperCertificate request)
        {
            try
            {
                var bodyParams = new DeveloperCertificate { Description = request.Description, Name = request.Name, };
                return await Client.CallApi<DeveloperCertificate>(path: "/v3/developer-certificates", bodyParams: bodyParams, method: HttpMethods.POST, objectToUnpack: request);
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
                var pathParams = new Dictionary<string, object> { { "cert_id", id }, };
                await Client.CallApi<DeveloperCertificate>(path: "/v3/trusted-certificates/{cert_id}", pathParams: pathParams, method: HttpMethods.DELETE);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<DeveloperCertificate> Get(string id)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "developerCertificateId", id }, };
                return await Client.CallApi<DeveloperCertificate>(path: "/v3/developer-certificates/{developerCertificateId}", pathParams: pathParams, method: HttpMethods.GET);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<TrustedCertificate> GetTrustedCertificateInfo(string id)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "cert_id", id }, };
                return await Client.CallApi<TrustedCertificate>(path: "/v3/trusted-certificates/{cert_id}", pathParams: pathParams, method: HttpMethods.GET);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}