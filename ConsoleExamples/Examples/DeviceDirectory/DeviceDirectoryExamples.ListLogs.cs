// <copyright file="DeviceDirectoryExamples.ListLogs.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.DeviceDirectory
{
    using System;
    using System.Collections.Generic;
    using MbedCloudSDK.Common.Filter;
    using MbedCloudSDK.Common.Query;
    using MbedCloudSDK.DeviceDirectory.Model.Logging;

    /// <summary>
    /// Device directory examples
    /// </summary>
    public partial class DeviceDirectoryExamples
    {
        /// <summary>
        /// List all device logs.
        /// </summary>
        /// <returns>List of device events</returns>
        public List<DeviceEvent> ListDevicesLogs()
        {
            var options = new QueryOptions
            {
                Limit = 5,
            };

            options.Filter.Add("deviceId", "015c45eb321700000000000100100155");
            options.Filter.Add("eventDate", new DateTime(2017, 1, 1), FilterOperator.GreaterOrEqual);
            options.Filter.Add("eventDate", new DateTime(2018, 1, 1), FilterOperator.LessOrEqual);

            var logs = api.ListDeviceEvents(options).Data;
            foreach (var log in logs)
            {
                Console.WriteLine(log.ToString());
            }

            return logs;
        }

        /// <summary>
        /// List the first 5 device events
        /// </summary>
        /// <returns>List of device events</returns>
        public List<DeviceEvent> ListDeviceEvents()
        {
            var options = new QueryOptions
            {
                Limit = 5,
            };
            var events = api.ListDeviceEvents(options).Data;
            foreach (var item in events)
            {
                Console.WriteLine(item);
            }

            return events;
        }
    }
}
