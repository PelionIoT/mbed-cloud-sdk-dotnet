// <copyright file="DeviceDirectoryExamples.CreateAndDelete.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.DeviceDirectory
{
    using System;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.DeviceDirectory.Api;
    using MbedCloudSDK.DeviceDirectory.Model.Device;

    /// <summary>
    /// Device directory examples
    /// </summary>
    public partial class DeviceDirectoryExamples
    {
        private Config config;
        private DeviceDirectoryApi api;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceDirectoryExamples"/> class.
        /// </summary>
        /// <param name="config">Config</param>
        public DeviceDirectoryExamples(Config config)
        {
            this.config = config;
            api = new DeviceDirectoryApi(this.config);
        }

        /// <summary>
        /// Create, update and delete a device
        /// </summary>
        /// <returns>Device</returns>
        public Device CreateDevice()
        {
            // create a new device
            var device = new Device
            {
                CertificateIssuerId = (GetHashCode() * 2).ToString(),
                CertificateFingerprint = (GetHashCode() * 3).ToString(),
            };

            // add the device
            var newDevice = api.AddDevice(device);
            Console.WriteLine($"Device createed with id - {newDevice.Id}");

            // update the device
            var updatedDevice = api.UpdateDevice(newDevice.Id, new Device { CertificateFingerprint = newDevice.CertificateFingerprint, CertificateIssuerId = (GetHashCode() * 4).ToString() });

            Console.WriteLine("Updated device");
            Console.WriteLine(updatedDevice);

            // delete the device
            api.DeleteDevice(updatedDevice.Id);

            return updatedDevice;
        }
    }
}