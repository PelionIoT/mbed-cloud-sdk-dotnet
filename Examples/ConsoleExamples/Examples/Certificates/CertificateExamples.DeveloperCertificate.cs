// <copyright file="CertificateExamples.DeveloperCertificate.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.Certificates
{
    using System;
    using Mbed.Cloud.Foundation.Common;
    using MbedCloudSDK.Certificates.Api;
    using MbedCloudSDK.Certificates.Model;

    /// <summary>
    /// Certificate examples
    /// </summary>
    public partial class CertificateExamples
    {
        private Config config;
        private CertificatesApi api;
        private Random rnd;

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateExamples"/> class.
        /// </summary>
        /// <param name="config">Config</param>
        public CertificateExamples(Config config)
        {
            this.config = config;
            api = new CertificatesApi(this.config);
            rnd = new Random();
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

            newCertificate.Name = GetRandomName();
            newCertificate.Description = "my updated certificate";

            Console.WriteLine(newCertificate);

            var updatedCertificate = api.UpdateCertificate(newCertificate.Id, newCertificate);

            Console.WriteLine($"updated certificate description - {updatedCertificate.Description}");

            api.DeleteCertificate(updatedCertificate.Id);

            Console.WriteLine("Deleted certificate");

            return updatedCertificate;
        }

        private string GetRandomName()
        {
            return $"myNewCertificate-{rnd.Next(1000)}";
        }
    }
}