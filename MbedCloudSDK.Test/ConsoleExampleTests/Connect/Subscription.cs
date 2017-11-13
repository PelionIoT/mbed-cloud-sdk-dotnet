using MbedCloudSDK.Common;
using NUnit.Framework;

namespace MbedCloudSDK.Test.ConsoleExampleTests.Connect
{
    [TestFixture]
    public class Subscription
    {
        [Test]
        public void SubscribeToResource()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var subscription = new ConsoleExamples.Examples.Connect.Subscription(config);
            var res = subscription.Subscribe();
        }
    }
}