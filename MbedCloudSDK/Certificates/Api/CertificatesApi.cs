// <copyright file="CertificatesApi.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Certificates.Api
{
    using System;
    using System.Linq;
    using connector_ca.Api;
    using connector_ca.Client;
    using iam.Api;
    using iam.Model;
    using MbedCloudSDK.Certificates.Model;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Query;
    using MbedCloudSDK.Exceptions;

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
    public class CertificatesApi : BaseApi
    {
        private DeveloperCertificateApi developerCertificateApi;
        private ServerCredentialsApi serverCredentialsApi;
        private AccountAdminApi iamAccountApi;
        private DeveloperApi developerApi;
        private string auth;

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificatesApi"/> class.
        /// Initalize certificates api
        /// </summary>
        /// <param name="config"><see cref="Config"/></param>
        public CertificatesApi(Config config)
            : base(config)
        {
            auth = string.Format("{0} {1}", config.AuthorizationPrefix, config.ApiKey);

            connector_ca.Client.Configuration.Default.ApiClient = new ApiClient(config.Host);
            connector_ca.Client.Configuration.Default.ApiKey["Authorization"] = config.ApiKey;
            connector_ca.Client.Configuration.Default.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            connector_ca.Client.Configuration.Default.DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss.fffZ";

            iam.Client.Configuration.Default.ApiClient = new iam.Client.ApiClient(config.Host);
            iam.Client.Configuration.Default.ApiKey["Authorization"] = config.ApiKey;
            iam.Client.Configuration.Default.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            iam.Client.Configuration.Default.DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss.fffZ";

            developerCertificateApi = new DeveloperCertificateApi();
            serverCredentialsApi = new ServerCredentialsApi();
            iamAccountApi = new AccountAdminApi();
            developerApi = new DeveloperApi();

            BootstrapServerUri = serverCredentialsApi.V3ServerCredentialsBootstrapGet(auth).ServerUri;
            Lmw2mServerUri = serverCredentialsApi.V3ServerCredentialsLwm2mGet(auth).ServerUri;
        }

        /// <summary>
        /// Gets Bootstrap server uri
        /// </summary>
        public string BootstrapServerUri { get; private set; }

        /// <summary>
        /// Gets lmw2m server Uri
        /// </summary>
        public string Lmw2mServerUri { get; private set; }

        /// <summary>
        /// Get meta data for the last Mbed Cloud API call
        /// </summary>
        /// <returns><see cref="ApiMetadata"/></returns>
        public static ApiMetadata GetLastApiMetadata()
        {
            return ApiMetadata.Map(Configuration.Default.ApiClient.LastApiResponse.LastOrDefault());
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
        /// <returns>Paginated response with <see cref="Certificate"/></returns>
        /// <param name="options"><see cref="QueryOptions"/></param>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public PaginatedResponse<Certificate> ListCertificates(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                return new PaginatedResponse<Certificate>(ListCertificatesFunc, options);
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        private ResponsePage<Certificate> ListCertificatesFunc(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                var resp = developerApi.GetAllCertificates(limit: options.Limit, after: options.After, order: options.Order, include: options.Include);
                var respCertificates = new ResponsePage<Certificate>(resp.After, resp.HasMore, resp.Limit, resp.Order.ToString(), resp.TotalCount);
                foreach (var certificate in resp.Data)
                {
                    respCertificates.Data.Add(Certificate.MapTrustedCert(certificate));
                }

                return respCertificates;
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
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
        /// <param name="certificateId"><see cref="Certificate.Id"/></param>
        /// <returns><see cref="Certificate"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public Certificate GetCertificate(string certificateId)
        {
                Certificate trustedCert = null;
                try
                {
                    var response = developerApi.GetCertificate(certificateId);
                    trustedCert = Certificate.MapTrustedCert(response, null, this);
                }
                catch (iam.Client.ApiException ex)
                {
                    throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
                }

                if (trustedCert.Type == CertificateType.Developer)
                {
                    try
                    {
                    var devResponse = developerCertificateApi.V3DeveloperCertificatesMuuidGet(trustedCert.Id, auth);
                    trustedCert = Certificate.MapDeveloperCert(devResponse, new Certificate());
                    }
                    catch (connector_ca.Client.ApiException ex)
                    {
                        throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
                    }
                }

                return trustedCert;
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

            if (certificateData == null || signature == null)
            {
                throw new ArgumentException("certificateData and signatureData are required when creating non developer certificate.");
            }

            var serviceEnum = Certificate.GetServiceEnum(certificate.Type.Value);
            try
            {
                var resp = iamAccountApi.AddCertificate(new TrustedCertificateReq(Certificate: certificateData, Name: certificate.Name, Service: serviceEnum, Signature: signature, Description: certificate.Description));
                return Certificate.MapTrustedCert(resp);
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
            var body = new connector_ca.Model.DeveloperCertificateRequestData(certificate.Name, certificate.Description);
            try
            {
                var response = developerCertificateApi.V3DeveloperCertificatesPost(auth, body);
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
        /// <param name="certificateId"><see cref="Certificate.Id"/></param>
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
                developerApi.DeleteCertificate(certificateId);
            }
            catch (iam.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
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
        /// <param name="certificateId"><see cref="Certificate.Id"/></param>
        /// <param name="updatedCertificate"><see cref="Certificate"/></param>
        /// <returns><see cref="Certificate"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public Certificate UpdateCertificate(string certificateId, Certificate updatedCertificate)
        {
            var originalCertificate = GetCertificate(certificateId);

            var certificate = Utils.MapToUpdate(originalCertificate, updatedCertificate) as Certificate;

            var serviceEnum = Certificate.GetUpdateServiceEnum(certificate);
            var statusEnum = Certificate.GetUpdateStatusEnum(certificate);

            var req = new TrustedCertificateUpdateReq(Status: statusEnum, Certificate: string.IsNullOrEmpty(updatedCertificate.CertificateData) ? null : certificate.CertificateData, Name: certificate.Name, Service: serviceEnum, Signature: string.IsNullOrEmpty(updatedCertificate.CertificateData) ? null : certificate.Signature, Description: certificate.Description);

            try
            {
                var resp = developerApi.UpdateCertificate(certificateId, req);
                return GetCertificate(resp.Id);
            }
            catch (iam.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorCode);
            }
        }
    }
}