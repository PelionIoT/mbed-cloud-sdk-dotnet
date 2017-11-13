using MbedCloudSDK.Common;
using NUnit.Framework;

namespace MbedCloudSDK.Test.ConsoleExampleTests.Update
{
    [TestFixture]
    public class ListUpdateCampaigns
    {
        [Test]
        public void ListUpdateCampaignsShouldReturn3Campaigns()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var listCampaigns = new ConsoleExamples.Examples.Update.ListUpdateCampaigns(config);
            var campaigns = listCampaigns.listCampaigns();
            Assert.AreEqual(3, campaigns.Count);
        }
    }
}