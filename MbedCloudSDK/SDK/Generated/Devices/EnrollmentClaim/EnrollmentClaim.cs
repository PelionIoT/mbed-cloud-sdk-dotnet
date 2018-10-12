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

    /// <summary>
    /// EnrollmentClaim
    /// </summary>
    public class EnrollmentClaim : BaseModel
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
    }
}