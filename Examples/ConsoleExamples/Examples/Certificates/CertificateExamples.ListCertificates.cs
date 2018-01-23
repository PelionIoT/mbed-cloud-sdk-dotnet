// <copyright file="CertificateExamples.ListCertificates.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.Certificates
{
    using System;
    using System.Collections.Generic;
    using MbedCloudSDK.Certificates.Model;
    using MbedCloudSDK.Common.Query;

    /// <summary>
    /// Certificate examples
    /// </summary>
    public partial class CertificateExamples
    {
        /// <summary>
        /// List the first 5 certificates
        /// </summary>
        /// <returns>List of certificates</returns>
        public List<Certificate> ListAllCertificates()
        {
            var options = new QueryOptions
            {
                Limit = 5,
                Order = "DESC",
            };
            var certificates = api.ListCertificates(options).Data;
            foreach (var item in certificates)
            {
                Console.WriteLine(item);
            }

            return certificates;
        }
    }
}