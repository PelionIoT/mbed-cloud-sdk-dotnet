using MbedCloudSDK.Common;
using NUnit.Framework;

namespace MbedCloudSDK.Test.ConsoleExampleTests.Update
{
    [TestFixture]
    public class CreateUpdateCampaign
    {
        [Test]
        public void CreateUpdateCampaignShouldReturnCampaign()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var createUpdateCampaign = new ConsoleExamples.Examples.Update.CreateUpdateCampaign(config);
            var campaign = createUpdateCampaign.CreateCampaign(false);
            Assert.IsNotNull(campaign);
        }
    }
}