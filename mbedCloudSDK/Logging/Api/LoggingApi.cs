using System;
using mbedCloudSDK.Common;
using mbedCloudSDK.Exceptions;
using System.Collections.Generic;
using mbedCloudSDK.Logging.Model;
using System.Threading.Tasks;

namespace mbedCloudSDK.Logging.Api
{
    /// <summary>
    /// Describing the public logging Api
    /// Exposes functionality from the following services:
    /// - Device logging
    /// - Access logging
    /// - Update campaign logging
    /// </summary>
    public class LoggingApi: BaseApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.Logging.LoggingApi"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
        public LoggingApi(Config config) : base(config)
        {
            device_catalog.Client.Configuration.Default.ApiKey["Authorization"] = config.ApiKey;
            device_catalog.Client.Configuration.Default.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            if (config.Host != string.Empty)
            {
                device_catalog.Client.Configuration.Default.ApiClient = new device_catalog.Client.ApiClient(config.Host);
            }
        }
        
        /// <summary>
        /// Lists the device logs.
        /// </summary>
        /// <returns>The device logs.</returns>
        /// <param name="listParams">List parameters.</param>
        public List<DeviceLog> ListDeviceLogs(ListParams listParams = null)
        {
            if (listParams == null)
            {
                listParams = new ListParams();
            }
            var api = new device_catalog.Api.DefaultApi();
            try
            {
                var deviceLogs = new List<DeviceLog>();
                var deviceLogsList = api.DeviceLogList(listParams.Limit, listParams.Order, listParams.After, listParams.Filter, listParams.Include).Data;
                foreach(var log in deviceLogsList)
                {
                    deviceLogs.Add(DeviceLog.Map(log));
                }
                return deviceLogs;
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Lists the device logs asynchronously.
        /// </summary>
        /// <returns>The device logs.</returns>
        /// <param name="listParams">List parameters.</param>
        public async Task<List<DeviceLog>> ListDeviceLogsAsync(ListParams listParams = null)
        {
            if (listParams == null)
            {
                listParams = new ListParams();
            }
            var api = new device_catalog.Api.DefaultApi();
            try
            {
                var deviceLogs = new List<DeviceLog>();
                var deviceLogsList = await api.DeviceLogListAsync(listParams.Limit, listParams.Order, listParams.After, listParams.Filter, listParams.Include);
                foreach (var log in deviceLogsList.Data)
                {
                    deviceLogs.Add(DeviceLog.Map(log));
                }
                return deviceLogs;
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
            var api = new device_catalog.Api.DefaultApi();
            try
            {
                return DeviceLog.Map(api.DeviceLogRetrieve(deviceLogId));
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
            var api = new device_catalog.Api.DefaultApi();
            try
            {
                return DeviceLog.Map(await api.DeviceLogRetrieveAsync(deviceLogId));
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
