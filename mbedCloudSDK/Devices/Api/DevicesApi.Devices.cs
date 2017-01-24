using mbedCloudSDK.Common;
using mbedCloudSDK.Devices.Model.Device;
using mbedCloudSDK.Devices.Model.Resource;
using mbedCloudSDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Devices.Api
{
    public partial class DevicesApi
    {
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
                foreach (var endpoint in endpoints)
                {
                    devices.Add(Device.Map(endpoint, this));
                }
                return devices;
            }
            catch (mds.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

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
                var resp = api.DeviceList(listParams.Limit, listParams.Order, listParams.After, listParams.Filter, listParams.Include);
                ResponsePage<Device> respDevices = new ResponsePage<Device>(resp.After, resp.HasMore, resp.Limit, resp.Order, resp.TotalCount);
                foreach (var device in resp.Data)
                {
                    respDevices.Data.Add(Device.Map(device, this));
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

        /// <summary>
        /// Gets the value of the resource..
        /// </summary>
        /// <param name="endpointName">Endpoint name.</param>
        /// <param name="resourcePath">Resource path.</param>
        public AsyncConsumer<string> GetResourceValue(string endpointName, string resourcePath)
        {
            resourcePath = FixedPath(resourcePath);
            var api = new mds.Api.ResourcesApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            var asyncID = api.V2EndpointsEndpointNameResourcePathGet(endpointName, resourcePath);
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
            resourcePath = FixedPath(resourcePath);
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
        public List<Resource> GetResources(string endpointName)
        {
            var api = new mds.Api.EndpointsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            try
            {
                var resp = api.V2EndpointsEndpointNameGet(endpointName);
                var resources = new List<Resource>();
                foreach(var resource in resp)
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
    }
}
