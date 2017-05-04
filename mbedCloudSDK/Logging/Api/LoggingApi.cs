using System;
using mbedCloudSDK.Common;
using mbedCloudSDK.Exceptions;
using System.Collections.Generic;
using mbedCloudSDK.Logging.Model;
using System.Threading.Tasks;
using mbedCloudSDK.Common.Query;

namespace mbedCloudSDK.Logging.Api
{
    /// <summary>
    /// Describing the public logging Api
    /// Exposes functionality from the following services:
    /// - Device logging
    /// - AccountManagement logging
    /// - Update campaign logging
    /// </summary>
    public class LoggingApi: BaseApi
    {
        private device_catalog.Api.DefaultApi deviceCatalogApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.Logging.LoggingApi"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
        public LoggingApi(Config config) : base(config)
        {
            device_catalog.Client.Configuration.Default.ApiKey["Authorization"] = config.ApiKey;
            device_catalog.Client.Configuration.Default.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            deviceCatalogApi = new device_catalog.Api.DefaultApi(config.Host);
        }



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
                var resp = deviceCatalogApi.DeviceLogList(options.Limit, options.Order, options.After, options.QueryString);
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
                return DeviceLog.Map(deviceCatalogApi.DeviceLogRetrieve(deviceLogId));
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
                return DeviceLog.Map(await deviceCatalogApi.DeviceLogRetrieveAsync(deviceLogId));
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
