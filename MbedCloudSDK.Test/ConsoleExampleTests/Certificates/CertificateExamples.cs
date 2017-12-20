using MbedCloudSDK.Common;
using NUnit.Framework;

namespace MbedCloudSDK.Test.ConsoleExampleTests.Certificates
{
    [TestFixture]
    public class CertificateExamples
    {
        [Test]
        public void ListAllCertificates()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var host = TestContext.Parameters["mbed_cloud_sdk_host"];
            var config = new Config(key, host);
            var certificatesApi = new ConsoleExamples.Examples.Certificates.CertificateExamples(config);
            var certificates = certificatesApi.ListAllCertificates();
            Assert.IsNotEmpty(certificates);
        }

        [Test]
        public void CreateCertificate()
        {
            var key = TestContext.Parameters["mbed_cloud_sdk_api_key"];
            var host = TestContext.Parameters["mbed_cloud_sdk_host"];
            var config = new Config(key, host);
            var certificatesApi = new ConsoleExamples.Examples.Certificates.CertificateExamples(config);
            var certificate = certificatesApi.CreateCertificate();
            Assert.IsNotNull(certificate);
        }
    }
}