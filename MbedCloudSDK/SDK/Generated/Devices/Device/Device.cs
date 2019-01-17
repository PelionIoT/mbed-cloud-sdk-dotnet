// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="Device.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation.Entities
{
    using Mbed.Cloud.Foundation.Common;
    using System;
    using System.Collections.Generic;
    using Mbed.Cloud.Foundation.Enums;

    /// <summary>
    /// Device
    /// </summary>
    public class Device : Entity
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
        /// auto_update
        /// </summary>
        public bool? AutoUpdate
        {
            get;
            set;
        }

        /// <summary>
        /// bootstrap_expiration_date
        /// </summary>
        public DateTime? BootstrapExpirationDate
        {
            get;
            set;
        }

        /// <summary>
        /// bootstrapped_timestamp
        /// </summary>
        public DateTime? BootstrappedTimestamp
        {
            get;
            set;
        }

        /// <summary>
        /// ca_id
        /// </summary>
        public string CaId
        {
            get;
            set;
        }

        /// <summary>
        /// connector_expiration_date
        /// </summary>
        public DateTime? ConnectorExpirationDate
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
            internal set;
        }

        /// <summary>
        /// custom_attributes
        /// </summary>
        public Dictionary<string, string> CustomAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// deployed_state
        /// </summary>
        public DeviceDeployedStateEnum? DeployedState
        {
            get;
            internal set;
        }

        /// <summary>
        /// deployment
        /// </summary>
        public string Deployment
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
        /// device_class
        /// </summary>
        public string DeviceClass
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
        /// device_key
        /// </summary>
        public string DeviceKey
        {
            get;
            set;
        }

        /// <summary>
        /// endpoint_name
        /// </summary>
        public string EndpointName
        {
            get;
            internal set;
        }

        /// <summary>
        /// endpoint_type
        /// </summary>
        public string EndpointType
        {
            get;
            set;
        }

        /// <summary>
        /// enrolment_list_timestamp
        /// </summary>
        public DateTime? EnrolmentListTimestamp
        {
            get;
            internal set;
        }

        /// <summary>
        /// firmware_checksum
        /// </summary>
        public string FirmwareChecksum
        {
            get;
            set;
        }

        /// <summary>
        /// host_gateway
        /// </summary>
        public string HostGateway
        {
            get;
            set;
        }

        /// <summary>
        /// issuer_fingerprint
        /// </summary>
        public string IssuerFingerprint
        {
            get;
            set;
        }

        /// <summary>
        /// last_operator_suspended_category
        /// </summary>
        public string LastOperatorSuspendedCategory
        {
            get;
            internal set;
        }

        /// <summary>
        /// last_operator_suspended_description
        /// </summary>
        public string LastOperatorSuspendedDescription
        {
            get;
            internal set;
        }

        /// <summary>
        /// last_operator_suspended_updated_at
        /// </summary>
        public DateTime? LastOperatorSuspendedUpdatedAt
        {
            get;
            internal set;
        }

        /// <summary>
        /// last_system_suspended_category
        /// </summary>
        public string LastSystemSuspendedCategory
        {
            get;
            internal set;
        }

        /// <summary>
        /// last_system_suspended_description
        /// </summary>
        public string LastSystemSuspendedDescription
        {
            get;
            internal set;
        }

        /// <summary>
        /// last_system_suspended_updated_at
        /// </summary>
        public DateTime? LastSystemSuspendedUpdatedAt
        {
            get;
            internal set;
        }

        /// <summary>
        /// lifecycle_status
        /// </summary>
        public DeviceLifecycleStatusEnum? LifecycleStatus
        {
            get;
            internal set;
        }

        /// <summary>
        /// manifest
        /// </summary>
        public string Manifest
        {
            get;
            set;
        }

        /// <summary>
        /// manifest_timestamp
        /// </summary>
        public DateTime? ManifestTimestamp
        {
            get;
            internal set;
        }

        /// <summary>
        /// mechanism
        /// </summary>
        public DeviceMechanismEnum? Mechanism
        {
            get;
            set;
        }

        /// <summary>
        /// mechanism_url
        /// </summary>
        public string MechanismUrl
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
        /// operator_suspended
        /// </summary>
        public bool? OperatorSuspended
        {
            get;
            internal set;
        }

        /// <summary>
        /// serial_number
        /// </summary>
        public string SerialNumber
        {
            get;
            set;
        }

        /// <summary>
        /// state
        /// </summary>
        public DeviceStateEnum? State
        {
            get;
            set;
        }

        /// <summary>
        /// system_suspended
        /// </summary>
        public bool? SystemSuspended
        {
            get;
            internal set;
        }

        /// <summary>
        /// updated_at
        /// </summary>
        public DateTime? UpdatedAt
        {
            get;
            internal set;
        }

        /// <summary>
        /// vendor_id
        /// </summary>
        public string VendorId
        {
            get;
            set;
        }
    }
}