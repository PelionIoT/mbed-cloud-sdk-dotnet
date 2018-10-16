// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 1.0.0
//
// <copyright file="EnrollmentBulkCreateTask.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace MbedCloud.SDK.Entities
{
    using MbedCloud.SDK.Common;
    using System;
    using MbedCloud.SDK.Enums;
    using System.IO;
    using System.Threading.Tasks;
    using MbedCloudSDK.Exceptions;
    using MbedCloud.SDK.Client;
    using System.Collections.Generic;

    /// <summary>
    /// EnrollmentBulkCreateTask
    /// </summary>
    public class EnrollmentBulkCreateTask : BaseEntity
    {
        public EnrollmentBulkCreateTask()
        {
        }

        public EnrollmentBulkCreateTask(Config config)
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
        /// completed_at
        /// </summary>
        public DateTime? CompletedAt
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
        /// errors_count
        /// </summary>
        public int? ErrorsCount
        {
            get;
            set;
        }

        /// <summary>
        /// errors_report_file
        /// </summary>
        public string ErrorsReportFile
        {
            get;
            set;
        }

        /// <summary>
        /// full_report_file
        /// </summary>
        public string FullReportFile
        {
            get;
            set;
        }

        /// <summary>
        /// processed_count
        /// </summary>
        public int? ProcessedCount
        {
            get;
            set;
        }

        /// <summary>
        /// status
        /// </summary>
        public EnrollmentBulkCreateTaskStatusEnum? Status
        {
            get;
            set;
        }

        /// <summary>
        /// total_count
        /// </summary>
        public int? TotalCount
        {
            get;
            set;
        }

        public async Task<EnrollmentBulkCreateTask> Create(Stream enrollmentIdentities)
        {
            try
            {
                var fileParams = new Dictionary<string, Stream> { { "enrollment_identities", enrollmentIdentities }, };
                return await Client.CallApi<EnrollmentBulkCreateTask>(path: "/v3/device-enrollments-bulk-uploads", fileParams: fileParams, method: HttpMethods.POST, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<EnrollmentBulkCreateTask> Get()
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "id", Id }, };
                return await Client.CallApi<EnrollmentBulkCreateTask>(path: "/v3/device-enrollments-bulk-uploads/{id}", pathParams: pathParams, method: HttpMethods.GET, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}