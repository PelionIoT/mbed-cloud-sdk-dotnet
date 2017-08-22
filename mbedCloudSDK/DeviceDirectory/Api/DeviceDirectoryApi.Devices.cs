using mbedCloudSDK.Common;
using mbedCloudSDK.Common.Query;
using mbedCloudSDK.DeviceDirectory.Model.Device;
using mbedCloudSDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using device_catalog.Model;

namespace mbedCloudSDK.DeviceDirectory.Api
{
    public partial class DeviceDirectoryApi
    {
        /// <summary>
        /// Lists the devices.
        /// </summary>
        /// <returns>The devices.</returns>
        /// <param name="options">Query options.</param>
        public PaginatedResponse<Device> ListDevices(DeviceQueryOptions options = null)
        {
            if (options == null)
            {
                options = new DeviceQueryOptions();
            }
            try
            {
                if (!string.IsNullOrEmpty(options.AttributesString) && options.Attributes == null)
                {
                    options.Attributes = Utils.ParseAttributeString(options.AttributesString);
                }
                return new PaginatedResponse<Device>(ListDevicesFunc, options);
            }
            catch (CloudApiException e)
            {
                throw e;
            }
        }

        private ResponsePage<Device> ListDevicesFunc(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new DeviceQueryOptions();
            }
            try
            {
                var resp = api.DeviceList(options.Limit, options.Order, options.After, options.QueryString, options.Include);
                ResponsePage<Device> respDevices = new ResponsePage<Device>(resp.After, resp.HasMore, resp.Limit, resp.Order, resp.TotalCount);
                foreach (var device in resp.Data)
                {
                    respDevices.Data.Add(Device.Map(device, this));
                }
                return respDevices;
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public Device GetDevice(string deviceId){
            try
            {
                var response = api.DeviceRetrieve(deviceId);
                return Device.Map(response);
            }
            catch(device_catalog.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        public Device AddDevice(Device device){
            var deviceDataPostRequest = new device_catalog.Model.DeviceDataPostRequest(DeviceKey:device.CertificateFingerprint,CaId:device.CertificateIssuerId){
                BootstrapExpirationDate = device.BootstrapExpirationDate,
                BootstrappedTimestamp = device.BootstrappedTimestamp,
                ConnectorExpirationDate = device.ConnectorExpirationDate,
                Mechanism = GetMechanismEnum(device),
                DeviceClass = device.DeviceClass,
                EndpointName = device.EndpointName,
                AutoUpdate = device.AutoUpdate,
                HostGateway = device.HostGateway,
                DeviceExecutionMode = device.DeviceExecutionMode,
                CustomAttributes = device.CustomAttributes,
                State = GetStateEnum(device),
                SerialNumber = device.SerialNumber,
                FirmwareChecksum = device.FirmwareChecksum,
                VendorId = device.VendorId,
                Description = device.Description,
                _Object = device._Object,
                EndpointType = device.EndpointType,
                Deployment = device.Deployment,
                MechanismUrl = device.MechanismUrl,
                TrustLevel = device.TrustLevel,
                Name = device.Name,
                DeviceKey = device.CertificateFingerprint,
                Manifest = device.Manifest,
                CaId = device.CertificateIssuerId
            };

            try
            {
                var response = api.DeviceCreate(deviceDataPostRequest);
                return GetDevice(response.Id);
            }
            catch(device_catalog.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }

        }

        public Device UpdateDevice(string deviceId, Device deviceToUpdate)
        {
            var originalDevice = GetDevice(deviceId);
            var device = Utils.MapToUpdate(originalDevice, deviceToUpdate) as Device;
            var deviceDataPutRequest = new device_catalog.Model.DeviceDataPutRequest(CaId: device.CertificateIssuerId, DeviceKey: device.CertificateFingerprint)
            {
                Description = device.Description,
                EndpointName = device.EndpointName,
                AutoUpdate = device.AutoUpdate,
                HostGateway = device.HostGateway,
                _Object = device._Object,
                CustomAttributes = device.CustomAttributes,
                EndpointType = device.EndpointType,
                Name = device.Name
            };

            try
            {
                var response = api.DeviceUpdate(deviceId, deviceDataPutRequest);
                return GetDevice(deviceId);
            }
            catch (device_catalog.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Deletes the device.
        /// </summary>
        /// <param name="deviceID">Device identifier.</param>
        public void DeleteDevice(string deviceID)
        {
            try
            {
                this.api.DeviceDestroy(deviceID);
            }
            catch (device_catalog.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        private DeviceDataPostRequest.MechanismEnum GetMechanismEnum(Device device){
            if (device.Mechanism.HasValue)
            {
                DeviceDataPostRequest.MechanismEnum mechanismEnum;
                switch (device.Mechanism.Value)
                {
                    case Mechanism.Connector:
                        mechanismEnum = DeviceDataPostRequest.MechanismEnum.Connector;
                        break;
                    case Mechanism.Direct:
                        mechanismEnum = DeviceDataPostRequest.MechanismEnum.Direct;
                        break;
                    default:
                        mechanismEnum = DeviceDataPostRequest.MechanismEnum.Connector;
                        break;
                }
                return mechanismEnum;
            }
            return DeviceDataPostRequest.MechanismEnum.Connector;
        }

        private DeviceDataPostRequest.StateEnum GetStateEnum(Device device){
            if (device.State.HasValue)
            {
                DeviceDataPostRequest.StateEnum stateEnum;
                switch (device.State.Value)
                {
                    case State.Bootstrapped:
                        stateEnum = DeviceDataPostRequest.StateEnum.Bootstrapped;
                        break;
                    case State.Cloudenrolling:
                        stateEnum = DeviceDataPostRequest.StateEnum.Cloudenrolling;
                        break;
                    case State.Deregistered:
                        stateEnum = DeviceDataPostRequest.StateEnum.Deregistered;
                        break;
                    case State.Registered:
                        stateEnum = DeviceDataPostRequest.StateEnum.Registered;
                        break;
                    case State.Unenrolled:
                        stateEnum = DeviceDataPostRequest.StateEnum.Unenrolled;
                        break;
                    default:
                        stateEnum = DeviceDataPostRequest.StateEnum.Bootstrapped;
                        break;
                }
                return stateEnum;
            }
            return DeviceDataPostRequest.StateEnum.Bootstrapped;
        }
    }
}
