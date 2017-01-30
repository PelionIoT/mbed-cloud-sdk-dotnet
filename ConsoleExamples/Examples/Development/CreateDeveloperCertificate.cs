using mbedCloudSDK.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamples.Examples.Development
{
    /// @example
    public class CreateDeveloperCertificate
    {
        private Config config;

        public CreateDeveloperCertificate(Config config)
        {
            this.config = config;
        }

        public void CreateCertificate()
        {
            CngKey key = CngKey.Create(CngAlgorithm.ECDsaP256, null, new CngKeyCreationParameters { ExportPolicy = CngExportPolicies.AllowPlaintextExport });
            ECDsaCng dsa = new ECDsaCng(key);
            byte[] privateBytes = key.Export(CngKeyBlobFormat.EccPrivateBlob);
            string privateString = Encoding.UTF8.GetString(privateBytes);
            byte[] publicBytes = key.Export(CngKeyBlobFormat.EccPublicBlob);
            byte[] pemPrivate = key.Export(CngKeyBlobFormat.Pkcs8PrivateBlob);
            string hex = BitConverter.ToString(pemPrivate);
            hex = hex.Replace("-", "");
            //string pemString = Encoding.UTF8.GetString(pemPrivate);
            Console.WriteLine(privateBytes);
        }
    }
}
