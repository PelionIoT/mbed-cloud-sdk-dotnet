using System;
using System.Threading.Tasks;
using Mbed.Cloud;
using Mbed.Cloud.Foundation;
using Mbed.Cloud.Foundation.Enums;
using MbedCloudSDK.Exceptions;
using NUnit.Framework;

[TestFixture]
public class CertificateBlacklistExamples
{
    [Test]
    public async Task CertificateBlacklisting()
    {
        try
        {
            var certId = "016711e8061a5ad1ecb35f6800000000";
            // an example: certificate_black_listing
            var sdk = new SDK();

            var trustedCert = await sdk
                                    .Foundation()
                                    .TrustedCertificateRepository()
                                    .Read(certId);

            trustedCert.Status = TrustedCertificateStatus.INACTIVE;

            await sdk
                    .Foundation()
                    .TrustedCertificateRepository()
                    .Update(trustedCert.Id, trustedCert);

            var deviceList = sdk
                                .Foundation()
                                .DeviceEnrollmentDenialRepository()
                                .List(
                                    new DeviceEnrollmentDenialDeviceEnrollmentDenialListOptions()
                                        .TrustedCertificateIdEqualTo(trustedCert.Id));

            foreach (var device in deviceList)
            {
                Console.WriteLine($"Device endpoint name: {device.EndpointName}");
            }
            // end of example
        }
        catch (CloudApiException e) when (e.ErrorCode == 400)
        {
            // currently expecting 400 as not activated in account
        }
    }

}