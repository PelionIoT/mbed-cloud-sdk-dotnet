using System;
using mbedCloudSDK.Common;
using provisioning_certificate.Model;

namespace mbedCloudSDK.Manufacturing
{
	/// <summary>
	/// Exposing functionality from the following services:
	/// - Production line certificates
	/// - Provisioning certificate
	/// - Factory tool download
	/// </summary>
	public class Manufacturing: BaseAPI
	{
		private string auth;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:mbedCloudSDK.Manufacturing.Manufacturing"/> class.
		/// </summary>
		/// <param name="config">Config.</param>
		public Manufacturing(Config config) : base(config)
		{
			this.auth = string.Format("{0} {1}", config.AuthorizationPrefix, config.ApiKey);
		}

		/// <summary>
		/// Gets the provisioning certificate.
		/// </summary>
		/// <returns>The provisioning certificate.</returns>
		public ProvisioningCertificate GetProvisioningCertificate()
		{
			var api = new provisioning_certificate.Api.DefaultApi(config.Host);
			api.Configuration.ApiKey["Authorization"] = config.ApiKey;
			api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
			try
			{
				return api.V3ProvisioningCertificateGet(this.auth);
			}
			catch (device_catalog.Client.ApiException e)
			{
				throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
			}
		}	
	}
}
