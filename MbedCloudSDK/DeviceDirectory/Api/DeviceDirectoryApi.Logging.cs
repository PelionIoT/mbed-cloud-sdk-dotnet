using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Query;
using MbedCloudSDK.DeviceDirectory.Model.Logging;
using MbedCloudSDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MbedCloudSDK.DeviceDirectory.Api
{
    public partial class DeviceDirectoryApi
    {
        /// <summary>
        /// Lists the device logs.
        /// </summary>
        /// <returns>The device logs.</returns>
        /// <param name="options">Query options.</param>
        public PaginatedResponse<DeviceLog> ListDeviceEvents(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }
            try
            {
                return new PaginatedResponse<DeviceLog>(ListDeviceEventsFunc, options);
            }
            catch (CloudApiException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Lists the device logs.
        /// </summary>
        /// <returns>The device logs.</returns>
        /// <param name="options">Query options.</param>
        private ResponsePage<DeviceLog> ListDeviceEventsFunc(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }
            try
            {
                var resp = this.api.DeviceLogList(options.Limit, options.Order, options.After, options.Filter.FilterString, options.Include);
                var respDeviceLogs = new ResponsePage<DeviceLog>(resp.After, resp.HasMore, resp.Limit, resp.Order, resp.TotalCount);
                foreach (var deviceLog in resp.Data)
                {
                    respDeviceLogs.Data.Add(DeviceLog.Map(deviceLog));
                }
                return respDeviceLogs;
            }
            catch (device_directory.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Gets the device log.
        /// </summary>
        /// <returns>The device log.</returns>
        /// <param name="deviceLogId">Device log identifier.</param>
        public DeviceLog GetDeviceEvent(string deviceEventId)
        {
            try
            {
                return DeviceLog.Map(api.DeviceLogRetrieve(deviceEventId));
            }
            catch (device_directory.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Gets the device log asynchronously.
        /// </summary>
        /// <returns>The device log.</returns>
        /// <param name="deviceLogId">Device log identifier.</param>
        public async Task<DeviceLog> GetDeviceEventAsync(string deviceLogId)
        {
            try
            {
                return DeviceLog.Map(await api.DeviceLogRetrieveAsync(deviceLogId));
            }
            catch (device_directory.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
