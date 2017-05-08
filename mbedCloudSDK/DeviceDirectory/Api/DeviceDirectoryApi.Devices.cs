using mbedCloudSDK.Common;
using mbedCloudSDK.Common.Query;
using mbedCloudSDK.DeviceDirectory.Model.Device;
using mbedCloudSDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var resp = api.DeviceList(options.Limit, options.Order, options.After, options.QueryString);
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

        /// <summary>
        /// Deletes the device.
        /// </summary>
        /// <param name="deviceID">Device identifier.</param>
        public void DeleteDevice(string deviceID)
        {
            this.api.DeviceDestroy(deviceID);
        }
    }
}
