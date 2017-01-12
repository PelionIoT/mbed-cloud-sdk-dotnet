using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using device_query_service.Model;
using mbedCloudSDK.Common;
using mbedCloudSDK.Exceptions;
using mds.Model;
using RestSharp;
using mbedCloudSDK.Devices.Model;

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
        private Dictionary<String, Model.Endpoint> queues;
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
            queues = new Dictionary<string, Model.Endpoint>();
        }

        #endregion

        #region Devices

        /// <summary>
        /// Lists the devices.
        /// </summary>
        /// <returns>The devices.</returns>
        /// <param name="listParams">List of parameters.</param>
        public List<device_catalog.Model.DeviceDetail> ListDevices(ListParams listParams = null)
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
                return api.DeviceList(listParams.Limit, listParams.Order, listParams.After, listParams.Filter, listParams.Include).Data;
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
            Webhook webhook = new Webhook(url, headers);
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
            queues.Clear();
        }

        #endregion

        #region Subscribtions

        /// <summary>
        /// Subscribe the specified endpointName and resourcePath.
        /// </summary>
        /// <param name="endpointName">Endpoint name.</param>
        /// <param name="resourcePath">Resource path.</param>
        public AsyncConsumer<String> Subscribe(String endpointName, String resourcePath)
        {
            string fixedPath = FixedPath(resourcePath);
            var api = new mds.Api.SubscriptionsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            api.V2SubscriptionsEndpointNameResourcePathPut(endpointName, fixedPath);
            Model.Endpoint e;
            Model.Resource r;
            if (queues.ContainsKey(endpointName)) 
            {
                e = queues[endpointName];
                if (!e.Resources.ContainsKey(resourcePath))
                {
                    r = new Model.Resource(resourcePath);
                    e.Resources.Add(resourcePath, r);
                }
                else 
                {
                    r = e.Resources[resourcePath];
                }
            }
            else {

                e = new Model.Endpoint(endpointName);
                r = new Model.Resource(resourcePath);
                e.Resources.Add(resourcePath, r);
                queues.Add(endpointName, e);
            }
            return new AsyncConsumer<String>(r.Queue);
        }

        /// <summary>
        /// Pres the subscribe.
        /// </summary>
        /// <param name="endpointName">Endpoint name.</param>
        /// <param name="resourcePath">Resource path.</param>
        /// <param name="endpointType">Endpoint type.</param>
        public void PreSubscribe(String endpointName, String resourcePath, String endpointType="")
        {
            var api = new mds.Api.SubscriptionsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            //TODO ResourcePath is not generated correctly
            Presubscription presubscription = new Presubscription(endpointName, endpointType); 
        }

        public void Unsubscribe(String endpointName, String resourcePath)
        {
            string fixedPath = FixedPath(resourcePath);
            var api = new mds.Api.SubscriptionsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            api.V2SubscriptionsEndpointNameResourcePathDelete(endpointName, fixedPath);
        }

        #endregion

        #region Endpoints

        /// <summary>
        /// Lists all endpoints.
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

        #endregion

        #region Resources

        /// <summary>
        /// Gets the resource.
        /// </summary>
        /// <param name="endpointName">Endpoint name.</param>
        /// <param name="resourcePath">Resource path.</param>
        public void GetResource(string endpointName, string resourcePath)
        {
            var api = new mds.Api.ResourcesApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            var asyncID =  api.V2EndpointsEndpointNameResourcePathGet(endpointName, resourcePath);
            Console.WriteLine(asyncID.AsyncResponseId);
            return;
        }

        /// <summary>
        /// Lists the resources.
        /// </summary>
        /// <returns>The resources.</returns>
        /// <param name="endpointName">Endpoint name.</param>
        public List<mds.Model.Resource> ListResources(string endpointName)
        {
            var api = new mds.Api.EndpointsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            return api.V2EndpointsEndpointNameGet(endpointName);
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
                if (resp.Notifications != null)
                {
                    foreach (var notification in resp.Notifications)
                    {
                        byte[] data = Convert.FromBase64String(notification.Payload);
                        string payload = Encoding.UTF8.GetString(data);
                        Model.Resource r = queues[notification.Ep].Resources[notification.Path];
                        r.Queue.Add(payload);
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
