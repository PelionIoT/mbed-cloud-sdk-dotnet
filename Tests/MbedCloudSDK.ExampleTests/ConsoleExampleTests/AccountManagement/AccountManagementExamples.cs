using MbedCloudSDK.Common;
using MbedCloudSDK.ExampleTests;
using NUnit.Framework;
using System;

namespace MbedCloudSDK.Test.ConsoleExampleTests.AccountManagement
{
    [TestFixture]
    public class AccountManagementExamples
    {
        [OneTimeSetUp]
        public void Init()
        {
            SetEnvironment.SetEnvironmentVariables();
        }

        [Test]
        public void GetAccountDetails()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var accountApi = new ConsoleExamples.Examples.AccountManagement.AccountManagementExamples(config);
            var account = accountApi.GetAccountDetails();
            Assert.IsNotNull(account);
        }

        [Test]
        public void GetAccountDetailsAsync()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var accountApi = new ConsoleExamples.Examples.AccountManagement.AccountManagementExamples(config);
            var account = accountApi.GetAccountDetailsAsync();
            Assert.IsNotNull(account);
        }

        [Test]
        public void ListApiKeys()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var accountApi = new ConsoleExamples.Examples.AccountManagement.AccountManagementExamples(config);
            var keys = accountApi.ListApiKeys();
            Assert.IsNotEmpty(keys);
        }

        [Test]
        public void ListApiKeysAsync()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var accountApi = new ConsoleExamples.Examples.AccountManagement.AccountManagementExamples(config);
            var keys = accountApi.ListApiKeysAsync().Result;
            Assert.IsNotEmpty(keys);
        }

        [Test]
        public void ListActiveUsers()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var accountApi = new ConsoleExamples.Examples.AccountManagement.AccountManagementExamples(config);
            var users = accountApi.ListActiveUsers();
            Assert.IsNotNull(users);
        }

        [Test]
        public void ListAllGroups()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var accountApi = new ConsoleExamples.Examples.AccountManagement.AccountManagementExamples(config);
            var groups = accountApi.ListAllGroups();
            Assert.IsNotEmpty(groups);
        }

        [Test]
        public void UpdateAccount()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var accountApi = new ConsoleExamples.Examples.AccountManagement.AccountManagementExamples(config);
            var account = accountApi.UpdateAccount();
            Assert.AreEqual("New York", account.City);
        }

        [Test]
        public void UpdateAccountAsync()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var accountApi = new ConsoleExamples.Examples.AccountManagement.AccountManagementExamples(config);
            var account = accountApi.UpdateAccountAsync().Result;
            Assert.AreEqual("New York", account.City);
        }

        [Test]
        public void GetApiKey()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var accountApi = new ConsoleExamples.Examples.AccountManagement.AccountManagementExamples(config);
            var apiKey = accountApi.GetApiKey();
            Assert.IsNotNull(apiKey);
        }

        [Test]
        public void GetApiKeyAsync()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var accountApi = new ConsoleExamples.Examples.AccountManagement.AccountManagementExamples(config);
            var apiKey = accountApi.GetApiKeyAsync().Result;
            Assert.IsNotNull(apiKey);
        }

        [Test]
        public void AddApiKey()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var accountApi = new ConsoleExamples.Examples.AccountManagement.AccountManagementExamples(config);
            var apiKey = accountApi.AddApiKey();
            Assert.IsNotNull(apiKey);
        }

        [Test]
        public void AddApiKeyAsync()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var accountApi = new ConsoleExamples.Examples.AccountManagement.AccountManagementExamples(config);
            var apiKey = accountApi.AddApiKeyAsync().Result;
            Assert.IsNotNull(apiKey);
        }

        [Test]
        public void AddUser()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var accountApi = new ConsoleExamples.Examples.AccountManagement.AccountManagementExamples(config);
            var user = accountApi.AddUser();
            Assert.IsNotNull(user);
        }

        [Test]
        public void AddUserAsync()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var accountApi = new ConsoleExamples.Examples.AccountManagement.AccountManagementExamples(config);
            var user = accountApi.AddUserAsync().Result;
            Assert.IsNotNull(user);
        }
    }
}