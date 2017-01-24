using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using developer_certificate.Api;
using developer_certificate.Client;
using mbedCloudSDK.Common;
using mbedCloudSDK.Exceptions;
using mbedCloudSDK.Development.Model;

namespace mbedCloudSDK.Development.Api
{
    /// <summary>
    /// Expose Developer Certificate functionality.
    /// </summary>
	public class DevelopmentApi: BaseApi
    {
        private string auth;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:mbedCloudSDK.Development.Development"/> class.
		/// </summary>
		/// <param name="config">Config.</param>
        public DevelopmentApi(Config config): base(config)
        {
            if (config.Host != string.Empty)
            {
                Configuration.Default.ApiClient = new ApiClient(config.Host);
            }
            Configuration.Default.ApiKey["Authorization"] = config.ApiKey;
            Configuration.Default.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            this.auth = string.Format("{0} {1}", config.AuthorizationPrefix, config.ApiKey);
        }

        /// <summary>
        /// Gets the certificate.
        /// </summary>
        /// <returns>The certificate.</returns>
        /// <param name="certificateId">Certificate identifier.</param>
        public DeveloperCertificate GetCertificate(string certificateId)
        {
            var api = new DefaultApi();
			try
			{
				return DeveloperCertificate.Map(api.V3DeveloperCertificateGet(certificateId));
			}
			catch (ApiException e)
			{
				throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
			}
        }

        /// <summary>
        /// Gets the certificate asynchronously.
        /// </summary>
        /// <returns>The certificate.</returns>
        /// <param name="certificateId">Certificate identifier.</param>
        public async Task<DeveloperCertificate> GetCertificateAsync(string certificateId)
        {
            var api = new DefaultApi();
            try
            {
                return DeveloperCertificate.Map(await api.V3DeveloperCertificateGetAsync(certificateId));
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }



        /// <summary>
        /// Revokes the certificate.
        /// </summary>
        /// <returns><c>true</c>, if certificate was revoked, <c>false</c> otherwise.</returns>
        /// <param name="certificateId">Certificate identifier.</param>
        public void DeleteCertificate(string certificateId)
        {
            var api = new DefaultApi();
            try
            {
                api.V3DeveloperCertificateDelete(certificateId);
            }
            catch(ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Revokes the certificate asynchronously.
        /// </summary>
        /// <returns><c>true</c>, if certificate was revoked, <c>false</c> otherwise.</returns>
        /// <param name="certificateId">Certificate identifier.</param>
        public async Task DeleteCertificateAsync(string certificateId)
        {
            var api = new DefaultApi();
            try
            {
                await api.V3DeveloperCertificateDeleteAsync(certificateId);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Creates the certificate.
        /// </summary>
        /// <returns>The certificate.</returns>
        /// <param name="publicKey">Public key.</param>
        public DeveloperCertificate AddCertificate(string publicKey)
        {
            var api = new DefaultApi();
            var body = new developer_certificate.Model.Body();
            body.PubKey = publicKey;
			try
			{
				return DeveloperCertificate.Map(api.V3DeveloperCertificatePost(this.auth, body));
			}
			catch (ApiException e)
			{
				throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
			}
        }

        /// <summary>
        /// Creates the certificate asynchronously.
        /// </summary>
        /// <returns>The certificate.</returns>
        /// <param name="publicKey">Public key.</param>
        public async Task<DeveloperCertificate> AddCertificateAsync(string publicKey)
        {
            var api = new DefaultApi();
            var body = new developer_certificate.Model.Body();
            body.PubKey = publicKey;
            try
            {
                return DeveloperCertificate.Map(await api.V3DeveloperCertificatePostAsync(this.auth, body));
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
