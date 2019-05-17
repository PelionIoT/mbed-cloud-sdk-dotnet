using System;
using System.Linq;
using Mbed.Cloud.Foundation;
using Mbed.Cloud.Foundation.Enums;
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
                var myConfig = new CertificateIssuerConfigRepository().List().All().FirstOrDefault(c => c.Reference == "LWM2M");
                // cloak
                Assert.AreEqual("LWM2M", myConfig.Reference);
                Assert.IsAssignableFrom(typeof(CertificateIssuerConfig), myConfig, "config should be instance of CertificateIssuerConfig");
                // uncloak

                var connectedDevices = new DeviceRepository()
                    .List()
                    .All()
                    .Where(d => d.State == DeviceState.REGISTERED)
                    .ToList();

                // cloak
                Assert.GreaterOrEqual(connectedDevices.Count, 1);
                // uncloak

                foreach (var device in connectedDevices)
                {
                    await new DeviceRepository().RenewCertificate(myConfig.Reference, device.Id);
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