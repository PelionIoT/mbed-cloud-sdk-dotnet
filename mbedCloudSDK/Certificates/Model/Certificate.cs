using mbedCloudSDK.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Certificates.Model
{
    class Certificate
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public CertificateType Type { get; private set; }
        
        /// <summary>
        /// Human readable description of this certificate.
        /// </summary>
        /// <value>Human readable description of this certificate.</value>
        public string Description { get; set; }
        
        /// <summary>
        /// Device execution mode where 1 means a developer certificate.
        /// </summary>
        /// <value>Device execution mode where 1 means a developer certificate.</value>
        public int? DeviceExecutionMode { get; private set; }
        
        /// <summary>
        /// Creation UTC time RFC3339.
        /// </summary>
        /// <value>Creation UTC time RFC3339.</value>
        public DateTime? CreatedAt { get; private set; }
        
        /// <summary>
        /// Subject of the certificate.
        /// </summary>
        /// <value>Subject of the certificate.</value>
        public string Subject { get; private set; }
        
        /// <summary>
        /// The UUID of the account.
        /// </summary>
        /// <value>The UUID of the account.</value>
        public string AccountId { get; private set; }

        /// <summary>
        /// Base 64 encoded SHA256 hash of AccountID.
        /// </summary>
        /// <value>Base 64 encoded SHA256 hash of AccountID.</value>
        public string Signature {get; private set;}
     
        /// <summary>
        /// Expiration time in UTC formatted as RFC3339.
        /// </summary>
        /// <value>Expiration time in UTC formatted as RFC3339.</value>
        public DateTime? Validity { get; private set; }
        
        /// <summary>
        /// Issuer of the certificate.
        /// </summary>
        /// <value>Issuer of the certificate.</value>
        public string Issuer { get; private set; }
        
        /// <summary>
        /// X509.v3 trusted certificate in PEM or base64 encoded DER format.
        /// </summary>
        /// <value>X509.v3 trusted certificate in PEM or base64 encoded DER format.</value>
        public string CertData { get; private set; }
        
        /// <summary>
        /// Entity ID.
        /// </summary>
        /// <value>Entity ID.</value>
        [NameOverride(Name = "CertificateId")]
        [JsonProperty]
        public string Id { get; private set; }
        
        /// <summary>
        /// Certificate name.
        /// </summary>
        /// <value>Certificate name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Content of the security.c file that will be flashed into the device to provide the security credentials
        /// </summary>
        /// <value>Content of the security.c file that will be flashed into the device to provide the security credentials</value>
        public string SecurityFileContent { get; private set; }
        
        /// <summary>
        /// PEM format X.509 developer certificate.
        /// </summary>
        /// <value>PEM format X.509 developer certificate.</value>
        public string DeveloperCertificate { get; private set; }
        
        /// <summary>
        /// URI to which the client needs to connect to.
        /// </summary>
        /// <value>URI to which the client needs to connect to.</value>
        public string ServerUri { get; set; }
        
        /// <summary>
        /// PEM format developer private key associated to the certificate.
        /// </summary>
        /// <value>PEM format developer private key associated to the certificate.</value>
        public string DeveloperPrivateKey { get; private set; }
        
        /// <summary>
        /// PEM format X.509 server certificate that will be used to validate the server certificate that will be received during the TLS/DTLS handshake.
        /// </summary>
        /// <value>PEM format X.509 server certificate that will be used to validate the server certificate that will be received during the TLS/DTLS handshake.</value>
        public string ServerCertificate { get; private set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Certificate {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DeviceExecutionMode: ").Append(DeviceExecutionMode).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  Validity: ").Append(Validity).Append("\n");
            sb.Append("  Issuer: ").Append(Issuer).Append("\n");
            sb.Append("  CertData: ").Append(CertData).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  SecurityFileContent: ").Append(SecurityFileContent).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DeveloperCertificate: ").Append(DeveloperCertificate).Append("\n");
            sb.Append("  ServerUri: ").Append(ServerUri).Append("\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  DeveloperPrivateKey: ").Append(DeveloperPrivateKey).Append("\n");
            sb.Append("  ServerCertificate: ").Append(ServerCertificate).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Map to Certificate object.
        /// </summary>
        /// <param name="trustedCertificate">TrustedCertificate response object.</param>
        /// <param name="certificate">Certificate to be updated.</param>
        /// <returns></returns>
        public static Certificate Map(iam.Model.TrustedCertificateResp trustedCertificate, Certificate certificate = null)
        {
            if (certificate == null)
            {
                certificate = new Certificate();
            }
            if (trustedCertificate.DeviceExecutionMode == 1)
            {
                certificate.Type = CertificateType.Developer;
            }
            else
            {
                switch (trustedCertificate.Service)
                {
                    case iam.Model.TrustedCertificateResp.ServiceEnum.Bootstrap:
                        certificate.Type = CertificateType.Bootstrap;
                        break;
                    case iam.Model.TrustedCertificateResp.ServiceEnum.Lwm2m:
                        certificate.Type = CertificateType.Lwm2m;
                        break;
                    default:
                        throw new System.IO.InvalidDataException("Wrong Trusted Certificate Service"); 
                }
            }
            
            certificate.DeviceExecutionMode = trustedCertificate.DeviceExecutionMode;
            certificate.Subject = trustedCertificate.Subject;
            certificate.AccountId = trustedCertificate.AccountId;
            certificate.Validity = trustedCertificate.Validity;
            certificate.Issuer = trustedCertificate.Issuer;
            certificate.CertData = trustedCertificate.Certificate;
            certificate.Id = trustedCertificate.Id;
            certificate.Name = trustedCertificate.Name;
            certificate.Description = trustedCertificate.Description;
            certificate.CreatedAt = trustedCertificate.CreatedAt;
            return certificate;
        }

        /// <summary>
        /// Map to Certificate object.
        /// </summary>
        /// <param name="developerCertificateData">Developer certificate data</param>
        /// <param name="certificate">Certificate to be updated</param>
        /// <returns></returns>
        public static Certificate Map(connector_ca.Model.DeveloperCertificateResponseData developerCertificateData, Certificate certificate = null)
        {
            if (certificate == null)
            {
                certificate = new Certificate();
            }
            certificate.Type = CertificateType.Developer;
            certificate.DeviceExecutionMode = 0;
            certificate.SecurityFileContent = developerCertificateData.SecurityFileContent;
            certificate.Description = developerCertificateData.Description;
            certificate.DeveloperCertificate = developerCertificateData.DeveloperCertificate;
            certificate.ServerUri = developerCertificateData.ServerUri;
            certificate.AccountId = developerCertificateData.AccountId;
            certificate.DeveloperPrivateKey = developerCertificateData.DeveloperPrivateKey;
            certificate.ServerCertificate = developerCertificateData.ServerCertificate;
            certificate.Id = developerCertificateData.Id;
            certificate.Name = developerCertificateData.Name;
            return certificate;
        }
    }
}
