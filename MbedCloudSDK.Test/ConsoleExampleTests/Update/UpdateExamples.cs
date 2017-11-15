using MbedCloudSDK.Common;
using NUnit.Framework;

namespace MbedCloudSDK.Test.ConsoleExampleTests.Update
{
    [TestFixture]
    public class UpdateExamples
    {
        [Test]
        public void CreateUpdateCampaign()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var createUpdateCampaign = new ConsoleExamples.Examples.Update.UpdateExamples(config);
            var campaign = createUpdateCampaign.CreateCampaign(false);
            Assert.IsNotNull(campaign);
        }

        [Test]
        public void ListFirmwareImages()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var listImages = new ConsoleExamples.Examples.Update.UpdateExamples(config);
            var images = listImages.ListImages();
            Assert.AreEqual(2, images.Count);
        }

        [Test]
        public void ListFirmwareManifests()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var listManifests = new ConsoleExamples.Examples.Update.UpdateExamples(config);
            var manifests = listManifests.ListManifests();
            Assert.AreEqual(2, manifests.Count);
        }

        [Test]
        public void ListUpdateCampaigns()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var listCampaigns = new ConsoleExamples.Examples.Update.UpdateExamples(config);
            var campaigns = listCampaigns.listCampaigns();
            Assert.AreEqual(3, campaigns.Count);
        }
    }
}