/* 
 * Provisioning endpoints - developer certificates.
 *
 * A developer certificate is used during development to allow quick association of the device with the mbed Cloud account of the developer. It is used instead of the Factory Tool.  The developer should generate a key-pair (NIST P-256 Elliptic Curve), add the public key to the mbed Cloud account using these APIs, and use the private key on the device (typically in a file named identity_dev_security.c). This creates an association between the device and the cloud.  Only one developer certificate per account is allowed.  As an example, a developer certificate can be created using OpenSSL as follows:  ``` openssl ecparam -out key.pem -name prime256v1 -genkey openssl ec -text -in key.pem -pubout ```  The output is:  ``` read EC key Private-Key: (256 bit) priv:     4e:50:25:1c:c0:70:29:05:dc:1d:7b:58:ba:a1:27:     c3:6f:aa:92:22:ca:0f:f1:af:74:cb:15:a4:cb:36:     98:3f pub:     04:35:54:40:80:f8:fb:45:ad:8a:fc:1a:9e:8c:88:     58:fa:84:91:ca:51:d2:09:d5:7b:35:9f:72:10:31:     a2:7c:d6:18:8b:49:d9:56:91:f0:99:b7:a9:a0:c6:     c1:5b:b8:d3:24:a8:cd:0c:76:9f:f0:c8:41:b0:a3:     dd:d3:2c:88:e1 ASN1 OID: prime256v1 NIST CURVE: P-256 writing EC key - -- --BEGIN PUBLIC KEY- -- -- MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAENVRAgPj7Ra2K/BqejIhY+oSRylHS CdV7NZ9yEDGifNYYi0nZVpHwmbepoMbBW7jTJKjNDHaf8MhBsKPd0yyI4Q== - -- --END PUBLIC KEY- -- -- ```  The bytes under \"priv\" are the 32 private key bytes. They should be placed on the device (in the identity_dev_security.c file), as a byte array.  The text starting with \"BEGIN PUBLIC KEY\" is the public key in PEM format, which should be uploaded using the POST API.  Another example, using Python:  ``` from ecdsa import SigningKey, NIST256p private_key = SigningKey.generate(curve=NIST256p) public_key = private_key.get_verifying_key() print \"Public key:\" print public_key.to_pem() bytes = bytearray(private_key.to_string()) for byte in bytes:   print hex(byte) + \",\", ``` 
 *
 * OpenAPI spec version: 0.8
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;

namespace developer_certificate.Client
{
    /// <summary>
    /// Represents configuration aspects required to interact with the API endpoints.
    /// </summary>
    public interface IApiAccessor
    {
        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        Configuration Configuration {get; set;}

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        String GetBasePath();
        
        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        ExceptionFactory ExceptionFactory { get; set; }
    }
}
