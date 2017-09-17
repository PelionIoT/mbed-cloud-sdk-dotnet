using MbedCloudSDK.Common;
using MbedCloudSDK.Connect.Model.ConnectedDevice;
using MbedCloudSDK.Connect.Model.Resource;
using MbedCloudSDK.Exceptions;
using System.Collections.Generic;
using System.Text;

namespace MbedCloudSDK.Connect.Api
{
    public partial class ConnectApi
    {
        /// <summary>
        /// Lists all endpoints.
        /// </summary>
        /// <returns>The list of endpoints.</returns>
        public List<ConnectedDevice> ListConnectedDevices()
        {
            try
            {
                var endpoints = endpointsApi.V2EndpointsGet();
                var devices = new List<ConnectedDevice>();
                foreach (var endpoint in endpoints)
                {
                    devices.Add(ConnectedDevice.Map(endpoint, this));
                }
                return devices;
            }
            catch (mds.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Gets the value of the resource..
        /// </summary>
        /// <param name="deviceId">Device Id</param>
        /// <param name="resourcePath">Resource path.</param>
        public string GetResourceValue(string deviceId, string resourcePath)
        {
            resourcePath = FixedPath(resourcePath);
            var asyncID = resourcesApi.V2EndpointsDeviceIdResourcePathGet(deviceId, resourcePath);
            var collection = new AsyncProducerConsumerCollection<string>();
            asyncResponses.Add(asyncID.AsyncResponseId, collection);

            if(asyncResponses.ContainsKey(asyncID.AsyncResponseId))
            {
                var res = asyncResponses[asyncID.AsyncResponseId].Take().Result;
                return res;
            }
            return null;
        }

        /// <summary>
        /// Gets the value of the resource asynchronously 
        /// </summary>
        /// <param name="deviceId">Device Id</param>
        /// <param name="resourcePath">Resource path.</param>
        public AsyncConsumer<string> GetResourceValueAsync(string deviceId, string resourcePath)
        {
            resourcePath = FixedPath(resourcePath);
            var asyncID = resourcesApi.V2EndpointsDeviceIdResourcePathGetAsync(deviceId, resourcePath).Result;
            var collection = new AsyncProducerConsumerCollection<string>();
            asyncResponses.Add(asyncID.AsyncResponseId, collection);
            return new AsyncConsumer<string>(asyncID.AsyncResponseId, collection);
        }

        /// <summary>
        /// Set value of the resource.
        /// </summary>
        /// <param name="deviceId">Id of the device.</param>
        /// <param name="resourcePath">Path to the resource.</param>
        /// <param name="resourceValue">Value to set.</param>
        /// <param name="noResponse">Don't get a response.</param>
        /// <returns></returns>
        public AsyncConsumer<string> SetResourceValue(string deviceId, string resourcePath, string resourceValue, bool? noResponse = null)
        {
            resourcePath = FixedPath(resourcePath);
            var asyncID = resourcesApi.V2EndpointsDeviceIdResourcePathPut(deviceId, resourcePath, resourceValue, noResponse);
            var collection = new AsyncProducerConsumerCollection<string>();
            asyncResponses.Add(asyncID.AsyncResponseId, collection);
            return new AsyncConsumer<string>(asyncID.AsyncResponseId, collection);
        }

        /// <summary>
        /// Set value of the resource asynchronously.
        /// </summary>
        /// <param name="deviceId">Id of the device.</param>
        /// <param name="resourcePath">Path to the resource.</param>
        /// <param name="resourceValue">Value to set.</param>
        /// <param name="noResponse">Don't get a response.</param>
        public AsyncConsumer<string> SetResourceValueAsync(string deviceId, string resourcePath, string resourceValue, bool? noResponse = null)
        {
            resourcePath = FixedPath(resourcePath);
            var asyncID = resourcesApi.V2EndpointsDeviceIdResourcePathPutAsync(deviceId, resourcePath, resourceValue, noResponse).Result;
            var collection = new AsyncProducerConsumerCollection<string>();
            asyncResponses.Add(asyncID.AsyncResponseId, collection);
            return new AsyncConsumer<string>(asyncID.AsyncResponseId, collection);
        }

        /// <summary>
        /// List Resources.
        /// </summary>
        /// <param name="deviceId">Id of the device that this resource belongs to.</param>
        /// <returns>List of resources for this endpoint.</returns>
        public List<Resource> ListResources(string deviceId)
        {
            try
            {
                var resourcesList = endpointsApi.V2EndpointsDeviceIdGet(deviceId);
                var resources = new List<Resource>();
                foreach (var resource in resourcesList)
                {
                    resources.Add(Resource.Map(deviceId, resource, this));
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
            api.V2EndpointsDeviceIdResourcePathDelete(deviceName, resourcePath, noResponse);
        }

        /// <summary>
        /// Get the resources.
        /// </summary>
        /// <returns>The resources.</returns>
        /// <param name="endpointName">Endpoint resources are connected to.</param>
        public List<Resource> GetResources(string endpointName)
        {
            try
            {
                var resp = endpointsApi.V2EndpointsDeviceIdGet(endpointName);
                var resources = new List<Resource>();
                foreach (var resource in resp)
                {
                    resources.Add(Resource.Map(endpointName, resource, this));
                }
                return resources;
            }
            catch (mds.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}