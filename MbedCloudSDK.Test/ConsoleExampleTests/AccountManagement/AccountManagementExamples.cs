using System;
using MbedCloudSDK.Common;
using NUnit.Framework;

namespace MbedCloudSDK.Test.ConsoleExampleTests.AccountManagement
{
    [TestFixture]
    public class AccountManagementExamples
    {
        [Test]
        public void GetAccountDetails()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var accountApi = new ConsoleExamples.Examples.AccountManagement.AccountManagementExamples(config);
            var account = accountApi.GetAccountDetails();
            Assert.NotNull(account);
        }

        [Test]
        public void GetAccountDetailsAsync()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var accountApi = new ConsoleExamples.Examples.AccountManagement.AccountManagementExamples(config);
            var account = accountApi.GetAccountDetailsAsync();
            Assert.NotNull(account);
        }

        [Test]
        public void ListApiKeys()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var accountApi = new ConsoleExamples.Examples.AccountManagement.AccountManagementExamples(config);
            var keys = accountApi.ListApiKeys();
            Assert.AreEqual(5, keys.Count);
        }

        [Test]
        public void ListApiKeysAsync()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var accountApi = new ConsoleExamples.Examples.AccountManagement.AccountManagementExamples(config);
            var keys = accountApi.ListApiKeysAsync().Result;
            Assert.AreEqual(5, keys.Count);
        }

        [Test]
        public void ListActiveUsers()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var accountApi = new ConsoleExamples.Examples.AccountManagement.AccountManagementExamples(config);
            var users = accountApi.ListActiveUsers();
            Assert.IsNotNull(users);
        }

        [Test]
        public void ListAllGroups()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var accountApi = new ConsoleExamples.Examples.AccountManagement.AccountManagementExamples(config);
            var groups = accountApi.ListAllGroups();
            Assert.IsNotEmpty(groups);
        }
    }
}