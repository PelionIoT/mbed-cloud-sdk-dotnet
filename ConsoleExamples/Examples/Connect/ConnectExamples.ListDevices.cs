// <copyright file="ConnectExamples.ListDevices.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.Connect
{
    using System;
    using System.Collections.Generic;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Query;
    using MbedCloudSDK.Connect.Api;
    using MbedCloudSDK.Connect.Model.ConnectedDevice;

    /// <summary>
    /// Connect Examples
    /// </summary>
    public partial class ConnectExamples
    {
#pragma warning disable SA1401, SA1307
        /// <summary>
        /// Api
        /// </summary>
        public ConnectApi api;
#pragma warning restore CS3021, SA1307
        private Config config;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectExamples"/> class.
        /// </summary>
        /// <param name="config">Config</param>
        public ConnectExamples(Config config)
        {
            this.config = config;
            api = new ConnectApi(config);
        }

        /// <summary>
        /// List Connected devices.
        /// </summary>
        /// <returns>List of connected devices</returns>
        public List<ConnectedDevice> ListConnectedDevices()
        {
            var options = new QueryOptions
            {
                Limit = 5,
            };
            var deviceList = api.ListConnectedDevices(options).Data;
            foreach (var endpoint in deviceList)
            {
                Console.WriteLine(endpoint);
            }

            return deviceList;
        }

        /// <summary>
        /// List connected devices created in October 2017
        /// </summary>
        /// <returns>List of connected devices</returns>
        public List<ConnectedDevice> ListConnectedDevicesWithFilter()
        {
            var options = new QueryOptions();
            options.Filter.Add("created_at", new DateTime(2017, 10, 1));
            options.Filter.Add("created_at", new DateTime(2017, 10, 31));
            var deviceList = api.ListConnectedDevices(options).Data;
            foreach (var endpoint in deviceList)
            {
                Console.WriteLine(endpoint);
            }

            return deviceList;
        }
    }
}
