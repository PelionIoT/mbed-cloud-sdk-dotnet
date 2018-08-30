using System;
using MbedCloudSDK.Accounts.User;
using MbedCloudSDK.Common;
using NUnit.Framework;

namespace Manhasset.Test
{
    [TestFixture]
    public class SingleEntryPoint
    {
        [Test]
        public void GlobalConfig()
        {
            var configA = new User().Config;
            var configB = new User().Config;

            Assert.AreEqual(configA, configB);
        }

        [Test]
        public void ChangedGlobalConfig()
        {
            MbedCloudSDKClient.Init(new Config("apiKey", "https://api.brazil.mbedcloud.com"));

            var configA = new User().Config;
            var configB = new User().Config;

            Assert.AreEqual("apiKey", configA.ApiKey);
            Assert.AreEqual("https://api.brazil.mbedcloud.com", configA.Host);

            Assert.AreEqual(configA, configB);

            MbedCloudSDKClient.Reset();
        }

        [Test]
        public void LocalConfig()
        {
            var newConfig = new Config("apiKey");
            var user = new User(newConfig);
            var config = user.Config;
            Assert.AreEqual("apiKey", config.ApiKey);
        }
    }
}