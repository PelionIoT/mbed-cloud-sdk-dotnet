using MbedCloudSDK.Common;
using MbedCloudSDK.ExampleTests;
using NUnit.Framework;
using System;

namespace MbedCloudSDK.Test.ConsoleExampleTests.Certificates
{
    [TestFixture]
    public class CertificateExamples
    {
        [OneTimeSetUp]
        public void Init()
        {
            SetEnvironment.SetEnvironmentVariables();
        }

        [Test]
        public void ListAllCertificates()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var certificatesApi = new ConsoleExamples.Examples.Certificates.CertificateExamples(config);
            var certificates = certificatesApi.ListAllCertificates();
            Assert.IsNotEmpty(certificates);
        }

        [Test]
        public void CreateCertificate()
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_HOST");
            var config = new Config(key, host);
            var certificatesApi = new ConsoleExamples.Examples.Certificates.CertificateExamples(config);
            var certificate = certificatesApi.CreateCertificate();
            Assert.IsNotNull(certificate);
        }
    }
}