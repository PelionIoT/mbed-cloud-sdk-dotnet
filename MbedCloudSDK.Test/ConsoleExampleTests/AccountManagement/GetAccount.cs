using System;
using MbedCloudSDK.Common;
using NUnit.Framework;

namespace MbedCloudSDK.Test.ConsoleExampleTests.AccountManagement
{
    [TestFixture]
    public class GetAccount
    {
        [Test]
        public void GetAccountShouldNotBeNull()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            Console.WriteLine(key);
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var accountApi = new ConsoleExamples.Examples.AccountManagement.GetAccount(config);
            var account = accountApi.GetAccountDetails();
            Assert.NotNull(account);
        }

        [Test]
        public void GetAccountAsyncShouldNotBeNull()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var config = new Config(key, "https://lab-api.mbedcloudintegration.net");
            var accountApi = new ConsoleExamples.Examples.AccountManagement.GetAccount(config);
            var account = accountApi.GetAccountDetailsAsync();
            Assert.NotNull(account);
        }
    }
}