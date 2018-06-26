// <copyright file="DeviceDirectoryExamples.DeviceCatalog.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.DeviceDirectory
{
    using System;
    using System.Collections.Generic;
    using MbedCloudSDK.Common.Query;
    using MbedCloudSDK.DeviceDirectory.Model.Device;

    /// <summary>
    /// Device directory examples
    /// </summary>
    public partial class DeviceDirectoryExamples
    {
        /// <summary>
        /// List DeviceDirectory.
        /// </summary>
        /// <returns>List of devices</returns>
        public IEnumerable<Device> ListAllDevices()
        {
            var options = new QueryOptions
            {
                Limit = 5,
                Order = "DESC",
            };
            var devices = api.ListDevices(options);
            Console.WriteLine("Listing devices ...");
            foreach (var device in devices)
            {
                Console.WriteLine($"{device.Id}, {device.State}, {device.CreatedAt}");
            }

            options.Filter.Add("state", "deregistered");

            // list the registered devices
            var registeredDeviceList = api.ListDevices(options);
            Console.WriteLine("Listing registered devices ...");
            foreach (var device in registeredDeviceList)
            {
                Console.WriteLine($"{device.Id}, {device.State}, {device.CreatedAt}");
            }

            return devices;
        }
    }
}