using System;
using System.Collections.Generic;
using developer_certificate.Client;
using device_catalog.Api;
using mbedCloudSDK.Common;
namespace mbedCloudSDK.Devices
{
	/// <summary>
	/// Devices.
	/// </summary>
	public class Devices : BaseAPI
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:mbedCloudSDK.Devices.Devices"/> class.
		/// </summary>
		/// <param name="config">Config.</param>
		public Devices(Config config) : base(config)
		{
			if (config.Host != string.Empty)
			{
				Configuration.Default.ApiClient = new ApiClient(config.Host);
			}
			Configuration.Default.ApiKey["Authorization"] = config.ApiKey;
			Configuration.Default.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
		}

		/// <summary>
		/// Lists the devices.
		/// </summary>
		/// <returns>The devices.</returns>
		public List<device_catalog.Model.DeviceDetail> ListDevices()
		{
			var api = new device_catalog.Api.DefaultApi(config.Host);
			api.Configuration.ApiKey["Authorization"] = config.ApiKey;
			api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
			return api.DeviceList().Data;
		}
			
	}
}
