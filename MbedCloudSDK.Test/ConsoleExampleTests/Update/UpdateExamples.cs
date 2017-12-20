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
            var host = TestContext.Parameters["mbed_cloud_sdk_host"];
            var config = new Config(key, host);
            var createUpdateCampaign = new ConsoleExamples.Examples.Update.UpdateExamples(config);
            var campaign = createUpdateCampaign.CreateCampaign();
            Assert.IsNotNull(campaign);
        }

        [Test]
        public void ListFirmwareImages()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var host = TestContext.Parameters["mbed_cloud_sdk_host"];
            var config = new Config(key, host);
            var listImages = new ConsoleExamples.Examples.Update.UpdateExamples(config);
            var images = listImages.ListImages();
            Assert.IsNotEmpty(images);
        }

        [Test]
        public void ListFirmwareManifests()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var host = TestContext.Parameters["mbed_cloud_sdk_host"];
            var config = new Config(key, host);
            var listManifests = new ConsoleExamples.Examples.Update.UpdateExamples(config);
            var manifests = listManifests.ListManifests();
            Assert.IsNotEmpty(manifests);
        }

        [Test]
        public void ListUpdateCampaigns()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var host = TestContext.Parameters["mbed_cloud_sdk_host"];
            var config = new Config(key, host);
            var listCampaigns = new ConsoleExamples.Examples.Update.UpdateExamples(config);
            var campaigns = listCampaigns.ListCampaigns();
            Assert.IsNotEmpty(campaigns);
        }
    }
}