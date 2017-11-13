using System;
using MbedCloudSDK.Common;
using NUnit.Framework;

namespace MbedCloudSDK.Test.ConsoleExampleTests.AccountManagement
{
    [TestFixture]
    public class ListApiKeys
    {
        [Test]
        public void ListApiKeysReturnsList()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var listApiKeys = new ConsoleExamples.Examples.AccountManagement.ListApiKeys(config);
            var keys = listApiKeys.GetApiKeys();
            Assert.AreEqual(5, keys.Count);
        }

        [Test]
        public void ListApiKeysAsync()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var listApiKeys = new ConsoleExamples.Examples.AccountManagement.ListApiKeys(config);
            var keys = listApiKeys.ListApiKeysAsync().Result;
            Assert.AreEqual(5, keys.Count);
        }
    }
}