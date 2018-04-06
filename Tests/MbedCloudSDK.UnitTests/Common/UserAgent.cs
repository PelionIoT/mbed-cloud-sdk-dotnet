using System;
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
            TestUserAgent(BaseApi.UserAgent);
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
                BasePath = "/",
                UserAgent = BaseApi.UserAgent,
            };

            var client = iamConfig.CreateApiClient();

            iamConfig.ApiClient.RestClient = restClient.Object;

            var iam = new AccountManagementApi(new Config(""), iamConfig);

            try
            {
                iam.ListApiKeys();
            }
            catch (Exception)
            {
            }

            TestUserAgent(iamConfig.ApiClient.RestClient.UserAgent);
        }

        [Test]
        public void TestAccountManagementDeveloperApi()
        {
            var accountManagement = new AccountManagementApi(new Config(""));
            TestUserAgent(accountManagement.developerApi.Configuration.UserAgent);
        }

        [Test]
        public void TestCertificatesDeveloperApi()
        {
            var certificates = new CertificatesApi(new Config(""), null, null, false);
            TestUserAgent(certificates.developerApi.Configuration.UserAgent);
        }

        [Test]
        public void TestCertificatesDeveloperCertificatesApi()
        {
            var certificates = new CertificatesApi(new Config(""), null, null, false);
            TestUserAgent(certificates.developerCertificateApi.Configuration.UserAgent);
        }

        [Test]
        public void TestConnectStatisticsApi()
        {
            var connect = new ConnectApi(new Config(""));
            TestUserAgent(connect.statisticsApi.Configuration.UserAgent);
        }

        [Test]
        public void TestConnectResourcesApi()
        {
            var connect = new ConnectApi(new Config(""));
            TestUserAgent(connect.resourcesApi.Configuration.UserAgent);
        }

        [Test]
        public void TestConnectDeviceDirectoryApi()
        {
            var connect = new ConnectApi(new Config(""));
            TestUserAgent(connect.deviceDirectoryApi.Configuration.UserAgent);
        }

        [Test]
        public void TestDeviceDirectoryApi()
        {
            var deviceDirectory = new DeviceDirectoryApi(new Config(""));
            TestUserAgent(deviceDirectory.api.Configuration.UserAgent);
        }

        [Test]
        public void TestEnrollmentApi()
        {
            var enrollment = new EnrollmentApi(new Config(""));
            TestUserAgent(enrollment.api.Configuration.UserAgent);
        }

        [Test]
        public void TestUpdateApi()
        {
            var update = new UpdateApi(new Config(""));
            TestUserAgent(update.api.Configuration.UserAgent);
        }

        private void TestUserAgent(string agent)
        {
            StringAssert.IsMatch(@"^mbed-cloud-sdk-dotnet\/\d+.\d+.\d+.\w+", agent, "User-Agent not in correct format");
        }
    }
}