// <copyright file="ConnectApi.ConnectedDevices.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        /// <param name="options"><see cref="QueryOptions"/></param>
        /// <returns>The list of connected devices.</returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var options = new QueryOptions();
        ///     options.Filter.Add("createdAt", new DateTime(2017, 1, 1), FilterOperator.GreaterOrEqual);
        ///     options.Filter.Add("createdAt", new DateTime(2018, 1, 1), FilterOperator.LessOrEqual);
        ///     var devices = connectApi.ListConnectedDevices(options);
        ///     foreach (var item in devices)
        ///     {
        ///         Console.WriteLine(item);
        ///     }
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
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
                    respDevices.Data.Add(ConnectedDevice.Map(device, this));
                }

                return respDevices;
            }
            catch (device_directory.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// List a device's resources with subscriptions
        /// </summary>
        /// <param name="deviceId">DeviceId</param>
        /// <returns>List of device subscriptions</returns>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var subscriptions = connectApi.ListDeviceSubscriptions("015bb66a92a30000000000010010006d");
        ///     foreach (var resource in subscriptions)
        ///     {
        ///         Console.WriteLine(resource);
        ///     }
        ///     return subscriptions;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <exception cref="CloudApiException">CloudApiException</exception>
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
        /// <example>
        /// <code>
        /// try
        /// {
        ///     connectApi.DeleteDeviceSubscriptions("015bb66a92a30000000000010010006d");
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <exception cref="CloudApiException">CloudApiException</exception>
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
        /// List Resources.
        /// </summary>
        /// <param name="deviceId">Id of the device that this resource belongs to.</param>
        /// <returns>List of resources for this endpoint.</returns>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var resources = connectApi.ListResources("015bb66a92a30000000000010010006d");
        ///     foreach (var resource in resources)
        ///     {
        ///         Console.WriteLine(resource);
        ///     }
        ///     return resources;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public List<Resource> ListResources(string deviceId)
        {
            try
            {
                return endpointsApi.V2EndpointsDeviceIdGet(deviceId)
                .Select(r => Resource.Map(deviceId, r, this))
                .ToList();
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
        /// <returns>The resource at the givn path</returns>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var resource = connectApi.GetResource("015bb66a92a30000000000010010006d", "5001/0/1");
        ///     return resource;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <exception cref="CloudApiException">CloudApiException</exception>
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

        /// <summary>
        /// Delete resource.
        /// </summary>
        /// <param name="deviceId">Device Id</param>
        /// <param name="resourcePath">Path to the resource.</param>
        /// <param name="noResponse">Whether to make a non-confirmable request to the device</param>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     connectApi.DeleteResource("015bb66a92a30000000000010010006d", "5001/0/1");
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public void DeleteResource(string deviceId, string resourcePath, bool? noResponse = null)
        {
            try
            {
                resourcesApi.V2EndpointsDeviceIdResourcePathDelete(deviceId, resourcePath, noResponse);
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
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var resp = connectApi.GetResourceValue("015bb66a92a30000000000010010006d", "5001/0/1");
        ///     Console.WriteLine($"The value of the resource is {resp}");
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public string GetResourceValue(string deviceId, string resourcePath)
        {
            try
            {
                var consumer = GetResourceValueAsync(deviceId, resourcePath).Result;

                if (AsyncResponses.ContainsKey(consumer.AsyncId))
                {
                    var res = AsyncResponses[consumer.AsyncId].Take().Result;
                    return res;
                }
                else
                {
                    throw new CloudApiException(404, "AsyncId not found.");
                }
            }
            catch (CloudApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Set value of the resource.
        /// </summary>
        /// <param name="deviceId">Id of the device.</param>
        /// <param name="resourcePath">Path to the resource.</param>
        /// <param name="resourceValue">Value to set.</param>
        /// <param name="noResponse">Don't get a response.</param>
        /// <returns>Async consumer with string</returns>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var resp = connectApi.SetResourceValue("015bb66a92a30000000000010010006d", "5001/0/1", "new value");
        ///     var newValue = connectApi.GetResourceValue("015bb66a92a30000000000010010006d", "5001/0/1");
        ///     Console.WriteLine($"The value of the resource is {newValue}");
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public string SetResourceValue(string deviceId, string resourcePath, string resourceValue, bool? noResponse = null)
        {
            try
            {
                var consumer = SetResourceValueAsync(deviceId, resourcePath, resourceValue, noResponse).Result;
                if (AsyncResponses.ContainsKey(consumer.AsyncId))
                {
                    var res = AsyncResponses[consumer.AsyncId].Take().Result;
                    return res;
                }
                else
                {
                    throw new CloudApiException(404, "AsyncId not found.");
                }
            }
            catch (mds.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Execute a function on a resource
        /// </summary>
        /// <param name="deviceId">Device ID</param>
        /// <param name="resourcePath">Resource path</param>
        /// <param name="functionName">The function to trigger</param>
        /// <param name="noResponse">If true, Mbed Device Connector will not wait for a response</param>
        /// <returns>AsyncConsumer with response</returns>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var resp = connectApi.ExecuteResource("015bb66a92a30000000000010010006d", "5001/0/1");
        ///     Console.WriteLine(resp);
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public string ExecuteResource(string deviceId, string resourcePath, string functionName = null, bool? noResponse = null)
        {
            try
            {
                var consumer = ExecuteResourceAsync(deviceId, resourcePath, functionName, noResponse).Result;
                if (AsyncResponses.ContainsKey(consumer.AsyncId))
                {
                    var res = AsyncResponses[consumer.AsyncId].Take().Result;
                    return res;
                }
                else
                {
                    throw new CloudApiException(404, "AsyncId not found.");
                }
            }
            catch (mds.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Execute a function on a resource asynchronously
        /// </summary>
        /// <param name="deviceId">Device Id</param>
        /// <param name="resourcePath">Resource path.</param>
        /// <param name="functionName">The function to trigger</param>
        /// <param name="noResponse">If true, Mbed Device Connector will not wait for a response</param>
        /// <returns>Async consumer with string</returns>
        public async System.Threading.Tasks.Task<AsyncConsumer<string>> ExecuteResourceAsync(string deviceId, string resourcePath, string functionName = null, bool? noResponse = null)
        {
            try
            {
                StartNotifications();
                resourcePath = FixedPath(resourcePath);
                var asyncID = await resourcesApi.V2EndpointsDeviceIdResourcePathPostAsync(deviceId, resourcePath, functionName, noResponse);
                var collection = new AsyncProducerConsumerCollection<string>();
                AsyncResponses.Add(asyncID.AsyncResponseId, collection);
                return new AsyncConsumer<string>(asyncID.AsyncResponseId, collection);
            }
            catch (mds.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Gets the value of the resource asynchronously
        /// </summary>
        /// <param name="deviceId">Device Id</param>
        /// <param name="resourcePath">Resource path.</param>
        /// <returns>Async consumer with string</returns>
        public async System.Threading.Tasks.Task<AsyncConsumer<string>> GetResourceValueAsync(string deviceId, string resourcePath)
        {
            StartNotifications();
            resourcePath = FixedPath(resourcePath);
            var asyncID = await resourcesApi.V2EndpointsDeviceIdResourcePathGetAsync(deviceId, resourcePath);
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
        public async System.Threading.Tasks.Task<AsyncConsumer<string>> SetResourceValueAsync(string deviceId, string resourcePath, string resourceValue, bool? noResponse = null)
        {
            StartNotifications();
            resourcePath = FixedPath(resourcePath);
            var asyncID = await resourcesApi.V2EndpointsDeviceIdResourcePathPutAsync(deviceId, resourcePath, resourceValue, noResponse);
            var collection = new AsyncProducerConsumerCollection<string>();
            AsyncResponses.Add(asyncID.AsyncResponseId, collection);
            return new AsyncConsumer<string>(asyncID.AsyncResponseId, collection);
        }
    }
}