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
                var myConfig = new CertificateIssuerConfig().List().All().FirstOrDefault(c => c.Reference == "LWM2M");
                // cloak
                Assert.IsAssignableFrom(typeof(CertificateIssuerConfig), myConfig, "config should be instance of CertificateIssuerConfig");
                Assert.AreEqual("LWM2M", myConfig.Reference);
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
                    await device.RenewCertificate(myConfig.Reference);
                }
                // end of example
            }
            catch (CloudApiException e) when (e.ErrorCode == 400)
            {
                // should throw 400, device cert cannot be renewed
                return;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}