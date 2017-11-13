using MbedCloudSDK.Common;
using NUnit.Framework;

namespace MbedCloudSDK.Test.ConsoleExampleTests.Connect
{
    [TestFixture]
    public class Webhook
    {
        [Test]
        public void WebhookReturnsValue()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var webhook = new ConsoleExamples.Examples.Connect.Webhook(config);
            Assert.IsNotNull(webhook);
        }
    }
}