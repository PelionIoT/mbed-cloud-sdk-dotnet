using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using device_query_service.Model;
using mbedCloudSDK.Common;
using mbedCloudSDK.Exceptions;
using RestSharp;
using mbedCloudSDK.Devices.Model;
using mbedCloudSDK.Devices.Model.Device;
using mbedCloudSDK.Devices.Model.Resource;

namespace mbedCloudSDK.Devices.Api
{
    /// <summary>
    /// Exposing functionality from the following underlying services:
    /// - Connector / mDS
    /// - Device query service
    /// - Device catalog
    /// </summary>
    public class DevicesApi : BaseApi
    {

        #region Variables

        private Task longPollingTask;
        private CancellationTokenSource cancellationToken;

        /// <summary>
        /// Resources that are currently subscribed.
        /// </summary>
        public static Dictionary<String, Resource> resourceSubscribtions = new Dictionary<string, Resource>();

        /// <summary>
        /// Responses to async requests.
        /// </summary>
        public static Dictionary<String, AsyncProducerConsumerCollection<String>> asyncResponses = new Dictionary<string, AsyncProducerConsumerCollection<String>>();

        private readonly string CustomAttributes = "custom_attributes__";

        #endregion

        #region Contructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.Devices.Devices"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
        public DevicesApi(Config config) : base(config)
        {
            cancellationToken = new CancellationTokenSource();
            longPollingTask = new Task(new Action(LongPolling), cancellationToken.Token, TaskCreationOptions.LongRunning);
            resourceSubscribtions = new Dictionary<string, Resource>();
        }

        #endregion

        #region Devices

        /// <summary>
        /// Lists the devices.
        /// </summary>
        /// <returns>The devices.</returns>
        /// <param name="listParams">List of parameters.</param>
        public PaginatedResponse<Device> ListDevices(ListParams listParams = null)
        {
            if (listParams == null)
            {
                listParams = new ListParams();
            }
            try
            {
                return new PaginatedResponse<Device>(ListDevicesFunc, listParams);
            }
            catch (CloudApiException e)
            {
                throw e;
            }
        }

        private ResponsePage<Device> ListDevicesFunc(ListParams listParams = null)
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
                //List<Device> devices = new List<Device>();
                var resp = api.DeviceList(listParams.Limit, listParams.Order, listParams.After, listParams.Filter, listParams.Include);
                ResponsePage<Device> respDevices = new ResponsePage<Device>();
                respDevices.After = resp.After;
                respDevices.HasMore = resp.HasMore;
                respDevices.Limit = resp.Limit;
                respDevices.Order = resp.Order;
                respDevices.TotalCount = resp.TotalCount;
                foreach(var device in resp.Data)
                {
                    respDevices.Data.Add(Device.Map(this, device));
                }
                return respDevices;
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Deletes the device.
        /// </summary>
        /// <param name="deviceID">Device identifier.</param>
        public void DeleteDevice(string deviceID)
        {
            var api = new device_catalog.Api.DefaultApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;

            api.DeviceDestroy(deviceID);
        }

        #endregion

        #region Notifications

        /// <summary>
        /// Registers the webhook.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="headers">Headers.</param>
        public void RegisterWebhook(string url, object headers=null)
        {
            var api = new mds.Api.NotificationsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            mds.Model.Webhook webhook = new mds.Model.Webhook(url, headers);
            api.V2NotificationCallbackPut(webhook);
        }

        /// <summary>
        /// Deregisters all webhooks. If no webhook is registered, an exception (404) will be raised.
        /// </summary>
        public void DeregisterWebhooks()
        {
            var api = new mds.Api.DefaultApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            api.V2NotificationCallbackDelete();
        }

        #endregion

        #region Subscribtions

        /// <summary>
        /// Subscribe the specified endpointName and resourcePath.
        /// </summary>
        /// <param name="endpointName">Endpoint name.</param>
        /// <param name="resource">Resource to subscribe.</param>
        public AsyncConsumer<String> Subscribe(String endpointName, Resource resource)
        {
            string fixedPath = FixedPath(resource.Uri);
            var api = new mds.Api.SubscriptionsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            api.V2SubscriptionsEndpointNameResourcePathPut(endpointName, fixedPath);
            string subscribePath = endpointName + resource.Uri;
            if (!DevicesApi.resourceSubscribtions.ContainsKey(subscribePath))
            {
                DevicesApi.resourceSubscribtions.Add(subscribePath, resource);
            }
            return new AsyncConsumer<String>(resource.Queue);
        }

        /// <summary>
        /// Presubscribe to the resource.
        /// </summary>
        /// <param name="endpointName">Endpoint name.</param>
        /// <param name="resourcePath">Resource path.</param>
        /// <param name="endpointType">Endpoint type.</param>
        public void Presubscribe(String endpointName, String resourcePath, String endpointType="")
        {
            var api = new mds.Api.SubscriptionsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            mds.Model.Presubscription presubscription = new mds.Model.Presubscription(endpointName, endpointType);
            mds.Model.PresubscriptionArray presubscriptionArray = new mds.Model.PresubscriptionArray();
            presubscriptionArray.Add(presubscription);
            api.V2SubscriptionsPut(presubscriptionArray);
        }

        /// <summary>
        /// Presubscribe to the resource asynchronously.
        /// </summary>
        /// <param name="endpointName">Endpoint name.</param>
        /// <param name="resourcePath">Resource path.</param>
        /// <param name="endpointType">Endpoint type.</param>
        public async Task PresubscribeAsync(String endpointName, String resourcePath, String endpointType = "")
        {
            var api = new mds.Api.SubscriptionsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            mds.Model.Presubscription presubscription = new mds.Model.Presubscription(endpointName, endpointType);
            mds.Model.PresubscriptionArray presubscriptionArray = new mds.Model.PresubscriptionArray();
            presubscriptionArray.Add(presubscription);
            await api.V2SubscriptionsPutAsync(presubscriptionArray);
        }

        /// <summary>
        /// Unsubscribe resource.
        /// </summary>
        /// <param name="deviceName">Name of the device.</param>
        /// <param name="resource">Resource to unsubscribe.</param>
        public void Unsubscribe(String deviceName, Resource resource)
        {
            string fixedPath = FixedPath(resource.Uri);
            var api = new mds.Api.SubscriptionsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            string subscribePath = deviceName + resource.Uri;
            api.V2SubscriptionsEndpointNameResourcePathDelete(deviceName, fixedPath);
            if (resourceSubscribtions.ContainsKey(subscribePath))
            {
                resourceSubscribtions.Remove(subscribePath);
            }
        }

        /// <summary>
        /// Unsubscribe resource asynchronously.
        /// </summary>
        /// <param name="deviceName">Name of the device.</param>
        /// <param name="resource">Resource to unsubscribe.</param>
        public async Task UnsubscribeAsync(String deviceName, Resource resource)
        {
            string fixedPath = FixedPath(resource.Uri);
            var api = new mds.Api.SubscriptionsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            string subscribePath = deviceName + resource.Uri;
            await api.V2SubscriptionsEndpointNameResourcePathDeleteAsync(deviceName, fixedPath);
            if (resourceSubscribtions.ContainsKey(subscribePath))
            {
                resourceSubscribtions.Remove(subscribePath);
            }
        }


        #endregion

        #region Endpoints

        /// <summary>
        /// Lists all endpoints.
        /// </summary>
        /// <returns>The endpoints.</returns>
        /// <param name="listParams">List of parameters.</param>
        public List<Device> ListConnectedDevices(ListParams listParams = null)
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
                var endpoints = api.V2EndpointsGet();
                List<Device> devices = new List<Device>();
                foreach(var endpoint in endpoints)
                {
                    devices.Add(Device.Map(this, endpoint));
                }
                return devices;
            }
            catch (mds.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        #endregion

        #region Resources

        /// <summary>
        /// Gets the value of the resource..
        /// </summary>
        /// <param name="endpointName">Endpoint name.</param>
        /// <param name="resourcePath">Resource path.</param>
        public AsyncConsumer<string> GetResourceValue(string endpointName, string resourcePath)
        {
            var api = new mds.Api.ResourcesApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            var asyncID =  api.V2EndpointsEndpointNameResourcePathGet(endpointName, resourcePath);
            AsyncProducerConsumerCollection<string> collection = new AsyncProducerConsumerCollection<string>();
            asyncResponses.Add(asyncID.AsyncResponseId, collection);
            return new AsyncConsumer<string>(collection);
        }

        /// <summary>
        /// Set value of the resource.
        /// </summary>
        /// <param name="deviceName">Name of the device.</param>
        /// <param name="resourcePath">Path to the resource.</param>
        /// <param name="resourceValue">Value to set.</param>
        /// <param name="noResponse">Don't get a response.</param>
        /// <returns></returns>
        public AsyncConsumer<string> SetResourceValue(string deviceName, string resourcePath, string resourceValue, bool? noResponse = null)
        {
            var api = new mds.Api.ResourcesApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            var asyncID = api.V2EndpointsEndpointNameResourcePathPut(deviceName, resourcePath, resourceValue, noResponse);
            AsyncProducerConsumerCollection<string> collection = new AsyncProducerConsumerCollection<string>();
            asyncResponses.Add(asyncID.AsyncResponseId, collection);
            return new AsyncConsumer<string>(collection);
        }

        /// <summary>
        /// Lists the resources.
        /// </summary>
        /// <returns>The resources.</returns>
        /// <param name="endpointName">Endpoint name.</param>
        public List<Resource> ListResources(string endpointName)
        {
            var api = new mds.Api.EndpointsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            try
            {
                var resourcesList = api.V2EndpointsEndpointNameGet(endpointName);
                List<Resource> resources = new List<Resource>();
                foreach (var resource in resourcesList)
                {
                    resources.Add(Resource.Map(this, endpointName, resource));
                }
                return resources;
            }
            catch (mds.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Delete resource.
        /// </summary>
        /// <param name="deviceName">Name of the Device</param>
        /// <param name="resourcePath">Path to the resource.</param>
        /// <param name="noResponse"></param>
        public void DeleteResource(string deviceName, string resourcePath, bool? noResponse = null)
        {
            var api = new mds.Api.ResourcesApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            api.V2EndpointsEndpointNameResourcePathDelete(deviceName, resourcePath, noResponse);
        }

        /// <summary>
        /// Get the resources.
        /// </summary>
        /// <returns>The resources.</returns>
        /// <param name="endpointName">Endpoint resources are connected to.</param>
        public List<mds.Model.Resource> GetResources(string endpointName)
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

        #endregion
        
        #region Queries
        
        /// <summary>
        /// Creates the filter.
        /// </summary>
        /// <returns>The filter.</returns>
        /// <param name="name">Name.</param>
        /// <param name="query">Query.</param>
        /// <param name="customAttributes">Custom attributes.</param>
        /// <param name="description">Description.</param>
        public DeviceQueryDetail CreateFilter(string name, Dictionary<String, String> query, Dictionary<String, String> customAttributes = null, string description=null)
        {
            var api = new device_query_service.Api.DefaultApi();
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;

            if (query == null)
            {
                query = new Dictionary<string, string>();
            }

            if (customAttributes != null)
            {
                foreach (var entry in customAttributes)
                {
                    query.Add(CustomAttributes + entry.Key, entry.Value);
                }
            }

            if (query.Count == 0)
            {
                throw new ValueException("Valid Filter needs to contain at least one element in query or customAttributes collections");
            }

            string queryString = string.Join("&", query.Select(q => String.Format("{0}={1}", q.Key, q.Value)));
            queryString = device_query_service.Client.ApiClient.UrlEncode(queryString);

            return api.DeviceQueryCreate(name, queryString, description);
        }
        
        /// <summary>
        /// Deletes the filter.
        /// </summary>
        /// <returns>The filter.</returns>
        /// <param name="filterID">Filter identifier.</param>
        public DeviceQueryDetail DeleteFilter(string filterID)
        {
            var api = new device_query_service.Api.DefaultApi();
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            return api.DeviceQueryDestroy(filterID);
        }

        /// <summary>
        /// Lists the filters.
        /// </summary>
        /// <returns>The filters.</returns>
        /// <param name="listParams">List parameters.</param>
        public List<DeviceQueryDetail> ListFilters(ListParams listParams = null)
        {
            if (listParams != null)
            {
                throw new NotImplementedException();
            }

            var api = new device_query_service.Api.DefaultApi();
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            try
            {
                return api.DeviceQueryList().Data;
            }
            catch (mds.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        #endregion
        
        #region Polling

        private void LongPolling()
        {
            var api = new mds.Api.NotificationsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            while (!cancellationToken.IsCancellationRequested)
            {
                var resp = api.V2NotificationPullGet();
                if (resp.AsyncResponses != null)
                {
                    foreach (var asyncReponse in resp.AsyncResponses)
                    {
                        byte[] data = Convert.FromBase64String(asyncReponse.Payload);
                        string payload = Encoding.UTF8.GetString(data);
                        if (asyncResponses.ContainsKey(asyncReponse.Id))
                        {
                            asyncResponses[asyncReponse.Id].Add(payload);
                        }
                    }
                }
                if (resp.Notifications != null)
                {
                    foreach (var notification in resp.Notifications)
                    {
                        byte[] data = Convert.FromBase64String(notification.Payload);
                        string payload = Encoding.UTF8.GetString(data);
                        string resourceSubs = notification.Ep + notification.Path;
                        if (resourceSubscribtions.ContainsKey(resourceSubs))
                        {
                            resourceSubscribtions[resourceSubs].Queue.Add(payload);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Starts the long polling.
        /// </summary>
        public void StartLongPolling()
        {
            longPollingTask.Start();
        }

        /// <summary>
        /// Stops the long polling.
        /// </summary>
        public void StopLongPolling()
        {
            cancellationToken.Cancel();
        }

        #endregion

        #region Utils

        private string FixedPath(string path)
        {
            if (path.StartsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                path = path.Substring(1);
            }
            return path;
        }

        #endregion
    }
}
