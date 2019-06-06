
using System;
using Newtonsoft.Json;
using MbedCloudSDK.Common.Extensions;
using System.Linq;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Threading;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.Common;
using System.Collections.Generic;
using Mbed.Cloud.Common;
using MbedCloudSDK.Connect.Api.Subscribe.Observers;
using Mbed.Cloud.Foundation;
using Mbed.Cloud.Foundation.Enums;
using Mbed.Cloud.RestClient;

namespace Playground
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var devCertRepo = new DeveloperCertificateRepository();

                var newCert = await devCertRepo.Create(new DeveloperCertificate
                {
                    Name = "AUTOTEST-4QN2R7",
                    Description = "Yes force store official cold television. Media hair indeed property. Improve detail increase yeah oh choose patient.",
                });

                Console.WriteLine($"The certificate from create {newCert.Certificate}");

                var readCert = await devCertRepo.Read(newCert.Id);

                Console.WriteLine($"The certificate from the read {readCert.Certificate}");

                var trustedInfo = await devCertRepo.GetTrustedCertificateInfo(readCert.Id);

                Console.WriteLine($"The certificate from the info {trustedInfo.Certificate}");

                await devCertRepo.Delete(readCert.Id);

                var res = "{\"name\":\"AUTOTEST-4QN2R7\",\"description\":\"Yes force store official cold television. Media hair indeed property. Improve detail increase yeah oh choose patient.\",\"account_id\":\"015a9e3ac83502420a01400a00000000\",\"owner_id\":\"016105b133f70a580a01071900000000\",\"certificate\":\"-----BEGIN CERTIFICATE-----\\nMIICgzCCAimgAwIBAgIQd/THat4vRee59bOA+X0nXjAKBggqhkjOPQQDAjCBojEL\\nMAkGA1UEBhMCR0IxFzAVBgNVBAgMDkNhbWJyaWRnZXNoaXJlMRIwEAYDVQQHDAlD\\nYW1icmlkZ2UxEDAOBgNVBAoMB0FSTSBMdGQxKTAnBgNVBAsMIDAxNWE5ZTNhYzgz\\nNTAyNDIwYTAxNDAwYTAwMDAwMDAwMSkwJwYDVQQDDCAwMTZhYmFiNGU3ZTQ2Njgz\\nYmZmMjVmMTkwM2MwMDAwMDAeFw0xOTA1MTUwODU2MTlaFw0yOTA1MTUwODU2MTla\\nMIGiMQswCQYDVQQGEwJHQjEXMBUGA1UECAwOQ2FtYnJpZGdlc2hpcmUxEjAQBgNV\\nBAcMCUNhbWJyaWRnZTEQMA4GA1UECgwHQVJNIEx0ZDEpMCcGA1UECwwgMDE1YTll\\nM2FjODM1MDI0MjBhMDE0MDBhMDAwMDAwMDAxKTAnBgNVBAMMIDAxNmFiYWI0ZTdl\\nNDY2ODNiZmYyNWYxOTAzYzAwMDAwMFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAE\\nw3eJRfylEozgaNquUao5Dzujru+QslNPw925iOZX14rlyB6R0jMU0ixqUbmvxzjH\\nQ+P2HUghUXpdHp0cRED/zKM/MD0wEgYJKwYBBAGgIIFJBAUCA0AAkTASBgNVHRMB\\nAf8ECDAGAQH/AgEAMBMGA1UdJQQMMAoGCCsGAQUFBwMCMAoGCCqGSM49BAMCA0gA\\nMEUCIQCiER3xj+dK4MJ5M7RnuphMvY6Ga6YS4iEOFztyBZDkYAIgLEKxepMhENOi\\n/KaGO7KyL7VOUMAJB/pcq9m8vncvdiw=\\n-----END CERTIFICATE-----\",\"service\":\"bootstrap\",\"issuer\":\"CN=016abab4e7e46683bff25f1903c00000,OU=015a9e3ac83502420a01400a00000000,O=ARM Ltd,L=Cambridge,ST=Cambridgeshire,C=GB\",\"subject\":\"CN=016abab4e7e46683bff25f1903c00000,OU=015a9e3ac83502420a01400a00000000,O=ARM Ltd,L=Cambridge,ST=Cambridgeshire,C=GB\",\"validity\":\"2029-05-15T08:56:19Z\",\"status\":\"ACTIVE\",\"certificate_fingerprint\":\"fb88ced96139e260de32e36b800b2ba0f747ed62b01a319aa6167cb249023640\",\"device_execution_mode\":1,\"enrollment_mode\":false,\"valid\":true,\"object\":\"trusted-cert\",\"id\":\"016abab4e7e46683bff25f1903c00000\",\"etag\":\"1\",\"created_at\":\"2019-05-15T08:56:19Z\",\"updated_at\":null}";

                var cert = JsonConvert.DeserializeObject<TrustedCertificate>(res, SerializationSettings.GetDeserializationSettings());

                Console.WriteLine(cert.Certificate);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception...");
                Console.WriteLine(e);
            }
        }
    }
}
