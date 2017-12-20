using MbedCloudSDK.Common;
using NUnit.Framework;

namespace MbedCloudSDK.Test.ConsoleExampleTests.DeviceDirectory
{
    [TestFixture]
    public class DeviceDirectoryExamples
    {
        [Test]
        public void AddQuery()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var host = TestContext.Parameters["mbed_cloud_sdk_host"];
            var config = new Config(key, host);
            var deviceQuery = new ConsoleExamples.Examples.DeviceDirectory.DeviceDirectoryExamples(config);
            var query = deviceQuery.AddQuery();
            Assert.NotNull(query);
        }

        [Test]
        public void CreateDevice()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var host = TestContext.Parameters["mbed_cloud_sdk_host"];
            var config = new Config(key, host);
            var deviceQuery = new ConsoleExamples.Examples.DeviceDirectory.DeviceDirectoryExamples(config);
            var device = deviceQuery.CreateDevice();
            Assert.IsNotNull(device);
        }

        [Test]
        public void ListAllDevices()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var host = TestContext.Parameters["mbed_cloud_sdk_host"];
            var config = new Config(key, host);
            var deviceQuery = new ConsoleExamples.Examples.DeviceDirectory.DeviceDirectoryExamples(config);
            var devices = deviceQuery.ListAllDevices();
            Assert.IsNotEmpty(devices);
        }

        [Test]
        public void ListDeviceLogs()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var host = TestContext.Parameters["mbed_cloud_sdk_host"];
            var config = new Config(key, host);
            var listLogs = new ConsoleExamples.Examples.DeviceDirectory.DeviceDirectoryExamples(config);
            var logs = listLogs.ListDevicesLogs();
            Assert.IsNotEmpty(logs);
        }

        [Test]
        public void ListDeviceEvents()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var host = TestContext.Parameters["mbed_cloud_sdk_host"];
            var config = new Config(key, host);
            var listEvents = new ConsoleExamples.Examples.DeviceDirectory.DeviceDirectoryExamples(config);
            var events = listEvents.ListDeviceEvents();
            Assert.IsNotEmpty(events);
        }
    }
}