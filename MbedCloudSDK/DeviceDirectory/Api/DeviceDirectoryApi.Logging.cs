// <copyright file="DeviceDirectoryApi.Logging.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.DeviceDirectory.Api
{
    using System.Threading.Tasks;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Query;
    using MbedCloudSDK.DeviceDirectory.Model.Logging;
    using MbedCloudSDK.Exceptions;

    /// <summary>
    /// Device Directory Api
    /// </summary>
    public partial class DeviceDirectoryApi
    {
        /// <summary>
        /// Lists the device events.
        /// </summary>
        /// <returns>The device events.</returns>
        /// <param name="options"><see cref="QueryOptions"/></param>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var options = new QueryOptions()
        ///     {
        ///         Limit = 5,
        ///     };
        ///
        ///     options.Filter.Add("deviceId", "015c45eb321700000000000100100155");
        ///     options.Filter.Add("eventDate", new DateTime(2017, 1, 1), FilterOperator.GreaterOrEqual);
        ///     options.Filter.Add("eventDate", new DateTime(2018, 1, 1), FilterOperator.LessOrEqual);
        ///
        ///     var events = deviceApi.ListDeviceEvents(options).Data;
        ///     foreach (var item in events)
        ///     {
        ///         Console.WriteLine(item);
        ///     }
        ///     return events;
        /// }
        /// catch (CloudApiExeption)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public PaginatedResponse<QueryOptions, DeviceEvent> ListDeviceEvents(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                return new PaginatedResponse<QueryOptions, DeviceEvent>(ListDeviceEventsFunc, options);
            }
            catch (CloudApiException)
            {
                throw;
            }
        }

        /// <summary>
        /// Lists the device logs.
        /// </summary>
        /// <returns>The device logs.</returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <param name="options">Query options.</param>
        private ResponsePage<DeviceEvent> ListDeviceEventsFunc(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                var resp = Api.DeviceLogList(limit: options.Limit, order: options.Order, after: options.After, filter: options.Filter?.FilterString, include: options.Include);
                var respDeviceLogs = new ResponsePage<DeviceEvent>(resp.After, resp.HasMore, resp.Limit, resp.Order, resp.TotalCount);
                foreach (var deviceLog in resp.Data)
                {
                    respDeviceLogs.Data.Add(DeviceEvent.Map(deviceLog));
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
        /// <param name="deviceEventId">Id</param>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var event = deviceApi.GetDeviceEvent("015c45eb321700000000000100100155");
        ///     return event;
        /// }
        /// catch (CloudApiExeption)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public DeviceEvent GetDeviceEvent(string deviceEventId)
        {
            try
            {
                return DeviceEvent.Map(Api.DeviceLogRetrieve(deviceEventId));
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
        /// <param name="deviceLogId">Id</param>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var event = await deviceApi.GetDeviceEventAsync("015c45eb321700000000000100100155");
        ///     return event;
        /// }
        /// catch (CloudApiExeption)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public async Task<DeviceEvent> GetDeviceEventAsync(string deviceLogId)
        {
            try
            {
                return DeviceEvent.Map(await Api.DeviceLogRetrieveAsync(deviceLogId));
            }
            catch (device_directory.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
