// <copyright file="DeviceDirectoryApi.Devices.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.DeviceDirectory.Api
{
    using device_directory.Model;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Query;
    using MbedCloudSDK.DeviceDirectory.Model.Device;
    using MbedCloudSDK.Exceptions;

    /// <summary>
    /// Device Directory Api
    /// </summary>
    public partial class DeviceDirectoryApi
    {
        /// <summary>
        /// Lists the devices.
        /// </summary>
        /// <returns>The devices.</returns>
        /// <param name="options">Query options.</param>
        public PaginatedResponse<Device> ListDevices(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                return new PaginatedResponse<Device>(ListDevicesFunc, options);
            }
            catch (CloudApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        private ResponsePage<Device> ListDevicesFunc(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                var resp = api.DeviceList(limit: options.Limit, order: options.Order, after: options.After, filter: options.Filter.FilterString, include: options.Include);
                var respDevices = new ResponsePage<Device>(resp.After, resp.HasMore, resp.Limit, resp.Order, resp.TotalCount);
                foreach (var device in resp.Data)
                {
                    respDevices.Data.Add(Device.Map(device, this));
                }

                return respDevices;
            }
            catch (device_directory.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get device details from catalog.
        /// </summary>
        /// <param name="deviceId">The ID of the device to retrieve.</param>
        /// <returns>Device</returns>
        public Device GetDevice(string deviceId)
        {
            try
            {
                var response = api.DeviceRetrieve(deviceId);
                return Device.Map(response);
            }
            catch (device_directory.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Add a new device to catalog.
        /// </summary>
        /// <param name="device">The device to add to catalog.</param>
        /// <returns>Device</returns>
        public Device AddDevice(Device device)
        {
            try
            {
                var response = api.DeviceCreate(Device.CreatePostRequest(device));
                return GetDevice(response.Id);
            }
            catch (device_directory.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Update existing device in catalog.
        /// </summary>
        /// <param name="deviceId">Device Id</param>
        /// <param name="deviceToUpdate">Device to update</param>
        /// <returns>Device</returns>
        public Device UpdateDevice(string deviceId, Device deviceToUpdate)
        {
            var originalDevice = GetDevice(deviceId);
            var device = Utils.MapToUpdate(originalDevice, deviceToUpdate) as Device;
            try
            {
                var response = api.DeviceUpdate(deviceId, Device.CreatePutRequest(device));
                return GetDevice(deviceId);
            }
            catch (device_directory.Client.ApiException ex)
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
                api.DeviceDestroy(deviceID);
            }
            catch (device_directory.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }
    }
}
