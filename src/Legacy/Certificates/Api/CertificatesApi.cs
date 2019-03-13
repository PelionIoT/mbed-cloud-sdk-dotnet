// <copyright file="CertificatesApi.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Certificates.Api
{
    using System;
    using System.Globalization;
    using System.Linq;
    using connector_ca.Api;
    using connector_ca.Client;
    using iam.Api;
    using iam.Model;
    using Mbed.Cloud.Common;
    using MbedCloudSDK.Certificates.Model;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using MbedCloudSDK.Exceptions;
    using static MbedCloudSDK.Common.Utils;

    /// <summary>
    /// Certificates Api
    /// </summary>
    /// <example>
    /// This API is intialized with a <see cref="Config"/> object.
    /// <code>
    /// using MbedCloudSDK.Common;
    /// var config = new config(apiKey);
    /// var connectApi = new CertificatesApi(config);
    /// </code>
    /// </example>
    public class CertificatesApi : Api
    {
        private string auth;
        private DeveloperApi developerApi;
        private DeveloperCertificateApi developerCertificateApi;
        private AccountAdminApi iamAccountApi;
        private ServerCredentialsApi serverCredentialsApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificatesApi"/> class.
        /// Initalize certificates api
        /// </summary>
        /// <param name="config"><see cref="Config"/></param>
        public CertificatesApi(Config config)
            : base(config)
        {
            auth = $"{config.AuthorizationPrefix} {config.ApiKey}";

            SetUpApi(config);

            SetCerverCredentials(auth);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificatesApi"/> class.
        /// Initalize certificates api
        /// </summary>
        /// <param name="config"><see cref="Config"/></param>
        /// <param name="connectorConfig">connectorConfig</param>
        /// <param name="iamConfig">iamConfig</param>
        /// <param name="setCerts">setCerts</param>
        internal CertificatesApi(Config config, Configuration connectorConfig = null, iam.Client.Configuration iamConfig = null, bool setCerts = false)
            : base(config)
        {
            auth = $"{config.AuthorizationPrefix} {config.ApiKey}";

            SetUpApi(config, connectorConfig, iamConfig);

            if (setCerts)
            {
                SetCerverCredentials(auth);
            }
        }

        /// <summary>
        /// Gets Bootstrap server uri
        /// </summary>
        /// <value>
        /// The bootstrap server credentials.
        /// </value>
        public connector_ca.Model.CredentialsResponseData BootstrapServerCredentials { get; private set; }

        /// <summary>
        /// Gets lmw2m server Uri
        /// </summary>
        public connector_ca.Model.CredentialsResponseData Lmw2mServerCredentials { get; private set; }

        /// <summary>
        /// Gets or sets the developer API.
        /// </summary>
        /// <value>
        /// The developer API.
        /// </value>
        internal DeveloperApi DeveloperApi { get => developerApi; set => developerApi = value; }

        /// <summary>
        /// Gets or sets the developer certificate API.
        /// </summary>
        /// <value>
        /// The developer certificate API.
        /// </value>
        internal DeveloperCertificateApi DeveloperCertificateApi { get => developerCertificateApi; set => developerCertificateApi = value; }

        /// <summary>
        /// Gets or sets the iam account API.
        /// </summary>
        /// <value>
        /// The iam account API.
        /// </value>
        internal AccountAdminApi IamAccountApi { get => iamAccountApi; set => iamAccountApi = value; }

        /// <summary>
        /// Gets or sets the server credentials API.
        /// </summary>
        /// <value>
        /// The server credentials API.
        /// </value>
        internal ServerCredentialsApi ServerCredentialsApi { get => serverCredentialsApi; set => serverCredentialsApi = value; }

        /// <summary>
        /// Get meta data for the last Mbed Cloud API call
        /// </summary>
        /// <returns><see cref="ApiMetadata"/></returns>
        public static ApiMetadata GetLastApiMetadata()
        {
            return ApiMetadata.Map(Configuration.Default.ApiClient.LastApiResponse.LastOrDefault());
        }

        /// <summary>
        /// Create a new Certificate.
        /// </summary>
        /// <param name="certificate"><see cref="Certificate"/> to be created.</param>
        /// <param name="certificateData">X509.v3 trusted certificate in PEM or base64 encoded DER format. Null for developer certificate.</param>
        /// <param name="signature">Base64 encoded signature of the account ID signed by the certificate to be uploaded. Signature must be hashed with SHA256. Null for developer certificate.</param>
        /// <returns><see cref="Certificate"/></returns>
        /// <example>
        /// This sample shows how to call the <see cref="CertificatesApi.AddCertificate(Certificate, string, string)"/> method.
        /// <code>
        /// try {
        ///     var certificate = new Certificate(certificateType: CertificateType.Bootstrap)
        ///     {
        ///         Name = "certificate",
        ///         Description = "This is my certificate",
        ///     };
        ///     var newCertificate = api.AddCertificate(certificate, "-----BEGIN CERTIFICATE-----\nMIICFzCCAbygAwIBAgIQX ... EPSDKEF\n-----END CERTIFICATE-----", "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
        ///     return newCertificate;
        /// }
        /// catch (CloudApiException) {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public Certificate AddCertificate(Certificate certificate, string certificateData = null, string signature = null)
        {
            if (!certificate.Type.HasValue || certificate.Type == CertificateType.Developer)
            {
                throw new CloudApiException(400, "Value of Certificate Type must be bootstrap or lwm2m");
            }

            if (certificateData == null)
            {
                throw new CloudApiException(400, "certificateData is required when creating non developer certificate.");
            }

            if (certificate.EnrollmentMode.HasValue)
            {
                if (!certificate.EnrollmentMode.Value && string.IsNullOrEmpty(certificate.Signature))
                {
                    throw new CloudApiException(400, "If enrollment mode is false, signature is required");
                }
            }

            var serviceEnum = Certificate.GetServiceEnum(certificate.Type.Value);
            try
            {
                TrustedCertificateReq.StatusEnum? status = null;
                if (certificate.Status.HasValue)
                {
                    status = certificate.Status.ParseEnum<TrustedCertificateReq.StatusEnum>();
                }

                var resp = IamAccountApi.AddCertificate(new TrustedCertificateReq(
                    Certificate: certificateData,
                    Status: status,
                    Name: certificate.Name,
                    Service: serviceEnum,
                    Signature: signature,
                    Description: certificate.Description,
                    EnrollmentMode: certificate.EnrollmentMode));
                return Certificate.MapTrustedCert(resp, api: this);
            }
            catch (iam.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Add Developer Certificate
        /// </summary>
        /// <example>
        /// This sample shows how to call the <see cref="CertificatesApi.AddDeveloperCertificate(Certificate)"/> method.
        /// <code>
        /// try {
        ///     var certificate = new Certificate
        ///     {
        ///         Name = "certificate",
        ///         Description = "This is my certificate",
        ///     };
        ///     var newCertificate = api.AddDeveloperCertificate(certificate);
        ///     return newCertificate;
        /// }
        /// catch (CloudApiException) {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="certificate"><see cref="Certificate"/></param>
        /// <returns><see cref="Certificate"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public Certificate AddDeveloperCertificate(Certificate certificate)
        {
            var body = new connector_ca.Model.DeveloperCertificateRequestData(Name: certificate.Name, Description: certificate.Description);
            try
            {
                var response = DeveloperCertificateApi.CreateDeveloperCertificate(auth, body);
                return Certificate.MapDeveloperCert(response);
            }
            catch (connector_ca.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Delete certificate.
        /// </summary>
        /// <param name="certificateId">Id</param>
        /// <example>
        /// This sample shows how to call the <see cref="CertificatesApi.DeleteCertificate(string)"/> method.
        /// <code>
        /// try
        /// {
        ///     certificatesApi.DeleteCertificate("015c64f76a7b02420a01230a0000000");
        /// }
        /// catch (CloudApiException) {
        ///     Throw;
        /// }
        /// </code>
        /// </example>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public void DeleteCertificate(string certificateId)
        {
            try
            {
                DeveloperApi.DeleteCertificate(certificateId);
            }
            catch (iam.Client.ApiException ex)
            {
                HandleNotFound<string, iam.Client.ApiException>(ex);
            }
        }

        /// <summary>
        /// Get certificate by Id.
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="CertificatesApi.GetCertificate(string)"/> method.
        /// <code>
        /// try
        /// {
        ///     var certificate = certificatesApi.GetCertificate("015c64f76a7b02420a01230a0000000");
        ///     return certificate;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="certificateId">Id</param>
        /// <returns><see cref="Certificate"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public Certificate GetCertificate(string certificateId)
        {
            Certificate trustedCert = null;
            try
            {
                var response = DeveloperApi.GetCertificate(certificateId);
                trustedCert = Certificate.MapTrustedCert(response, null, this);
            }
            catch (iam.Client.ApiException ex)
            {
                HandleNotFound<Certificate, iam.Client.ApiException>(ex);
            }

            if (trustedCert?.Type == CertificateType.Developer)
            {
                try
                {
                    var devResponse = DeveloperCertificateApi.GetDeveloperCertificate(trustedCert.Id, auth);
                    trustedCert = Certificate.MapDeveloperCert(devResponse, trustedCert);
                }
                catch (connector_ca.Client.ApiException ex)
                {
                    HandleNotFound<Certificate, iam.Client.ApiException>(ex);
                }
            }

            return trustedCert;
        }

        /// <summary>
        /// Lists certificates.
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="CertificatesApi.ListCertificates(QueryOptions)"/> method.
        /// <code>
        /// try
        /// {
        ///     var options = new QueryOptions
        ///     {
        ///         Limit = 5,
        ///         Order = "ASC",
        ///     };
        ///     options.Filter.Add("type", "bootstrap");
        ///
        ///     var certificates = certificatesApi.ListCertificates(options);
        ///     foreach (item in certificates)
        ///     {
        ///         Console.WriteLine(item);
        ///     }
        ///     return certificates;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <example>
        /// Currently returns partially populated certificates. To obtain the full certificate object:
        /// <code>
        /// try
        /// {
        ///     var list = certificatesApi.ListCertificates().Data
        ///         .Select(cert => certificatesApi.GetCertificate(cert.Id))
        ///         .ToList();
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <returns>Paginated response with <see cref="Certificate"/></returns>
        /// <param name="options"><see cref="QueryOptions"/></param>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public PaginatedResponse<QueryOptions, Certificate> ListCertificates(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                return new PaginatedResponse<QueryOptions, Certificate>(ListCertificatesFunc, options);
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Update Certificate.
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="CertificatesApi.UpdateCertificate(string, Certificate)"/> method.
        /// <code>
        /// try
        /// {
        ///     var updatedCertificate = new Certificate
        ///     {
        ///          Name = "updatedCertificate",
        ///          Description = "updated certificate description",
        ///     }
        ///     var certificate = certificatesApi.UpdateCertificate("015c64f76a7b02420a01230a00000000", updatedCertificate);
        ///     return certificate;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="certificateId">Id</param>
        /// <param name="updatedCertificate"><see cref="Certificate"/></param>
        /// <returns><see cref="Certificate"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public Certificate UpdateCertificate(string certificateId, Certificate updatedCertificate)
        {
            var originalCertificate = GetCertificate(certificateId);

            var certificate = originalCertificate.MapToUpdate(updatedCertificate) as Certificate;

            var serviceEnum = Certificate.GetUpdateServiceEnum(certificate);
            var statusEnum = Certificate.GetUpdateStatusEnum(certificate);

            var req = new TrustedCertificateUpdateReq(
                    Status: statusEnum,
                    Certificate: certificate.CertificateData,
                    Name: certificate.Name,
                    Service: serviceEnum,
                    Signature: certificate.Signature,
                    Description: certificate.Description,
                    EnrollmentMode: certificate.EnrollmentMode);

            try
            {
                var resp = DeveloperApi.UpdateCertificate(certificateId, req);
                return GetCertificate(resp.Id);
            }
            catch (iam.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorCode);
            }
        }

        private async System.Threading.Tasks.Task<ResponsePage<Certificate>> ListCertificatesFunc(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                var type = options.Filter.GetFirstValueByKey("type") ?? options.Filter.GetFirstValueByKey("event_type");
                var serviceEq = (type == "developer") ? "bootstrap" : type;
                var executionMode = (type == "developer") ? new int?(1) : null;
                var expiredParsed = int.TryParse(options.Filter.GetFirstValueByKey("expires"), NumberStyles.None, null, out int expires);

                var resp = await DeveloperApi.GetAllCertificatesAsync(limit: options.Limit, after: options.After, order: options.Order, include: options.Include, serviceEq: serviceEq, expireEq: expiredParsed ? new int?(expires) : null, deviceExecutionModeEq: executionMode, ownerEq: options.Filter.GetFirstValueByKey("owner_id"));
                var responsePage = new ResponsePage<Certificate>(after: resp.After, hasMore: resp.HasMore, totalCount: resp.TotalCount);
                foreach (var certificate in resp.Data)
                {
                    responsePage.Add(Certificate.MapTrustedCert(certificate));
                }

                return responsePage;
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        private void SetCerverCredentials(string auth)
        {
            var serverCredentials = ServerCredentialsApi.GetAllServerCredentials(auth);
            BootstrapServerCredentials = serverCredentials.Bootstrap;
            Lmw2mServerCredentials = serverCredentials.Lwm2m;
        }

        private void SetUpApi(Config config, connector_ca.Client.Configuration connectorConfig = null, iam.Client.Configuration iamConfig = null)
        {
            if (connectorConfig == null)
            {
                connectorConfig = new connector_ca.Client.Configuration
                {
                    BasePath = config.Host,
                    DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss.fffZ",
                    UserAgent = UserAgent,
                };
                connectorConfig.AddApiKey("Authorization", config.ApiKey);
                connectorConfig.AddApiKeyPrefix("Authorization", config.AuthorizationPrefix);
                connectorConfig.CreateApiClient();
            }

            if (iamConfig == null)
            {
                iamConfig = new iam.Client.Configuration
                {
                    BasePath = config.Host,
                    DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss.fffZ",
                    UserAgent = UserAgent,
                };
                iamConfig.AddApiKey("Authorization", config.ApiKey);
                iamConfig.AddApiKeyPrefix("Authorization", config.AuthorizationPrefix);
                iamConfig.CreateApiClient();
            }

            DeveloperCertificateApi = new DeveloperCertificateApi(connectorConfig);
            ServerCredentialsApi = new ServerCredentialsApi(connectorConfig);
            IamAccountApi = new AccountAdminApi(iamConfig);
            DeveloperApi = new DeveloperApi(iamConfig);
        }
    }
}