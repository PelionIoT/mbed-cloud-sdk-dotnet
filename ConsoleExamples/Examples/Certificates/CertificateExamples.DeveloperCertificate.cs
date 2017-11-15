using System;
using MbedCloudSDK.Certificates.Api;
using MbedCloudSDK.Certificates.Model;
using MbedCloudSDK.Common;

namespace ConsoleExamples.Examples.Certificates
{
    public partial class CertificateExamples
    {
        private Config config;
        private CertificatesApi api;

        public CertificateExamples(Config _config)
        {
            config = _config;
            api = new CertificatesApi(config);
        }

        public Certificate CreateCertificate()
        {
            var certificate = new Certificate()
            {
                Name = $"myNewCertificate-{DateTime.Now}"
            };
            var newCertificate = api.AddDeveloperCertificate(certificate);
            Console.WriteLine($"New certificate id - {newCertificate.Id}");

            var updatedCertificate = api.UpdateCertificate(newCertificate.Id, new Certificate { Description = "my updated certificate" });

            Console.WriteLine($"updated certificate description - {updatedCertificate.Description}");

            api.DeleteCertificate(updatedCertificate.Id);

            Console.WriteLine("Deleted certificate");

            return updatedCertificate;
        }
    }
}