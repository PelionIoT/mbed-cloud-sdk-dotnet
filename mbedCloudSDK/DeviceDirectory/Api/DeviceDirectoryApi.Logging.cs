using mbedCloudSDK.Common;
using mbedCloudSDK.Common.Query;
using mbedCloudSDK.DeviceDirectory.Model.Logging;
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
        /// Lists the device logs.
        /// </summary>
        /// <returns>The device logs.</returns>
        /// <param name="options">Query options.</param>
        public PaginatedResponse<DeviceLog> ListDeviceLogs(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }
            try
            {
                return new PaginatedResponse<DeviceLog>(ListDeviceLogsFunc, options);
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
        private ResponsePage<DeviceLog> ListDeviceLogsFunc(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }
            try
            {
                var resp = this.api.DeviceLogList(options.Limit, options.Order, options.After, options.QueryString);
                ResponsePage<DeviceLog> respDeviceLogs = new ResponsePage<DeviceLog>(resp.After, resp.HasMore, resp.Limit, resp.Order, resp.TotalCount);
                foreach (var deviceLog in resp.Data)
                {
                    respDeviceLogs.Data.Add(DeviceLog.Map(deviceLog));
                }
                return respDeviceLogs;
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Gets the device log.
        /// </summary>
        /// <returns>The device log.</returns>
        /// <param name="deviceLogId">Device log identifier.</param>
        public DeviceLog GetDeviceLog(string deviceLogId)
        {
            try
            {
                return DeviceLog.Map(this.api.DeviceLogRetrieve(deviceLogId));
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Gets the device log asynchronously.
        /// </summary>
        /// <returns>The device log.</returns>
        /// <param name="deviceLogId">Device log identifier.</param>
        public async Task<DeviceLog> GetDeviceLogAsync(string deviceLogId)
        {
            try
            {
                return DeviceLog.Map(await this.api.DeviceLogRetrieveAsync(deviceLogId));
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
