using connector_ca.Api;
using iam.Api;
using iam.Model;
using mbedCloudSDK.Certificates.Model;
using mbedCloudSDK.Common;
using mbedCloudSDK.Common.Query;
using mbedCloudSDK.Exceptions;
using System;

namespace mbedCloudSDK.Certificates.Api
{
    /// <summary>
    /// Exposing functionality to:
    /// - Manage CA certificates
    /// - Manage developer certificates
    /// </summary>
    class CertificatesApi : BaseApi
    {
        private DeveloperCertificateApi developerCertificateApi;
        private ServerCredentialsApi serverCredentialsApi;
        private AccountAdminApi iamAccountApi;
        private string auth;
        private string bootstrapServerUri;
        private string lmw2mServerUri;

        public CertificatesApi(Config config) : base(config)
        {
            this.auth = string.Format("{0} {1}", config.AuthorizationPrefix, config.ApiKey);

            developerCertificateApi = new DeveloperCertificateApi(config.Host);
            developerCertificateApi.Configuration.ApiKey["Authorization"] = config.ApiKey;
            developerCertificateApi.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;

            serverCredentialsApi = new ServerCredentialsApi(config.Host);
            serverCredentialsApi.Configuration.ApiKey["Authorization"] = config.ApiKey;
            serverCredentialsApi.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;

            iamAccountApi = new AccountAdminApi(config.Host);
            iamAccountApi.Configuration.ApiKey["Authorization"] = config.ApiKey;
            iamAccountApi.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;

            bootstrapServerUri = serverCredentialsApi.V3ServerCredentialsBootstrapGet(this.auth).ServerUri;
            lmw2mServerUri = serverCredentialsApi.V3ServerCredentialsLwm2mGet(this.auth).ServerUri;
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
                var resp = iamAccountApi.GetAllCertificates(options.Limit, options.Order, options.After, options.QueryString);
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
        /// <param name="id">Id of the certificate.</param>
        /// <returns>Object representing certificate.</returns>
        public Certificate GetCertificate(string id)
        {
                Certificate trustedCert = null;
                try
                {
                    var response = iamAccountApi.GetCertificate(id);
                    trustedCert = Certificate.Map(response);
                }
                catch (iam.Client.ApiException ex)
                {
                    throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent );
                }
                if (trustedCert.Type == CertificateType.Developer)
                {
                    try
                    {
                        var devResponse = developerCertificateApi.V3DeveloperCertificatesIdGet(trustedCert.Id, this.auth);
                        trustedCert = Certificate.Map(devResponse, trustedCert);
                    }
                    catch (connector_ca.Client.ApiException ex)
                    {
                        throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
                    }
                }
                else
                {
                    switch (trustedCert.Type)
                    {
                        case CertificateType.Bootstrap:
                            trustedCert.ServerUri = this.bootstrapServerUri;
                            break;
                        case CertificateType.Lwm2m:
                            trustedCert.ServerUri = this.lmw2mServerUri;
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
        /// <param name="signatureData">Base64 encoded signature of the account ID signed by the certificate to be uploaded. Signature must be hashed with SHA256. Null for developer certificate.</param>
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
        public Certificate AddCertificate(Certificate certificate, string certificateData = null, string signatureData = null)
        {
            if (certificate.Type == CertificateType.Developer)
            {
                if (certificateData != null || signatureData != null)
                {
                    throw new ArgumentException("certificateData and signatureData are not required when creating developer certificate.");
                }
                connector_ca.Model.DeveloperCertificateRequestData body = new connector_ca.Model.DeveloperCertificateRequestData(certificate.Name, certificate.Description);
                body.Name = certificate.Name;
                body.Description = certificate.Description;
                try
                {
                    var response = developerCertificateApi.V3DeveloperCertificatesPost(this.auth, body);
                    return GetCertificate(response.Id);
                }
                catch (connector_ca.Client.ApiException ex)
                {
                    throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
                }
            }
            else
            {
                if (certificateData == null || signatureData == null)
                {
                    throw new ArgumentException("certificateData and signatureData are required when creating non developer certificate.");
                }
                TrustedCertificateReq trustedCertificate = new TrustedCertificateReq();
                trustedCertificate.Certificate = certificateData;
                trustedCertificate.Description = certificate.Description;
                trustedCertificate.Name = certificate.Name;
                switch (certificate.Type)
                {
                    case CertificateType.Bootstrap:
                        trustedCertificate.Service = TrustedCertificateReq.ServiceEnum.Bootstrap;
                        break;
                    case CertificateType.Lwm2m:
                        trustedCertificate.Service = TrustedCertificateReq.ServiceEnum.Lwm2m;
                        break;
                }
                trustedCertificate.Signature = signatureData;
                try
                {
                    var resp = iamAccountApi.AddCertificate(trustedCertificate);
                    return GetCertificate(resp.Id);
                }
                catch (iam.Client.ApiException ex)
                {
                    throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
                }
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
        public void DeleteCertificate(String certificateId)
        {
            try
            {
                iamAccountApi.DeleteCertificate(certificateId);
            }
            catch(iam.Client.ApiException ex )
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
        public Certificate UpdateCertificate(Certificate certificate)
        {
            TrustedCertificateReq req = new TrustedCertificateReq();
            req.Name = certificate.Name;
            req.Description = certificate.Description;
            try
            {
                var resp = iamAccountApi.UpdateCertificate(certificate.Id, req);
                return GetCertificate(resp.Id);
            }
            catch (CloudApiException ex)
            {
                throw ex;
            }
        }
    }
}
