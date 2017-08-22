using mbedCloudSDK.Common;
using mbedCloudSDK.Connect.Model.ConnectedDevice;
using mbedCloudSDK.Connect.Model.Resource;
using mbedCloudSDK.Exceptions;
using System.Collections.Generic;
using System.Text;

namespace mbedCloudSDK.Connect.Api
{
    public partial class ConnectApi
    {
        /// <summary>
        /// Lists all endpoints.
        /// </summary>
        /// <returns>The list of endpoints.</returns>
        public List<ConnectedDevice> ListConnectedDevices()
        {
            var api = new mds.Api.EndpointsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            try
            {
                var endpoints = api.V2EndpointsGet();
                List<ConnectedDevice> devices = new List<ConnectedDevice>();
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
        public AsyncConsumer<string> GetResourceValue(string deviceId, string resourcePath)
        {
            resourcePath = FixedPath(resourcePath);
            var api = new mds.Api.ResourcesApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            var asyncID = api.V2EndpointsDeviceIdResourcePathGet(deviceId, resourcePath);
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
        public AsyncConsumer<string> SetResourceValue([NameOverride(Name = "DeviceId")]string deviceName, string resourcePath, byte[] resourceValue, bool? noResponse = null)
        {
            resourcePath = FixedPath(resourcePath);
            var api = new mds.Api.ResourcesApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            var asyncID = api.V2EndpointsDeviceIdResourcePathPut(deviceName, resourcePath, resourceValue, noResponse);
            AsyncProducerConsumerCollection<string> collection = new AsyncProducerConsumerCollection<string>();
            asyncResponses.Add(asyncID.AsyncResponseId, collection);
            return new AsyncConsumer<string>(collection);
        }

        /// <summary>
        /// List Resources.
        /// </summary>
        /// <param name="deviceId">Id of the device that this resource belongs to.</param>
        /// <returns>List of resources for this endpoint.</returns>
        public List<Resource> ListResources(string deviceId)
        {
            var api = new mds.Api.EndpointsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            try
            {
                var resourcesList = api.V2EndpointsDeviceIdGet(deviceId);
                List<Resource> resources = new List<Resource>();
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
            var api = new mds.Api.EndpointsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            try
            {
                var resp = api.V2EndpointsDeviceIdGet(endpointName);
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
