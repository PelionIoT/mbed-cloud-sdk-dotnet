using mbedCloudSDK.Access.Api;
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

        private string certificate = @"
            //----------------------------------------------------------------------------
            //   The confidential and proprietary information contained in this file may
            //   only be used by a person authorised under and to the extent permitted
            //   by a subsisting licensing agreement from ARM Limited or its affiliates.
            //
            //          (C) COPYRIGHT 2013-2017 ARM Limited or its affiliates.
            //              ALL RIGHTS RESERVED
            //
            //   This entire notice must be reproduced on all copies of this file
            //   and copies of this file may only be made by a person if such person is
            //   permitted to do so under the terms of a subsisting license agreement
            //   from ARM Limited or its affiliates.
            //----------------------------------------------------------------------------
            /*
            {0}
            {1}*/
            # ifndef __IDENTITY_DEV_SECURITY_H__
            #define __IDENTITY_DEV_SECURITY_H__
            # include <inttypes.h>
                    const char gIdcDevSecurityAccountId[33] = '{2}';
                    const uint8_t gIdcDevSecurityPrivateSignKey[32] = {{
            {3}
            }};
            #endif //__IDENTITY_DEV_SECURITY_H";

        public void CreateCertificate()
        {
            CngKey key = CngKey.Create(CngAlgorithm.ECDsaP256, null, new CngKeyCreationParameters { ExportPolicy = CngExportPolicies.AllowPlaintextExport });
            byte[] keyBytes = key.Export(CngKeyBlobFormat.EccPrivateBlob);
            byte[] publicBytes = key.Export(CngKeyBlobFormat.EccPublicBlob);
            byte[] privateKeyBytes = new byte[32];
            // Private key is on the last 32 bytes of key.
            Array.Copy(keyBytes, 72, privateKeyBytes, 0, 32);
            string privateHex = string.Join(",", privateKeyBytes.Select(b =>
            {
                return String.Format("0x{0}", b.ToString());
            }));
            var accessApi = new AccessApi(config);
            var accountId = accessApi.GetAccount().Id;
            string privatePem = Convert.ToBase64String(privateKeyBytes); 
            string publicPem = Convert.ToBase64String(publicBytes);
            String certString = String.Format(certificate, publicPem, privatePem, accountId, privateHex);
            Console.WriteLine(certString);
        }
    }
}
