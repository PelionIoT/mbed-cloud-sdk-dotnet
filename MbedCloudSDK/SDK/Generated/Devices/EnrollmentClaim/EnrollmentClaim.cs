// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 1.0.0
//
// <copyright file="EnrollmentClaim.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace MbedCloud.SDK.Entities
{
    using MbedCloud.SDK.Common;
    using System;
    using System.Threading.Tasks;
    using MbedCloudSDK.Exceptions;
    using MbedCloud.SDK.Client;
    using System.Collections.Generic;

    /// <summary>
    /// EnrollmentClaim
    /// </summary>
    public class EnrollmentClaim : BaseEntity
    {
        public EnrollmentClaim()
        {
        }

        public EnrollmentClaim(Config config)
        {
            Config = config;
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
        /// claimed_at
        /// </summary>
        public DateTime? ClaimedAt
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
        /// enrolled_device_id
        /// </summary>
        public string EnrolledDeviceId
        {
            get;
            set;
        }

        /// <summary>
        /// enrollment_identity
        /// </summary>
        public string EnrollmentIdentity
        {
            get;
            set;
        }

        /// <summary>
        /// expires_at
        /// </summary>
        public DateTime? ExpiresAt
        {
            get;
            set;
        }

        public async Task<EnrollmentClaim> Create()
        {
            try
            {
                var bodyParams = new EnrollmentClaim { EnrollmentIdentity = EnrollmentIdentity, };
                return await Client.CallApi<EnrollmentClaim>(path: "/v3/device-enrollments", bodyParams: bodyParams, method: HttpMethods.POST, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<EnrollmentClaim> Delete()
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "id", Id }, };
                return await Client.CallApi<EnrollmentClaim>(path: "/v3/device-enrollments/{id}", pathParams: pathParams, method: HttpMethods.DELETE, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<EnrollmentClaim> Get()
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "id", Id }, };
                return await Client.CallApi<EnrollmentClaim>(path: "/v3/device-enrollments/{id}", pathParams: pathParams, method: HttpMethods.GET, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public PaginatedResponse<QueryOptions, EnrollmentClaim> List(string after = null, string include = null, int limit = 0, string order = null)
        {
            try
            {
                var queryParams = new Dictionary<string, object> { { "after", after }, { "include", include }, { "limit", limit }, { "order", order }, };
                var options = new QueryOptions { After = after, Include = include, Limit = limit, Order = order, };
                Func<QueryOptions, ResponsePage<EnrollmentClaim>> paginatedFunc = (QueryOptions _options) => AsyncHelper.RunSync<ResponsePage<EnrollmentClaim>>(() => Client.CallApi<ResponsePage<EnrollmentClaim>>(path: "/v3/device-enrollments", queryParams: queryParams, method: HttpMethods.GET));
                return new PaginatedResponse<QueryOptions, EnrollmentClaim>(paginatedFunc, options);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}