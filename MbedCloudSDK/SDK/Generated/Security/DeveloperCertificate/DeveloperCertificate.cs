// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 1.0.0
//
// <copyright file="DeveloperCertificate.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace MbedCloud.SDK.Entities
{
    using MbedCloud.SDK.Common;
    using System.Collections.Generic;
    using System;
    using MbedCloud.SDK.Entities;
    using System.Threading.Tasks;
    using MbedCloudSDK.Exceptions;
    using MbedCloud.SDK.Client;

    /// <summary>
    /// DeveloperCertificate
    /// </summary>
    public class DeveloperCertificate : BaseEntity
    {
        public DeveloperCertificate()
        {
        }

        public DeveloperCertificate(Config config)
        {
            Config = config;
        }

        internal static Dictionary<string, string> Renames = new Dictionary<string, string>() { { "CertificateContent", "developer_certificate" }, { "Id", "developerCertificateId" }, };

        /// <summary>
        /// account_id
        /// </summary>
        public string AccountId
        {
            get;
            set;
        }

        /// <summary>
        /// certificate_content
        /// </summary>
        public string CertificateContent
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
        /// description
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// developer_private_key
        /// </summary>
        public string DeveloperPrivateKey
        {
            get;
            set;
        }

        /// <summary>
        /// name
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// security_file_content
        /// </summary>
        public string SecurityFileContent
        {
            get;
            set;
        }

        public async Task<DeveloperCertificate> Create()
        {
            try
            {
                var bodyParams = new DeveloperCertificate { Description = Description, Name = Name, };
                return await Client.CallApi<DeveloperCertificate>(path: "/v3/developer-certificates", bodyParams: bodyParams, method: HttpMethods.POST, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<DeveloperCertificate> Delete()
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "cert-id", Id }, };
                return await Client.CallApi<DeveloperCertificate>(path: "/v3/trusted-certificates/{cert-id}", pathParams: pathParams, method: HttpMethods.DELETE, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<DeveloperCertificate> Get()
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "developerCertificateId", Id }, };
                return await Client.CallApi<DeveloperCertificate>(path: "/v3/developer-certificates/{developerCertificateId}", pathParams: pathParams, method: HttpMethods.GET, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<TrustedCertificate> TrustedCertificateInfo()
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "cert-id", Id }, };
                return await Client.CallApi<TrustedCertificate>(path: "/v3/trusted-certificates/{cert-id}", pathParams: pathParams, method: HttpMethods.GET);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}