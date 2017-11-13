using MbedCloudSDK.Common;
using NUnit.Framework;

namespace MbedCloudSDK.Test.ConsoleExampleTests.Update
{
    [TestFixture]
    public class ListFirmwareManifests
    {
        [Test]
        public void ListFirmwareManifestsShouldReturn2Manifests()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var listManifests = new ConsoleExamples.Examples.Update.ListFirmwareManifests(config);
            var manifests = listManifests.ListManifests();
            Assert.AreEqual(2, manifests.Count);
        }
    }
}