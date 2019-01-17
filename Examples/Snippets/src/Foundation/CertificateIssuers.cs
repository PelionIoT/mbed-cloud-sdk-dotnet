using System.Threading.Tasks;
using Mbed.Cloud.Foundation.Entities;
using NUnit.Framework;

namespace Snippets.src.Foundation
{
    [TestFixture]
    public class CertificateIssuers
    {
        [Test]
        public async Task GetDefaultCertificateIssuerConfig()
        {
            var defaultIssuer = await new CertificateIssuerConfigRepository().GetDefault();
            Assert.IsInstanceOf(typeof(CertificateIssuerConfig), defaultIssuer);
        }
    }
}