using System;
using mbedCloudSDK.Common;
using mbedCloudSDK.Exceptions;
using System.Collections.Generic;

namespace mbedCloudSDK.Logging
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
            device_catalog.Client.Configuration.Default..ApiKey["Authorization"] = config.ApiKey;
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
        public List<device_catalog.Model.DeviceLogSerializerData>ListDeviceLogs(ListParams listParams = null)
        {
            if (listParams == null)
            {
                listParams = new ListParams();
            }
            var api = new device_catalog.Api.DefaultApi();
            try
            {
                return api.DeviceLogList(listParams.Limit, listParams.Order, listParams.After, listParams.Filter, listParams.Include).Data;
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
        public device_catalog.Model.DeviceLogSerializer GetDeviceLog(string deviceLogId)
        {
            var api = new device_catalog.Api.DefaultApi();
            try
            {
                return api.DeviceLogRetrieve(deviceLogId);
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
