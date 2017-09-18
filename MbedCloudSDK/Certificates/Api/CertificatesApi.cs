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
    /// Exposing functionality to:
    /// - Manage CA certificates
    /// - Manage developer certificates
    /// </summary>
    public class CertificatesApi : BaseApi
    {
        private DeveloperCertificateApi developerCertificateApi;
        private ServerCredentialsApi serverCredentialsApi;
        private AccountAdminApi iamAccountApi;
        private DeveloperApi developerApi;
        private string auth;
        private string bootstrapServerUri;
        private string lmw2mServerUri;

        public CertificatesApi(Config config)
            : base(config)
        {
            auth = string.Format("{0} {1}", config.AuthorizationPrefix, config.ApiKey);

            Configuration.Default.ApiClient = new ApiClient(config.Host);
            Configuration.Default.ApiKey["Authorization"] = config.ApiKey;
            Configuration.Default.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;

            developerCertificateApi = new DeveloperCertificateApi();
            serverCredentialsApi = new ServerCredentialsApi();
            iamAccountApi = new AccountAdminApi();
            developerApi = new DeveloperApi();

            bootstrapServerUri = serverCredentialsApi.V3ServerCredentialsBootstrapGet(auth).ServerUri;
            lmw2mServerUri = serverCredentialsApi.V3ServerCredentialsLwm2mGet(auth).ServerUri;
        }

        /// <summary>
        /// Get meta data for the last Mbed Cloud API call
        /// </summary>
        public ApiMetadata GetLastApiMetadata()
        {
            return ApiMetadata.Map(Configuration.Default.ApiClient.LastApiResponse.LastOrDefault());
        }

        /// <summary>
        /// Lists certificates.
        /// </summary>
        /// <returns>Paginated response with certificates.</returns>
        /// <param name="options">Options used to query certificates.</param>
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
            catch (CloudApiException e)
            {
                throw e;
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
                ResponsePage<Certificate> respCertificates = new ResponsePage<Certificate>(resp.After, resp.HasMore, resp.Limit, resp.Order.ToString(), resp.TotalCount);
                foreach (var certificate in resp.Data)
                {
                    respCertificates.Data.Add(Certificate.Map(certificate));
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
        /// <param name="certificateId">Id of the certificate.</param>
        /// <returns>Object representing certificate.</returns>
        public Certificate GetCertificate(string certificateId)
        {
                Certificate trustedCert = null;
                try
                {
                    var response = developerApi.GetCertificate(certificateId);
                    trustedCert = Certificate.Map(response);
                }
                catch (iam.Client.ApiException ex)
                {
                    throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
                }

                if (trustedCert.Type == CertificateType.Developer)
                {
                    try
                    {
                        var devResponse = developerCertificateApi.V3DeveloperCertificatesIdGet(trustedCert.Id, auth);
                        trustedCert = Certificate.Map(devResponse, trustedCert);
                    }
                    catch (ApiException ex)
                    {
                        throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
                    }
                }
                else
                {
                    switch (trustedCert.Type)
                    {
                        case CertificateType.Bootstrap:
                            trustedCert.ServerUri = bootstrapServerUri;
                            break;
                        case CertificateType.Lwm2m:
                            trustedCert.ServerUri = lmw2mServerUri;
                            break;
                    }
                }

                return trustedCert;
        }

        /// <summary>
        /// Create a new Certificate.
        /// </summary>
        /// <param name="certificate">Certificate to be created.</param>
        /// <param name="certificateData">X509.v3 trusted certificate in PEM or base64 encoded DER format. Null for developer certificate.</param>
        /// <param name="signature">Base64 encoded signature of the account ID signed by the certificate to be uploaded. Signature must be hashed with SHA256. Null for developer certificate.</param>
        /// <returns>Certificate</returns>
        /// <exception cref="CloudApiException">Error while adding certificate.</exception>
        /// <exception cref="ArgumentException">Invalid arguments..</exception>
        /// <example>
        /// This sample shows how to call the <see cref="AddCertificate"/> method.
        /// <code>
        /// class TestClass
        /// {
        ///     static int Main()
        ///     {
        ///         Config config = new Config(apiKey);
        ///         config.Host = "https://lab-api.mbedcloudintegration.net";
        ///         CertificatesApi api = new CertificatesApi(config);
        ///         Certificate certificate = new Certificate();
        ///         certificate.Type = CertificateType.Developer;
        ///         certificate.Name = "developer certificate";
        ///         certificate.Description = "This is my dev certificate";
        ///         try {
        ///             Certificate createdCert = api.AddCertificate(certificate);
        ///             Console.WriteLine(createdCert);
        ///         }
        ///         catch (CloudApiException ex) {
        ///             Console.WriteLine(ex.Message);
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        public Certificate AddCertificate(Certificate certificate, string certificateData = null, string signature = null)
        {
            if (!certificate.Type.HasValue)
            {
                throw new CloudApiException(400, "Value of Certificate Type must be bootstrap or lwm2m");
            }

            if (certificateData == null || signature == null)
            {
                throw new ArgumentException("certificateData and signatureData are required when creating non developer certificate.");
            }

            var serviceEnum = Certificate.GetServiceEnum(certificate);
            try
            {
                var resp = iamAccountApi.AddCertificate(new TrustedCertificateReq(Certificate: certificateData, Name: certificate.Name, Service: serviceEnum, Signature: signature, Description: certificate.Description));
                return Certificate.Map(resp);
            }
            catch (iam.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        public Certificate AddDeveloperCertificate(Certificate certificate)
        {
            connector_ca.Model.DeveloperCertificateRequestData body = new connector_ca.Model.DeveloperCertificateRequestData(certificate.Name, certificate.Description);
            try
            {
                var response = developerCertificateApi.V3DeveloperCertificatesPost(auth, body);
                return GetCertificate(response.Id);
            }
            catch (ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Delete certificate.
        /// </summary>
        /// <param name="certificateId">Id of the certificate.</param>
        /// <exception cref="CloudApiException">Error while deleting certificate.</exception>
        /// <example>
        /// This sample shows how to call the <see cref="DeleteCertificate"/> method.
        /// <code>
        /// class TestClass
        /// {
        ///     static int Main()
        ///     {
        ///         String id="00000000";
        ///         Config config = new Config(apiKey);
        ///         config.Host = "https://lab-api.mbedcloudintegration.net";
        ///         CertificatesApi api = new CertificatesApi(config);
        ///         try {
        ///             api.DeleteCertificate(id);
        ///         }
        ///         catch (CloudApiException ex) {
        ///             Console.WriteLine(ex);
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
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
        /// <param name="certificate">Certificate with updated data.</param>
        /// <returns>Updated Certificate.</returns>
        /// <exception cref="CloudApiException">Error while uploading certificate.</exception>
        public Certificate UpdateCertificate(string certificateId, Certificate updatedCertificate)
        {
            var originalCertificate = GetCertificate(certificateId);

            var certificate = Utils.MapToUpdate(originalCertificate, updatedCertificate) as Certificate;

            if (certificate.Type == CertificateType.Developer)
            {
                var body = new connector_ca.Model.DeveloperCertificateRequestData(Name: certificate.Name, Description: certificate.Description);
                try
                {
                    var response = developerCertificateApi.V3DeveloperCertificatesPost(auth, body);
                    return GetCertificate(response.Id);
                }
                catch (connector_ca.Client.ApiException ex)
                {
                    throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
                }
            }
            else
            {
                var serviceEnum = Certificate.GetUpdateServiceEnum(certificate);
                var statusEnum = Certificate.GetUpdateStatusEnum(certificate);

                var req = new TrustedCertificateUpdateReq(Status: statusEnum, Certificate: string.IsNullOrEmpty(updatedCertificate.CertificateData) ? null : certificate.CertificateData, Name: certificate.Name, Service: serviceEnum, Signature: string.IsNullOrEmpty(updatedCertificate.CertificateData) ? null : certificate.Signature, Description: certificate.Description);

                try
                {
                    var resp = developerApi.UpdateCertificate(certificateId, req);
                    return GetCertificate(resp.Id);
                }
                catch (CloudApiException ex)
                {
                    throw ex;
                }
            }
        }
    }
}
