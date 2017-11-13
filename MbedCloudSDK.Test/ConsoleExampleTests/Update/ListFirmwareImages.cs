using MbedCloudSDK.Common;
using NUnit.Framework;

namespace MbedCloudSDK.Test.ConsoleExampleTests.Update
{
    [TestFixture]
    public class ListFirmwareImages
    {
        [Test]
        public void ListFirmwareImagesShouldReturn2Images()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var listImages = new ConsoleExamples.Examples.Update.ListFirmwareImages(config);
            var images = listImages.ListImages();
            Assert.AreEqual(2, images.Count);
        }
    }
}