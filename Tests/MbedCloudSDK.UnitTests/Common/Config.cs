using System;
using System.IO;
using System.Threading;
using NUnit.Framework;

namespace MbedCloudSDK.UnitTests.Common
{
    [TestFixture]
    public class Config
    {
        private const string apiKey = "someApiKey";

        private const string host = "someHost";

        private const string envPath = ".env";

        [Test]
        public void DotEnvProvided()
        {
            string[] env = { $"{MbedCloudSDK.Common.Config.API_KEY}={apiKey}", $"{MbedCloudSDK.Common.Config.HOST}={host}" };
            System.IO.File.WriteAllLines(envPath, env);

            var config = new MbedCloudSDK.Common.Config();

            Assert.AreEqual(config.ApiKey, apiKey);
            Assert.AreEqual(config.Host, host);

            System.IO.File.Delete(envPath);
        }

        [Test]
        public void DotEnvAndBools()
        {
            string[] env = { $"{MbedCloudSDK.Common.Config.API_KEY}={apiKey}", $"{MbedCloudSDK.Common.Config.HOST}={host}" };
            System.IO.File.WriteAllLines(envPath, env);

            var config = new MbedCloudSDK.Common.Config(true, true);

            Assert.AreEqual(config.ApiKey, apiKey);
            Assert.AreEqual(config.Host, host);

            System.IO.File.Delete(envPath);
        }

        [Test]
        public void EnvironmentVariables()
        {
            Environment.SetEnvironmentVariable(MbedCloudSDK.Common.Config.API_KEY, apiKey);
            Environment.SetEnvironmentVariable(MbedCloudSDK.Common.Config.HOST, host);

            var config = new MbedCloudSDK.Common.Config();

            Assert.AreEqual(config.ApiKey, apiKey);
            Assert.AreEqual(config.Host, host);

            Environment.SetEnvironmentVariable(MbedCloudSDK.Common.Config.API_KEY, null);
            Environment.SetEnvironmentVariable(MbedCloudSDK.Common.Config.HOST, null);
        }

        [Test]
        public void EnvironmentVariablesAndBools()
        {
            Environment.SetEnvironmentVariable(MbedCloudSDK.Common.Config.API_KEY, apiKey);
            Environment.SetEnvironmentVariable(MbedCloudSDK.Common.Config.HOST, host);

            var config = new MbedCloudSDK.Common.Config(true, true);

            Assert.AreEqual(config.ApiKey, apiKey);
            Assert.AreEqual(config.Host, host);
            Assert.AreEqual(config.ForceClear, true);
            Assert.AreEqual(config.AutostartNotifications, true);

            Environment.SetEnvironmentVariable(MbedCloudSDK.Common.Config.API_KEY, null);
            Environment.SetEnvironmentVariable(MbedCloudSDK.Common.Config.HOST, null);
        }

        [Test]
        public void ApiKeyAndHostPassed()
        {
            var config = new MbedCloudSDK.Common.Config(apiKey, host);

            Assert.AreEqual(config.ApiKey, apiKey);
            Assert.AreEqual(config.Host, host);
        }

        /*
        [Test]
        public void ApiKeyPassedAndDefaultHost()
        {
            var config = new MbedCloudSDK.Common.Config(apiKey);

            Assert.AreEqual(config.ApiKey, apiKey);
            Assert.AreEqual(config.Host, "https://api.us-east-1.mbedcloud.com");
        }
        */

        [Test]
        public void AllParamsSet()
        {
            var config = new MbedCloudSDK.Common.Config(apiKey, host, true, true);

            Assert.AreEqual(config.ApiKey, apiKey);
            Assert.AreEqual(config.Host, host);
            Assert.AreEqual(config.ForceClear, true);
            Assert.AreEqual(config.AutostartNotifications, true);
        }
    }
}