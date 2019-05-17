using System.Linq;
using Mbed.Cloud.Foundation;
using NUnit.Framework;

namespace Snippets.src.Foundation
{
    [TestFixture]
    public class Certificates
    {
        [Test]
        [Ignore("Not currently used as an example")]
        public async System.Threading.Tasks.Task GetDeveloperInfoAsync()
        {
            var trustedCertificateRepo = new TrustedCertificateRepository();
            var certificate = trustedCertificateRepo.List().All().FirstOrDefault(c => c.IsDeveloperCertificate == true);

            Assert.IsInstanceOf(typeof(TrustedCertificate), certificate);

            var devInfo = await trustedCertificateRepo.GetDeveloperCertificateInfo(certificate.Id);

            Assert.IsInstanceOf(typeof(DeveloperCertificate), devInfo);
        }

        [Test]
        [Ignore("Not currently used as an example")]
        public async System.Threading.Tasks.Task GetTrustedInfoAsync()
        {
            var trustedCertificateRepo = new TrustedCertificateRepository();
            var certificate = trustedCertificateRepo.List().All().FirstOrDefault(c => c.IsDeveloperCertificate == true);

            var devCertificateRepo = new DeveloperCertificateRepository();
            var devCertificate = await devCertificateRepo.Read(certificate.Id);

            Assert.IsInstanceOf(typeof(DeveloperCertificate), devCertificate);

            var trustedInfo = await devCertificateRepo.GetTrustedCertificateInfo(devCertificate.Id);
            Assert.IsInstanceOf(typeof(TrustedCertificate), trustedInfo);
        }
    }
}