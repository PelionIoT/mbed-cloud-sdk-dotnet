using System;
using System.Collections;
using System.IO;
using Mbed.Cloud.Common;
using NUnit.Framework;

namespace MbedCloudSDK.UnitTests.Common
{
    [TestFixture]
    public class DotEnv
    {
        private IDictionary currentEnvironment;
        private const string apiKey = "someApiKey";

        private const string host = "https://api.us-west-1.mbedcloud.com";

        private string envPath = Path.Join(AppDomain.CurrentDomain.BaseDirectory, ".env");

        [SetUp]
        public void Init()
        {
            TestContext.Progress.WriteLine("env " + Environment.GetEnvironmentVariable(Config.API_KEY));
            TestContext.Progress.WriteLine("env " + Environment.GetEnvironmentVariable(Config.HOST));

            currentEnvironment = Environment.GetEnvironmentVariables();

            foreach (var key in currentEnvironment.Keys)
            {
                if (key is string stringKey && stringKey.Contains("SDK"))
                {
                    TestContext.Progress.WriteLine("original key + " + stringKey + " originalValue: " + currentEnvironment[key]);
                    Environment.SetEnvironmentVariable(stringKey, null);
                }
            }

            TestContext.Progress.WriteLine("env " + Environment.GetEnvironmentVariable(Config.API_KEY));
            TestContext.Progress.WriteLine("env " + Environment.GetEnvironmentVariable(Config.HOST));

            string[] env = { $"{Config.API_KEY}={apiKey}", $"{Config.HOST}={host}" };
            System.IO.File.WriteAllLines(envPath, env);
        }

        [TearDown]
        public void Cleanup()
        {
            System.IO.File.Delete(envPath);

            foreach (var key in currentEnvironment.Keys)
            {
                var value = currentEnvironment[key];

                if (key is string stringKey && value is string stringValue && stringKey.Contains("SDK"))
                {
                    TestContext.Progress.WriteLine("key " + stringKey + " value " + stringValue);
                    Environment.SetEnvironmentVariable(stringKey, stringValue);
                }
            }

            TestContext.Progress.WriteLine(Environment.GetEnvironmentVariable(Config.API_KEY));
            TestContext.Progress.WriteLine(Environment.GetEnvironmentVariable(Config.HOST));
        }

        [Test]
        // [Ignore("Currently not working in windows")]
        public void DotEnvProvided()
        {
            var config = new Config();

            Assert.AreEqual(config.ApiKey, apiKey);
            Assert.AreEqual(config.Host, host);
        }

        [Test]
        // [Ignore("Currently not working in windows")]
        public void DotEnvAndBools()
        {
            var config = new Config
            {
                ForceClear = true,
                AutostartNotifications = true,
            };

            Assert.AreEqual(config.ApiKey, apiKey);
            Assert.AreEqual(config.Host, host);
        }

    }
}