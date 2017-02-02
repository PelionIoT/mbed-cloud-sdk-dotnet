using System;
using mbedCloudSDK.Common;
using mbedCloudSDK.Exceptions;
using provisioning_certificate.Model;

namespace mbedCloudSDK.Manufacturing.Api
{
	/// <summary>
	/// Exposing functionality from the following services:
	/// - Production line certificates
	/// - Provisioning certificate
	/// - Factory tool download
	/// </summary>
	public class ManufacturingApi: BaseApi
	{
		private string auth;
        private provisioning_certificate.Api.DefaultApi provisioningCertificateApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.Manufacturing.Manufacturing"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
        public ManufacturingApi(Config config) : base(config)
		{
			this.auth = string.Format("{0} {1}", config.AuthorizationPrefix, config.ApiKey);
            provisioningCertificateApi = new provisioning_certificate.Api.DefaultApi(config.Host);
            provisioningCertificateApi.Configuration.ApiKey["Authorization"] = config.ApiKey;
            provisioningCertificateApi.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
        }

		/// <summary>
		/// Gets the provisioning certificate.
		/// </summary>
		/// <returns>The provisioning certificate.</returns>
		public ProvisioningCertificate GetProvisioningCertificate()
		{
			try
			{
				return provisioningCertificateApi.V3ProvisioningCertificateGet(this.auth);
			}
			catch (device_catalog.Client.ApiException e)
			{
				throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
			}
		}
	}
}
