// <copyright file="Certificate.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Certificates.Model
{
    using System;
    using System.Text;
    using iam.Model;
    using Mbed.Cloud.Foundation.Common;
    using MbedCloudSDK.Certificates.Api;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using Newtonsoft.Json;

    /// <summary>
    /// Certificate
    /// </summary>
    public class Certificate : Entity
    {
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
        /// Gets or sets the enrollment mode. If true, signature parameter is not required. Default value is false.
        /// </summary>
        public bool? EnrollmentMode { get; set; } = false;

        /// <summary>
        /// Gets the time certificate was updated
        /// </summary>
        [JsonProperty]
        public DateTime? UpdatedAt { get; private set; }

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
        /// <param name="signature">Certificate signature</param>
        /// <returns>Certificate</returns>
        public static Certificate MapTrustedCert(iam.Model.TrustedCertificateResp trustedCertificate, Certificate certificate = null, CertificatesApi api = null, string signature = null)
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
                            certificate.ServerUri = api.BootstrapServerCredentials.Url;
                            certificate.ServerCertificate = api.BootstrapServerCredentials.Url;
                            break;
                        case CertificateType.Lwm2m:
                            certificate.ServerUri = api.Lmw2mServerCredentials.Url;
                            certificate.ServerCertificate = api.Lmw2mServerCredentials.Url;
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
            certificate.Status = trustedCertificate.Status.ParseEnum<CertificateStatus>();
            certificate.OwnerId = trustedCertificate.OwnerId;
            certificate.EnrollmentMode = trustedCertificate.EnrollmentMode ?? false;
            certificate.UpdatedAt = trustedCertificate.UpdatedAt;
            certificate.Signature = signature;
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
            certificate.DeviceExecutionMode = 1;
            certificate.SecurityFileContent = developerCertificateData.SecurityFileContent;
            certificate.Description = developerCertificateData.Description;
            certificate.DeveloperCertificate = developerCertificateData.DeveloperCertificate;
            certificate.AccountId = developerCertificateData.AccountId;
            certificate.DeveloperPrivateKey = developerCertificateData.DeveloperPrivateKey;
            certificate.CreatedAt = developerCertificateData.CreatedAt;
            certificate.Id = developerCertificateData.Id;
            certificate.Name = developerCertificateData.Name;
            certificate.HeaderFile = certificate.SecurityFileContent;
            certificate.Status = CertificateStatus.Active;
            certificate.Issuer = string.Empty;
            certificate.Subject = string.Empty;
            certificate.Validity = DateTime.Now;
            certificate.CertificateData = string.Empty;
            certificate.OwnerId = string.Empty;
            return certificate;
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();
    }
}
