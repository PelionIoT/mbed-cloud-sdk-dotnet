// <copyright file="Certificate.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Certificates.Model
{
    using System;
    using System.Text;
    using iam.Model;
    using MbedCloudSDK.Certificates.Api;
    using MbedCloudSDK.Common;
    using Newtonsoft.Json;

    /// <summary>
    /// Certificate
    /// </summary>
    public class Certificate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Certificate" /> class.
        /// </summary>
        public Certificate()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Certificate" /> class.
        /// </summary>
        /// <param name="description">description</param>
        /// <param name="subject">subject</param>
        /// <param name="accountId">accountId</param>
        /// <param name="signature">signature</param>
        /// <param name="issuer">issuer</param>
        /// <param name="certificateData">certificateData</param>
        /// <param name="id">id</param>
        /// <param name="name">name</param>
        /// <param name="securityFileContent">securityFileContent</param>
        /// <param name="developerCertificate">developerCertificate</param>
        /// <param name="serverUri">serverUri</param>
        /// <param name="developerPrivateKey">developerPrivateKey</param>
        /// <param name="serverCertificate">serverCertificate</param>
        /// <param name="ownerId">ownerId</param>
        /// <param name="headerFile">headerFile</param>
        /// <param name="certificateType">certificateType</param>
        public Certificate(string description = null, string subject = null, string accountId = null, string signature = null, string issuer = null, string certificateData = null, string id = null, string name = null, string securityFileContent = null, string developerCertificate = null, string serverUri = null, string developerPrivateKey = null, string serverCertificate = null, string ownerId = null, string headerFile = null, CertificateType certificateType = default(CertificateType))
        {
            Description = description;
            Subject = subject;
            AccountId = accountId;
            Signature = signature;
            Issuer = issuer;
            CertificateData = certificateData;
            Id = id;
            Name = name;
            SecurityFileContent = securityFileContent;
            DeveloperCertificate = developerCertificate;
            ServerUri = serverUri;
            DeveloperPrivateKey = developerPrivateKey;
            ServerCertificate = serverCertificate;
            OwnerId = ownerId;
            HeaderFile = headerFile;
            Type = certificateType;
        }

        /// <summary>
        /// Gets type of Certificate
        /// </summary>
        [JsonConverter(typeof(CertificateTypeConverter))]
        [JsonProperty]
        public CertificateType? Type { get; private set; }

        /// <summary>
        /// Gets or sets human readable description of this certificate.
        /// </summary>
        /// <value>Human readable description of this certificate.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets device execution mode where 1 means a developer certificate.
        /// </summary>
        /// <value>Device execution mode where 1 means a developer certificate.</value>
        public int? DeviceExecutionMode { get; set; }

        /// <summary>
        /// Gets creation UTC time RFC3339.
        /// </summary>
        /// <value>Creation UTC time RFC3339.</value>
        [JsonProperty]
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// Gets subject of the certificate.
        /// </summary>
        /// <value>Subject of the certificate.</value>
        [JsonProperty]
        public string Subject { get; private set; }

        /// <summary>
        /// Gets the UUID of the account.
        /// </summary>
        /// <value>The UUID of the account.</value>
        [JsonProperty]
        public string AccountId { get; private set; }

        /// <summary>
        /// Gets or sets base 64 encoded SHA256 hash of AccountID.
        /// </summary>
        /// <value>Base 64 encoded SHA256 hash of AccountID.</value>
        public string Signature { get; set; }

        /// <summary>
        /// Gets or sets expiration time in UTC formatted as RFC3339.
        /// </summary>
        /// <value>Expiration time in UTC formatted as RFC3339.</value>
        public DateTime? Validity { get; set; }

        /// <summary>
        /// Gets issuer of the certificate.
        /// </summary>
        /// <value>Issuer of the certificate.</value>
        [JsonProperty]
        public string Issuer { get; private set; }

        /// <summary>
        /// Gets x509.v3 trusted certificate in PEM or base64 encoded DER format.
        /// </summary>
        /// <value>X509.v3 trusted certificate in PEM or base64 encoded DER format.</value>
        [JsonProperty]
        public string CertificateData { get; private set; }

        /// <summary>
        /// Gets certificate Id.
        /// </summary>
        /// <value>certificate Id.</value>
        [NameOverride(Name = "CertificateId")]
        [JsonProperty]
        public string Id { get; private set; }

        /// <summary>
        /// Gets or sets certificate name.
        /// </summary>
        /// <value>Certificate name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets content of the security.c file that will be flashed into the device to provide the security credentials
        /// </summary>
        /// <value>Content of the security.c file that will be flashed into the device to provide the security credentials</value>
        public string SecurityFileContent { get; set; }

        /// <summary>
        /// Gets PEM format X.509 developer certificate.
        /// </summary>
        /// <value>PEM format X.509 developer certificate.</value>
        [JsonProperty]
        public string DeveloperCertificate { get; private set; }

        /// <summary>
        /// Gets URI to which the client needs to connect to.
        /// </summary>
        /// <value>URI to which the client needs to connect to.</value>
        [JsonProperty]
        public string ServerUri { get; private set; }

        /// <summary>
        /// Gets PEM format developer private key associated to the certificate.
        /// </summary>
        /// <value>PEM format developer private key associated to the certificate.</value>
        [JsonProperty]
        public string DeveloperPrivateKey { get; private set; }

        /// <summary>
        /// Gets PEM format X.509 server certificate that will be used to validate the server certificate and that will be received during the TLS/DTLS handshake.
        /// </summary>
        /// <value>PEM format X.509 server certificate that will be used to validate the server certificate and that will be received during the TLS/DTLS handshake.</value>
        [JsonProperty]
        public string ServerCertificate { get; private set; }

        /// <summary>
        /// Gets the Status of the certificate.
        /// </summary>
        /// <value>The Status of the certificate.</value>
        [JsonConverter(typeof(CertificateStatusConverter))]
        [JsonProperty]
        public CertificateStatus? Status { get; private set; }

        /// <summary>
        /// Gets bootstrap server URI to which the client needs to connect to.
        /// </summary>
        /// <value>Bootstrap server URI to which the client needs to connect to.</value>
        [JsonProperty]
        public string OwnerId { get; private set; }

        /// <summary>
        /// Gets Content of the security.c file that will be flashed into the device to provide the security credentials.
        /// </summary>
        [JsonProperty]
        public string HeaderFile { get; private set; }

        /// <summary>
        /// Get Service Enum
        /// </summary>
        /// <param name="type">Certificate</param>
        /// <returns>Trusted Certificate Request Service Enum</returns>
        public static TrustedCertificateReq.ServiceEnum GetServiceEnum(CertificateType type)
        {
            TrustedCertificateReq.ServiceEnum serviceEnum;
            switch (type)
            {
                case CertificateType.Bootstrap:
                    serviceEnum = TrustedCertificateReq.ServiceEnum.Bootstrap;
                    break;
                case CertificateType.Lwm2m:
                    serviceEnum = TrustedCertificateReq.ServiceEnum.Lwm2m;
                    break;
                default:
                    serviceEnum = TrustedCertificateReq.ServiceEnum.Bootstrap;
                    break;
            }

            return serviceEnum;
        }

        private static TrustedCertificateReq.StatusEnum GetStatusEnum(Certificate certificate)
        {
            TrustedCertificateReq.StatusEnum statusEnum;
            switch (certificate.Status)
            {
                case CertificateStatus.Active:
                    statusEnum = TrustedCertificateReq.StatusEnum.ACTIVE;
                    break;
                case CertificateStatus.Inactive:
                    statusEnum = TrustedCertificateReq.StatusEnum.INACTIVE;
                    break;
                default:
                    statusEnum = TrustedCertificateReq.StatusEnum.ACTIVE;
                    break;
            }

            return statusEnum;
        }

        /// <summary>
        /// Get update service enum
        /// </summary>
        /// <param name="certificate">Certificate</param>
        /// <returns>Trusted certificate update request service enum</returns>
        public static TrustedCertificateUpdateReq.ServiceEnum GetUpdateServiceEnum(Certificate certificate)
        {
            TrustedCertificateUpdateReq.ServiceEnum serviceEnum;
            switch (certificate.Type)
            {
                case CertificateType.Bootstrap:
                    serviceEnum = TrustedCertificateUpdateReq.ServiceEnum.Bootstrap;
                    break;
                case CertificateType.Lwm2m:
                    serviceEnum = TrustedCertificateUpdateReq.ServiceEnum.Lwm2m;
                    break;
                default:
                    serviceEnum = TrustedCertificateUpdateReq.ServiceEnum.Bootstrap;
                    break;
            }

            return serviceEnum;
        }

        /// <summary>
        /// Get update status enum
        /// </summary>
        /// <param name="certificate">Certificate</param>
        /// <returns>Trusted certificate update request status enum</returns>
        public static TrustedCertificateUpdateReq.StatusEnum GetUpdateStatusEnum(Certificate certificate)
        {
            TrustedCertificateUpdateReq.StatusEnum statusEnum;
            switch (certificate.Status)
            {
                case CertificateStatus.Active:
                    statusEnum = TrustedCertificateUpdateReq.StatusEnum.ACTIVE;
                    break;
                case CertificateStatus.Inactive:
                    statusEnum = TrustedCertificateUpdateReq.StatusEnum.INACTIVE;
                    break;
                default:
                    statusEnum = TrustedCertificateUpdateReq.StatusEnum.ACTIVE;
                    break;
            }

            return statusEnum;
        }

        /// <summary>
        /// Map to Certificate object.
        /// </summary>
        /// <param name="trustedCertificate">TrustedCertificate response object.</param>
        /// <param name="certificate">Certificate to be updated.</param>
        /// <param name="api">Certificate Api</param>
        /// <returns>Certificate</returns>
        public static Certificate MapTrustedCert(iam.Model.TrustedCertificateResp trustedCertificate, Certificate certificate = null, CertificatesApi api = null)
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

                if (api != null)
                {
                    switch (certificate.Type)
                    {
                        case CertificateType.Bootstrap:
                            certificate.ServerUri = api.BootstrapServerCredentials.ServerUri;
                            certificate.ServerCertificate = api.BootstrapServerCredentials.ServerCertificate;
                            break;
                        case CertificateType.Lwm2m:
                            certificate.ServerUri = api.Lmw2mServerCredentials.ServerUri;
                            certificate.ServerCertificate = api.Lmw2mServerCredentials.ServerCertificate;
                            break;
                    }
                }
            }

            certificate.DeviceExecutionMode = trustedCertificate.DeviceExecutionMode;
            certificate.Subject = trustedCertificate.Subject;
            certificate.AccountId = trustedCertificate.AccountId;
            certificate.Validity = trustedCertificate.Validity;
            certificate.Issuer = trustedCertificate.Issuer;
            certificate.CertificateData = trustedCertificate.Certificate;
            certificate.Id = trustedCertificate.Id;
            certificate.Name = trustedCertificate.Name;
            certificate.Description = trustedCertificate.Description;
            certificate.CreatedAt = trustedCertificate.CreatedAt;
            certificate.Status = Utils.ParseEnum<CertificateStatus>(trustedCertificate.Status);
            certificate.OwnerId = trustedCertificate.OwnerId;
            return certificate;
        }

        /// <summary>
        /// Map to Certificate object.
        /// </summary>
        /// <param name="developerCertificateData">Developer certificate data</param>
        /// <param name="certificate">Certificate to be updated</param>
        /// <returns>Certificate</returns>
        public static Certificate MapDeveloperCert(connector_ca.Model.DeveloperCertificateResponseData developerCertificateData, Certificate certificate = null)
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
            certificate.CreatedAt = DateTime.Parse(developerCertificateData.CreatedAt);
            return certificate;
        }

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
            sb.Append("  Type: ").Append(Convert.ToString(Type)).Append("\n");
            sb.Append("  Status: ").Append(Convert.ToString(Status)).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  Validity: ").Append(Validity).Append("\n");
            sb.Append("  Issuer: ").Append(Issuer).Append("\n");
            sb.Append("  CertData: ").Append(CertificateData).Append("\n");
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
    }
}
