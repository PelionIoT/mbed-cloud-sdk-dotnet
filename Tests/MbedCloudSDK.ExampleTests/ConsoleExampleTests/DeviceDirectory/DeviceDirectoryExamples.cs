using MbedCloudSDK.Common;
using MbedCloudSDK.ExampleTests;
using NUnit.Framework;
using System;

namespace MbedCloudSDK.Test.ConsoleExampleTests.DeviceDirectory
{
    [TestFixture]
    public class DeviceDirectoryExamples
    {
        [OneTimeSetUp]
        public void Init()
        {
            SetEnvironment.SetEnvironmentVariables();
        }

        [Test]
        public void AddQuery()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_API_HOST");
            var config = new Config(key, host);
            var deviceQuery = new ConsoleExamples.Examples.DeviceDirectory.DeviceDirectoryExamples(config);
            var query = deviceQuery.AddQuery();
            Assert.IsNotNull(query);
        }

        [Test]
        public void CreateDevice()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_API_HOST");
            var config = new Config(key, host);
            var deviceQuery = new ConsoleExamples.Examples.DeviceDirectory.DeviceDirectoryExamples(config);
            var device = deviceQuery.CreateDevice();
            Assert.IsNotNull(device);
        }

        [Test]
        public void ListAllDevices()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_API_HOST");
            var config = new Config(key, host);
            var deviceQuery = new ConsoleExamples.Examples.DeviceDirectory.DeviceDirectoryExamples(config);
            var devices = deviceQuery.ListAllDevices();
            Assert.IsNotEmpty(devices);
        }

        [Test]
        public void ListDeviceLogs()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_API_HOST");
            var config = new Config(key, host);
            var listLogs = new ConsoleExamples.Examples.DeviceDirectory.DeviceDirectoryExamples(config);
            var logs = listLogs.ListDevicesLogs();
            Assert.IsNotNull(logs);
        }

        [Test]
        public void ListDeviceEvents()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_API_HOST");
            var config = new Config(key, host);
            var listEvents = new ConsoleExamples.Examples.DeviceDirectory.DeviceDirectoryExamples(config);
            var events = listEvents.ListDeviceEvents();
            Assert.IsNotEmpty(events);
        }
    }
}