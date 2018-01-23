using System;
using System.Threading;
using MbedCloudSDK.Common;
using MbedCloudSDK.ExampleTests;
using NUnit.Framework;

namespace MbedCloudSDK.Test.ConsoleExampleTests.Connect
{
    [TestFixture]
    public class ConnectExamples
    {
        [OneTimeSetUp]
        public void Init()
        {
            SetEnvironment.SetEnvironmentVariables();
        }

        [Test]
        public void ListConnectedDevices()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var connectExamples = new ConsoleExamples.Examples.Connect.ConnectExamples(config);
            var devices = connectExamples.ListConnectedDevices();
            Assert.IsNotEmpty(devices);
        }

        [Test]
        public void ListConnectedDevicesWithFilters()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var connectExamples = new ConsoleExamples.Examples.Connect.ConnectExamples(config);
            var devicesFiltered = connectExamples.ListConnectedDevicesWithFilter();
            Assert.IsNotNull(devicesFiltered);
        }

        [Test]
        public void DeviceMetrics30Days()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var connectExamples = new ConsoleExamples.Examples.Connect.ConnectExamples(config);

            var metricDays = connectExamples.ListLast30Days();
            Assert.IsNotNull(metricDays);
        }

        [Test]
        public void DeviceMetrics2Days()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var connectExamples = new ConsoleExamples.Examples.Connect.ConnectExamples(config);

            var metricDays2 = connectExamples.ListLast2Days();
            Assert.IsNotNull(metricDays2);
        }

        [Test]
        public void DeviceMetricsMonth()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var connectExamples = new ConsoleExamples.Examples.Connect.ConnectExamples(config);

            var metricMonth = connectExamples.ListMonth();
            Assert.IsNotNull(metricMonth);
        }

        [Test]
        public void PreSubscription()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var connectExamples = new ConsoleExamples.Examples.Connect.ConnectExamples(config);
            var presub = connectExamples.CreatePreSubscription();
            Assert.IsNotNull(presub);
        }
    }
}