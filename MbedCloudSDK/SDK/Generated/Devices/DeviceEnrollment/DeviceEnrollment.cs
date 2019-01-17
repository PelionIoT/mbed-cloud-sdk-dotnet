// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="DeviceEnrollment.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation.Entities
{
    using Mbed.Cloud.Foundation.Common;
    using System;

    /// <summary>
    /// DeviceEnrollment
    /// </summary>
    public class DeviceEnrollment : Entity
    {
        /// <summary>
        /// account_id
        /// </summary>
        public string AccountId
        {
            get;
            internal set;
        }

        /// <summary>
        /// claimed_at
        /// </summary>
        public DateTime? ClaimedAt
        {
            get;
            internal set;
        }

        /// <summary>
        /// created_at
        /// </summary>
        public DateTime? CreatedAt
        {
            get;
            internal set;
        }

        /// <summary>
        /// enrolled_device_id
        /// </summary>
        public string EnrolledDeviceId
        {
            get;
            internal set;
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
            internal set;
        }
    }
}