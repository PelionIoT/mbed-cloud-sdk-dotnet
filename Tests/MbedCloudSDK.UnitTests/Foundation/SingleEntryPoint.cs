using Mbed.Cloud;
using Mbed.Cloud.Common;
using Mbed.Cloud.Foundation;
using NUnit.Framework;

namespace MbedCloudSDK.UnitTests.Foundation
{
    [TestFixture]
    public class SingleEntryPoint
    {
        [Test]
        public void GlobalConfig()
        {
            var sdk = new SDK();
            Assert.IsNotNull(sdk.Config);
            Assert.IsInstanceOf(typeof(string), sdk.Config.ApiKey);
        }

        [Test]
        public void GlobalConfigOnEntityRepository()
        {
            var userRepo = new UserRepository();
            Assert.IsNotNull(userRepo.Config);
            Assert.IsInstanceOf(typeof(string), userRepo.Config.ApiKey);
        }

        [Test]
        public void SDKInstance()
        {
            var sdk = new SDK(new Config("ak_1"));
            Assert.AreEqual("ak_1", sdk.Config.ApiKey);

            // var user = sdk.User();
            // Assert.AreEqual("ak_1", user.Config.ApiKey);
        }

        [Test]
        public void MultipleSDKInstances()
        {
            var sdk1 = new SDK(new Config("ak_1"));
            Assert.AreEqual("ak_1", sdk1.Config.ApiKey);

            var sdk2 = new SDK(new Config("ak_2"));
            Assert.AreEqual("ak_2", sdk2.Config.ApiKey);
        }

        [Test]
        public void ReusableConfig()
        {
            var config = new Config("ak_1");
            var sdk = new SDK(config);

            Assert.AreEqual("ak_1", sdk.Config.ApiKey);

            var user = sdk.Entities().UserRepository();
            Assert.AreEqual("ak_1", user.Config.ApiKey);

            var sdk2 = new SDK(config);
            Assert.AreEqual("ak_1", sdk.Config.ApiKey);

            var user2 = new UserRepository(config);
            Assert.AreEqual("ak_1", user2.Config.ApiKey);
        }
    }
}