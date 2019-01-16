// using System.Linq;
// using MbedCloud.SDK.Entities;
// using NUnit.Framework;

// namespace Snippets.src.Foundation
// {
//     [TestFixture]
//     public class Certificates
//     {
//         [Test]
//         public async System.Threading.Tasks.Task GetDeveloperInfoAsync()
//         {
//             var certificate = new TrustedCertificate().List().All().FirstOrDefault(c => c.IsDeveloperCertificate == true);

//             Assert.IsInstanceOf(typeof(TrustedCertificate), certificate);

//             var devInfo = await certificate.GetDeveloperCertificateInfo();

//             Assert.IsInstanceOf(typeof(DeveloperCertificate), devInfo);
//         }

//         [Test]
//         public async System.Threading.Tasks.Task GetTrustedInfoAsync()
//         {
//             var certificate = new TrustedCertificate().List().All().FirstOrDefault(c => c.IsDeveloperCertificate == true);

//             var devCertificate = await new DeveloperCertificate
//             {
//                 Id = certificate.Id
//             }.Get();

//             Assert.IsInstanceOf(typeof(DeveloperCertificate), devCertificate);

//             var trustedInfo = await devCertificate.GetTrustedCertificateInfo();
//             Assert.IsInstanceOf(typeof(TrustedCertificate), trustedInfo);
//         }
//     }
// }