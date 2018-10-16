// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 1.0.0
//
// <copyright file="CertificateIssuerConfig.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace MbedCloud.SDK.Entities
{
    using MbedCloud.SDK.Common;
    using System.Collections.Generic;
    using System;
    using System.Threading.Tasks;
    using MbedCloudSDK.Exceptions;
    using MbedCloud.SDK.Client;

    /// <summary>
    /// CertificateIssuerConfig
    /// </summary>
    public class CertificateIssuerConfig : BaseEntity
    {
        public CertificateIssuerConfig()
        {
        }

        public CertificateIssuerConfig(Config config)
        {
            Config = config;
        }

        internal static Dictionary<string, string> Renames = new Dictionary<string, string>() { { "Id", "certificate-issuer-configuration-id" }, };

        /// <summary>
        /// certificate_issuer_id
        /// </summary>
        public string CertificateIssuerId
        {
            get;
            set;
        }

        /// <summary>
        /// created_at
        /// </summary>
        public DateTime? CreatedAt
        {
            get;
            set;
        }

        /// <summary>
        /// is_custom
        /// </summary>
        public bool? IsCustom
        {
            get;
            set;
        }

        /// <summary>
        /// reference
        /// </summary>
        public string Reference
        {
            get;
            set;
        }

        /// <summary>
        /// updated_at
        /// </summary>
        public DateTime? UpdatedAt
        {
            get;
            set;
        }

        public async Task<CertificateIssuerConfig> Create()
        {
            try
            {
                var bodyParams = new CertificateIssuerConfig { CertificateIssuerId = CertificateIssuerId, Reference = Reference, };
                return await Client.CallApi<CertificateIssuerConfig>(path: "/v3/certificate-issuer-configurations", bodyParams: bodyParams, method: HttpMethods.POST, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<CertificateIssuerConfig> Delete()
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "certificate-issuer-configuration-id", Id }, };
                return await Client.CallApi<CertificateIssuerConfig>(path: "/v3/certificate-issuer-configurations/{certificate-issuer-configuration-id}", pathParams: pathParams, method: HttpMethods.DELETE, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<CertificateIssuerConfig> Get()
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "certificate-issuer-configuration-id", Id }, };
                return await Client.CallApi<CertificateIssuerConfig>(path: "/v3/certificate-issuer-configurations/{certificate-issuer-configuration-id}", pathParams: pathParams, method: HttpMethods.GET, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public PaginatedResponse<QueryOptions, CertificateIssuerConfig> List()
        {
            try
            {
                var options = new QueryOptions { };
                Func<QueryOptions, ResponsePage<CertificateIssuerConfig>> paginatedFunc = (QueryOptions _options) => AsyncHelper.RunSync<ResponsePage<CertificateIssuerConfig>>(() => Client.CallApi<ResponsePage<CertificateIssuerConfig>>(path: "/v3/certificate-issuer-configurations", method: HttpMethods.GET));
                return new PaginatedResponse<QueryOptions, CertificateIssuerConfig>(paginatedFunc, options);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<CertificateIssuerConfig> Update()
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "certificate-issuer-configuration-id", Id }, };
                var bodyParams = new CertificateIssuerConfig { CertificateIssuerId = CertificateIssuerId, };
                return await Client.CallApi<CertificateIssuerConfig>(path: "/v3/certificate-issuer-configurations/{certificate-issuer-configuration-id}", pathParams: pathParams, bodyParams: bodyParams, method: HttpMethods.PUT, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}