using MbedCloudSDK.Common;
using NUnit.Framework;

namespace MbedCloudSDK.Test.ConsoleExampleTests.DeviceDirectory
{
    [TestFixture]
    public class ListLogs
    {
        [Test]
        public void ListLogsShouldOnlyReturn10Logs()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var listLogs = new ConsoleExamples.Examples.DeviceDirectory.ListLogs(config);
            var logs = listLogs.ListDevicesLogs();
            Assert.AreEqual(5, logs.Count);
        }
    }
}