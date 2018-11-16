using System;
using System.Linq;
using MbedCloud.SDK.Entities;
using MbedCloud.SDK.Enums;
using MbedCloudSDK.Exceptions;
using NUnit.Framework;

namespace Snippets.src.Foundation
{
    [TestFixture]
    public class CertRenew
    {
        [Test]
        public async System.Threading.Tasks.Task RenewDeviceCertificateAsync()
        {
            try
            {
                // an example: certificate renew
                var myConfig = new CertificateIssuerConfig().List().All().FirstOrDefault(c => c.CertificateReference == "LWM2M");
                // cloak
                Assert.AreEqual("LWM2M", myConfig.CertificateReference);
                Assert.IsAssignableFrom(typeof(CertificateIssuerConfig), myConfig, "config should be instance of CertificateIssuerConfig");
                // uncloak

                var connectedDevices = new Device()
                    .List()
                    .All()
                    .Where(d => d.State == DeviceStateEnum.REGISTERED)
                    .ToList();

                // cloak
                Assert.GreaterOrEqual(connectedDevices.Count, 1);
                // uncloak

                foreach (var device in connectedDevices)
                {
                    await device.RenewCertificate(myConfig.CertificateReference);
                }
                // end of example
            }
            catch (CloudApiException e) when (e.ErrorCode == 400 || e.ErrorCode == 423)
            {
                // should throw 423, device cert cannot be renewed
                return;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}