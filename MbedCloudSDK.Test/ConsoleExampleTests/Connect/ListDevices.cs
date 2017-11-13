using System;
using MbedCloudSDK.Common;
using NUnit.Framework;

namespace MbedCloudSDK.Test.ConsoleExampleTests.Connect
{
    [TestFixture]
    public class ListDevices
    {
        [Test]
        public void ListConnectedDevicesShouldNotBeNull()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var listDevices = new ConsoleExamples.Examples.Connect.ListDevices(config);
            var devices = listDevices.ListConnectedDevices();
            Console.WriteLine(devices.Count);
            Assert.AreEqual(1, devices.Count);
        }

        [Test]
        public void ListDevicesShouldNotBeNull()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var listDevices = new ConsoleExamples.Examples.Connect.ListDevices(config);
            var devices = listDevices.ListAllDevices();
            Assert.AreEqual(5, devices.Count);
        }
    }
}