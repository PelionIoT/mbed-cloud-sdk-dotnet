using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using mbedCloudSDK.Common;
using mds.Model;
using RestSharp;

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
		private Task longPollingTask;
		private CancellationToken cancelLongPollingToken;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:mbedCloudSDK.Devices.Devices"/> class.
		/// </summary>
		/// <param name="config">Config.</param>
		public Devices(Config config) : base(config)
		{
			cancelLongPollingToken = new CancellationToken();
			longPollingTask = Task.Factory.StartNew(() =>
			{
				var api = new mds.Api.NotificationsApi(config.Host);
				api.Configuration.ApiKey["Authorization"] = config.ApiKey;
				api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
				while (!cancelLongPollingToken.IsCancellationRequested)
				{
					var resp = api.V2NotificationPullGet();
					if (resp.Notifications != null)
					{
						foreach (var notification in resp.Notifications)
						{
							byte[] data = Convert.FromBase64String(notification.Payload);
							string payload = Encoding.UTF8.GetString(data);
							Console.WriteLine(payload);
						}
					}
				}
			}, cancelLongPollingToken, TaskCreationOptions.LongRunning, TaskScheduler.Default);
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

		/// <summary>
		/// Get the resources.
		/// </summary>
		/// <returns>The resources.</returns>
		/// <param name="endpointName">Endpoint resources are connected to.</param>
		public List<Resource> GetResources(string endpointName)
		{
			var api = new mds.Api.EndpointsApi(config.Host);
			api.Configuration.ApiKey["Authorization"] = config.ApiKey;
			api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
			try
			{
				return api.V2EndpointsEndpointNameGet(endpointName);
			}
			catch (mds.Client.ApiException e)
			{
				throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
			}
		}

		public void Subscribe(String endpointName, String resourcePath)
		{
			String fixedPath = resourcePath;
			if (resourcePath.StartsWith("/"))
			{
				fixedPath = resourcePath.Substring(1);
			}
			var api = new mds.Api.SubscriptionsApi(config.Host);
			api.Configuration.ApiKey["Authorization"] = config.ApiKey;
			api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
			api.V2SubscriptionsEndpointNameResourcePathGet(endpointName, fixedPath);
			//var endpoints = api.V2SubscriptionsEndpointNameGetWithHttpInfo(endpointName);
			//return;
			//fixedPath = api.Configuration.ApiClient.EscapeString(fixedPath);
			//RestClient.Execute(request);
			//api.V2SubscriptionsEndpointNameResourcePathGet(endpointName, fixedPath);
			//api.V2SubscriptionsEndpointNameResourcePathPut("", "");
		}

		public List<Resource> ListResources(string endpointName)
		{
			var api = new mds.Api.EndpointsApi(config.Host);
			api.Configuration.ApiKey["Authorization"] = config.ApiKey;
			api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
			return api.V2EndpointsEndpointNameGet(endpointName);
		}

		public void GetResource(string endpointName, string resourcePath)
		{
			var api = new mds.Api.ResourcesApi(config.Host);
			api.Configuration.ApiKey["Authorization"] = config.ApiKey;
			api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
			var asyncID =  api.V2EndpointsEndpointNameResourcePathGet(endpointName, resourcePath);
			return;
		}
	}
}
