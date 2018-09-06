using System;
using MbedCloudSDK.Entities.User;
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
        public void LocalConfig()
        {
            var newConfig = new Config("apiKey");
            var user = new User(newConfig);
            var config = user.Config;
            Assert.AreEqual("apiKey", config.ApiKey);
        }
    }
}