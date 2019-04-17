// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="DeviceEnrollmentDenialListOptions.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation
{
    using Mbed.Cloud.Common;
    using Mbed.Cloud.Common.Filters;

    /// <summary>
    /// DeviceEnrollmentDenialListOptions
    /// </summary>
    public class DeviceEnrollmentDenialListOptions : QueryOptions, IDeviceEnrollmentDenialListOptions
    {
        public DeviceEnrollmentDenialListOptions()
        {
            Filter = new Filter();
        }

        /// <summary>
        /// Filter object
        /// </summary>
        public Filter Filter
        {
            get;
            set;
        }

        public DeviceEnrollmentDenialListOptions TrustedCertificateIdEqualTo(string value)
        {
            this.Filter.AddFilterItem("trusted_certificate_id", new FilterItem(value, FilterOperator.Equals));
            return this;
        }

        public DeviceEnrollmentDenialListOptions EndpointNameEqualTo(string value)
        {
            this.Filter.AddFilterItem("endpoint_name", new FilterItem(value, FilterOperator.Equals));
            return this;
        }
    }
}