using MbedCloudSDK.Common;
using NUnit.Framework;

namespace MbedCloudSDK.Test.ConsoleExampleTests.DeviceDirectory
{
    [TestFixture]
    public class DeviceQuery
    {
        [Test]
        public void AddQueryShouldAddQuery()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var deviceQuery = new ConsoleExamples.Examples.DeviceDirectory.DeviceQuery(config);
            var query = deviceQuery.AddQuery();
            Assert.NotNull(query);
        }
    }
}