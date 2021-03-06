// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="SubtenantTrustedCertificateRepository.cs" company="Arm">
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
    /// SubtenantTrustedCertificateRepository
    /// </summary>
    public class SubtenantTrustedCertificateRepository : Repository, ISubtenantTrustedCertificateRepository
    {
        public SubtenantTrustedCertificateRepository()
        {
        }

        public SubtenantTrustedCertificateRepository(Config config, Client client = null) : base(config, client)
        {
        }

        public async Task<SubtenantTrustedCertificate> Create(string accountId, SubtenantTrustedCertificate request)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "account_id", accountId }, };
                var bodyParams = new SubtenantTrustedCertificate { Certificate = request.Certificate, Description = request.Description, EnrollmentMode = request.EnrollmentMode, Name = request.Name, Service = request.Service, Status = request.Status, };
                return await Client.CallApi<SubtenantTrustedCertificate>(path: "/v3/accounts/{account_id}/trusted-certificates", pathParams: pathParams, bodyParams: bodyParams, objectToUnpack: request, method: HttpMethods.POST);
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
                var pathParams = new Dictionary<string, object> { { "account_id", accountId }, { "cert_id", id }, };
                await Client.CallApi<SubtenantTrustedCertificate>(path: "/v3/accounts/{account_id}/trusted-certificates/{cert_id}", pathParams: pathParams, method: HttpMethods.DELETE);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<DeveloperCertificate> GetDeveloperCertificateInfo(string id)
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

        public async Task<SubtenantTrustedCertificate> Read(string accountId, string id)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "account_id", accountId }, { "cert_id", id }, };
                return await Client.CallApi<SubtenantTrustedCertificate>(path: "/v3/accounts/{account_id}/trusted-certificates/{cert_id}", pathParams: pathParams, method: HttpMethods.GET);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<SubtenantTrustedCertificate> Update(string accountId, string id, SubtenantTrustedCertificate request)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "account_id", accountId }, { "cert_id", id }, };
                var bodyParams = new SubtenantTrustedCertificate { Certificate = request.Certificate, Description = request.Description, EnrollmentMode = request.EnrollmentMode, Name = request.Name, Service = request.Service, Status = request.Status, };
                return await Client.CallApi<SubtenantTrustedCertificate>(path: "/v3/accounts/{account_id}/trusted-certificates/{cert_id}", pathParams: pathParams, bodyParams: bodyParams, objectToUnpack: request, method: HttpMethods.PUT);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}