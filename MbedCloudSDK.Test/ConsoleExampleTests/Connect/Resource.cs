using System;
using MbedCloudSDK.Common;
using NUnit.Framework;

namespace MbedCloudSDK.Test.ConsoleExampleTests.Connect
{
    [TestFixture]
    public class Resource
    {
        [Test, Timeout(10000)]
        public void GetResourceValueGetsAValue()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var resource = new ConsoleExamples.Examples.Connect.Resource(config);
            var resourceValue = resource.GetResourceValue();
            Assert.AreNotEqual("no resource found", resourceValue);
        }

        [Test, Timeout(10000)]
        public void SetResourceValueSetsTheValue()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var resource = new ConsoleExamples.Examples.Connect.Resource(config);
            var setResourceValue = resource.SetResourceValue();
            Console.WriteLine(setResourceValue);
            Assert.IsNotNull(setResourceValue);
            Assert.AreEqual("test-value", setResourceValue);
        }
    }
}