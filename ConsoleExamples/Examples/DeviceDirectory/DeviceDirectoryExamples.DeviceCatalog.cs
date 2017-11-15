using MbedCloudSDK.Common;
using System;
using System.Collections.Generic;
using MbedCloudSDK.DeviceDirectory.Model.Device;
using MbedCloudSDK.DeviceDirectory.Api;
using MbedCloudSDK.Common.Query;

namespace ConsoleExamples.Examples.DeviceDirectory
{
    public partial class DeviceDirectoryExamples
    {
        /// <summary>
        /// List DeviceDirectory.
        /// </summary>
        public List<Device> ListAllDevices()
        {
            var options = new QueryOptions()
            {
                Limit = 5,
                Order = "DESC"
            };
            var devices = api.ListDevices(options).Data;
            Console.WriteLine("Listing devices ...");
            foreach (var device in devices)
            {
                Console.WriteLine($"{device.Id}, {device.State}, {device.CreatedAt}");
            }

            options.Filter.Add("state", "deregistered");
            //list the registered devices
            var registeredDeviceList = api.ListDevices(options).Data;
            Console.WriteLine("Listing registered devices ...");
            foreach (var device in registeredDeviceList)
            {
                Console.WriteLine($"{device.Id}, {device.State}, {device.CreatedAt}");
            }

            return devices;
        }
    }
}