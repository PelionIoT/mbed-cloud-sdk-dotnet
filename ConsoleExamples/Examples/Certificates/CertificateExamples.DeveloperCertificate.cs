// <copyright file="CertificateExamples.DeveloperCertificate.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.Certificates
{
    using System;
    using MbedCloudSDK.Certificates.Api;
    using MbedCloudSDK.Certificates.Model;
    using MbedCloudSDK.Common;

    /// <summary>
    /// Certificate examples
    /// </summary>
    public partial class CertificateExamples
    {
        private Config config;
        private CertificatesApi api;

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateExamples"/> class.
        /// </summary>
        /// <param name="config">Config</param>
        public CertificateExamples(Config config)
        {
            this.config = config;
            api = new CertificatesApi(this.config);
        }

        /// <summary>
        /// Create, update and delete a certificate
        /// </summary>
        /// <returns>Certificate</returns>
        public Certificate CreateCertificate()
        {
            var certificate = new Certificate
            {
                Name = GetRandomName(),
            };
            var newCertificate = api.AddDeveloperCertificate(certificate);
            Console.WriteLine($"New certificate id - {newCertificate.Id}");

            var updatedCertificate = api.UpdateCertificate(newCertificate.Id, new Certificate { Name = GetRandomName(), Description = "my updated certificate" });

            Console.WriteLine($"updated certificate description - {updatedCertificate.Description}");

            api.DeleteCertificate(updatedCertificate.Id);

            Console.WriteLine("Deleted certificate");

            return updatedCertificate;
        }

        private static string GetRandomName()
        {
            return $"myNewCertificate-{DateTime.Now}";
        }
    }
}