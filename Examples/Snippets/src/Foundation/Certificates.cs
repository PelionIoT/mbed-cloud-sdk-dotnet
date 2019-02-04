// using System.Linq;
// using Mbed.Cloud.Foundation.Entities;
// using NUnit.Framework;

// namespace Snippets.src.Foundation
// {
//     [TestFixture]
//     public class Certificates
//     {
//         [Test]
//         public async System.Threading.Tasks.Task GetDeveloperInfoAsync()
//         {
//             var trustedCertificateRepo = new TrustedCertificateRepository();
//             var certificate = trustedCertificateRepo.List().All().FirstOrDefault(c => c.IsDeveloperCertificate == true);

//             Assert.IsInstanceOf(typeof(TrustedCertificate), certificate);

//             var devInfo = await trustedCertificateRepo.GetDeveloperCertificateInfo(certificate.Id);

//             Assert.IsInstanceOf(typeof(DeveloperCertificate), devInfo);
//         }

//         [Test]
//         public async System.Threading.Tasks.Task GetTrustedInfoAsync()
//         {
//             var trustedCertificateRepo = new TrustedCertificateRepository();
//             var certificate = trustedCertificateRepo.List().All().FirstOrDefault(c => c.IsDeveloperCertificate == true);

//             var devCertificateRepo = new DeveloperCertificateRepository();
//             var devCertificate = await devCertificateRepo.Get(certificate.Id);

//             Assert.IsInstanceOf(typeof(DeveloperCertificate), devCertificate);

//             var trustedInfo = await devCertificateRepo.GetTrustedCertificateInfo(devCertificate.Id);
//             Assert.IsInstanceOf(typeof(TrustedCertificate), trustedInfo);
//         }
//     }
// }