using System;
using System.IO;
using Mbed.Cloud.Common;
using MbedCloudSDK.AccountManagement.Api;
using MbedCloudSDK.Certificates.Api;
using MbedCloudSDK.Common;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.DeviceDirectory.Api;
using MbedCloudSDK.Enrollment.Api;
using MbedCloudSDK.Update.Api;
using Moq;
using NUnit.Framework;
using RestSharp;

namespace MbedCloudSDK.UnitTests.Common
{
    [TestFixture]
    public class UserAgent
    {
        [Test]
        public void TestUserAgent()
        {
            TestUserAgent(Api.UserAgent);
        }

        [Test]
        public void TestRequest()
        {
            var restClient = new Mock<RestClient>();

            restClient.Setup(x => x.Execute(
                It.IsAny<IRestRequest>()
            )).Returns((IRestRequest val) => { return new RestResponse { Request = val }; });

            var iamConfig = new iam.Client.Configuration
            {
                BasePath = Path.Combine("/"),
                UserAgent = Api.UserAgent,
            };

            var client = iamConfig.CreateApiClient();

            iamConfig.ApiClient.RestClient = restClient.Object;

            var iam = new AccountManagementApi(new Config("apiKey"), iamConfig);

            try
            {
                iam.GetAccount();
            }
            catch (Exception)
            {
            }

            TestUserAgent(iamConfig.ApiClient.RestClient.UserAgent);
        }

        [Test]
        public void TestAccountManagementDeveloperApi()
        {
            var accountManagement = new AccountManagementApi(new Config("apiKey"));
            TestUserAgent(accountManagement.DeveloperApi.Configuration.UserAgent);
        }

        [Test]
        public void TestCertificatesDeveloperApi()
        {
            var certificates = new CertificatesApi(new Config("apiKey"), null, null, false);
            TestUserAgent(certificates.DeveloperApi.Configuration.UserAgent);
        }

        [Test]
        public void TestCertificatesDeveloperCertificatesApi()
        {
            var certificates = new CertificatesApi(new Config("apiKey"), null, null, false);
            TestUserAgent(certificates.DeveloperCertificateApi.Configuration.UserAgent);
        }

        [Test]
        public void TestConnectStatisticsApi()
        {
            var connect = new ConnectApi(new Config("apiKey"));
            TestUserAgent(connect.StatisticsApi.Configuration.UserAgent);
        }

        [Test]
        public void TestConnectResourcesApi()
        {
            var connect = new ConnectApi(new Config("apiKey"));
            TestUserAgent(connect.ResourcesApi.Configuration.UserAgent);
        }

        [Test]
        public void TestConnectDeviceDirectoryApi()
        {
            var connect = new ConnectApi(new Config("apiKey"));
            TestUserAgent(connect.DeviceDirectoryApi.Configuration.UserAgent);
        }

        [Test]
        public void TestDeviceDirectoryApi()
        {
            var deviceDirectory = new DeviceDirectoryApi(new Config("apiKey"));
            TestUserAgent(deviceDirectory.Api.Configuration.UserAgent);
        }

        [Test]
        public void TestEnrollmentApi()
        {
            var enrollment = new EnrollmentApi(new Config("apiKey"));
            TestUserAgent(enrollment.Api.Configuration.UserAgent);
        }

        [Test]
        public void TestUpdateApi()
        {
            var update = new UpdateApi(new Config("apiKey"));
            TestUserAgent(update.Api.Configuration.UserAgent);
        }

        private void TestUserAgent(string agent)
        {
            StringAssert.IsMatch(@"^mbed-cloud-sdk-dotnet\/\d+.\d+.\d+", agent, "User-Agent not in correct format");
        }
    }
}