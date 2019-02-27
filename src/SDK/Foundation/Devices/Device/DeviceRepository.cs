// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="DeviceRepository.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation.Entities
{
    using Mbed.Cloud.Foundation.Common;
    using Mbed.Cloud.Foundation.ListOptions;
    using Mbed.Cloud.Foundation.Entities;
    using System.Threading.Tasks;
    using MbedCloudSDK.Exceptions;
    using System.Collections.Generic;
    using System;
    using Mbed.Cloud.Foundation.RestClient;

    /// <summary>
    /// DeviceRepository
    /// </summary>
    public class DeviceRepository : Repository, IDeviceRepository
    {
        public DeviceRepository()
        {
        }

        public DeviceRepository(Config config, Client client = null) : base(config, client)
        {
        }

        public async Task<Device> Create(Device request)
        {
            try
            {
                var bodyParams = new Device { AutoUpdate = request.AutoUpdate, BootstrapExpirationDate = request.BootstrapExpirationDate, BootstrappedTimestamp = request.BootstrappedTimestamp, CaId = request.CaId, ConnectorExpirationDate = request.ConnectorExpirationDate, CustomAttributes = request.CustomAttributes, Deployment = request.Deployment, Description = request.Description, DeviceClass = request.DeviceClass, DeviceExecutionMode = request.DeviceExecutionMode, DeviceKey = request.DeviceKey, EndpointName = request.EndpointName, EndpointType = request.EndpointType, FirmwareChecksum = request.FirmwareChecksum, HostGateway = request.HostGateway, Manifest = request.Manifest, Mechanism = request.Mechanism, MechanismUrl = request.MechanismUrl, Name = request.Name, SerialNumber = request.SerialNumber, State = request.State, VendorId = request.VendorId, };
                return await Client.CallApi<Device>(path: "/v3/devices/", bodyParams: bodyParams, method: HttpMethods.POST, objectToUnpack: request);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "id", id }, };
                await Client.CallApi<Device>(path: "/v3/devices/{id}/", pathParams: pathParams, method: HttpMethods.DELETE);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<Device> Get(string id)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "id", id }, };
                return await Client.CallApi<Device>(path: "/v3/devices/{id}/", pathParams: pathParams, method: HttpMethods.GET);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public PaginatedResponse<IDeviceListOptions, Device> List(IDeviceListOptions options = null)
        {
            try
            {
                if (options == null)
                {
                    options = new DeviceListOptions();
                }

                Func<IDeviceListOptions, Task<ResponsePage<Device>>> paginatedFunc = async (IDeviceListOptions _options) => { var queryParams = new Dictionary<string, object> { { "after", _options.After }, { "include", _options.Include }, { "limit", _options.Limit }, { "order", _options.Order }, }; return await Client.CallApi<ResponsePage<Device>>(path: "/v3/devices/", queryParams: queryParams, method: HttpMethods.GET); };
                return new PaginatedResponse<IDeviceListOptions, Device>(paginatedFunc, options);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<CertificateEnrollment> RenewCertificate(string certificateName, string id)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "certificate-name", certificateName }, { "device-id", id }, };
                return await Client.CallApi<CertificateEnrollment>(path: "/v3/devices/{device-id}/certificates/{certificate-name}/renew", pathParams: pathParams, method: HttpMethods.POST);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<Device> Update(string id, Device request)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "id", id }, };
                var bodyParams = new Device { AutoUpdate = request.AutoUpdate, CaId = request.CaId, CustomAttributes = request.CustomAttributes, Description = request.Description, DeviceKey = request.DeviceKey, EndpointName = request.EndpointName, EndpointType = request.EndpointType, HostGateway = request.HostGateway, Name = request.Name, };
                return await Client.CallApi<Device>(path: "/v3/devices/{id}/", pathParams: pathParams, bodyParams: bodyParams, method: HttpMethods.PUT, objectToUnpack: request);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}