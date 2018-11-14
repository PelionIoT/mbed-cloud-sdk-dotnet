// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 1.0.0
//
// <copyright file="SubtenantTrustedCertificate.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace MbedCloud.SDK.Entities
{
    using MbedCloud.SDK.Common;
    using MbedCloud.SDK.Client;
    using System;
    using MbedCloud.SDK.Enums;
    using MbedCloud.SDK.Entities;
    using System.Threading.Tasks;
    using MbedCloudSDK.Exceptions;
    using System.Collections.Generic;

    /// <summary>
    /// SubtenantTrustedCertificate
    /// </summary>
    public class SubtenantTrustedCertificate : BaseEntity
    {
        public SubtenantTrustedCertificate()
        {
        }

        public SubtenantTrustedCertificate(Config config) : base(config)
        {
        }

        /// <summary>
        /// account_id
        /// </summary>
        public string AccountId
        {
            get;
            set;
        }

        /// <summary>
        /// certificate
        /// </summary>
        public string Certificate
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
        /// device_execution_mode
        /// </summary>
        public int? DeviceExecutionMode
        {
            get;
            set;
        }

        /// <summary>
        /// enrollment_mode
        /// </summary>
        public bool? EnrollmentMode
        {
            get;
            set;
        }

        /// <summary>
        /// is_developer_certificate
        /// </summary>
        public bool? IsDeveloperCertificate
        {
            get
            {
                return CustomFunctions.IsDeveloperCertificateGetter(this);
            }

            set
            {
                CustomFunctions.IsDeveloperCertificateSetter(this, value);
            }
        }

        /// <summary>
        /// issuer
        /// </summary>
        public string Issuer
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
        /// owner_id
        /// </summary>
        public string OwnerId
        {
            get;
            set;
        }

        /// <summary>
        /// service
        /// </summary>
        public SubtenantTrustedCertificateServiceEnum? Service
        {
            get;
            set;
        }

        /// <summary>
        /// status
        /// </summary>
        public SubtenantTrustedCertificateStatusEnum? Status
        {
            get;
            set;
        }

        /// <summary>
        /// subject
        /// </summary>
        public string Subject
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

        /// <summary>
        /// validity
        /// </summary>
        public DateTime? Validity
        {
            get;
            set;
        }

        public async Task<SubtenantTrustedCertificate> Create(string accountID)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "accountID", accountID }, };
                var bodyParams = new SubtenantTrustedCertificate { Certificate = Certificate, Description = Description, EnrollmentMode = EnrollmentMode, Name = Name, Service = Service, Status = Status, };
                return await Client.CallApi<SubtenantTrustedCertificate>(path: "/v3/accounts/{accountID}/trusted-certificates", pathParams: pathParams, bodyParams: bodyParams, method: HttpMethods.POST, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<SubtenantTrustedCertificate> Delete(string accountID)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "accountID", accountID }, { "cert-id", Id }, };
                return await Client.CallApi<SubtenantTrustedCertificate>(path: "/v3/accounts/{accountID}/trusted-certificates/{cert-id}", pathParams: pathParams, method: HttpMethods.DELETE, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<DeveloperCertificate> DeveloperCertificateInfo()
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "developerCertificateId", Id }, };
                return await Client.CallApi<DeveloperCertificate>(path: "/v3/developer-certificates/{developerCertificateId}", pathParams: pathParams, method: HttpMethods.GET);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<SubtenantTrustedCertificate> Get(string accountID)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "accountID", accountID }, { "cert-id", Id }, };
                return await Client.CallApi<SubtenantTrustedCertificate>(path: "/v3/accounts/{accountID}/trusted-certificates/{cert-id}", pathParams: pathParams, method: HttpMethods.GET, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<SubtenantTrustedCertificate> Update(string accountID)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "accountID", accountID }, { "cert-id", Id }, };
                var bodyParams = new SubtenantTrustedCertificate { Certificate = Certificate, Description = Description, EnrollmentMode = EnrollmentMode, Name = Name, Service = Service, Status = Status, };
                return await Client.CallApi<SubtenantTrustedCertificate>(path: "/v3/accounts/{accountID}/trusted-certificates/{cert-id}", pathParams: pathParams, bodyParams: bodyParams, method: HttpMethods.PUT, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}