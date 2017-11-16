using System;
using System.Threading;
using MbedCloudSDK.Common;
using NUnit.Framework;

namespace MbedCloudSDK.Test.ConsoleExampleTests.Connect
{
    [TestFixture]
    public class ConnectExamples
    {
        [Test]
        public void ListConnectedDevices()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var connectExamples = new ConsoleExamples.Examples.Connect.ConnectExamples(config);
            var devices = connectExamples.ListConnectedDevices();
            Assert.AreEqual(2, devices.Count);
        }

        [Test]
        public void ListConnectedDevicesWithFilters()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var connectExamples = new ConsoleExamples.Examples.Connect.ConnectExamples(config);
            var devicesFiltered = connectExamples.ListConnectedDevicesWithFilter();
            Assert.IsNotNull(devicesFiltered);
        }

        [Test]
        public void DeviceMetrics30Days()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var connectExamples = new ConsoleExamples.Examples.Connect.ConnectExamples(config);

            var metricDays = connectExamples.ListLast30Days();
            Assert.IsNotNull(metricDays);
        }

        [Test]
        public void DeviceMetrics2Days()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var connectExamples = new ConsoleExamples.Examples.Connect.ConnectExamples(config);

            var metricDays2 = connectExamples.ListLast2Days();
            Assert.IsNotNull(metricDays2);
        }

        [Test]
        public void DeviceMetricsMonth()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var connectExamples = new ConsoleExamples.Examples.Connect.ConnectExamples(config);

            var metricMonth = connectExamples.ListMonth();
            Assert.IsNotNull(metricMonth);
        }

        [Test]
        public void PreSubscription()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var connectExamples = new ConsoleExamples.Examples.Connect.ConnectExamples(config);
            var presub = connectExamples.CreatePreSubscription();
            Assert.IsNotNull(presub);
        }
    }
}