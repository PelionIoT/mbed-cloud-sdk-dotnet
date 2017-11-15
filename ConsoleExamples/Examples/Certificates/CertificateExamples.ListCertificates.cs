using MbedCloudSDK.Common;
using System;
using MbedCloudSDK.Certificates.Api;
using MbedCloudSDK.Common.Query;
using System.Collections.Generic;
using MbedCloudSDK.Certificates.Model;

namespace ConsoleExamples.Examples.Certificates
{
    public partial class CertificateExamples
    {
        public List<Certificate> ListAllCertificates()
        {
            var options = new QueryOptions()
            {
                Limit = 5,
                Order = "DESC"
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