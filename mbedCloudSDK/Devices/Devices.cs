using System;
using System.Collections.Generic;
using mbedCloudSDK.Common;
namespace mbedCloudSDK.Devices
{
	/// <summary>
	/// Exposing functionality from the following underlying services:
	/// - Connector / mDS
	/// - Device query service
	/// - Device catalog
	/// </summary>
	public class Devices : BaseAPI
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:mbedCloudSDK.Devices.Devices"/> class.
		/// </summary>
		/// <param name="config">Config.</param>
		public Devices(Config config) : base(config)
		{
		}

		/// <summary>
		/// Lists the devices.
		/// </summary>
		/// <returns>The devices.</returns>
		/// <param name="listParams">List of parameters.</param>
		public List<device_catalog.Model.DeviceSerializerData> ListDevices(ListParams listParams = null)
		{
			if (listParams == null)
			{
				listParams = new ListParams();
			}
			var api = new device_catalog.Api.DefaultApi(config.Host);
			api.Configuration.ApiKey["Authorization"] = config.ApiKey;
			api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
			try
			{
				return api.DeviceList(listParams.Limit,listParams.Order, listParams.After, listParams.Filter, listParams.Include).Data;
			}
			catch (device_catalog.Client.ApiException e)
			{
				throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
			}
		}

		/// <summary>
		/// Lists the endpoints.
		/// </summary>
		/// <returns>The endpoints.</returns>
		/// <param name="listParams">List of parameters.</param>
		public List<mds.Model.Endpoint> ListEndpoints(ListParams listParams = null)
		{
			if (listParams != null)
			{
				throw new NotImplementedException();
			}
			var api = new mds.Api.EndpointsApi(config.Host);
			api.Configuration.ApiKey["Authorization"] = config.ApiKey;
			api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
			try
			{
				return api.V2EndpointsGet();
			}
			catch (mds.Client.ApiException e)
			{
				throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
			}
		}

	}
}
