using MbedCloud.SDK.Entities;
using NUnit.Framework;

namespace Snippets.src.Foundation
{
    [TestFixture]
    public class CertificateIssuers
    {
        [Test]
        public async System.Threading.Tasks.Task GetDefaultCertificateIssuerConfig()
        {
            var defaultIssuer = await new CertificateIssuerConfig().GetDefault();
            Assert.IsInstanceOf(typeof(CertificateIssuerConfig), defaultIssuer);
        }
    }
}