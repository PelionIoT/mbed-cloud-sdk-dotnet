using System;
using MbedCloudSDK.Common;
using MbedCloudSDK.DeviceDirectory.Api;
using MbedCloudSDK.DeviceDirectory.Model.Device;

namespace ConsoleExamples.Examples.DeviceDirectory
{
    public partial class DeviceDirectoryExamples
    {
        private Config config;
        private DeviceDirectoryApi api;

        public DeviceDirectoryExamples(Config _config)
        {
            config = _config;
            api = new DeviceDirectoryApi(config);
        }

        public Device CreateDevice()
        {
            var device = new Device()
            {
                CertificateIssuerId = (GetHashCode() * 2).ToString(),
                CertificateFingerprint = (GetHashCode() * 3).ToString()
            };
            var newDevice = api.AddDevice(device);
            Console.WriteLine($"Device createed with id - {newDevice.Id}");

            var updatedDevice = api.UpdateDevice(newDevice.Id, new Device { CertificateFingerprint = newDevice.CertificateFingerprint, CertificateIssuerId = (GetHashCode() * 4).ToString() });

            Console.WriteLine("Updated device");

            api.DeleteDevice(updatedDevice.Id);

            return updatedDevice;
        }
    }
}