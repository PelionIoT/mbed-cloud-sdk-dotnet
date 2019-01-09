// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 1.0.0
//
// <copyright file="Device.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace MbedCloud.SDK.Entities
{
    using MbedCloud.SDK.Common;
    using MbedCloud.SDK.Client;
    using System;
    using MbedCloud.SDK.Enums;
    using System.Collections.Generic;
    using MbedCloud.SDK.Entities;
    using System.Threading.Tasks;
    using MbedCloudSDK.Exceptions;

    /// <summary>
    /// Device
    /// </summary>
    public class Device : BaseEntity
    {
        public Device()
        {
        }

        public Device(Config config) : base(config)
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
            set;
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
            set;
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
            set;
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
            set;
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
        /// groups
        /// </summary>
        public List<string> Groups
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
            set;
        }

        /// <summary>
        /// last_operator_suspended_description
        /// </summary>
        public string LastOperatorSuspendedDescription
        {
            get;
            set;
        }

        /// <summary>
        /// last_operator_suspended_updated_at
        /// </summary>
        public DateTime? LastOperatorSuspendedUpdatedAt
        {
            get;
            set;
        }

        /// <summary>
        /// last_system_suspended_category
        /// </summary>
        public string LastSystemSuspendedCategory
        {
            get;
            set;
        }

        /// <summary>
        /// last_system_suspended_description
        /// </summary>
        public string LastSystemSuspendedDescription
        {
            get;
            set;
        }

        /// <summary>
        /// last_system_suspended_updated_at
        /// </summary>
        public DateTime? LastSystemSuspendedUpdatedAt
        {
            get;
            set;
        }

        /// <summary>
        /// lifecycle_status
        /// </summary>
        public DeviceLifecycleStatusEnum? LifecycleStatus
        {
            get;
            set;
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
            set;
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
            set;
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
        /// vendor_id
        /// </summary>
        public string VendorId
        {
            get;
            set;
        }

        public async Task<Device> Create()
        {
            try
            {
                var bodyParams = new Device { AutoUpdate = AutoUpdate, BootstrapExpirationDate = BootstrapExpirationDate, BootstrappedTimestamp = BootstrappedTimestamp, CaId = CaId, ConnectorExpirationDate = ConnectorExpirationDate, CustomAttributes = CustomAttributes, Deployment = Deployment, Description = Description, DeviceClass = DeviceClass, DeviceExecutionMode = DeviceExecutionMode, DeviceKey = DeviceKey, EndpointName = EndpointName, EndpointType = EndpointType, FirmwareChecksum = FirmwareChecksum, Groups = Groups, HostGateway = HostGateway, IssuerFingerprint = IssuerFingerprint, Manifest = Manifest, Mechanism = Mechanism, MechanismUrl = MechanismUrl, Name = Name, SerialNumber = SerialNumber, State = State, VendorId = VendorId, };
                return await Client.CallApi<Device>(path: "/v3/devices/", bodyParams: bodyParams, method: HttpMethods.POST, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<Device> Delete()
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "id", Id }, };
                return await Client.CallApi<Device>(path: "/v3/devices/{id}/", pathParams: pathParams, method: HttpMethods.DELETE, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<Device> Get()
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "id", Id }, };
                return await Client.CallApi<Device>(path: "/v3/devices/{id}/", pathParams: pathParams, method: HttpMethods.GET, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public PaginatedResponse<QueryOptions, Device> List(QueryOptions options = null)
        {
            try
            {
                if (options == null)
                {
                    options = new QueryOptions();
                }

                Func<QueryOptions, ResponsePage<Device>> paginatedFunc = (QueryOptions _options) => AsyncHelper.RunSync<ResponsePage<Device>>(() => { var queryParams = new Dictionary<string, object> { { "after", _options.After }, { "include", _options.Include }, { "limit", _options.Limit }, { "order", _options.Order }, }; return Client.CallApi<ResponsePage<Device>>(path: "/v3/devices/", queryParams: queryParams, method: HttpMethods.GET); });
                return new PaginatedResponse<QueryOptions, Device>(paginatedFunc, options);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<CertificateEnrollment> RenewCertificate(string certificateName)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "certificate-name", certificateName }, { "device-id", Id }, };
                return await Client.CallApi<CertificateEnrollment>(path: "/v3/devices/{device-id}/certificates/{certificate-name}/renew", pathParams: pathParams, method: HttpMethods.POST);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<Device> Update()
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "id", Id }, };
                var bodyParams = new Device { AutoUpdate = AutoUpdate, CaId = CaId, CustomAttributes = CustomAttributes, Description = Description, DeviceKey = DeviceKey, EndpointName = EndpointName, EndpointType = EndpointType, Groups = Groups, HostGateway = HostGateway, Name = Name, };
                return await Client.CallApi<Device>(path: "/v3/devices/{id}/", pathParams: pathParams, bodyParams: bodyParams, method: HttpMethods.PUT, objectToUnpack: this);
            }
            catch (MbedCloud.SDK.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}