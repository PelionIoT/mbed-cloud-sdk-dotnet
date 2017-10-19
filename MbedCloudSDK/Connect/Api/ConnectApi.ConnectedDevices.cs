// <copyright file="ConnectApi.ConnectedDevices.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Filter;
    using MbedCloudSDK.Common.Query;
    using MbedCloudSDK.Connect.Model.ConnectedDevice;
    using MbedCloudSDK.Connect.Model.Resource;
    using MbedCloudSDK.Exceptions;

    /// <summary>
    /// Connect Api
    /// </summary>
    public partial class ConnectApi
    {
        /// <summary>
        /// Lists all connected devices.
        /// </summary>
        /// <param name="options">options</param>
        /// <returns>The list of connected devices.</returns>
        public PaginatedResponse<ConnectedDevice> ListConnectedDevices(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            if (options.Filter == null)
            {
                options.Filter = new Filter();
            }

            options.Filter.Add("state", "registered");

            try
            {
                return new PaginatedResponse<ConnectedDevice>(ListConnectedDevicesFunc, options);
            }
            catch (CloudApiException)
            {
                throw;
            }
        }

        private ResponsePage<ConnectedDevice> ListConnectedDevicesFunc(QueryOptions options)
        {
            try
            {
                var resp = deviceDirectoryApi.DeviceList(limit: options.Limit, order: options.Order, after: options.After, filter: options.Filter?.FilterString, include: options.Include);
                var respDevices = new ResponsePage<ConnectedDevice>(after: resp.After, hasMore: resp.HasMore, limit: resp.Limit, order: resp.Order, totalCount: resp.TotalCount);
                foreach (var device in resp.Data)
                {
                    using (var connectApi = new ConnectApi(Config))
                    {
                        respDevices.Data.Add(ConnectedDevice.Map(device, connectApi));
                    }
                }

                return respDevices;
            }
            catch (device_directory.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// List a device's subscriptions
        /// </summary>
        /// <param name="deviceId">Device Id</param>
        /// <returns>List of device subscriptions</returns>
        public string[] ListDeviceSubscriptions(string deviceId)
        {
            try
            {
                return subscriptionsApi.V2SubscriptionsDeviceIdGet(deviceId).Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (mds.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Removes a device's subscriptions
        /// </summary>
        /// <param name="deviceId">Device Id</param>
        public void DeleteDeviceSubscriptions(string deviceId)
        {
            try
            {
                subscriptionsApi.V2SubscriptionsDeviceIdDelete(deviceId);
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
        /// <returns>Resourse Value</returns>
        public string GetResourceValue(string deviceId, string resourcePath)
        {
            resourcePath = FixedPath(resourcePath);
            var asyncID = resourcesApi.V2EndpointsDeviceIdResourcePathGet(deviceId, resourcePath);
            var collection = new AsyncProducerConsumerCollection<string>();
            AsyncResponses.Add(asyncID.AsyncResponseId, collection);

            if (AsyncResponses.ContainsKey(asyncID.AsyncResponseId))
            {
                var res = AsyncResponses[asyncID.AsyncResponseId].Take().Result;
                return res;
            }

            return null;
        }

        /// <summary>
        /// Gets the value of the resource asynchronously
        /// </summary>
        /// <param name="deviceId">Device Id</param>
        /// <param name="resourcePath">Resource path.</param>
        /// <returns>Async consumer with string</returns>
        public AsyncConsumer<string> GetResourceValueAsync(string deviceId, string resourcePath)
        {
            resourcePath = FixedPath(resourcePath);
            var asyncID = resourcesApi.V2EndpointsDeviceIdResourcePathGetAsync(deviceId, resourcePath).Result;
            var collection = new AsyncProducerConsumerCollection<string>();
            AsyncResponses.Add(asyncID.AsyncResponseId, collection);
            return new AsyncConsumer<string>(asyncID.AsyncResponseId, collection);
        }

        /// <summary>
        /// Set value of the resource.
        /// </summary>
        /// <param name="deviceId">Id of the device.</param>
        /// <param name="resourcePath">Path to the resource.</param>
        /// <param name="resourceValue">Value to set.</param>
        /// <param name="noResponse">Don't get a response.</param>
        /// <returns>Async consumer with string</returns>
        public AsyncConsumer<string> SetResourceValue(string deviceId, string resourcePath, string resourceValue, bool? noResponse = null)
        {
            resourcePath = FixedPath(resourcePath);
            var asyncID = resourcesApi.V2EndpointsDeviceIdResourcePathPut(deviceId, resourcePath, resourceValue, noResponse);
            var collection = new AsyncProducerConsumerCollection<string>();
            AsyncResponses.Add(asyncID.AsyncResponseId, collection);
            return new AsyncConsumer<string>(asyncID.AsyncResponseId, collection);
        }

        /// <summary>
        /// Set value of the resource asynchronously.
        /// </summary>
        /// <param name="deviceId">Id of the device.</param>
        /// <param name="resourcePath">Path to the resource.</param>
        /// <param name="resourceValue">Value to set.</param>
        /// <param name="noResponse">Don't get a response.</param>
        /// <returns>Async consumer with string</returns>
        public AsyncConsumer<string> SetResourceValueAsync(string deviceId, string resourcePath, string resourceValue, bool? noResponse = null)
        {
            resourcePath = FixedPath(resourcePath);
            var asyncID = resourcesApi.V2EndpointsDeviceIdResourcePathPutAsync(deviceId, resourcePath, resourceValue, noResponse).Result;
            var collection = new AsyncProducerConsumerCollection<string>();
            AsyncResponses.Add(asyncID.AsyncResponseId, collection);
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
        /// <param name="noResponse">no response</param>
        public void DeleteResource(string deviceName, string resourcePath, bool? noResponse = null)
        {
            resourcesApi.V2EndpointsDeviceIdResourcePathDelete(deviceName, resourcePath, noResponse);
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

        /// <summary>
        /// Get a resource from the path
        /// </summary>
        /// <param name="deviceId">Id of the device</param>
        /// <param name="resourcePath">Path to the resource</param>
        /// <returns>The resource at the givn path. Throws if not found</returns>
        public Resource GetResource(string deviceId, string resourcePath)
        {
            var resources = ListResources(deviceId);
            foreach (var resource in resources)
            {
                if (resource.Path == resourcePath)
                {
                    return resource;
                }
            }

            throw new CloudApiException(404, "Resource not found");
        }
    }
}