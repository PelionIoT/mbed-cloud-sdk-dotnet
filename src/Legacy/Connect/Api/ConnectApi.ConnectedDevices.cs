// <copyright file="ConnectApi.ConnectedDevices.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Mime;
    using System.Text;
    using System.Threading.Tasks;
    using Mbed.Cloud.Common;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using MbedCloudSDK.Common.Filter;
    using MbedCloudSDK.Connect.Model.ConnectedDevice;
    using MbedCloudSDK.Exceptions;
    using mds.Model;
    using Nito.AsyncEx;
    using static MbedCloudSDK.Common.Utils;

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
        public PaginatedResponse<QueryOptions, ConnectedDevice> ListConnectedDevices(QueryOptions options = null)
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
                return new PaginatedResponse<QueryOptions, ConnectedDevice>(ListConnectedDevicesFunc, options);
            }
            catch (CloudApiException)
            {
                throw;
            }
        }

        private async Task<ResponsePage<ConnectedDevice>> ListConnectedDevicesFunc(QueryOptions options)
        {
            try
            {
                var resp = await DeviceDirectoryApi.DeviceListAsync(limit: options.Limit, order: options.Order, after: options.After, filter: options.Filter?.FilterString, include: options.Include);
                var respDevices = new ResponsePage<ConnectedDevice>(after: resp.After, hasMore: resp.HasMore, totalCount: resp.TotalCount);
                foreach (var device in resp.Data)
                {
                    respDevices.Add(ConnectedDevice.Map(device, this));
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
        public IEnumerable<string> ListDeviceSubscriptions(string deviceId)
        {
            string subscriptionsString;
            try
            {
                subscriptionsString = SubscriptionsApi.GetEndpointSubscriptions(deviceId);
            }
            catch (mds.Client.ApiException e)
            {
                if (e.ErrorCode == 404)
                {
                    return new string[] { };
                }

                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }

            if (!string.IsNullOrEmpty(subscriptionsString))
            {
                return subscriptionsString.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }

            return new string[] { };
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
                SubscriptionsApi.DeleteEndpointSubscriptions(deviceId);
                ResourceSubscribtions.Keys
                    .Where(k => k.Contains(deviceId))
                    .ToList()
                    .ForEach(d => ResourceSubscribtions.TryRemove(d, out var removedItem));
            }
            catch (mds.Client.ApiException e) when (e.ErrorCode != 404)
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
        public IEnumerable<Model.Resource.Resource> ListResources(string deviceId)
        {
            try
            {
                return EndpointsApi.GetEndpointResources(deviceId)
                    ?.Select(r => Model.Resource.Resource.Map(deviceId, r, this));
            }
            catch (mds.Client.ApiException e)
            {
                return HandleNotFound<IEnumerable<Model.Resource.Resource>, mds.Client.ApiException>(e);
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
        public Model.Resource.Resource GetResource(string deviceId, string resourcePath)
        {
            var resources = ListResources(deviceId);
            return resources.FirstOrDefault(r => r.Path.EndsWith(resourcePath));
        }

        /// <summary>
        /// Execute a function on a resource
        /// </summary>
        /// <param name="deviceId">Device ID</param>
        /// <param name="resourcePath">Resource path</param>
        /// <param name="functionName">The function to trigger</param>
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
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="deviceId"/> is <see langword="null"/>.
        /// <br/>-or-<br/>
        /// If <paramref name="resourcePath"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="deviceId"/> is a blank or empty string.
        /// <br/>-or-<br/>
        /// If <paramref name="resourcePath"/> is a blank or empty string.
        /// </exception>
        /// <exception cref="CloudApiException">
        /// If an error occurred while communicating with the server or if the server responsed with an error.
        /// </exception>
        public string ExecuteResource(string deviceId, string resourcePath, string functionName = null)
            => ExecuteSynchronously(ExecuteResourceAsync(deviceId, resourcePath, functionName));

        /// <summary>
        /// Execute a function on a resource asynchronously
        /// </summary>
        /// <param name="deviceId">Device Id</param>
        /// <param name="resourcePath">Resource path.</param>
        /// <param name="functionName">The function to trigger</param>
        /// <returns>Async consumer with string</returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="deviceId"/> is <see langword="null"/>.
        /// <br/>-or-<br/>
        /// If <paramref name="resourcePath"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="deviceId"/> is a blank or empty string.
        /// <br/>-or-<br/>
        /// If <paramref name="resourcePath"/> is a blank or empty string.
        /// </exception>
        /// <exception cref="CloudApiException">
        /// If an error occurred while communicating with the server or if the server responsed with an error.
        /// </exception>
        public async Task<AsyncConsumer<string>> ExecuteResourceAsync(string deviceId, string resourcePath, string functionName = null)
        {
            ThrowIfNullOrEmpty(deviceId, nameof(deviceId));
            ThrowIfNullOrEmpty(resourcePath, nameof(resourcePath));

            var deviceRequest = new DeviceRequest(Method: HttpMethod.Post.Method, Uri: AddLeadingSlash(resourcePath))
            {
                PayloadB64 = functionName,
            };

            return await CreateAsyncRequestAsync(deviceId, deviceRequest).ConfigureAwait(false);
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
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="deviceId"/> is <see langword="null"/>.
        /// <br/>-or-<br/>
        /// If <paramref name="resourcePath"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="deviceId"/> is a blank or empty string.
        /// <br/>-or-<br/>
        /// If <paramref name="resourcePath"/> is a blank or empty string.
        /// </exception>
        /// <exception cref="CloudApiException">
        /// If an error occurred while communicating with the server or if the server responsed with an error.
        /// </exception>
        public string GetResourceValue(string deviceId, string resourcePath)
            => ExecuteSynchronously(GetResourceValueAsync(deviceId, resourcePath));

        /// <summary>
        /// Gets the value of the resource asynchronously
        /// </summary>
        /// <param name="deviceId">Device Id</param>
        /// <param name="resourcePath">Resource path.</param>
        /// <returns>Async consumer with string</returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="deviceId"/> is <see langword="null"/>.
        /// <br/>-or-<br/>
        /// If <paramref name="resourcePath"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="deviceId"/> is a blank or empty string.
        /// <br/>-or-<br/>
        /// If <paramref name="resourcePath"/> is a blank or empty string.
        /// </exception>
        /// <exception cref="CloudApiException">
        /// If an error occurred while communicating with the server or if the server responsed with an error.
        /// </exception>
        public async Task<AsyncConsumer<string>> GetResourceValueAsync(string deviceId, string resourcePath)
        {
            ThrowIfNullOrEmpty(deviceId, nameof(deviceId));
            ThrowIfNullOrEmpty(resourcePath, nameof(resourcePath));

            var deviceRequest = new DeviceRequest(Method: HttpMethod.Get.Method, Uri: AddLeadingSlash(resourcePath));

            return await CreateAsyncRequestAsync(deviceId, deviceRequest).ConfigureAwait(false);
        }

        /// <summary>
        /// Sets the value for the specified resource.
        /// </summary>
        /// <param name="deviceId">ID of the device which contains the resource.</param>
        /// <param name="resourcePath">Full path of the resource to write.</param>
        /// <param name="resourceValue">The new value for the specified resource, sent as an UTF-8 encoded stream.</param>
        /// <returns>
        /// The ID of the asynchronous request.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="deviceId"/> is <see langword="null"/>.
        /// <br/>-or-<br/>
        /// If <paramref name="resourcePath"/> is <see langword="null"/>.
        /// <br/>-or-<br/>
        /// If <paramref name="resourceValue"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="deviceId"/> is a blank or empty string.
        /// <br/>-or-<br/>
        /// If <paramref name="resourcePath"/> is a blank or empty string.
        /// </exception>
        /// <exception cref="CloudApiException">
        /// If an error occurred while communicating with the server or if the server responsed with an error.
        /// </exception>
        public string SetResourceValue(string deviceId, string resourcePath, string resourceValue)
            => ExecuteSynchronously(SetResourceValueAsync(deviceId, resourcePath, resourceValue));

        /// <overloads>
        /// Sets the value for the specified resource.
        /// </overloads>
        /// <summary>
        /// Sets the value for the specified string resource.
        /// </summary>
        /// <param name="deviceId">ID of the device which contains the resource.</param>
        /// <param name="resourcePath">Full path of the resource to write.</param>
        /// <param name="resourceValue">The new value for the specified resource, sent as an UTF-8 encoded stream.</param>
        /// <returns>
        /// The ID of the asynchronous request.
        /// </returns>
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
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="deviceId"/> is <see langword="null"/>.
        /// <br/>-or-<br/>
        /// If <paramref name="resourcePath"/> is <see langword="null"/>.
        /// <br/>-or-<br/>
        /// If <paramref name="resourceValue"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="deviceId"/> is a blank or empty string.
        /// <br/>-or-<br/>
        /// If <paramref name="resourcePath"/> is a blank or empty string.
        /// </exception>
        /// <exception cref="CloudApiException">
        /// If an error occurred while communicating with the server or if the server responsed with an error.
        /// </exception>
        public async Task<AsyncConsumer<string>> SetResourceValueAsync(string deviceId, string resourcePath, string resourceValue)
        {
            ThrowIfNullOrEmpty(deviceId, nameof(deviceId));
            ThrowIfNullOrEmpty(resourcePath, nameof(resourcePath));

            if (resourceValue == null)
            {
                throw new ArgumentNullException(nameof(resourceValue));
            }

            return await SetResourceValueAsync(
                deviceId,
                resourcePath,
                Encoding.UTF8.GetBytes(resourceValue),
                MediaTypeNames.Text.Plain).ConfigureAwait(false);
        }

        /// <summary>
        /// Sets the value for the specified 64 bit signed integer resource.
        /// </summary>
        /// <param name="deviceId">ID of the device which contains the resource.</param>
        /// <param name="resourcePath">Full path of the resource to write.</param>
        /// <param name="resourceValue">The new value for the specified resource, sent as big endian byte array.</param>
        /// <returns>
        /// The ID of the asynchronous request.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="deviceId"/> is <see langword="null"/>.
        /// <br/>-or-<br/>
        /// If <paramref name="resourcePath"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="deviceId"/> is a blank or empty string.
        /// <br/>-or-<br/>
        /// If <paramref name="resourcePath"/> is a blank or empty string.
        /// </exception>
        /// <exception cref="CloudApiException">
        /// If an error occurred while communicating with the server or if the server responsed with an error.
        /// </exception>
        public async Task<AsyncConsumer<string>> SetResourceValueAsync(string deviceId, string resourcePath, long resourceValue)
        {
            ThrowIfNullOrEmpty(deviceId, nameof(deviceId));
            ThrowIfNullOrEmpty(resourcePath, nameof(resourcePath));

            return await SetResourceValueAsync(
                deviceId,
                resourcePath,
                BitConverter.GetBytes(IPAddress.HostToNetworkOrder(resourceValue)),
                MediaTypeNames.Text.Plain).ConfigureAwait(false);
        }

        /// <summary>
        /// Sets the value for the specified 32 bit signed integer resource.
        /// </summary>
        /// <param name="deviceId">ID of the device which contains the resource.</param>
        /// <param name="resourcePath">Full path of the resource to write.</param>
        /// <param name="resourceValue">The new value for the specified resource, sent as big endian byte array.</param>
        /// <returns>
        /// The ID of the asynchronous request.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="deviceId"/> is <see langword="null"/>.
        /// <br/>-or-<br/>
        /// If <paramref name="resourcePath"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="deviceId"/> is a blank or empty string.
        /// <br/>-or-<br/>
        /// If <paramref name="resourcePath"/> is a blank or empty string.
        /// </exception>
        /// <exception cref="CloudApiException">
        /// If an error occurred while communicating with the server or if the server responsed with an error.
        /// </exception>
        public async Task<AsyncConsumer<string>> SetResourceValueAsync(string deviceId, string resourcePath, int resourceValue)
        {
            ThrowIfNullOrEmpty(deviceId, nameof(deviceId));
            ThrowIfNullOrEmpty(resourcePath, nameof(resourcePath));

            return await SetResourceValueAsync(
                deviceId,
                resourcePath,
                BitConverter.GetBytes(IPAddress.HostToNetworkOrder(resourceValue)),
                MediaTypeNames.Text.Plain).ConfigureAwait(false);
        }

        /// <summary>
        /// Sets the value for the specified 16 bit signed integer resource.
        /// </summary>
        /// <param name="deviceId">ID of the device which contains the resource.</param>
        /// <param name="resourcePath">Full path of the resource to write.</param>
        /// <param name="resourceValue">The new value for the specified resource, sent as big endian byte array.</param>
        /// <returns>
        /// The ID of the asynchronous request.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="deviceId"/> is <see langword="null"/>.
        /// <br/>-or-<br/>
        /// If <paramref name="resourcePath"/> is <see langword="null"/>.
        /// <br/>-or-<br/>
        /// If <paramref name="resourceValue"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="deviceId"/> is a blank or empty string.
        /// </exception>
        /// <exception cref="CloudApiException">
        /// If an error occurred while communicating with the server or if the server responsed with an error.
        /// </exception>
        public async Task<AsyncConsumer<string>> SetResourceValueAsync(string deviceId, string resourcePath, short resourceValue)
        {
            ThrowIfNullOrEmpty(deviceId, nameof(deviceId));
            ThrowIfNullOrEmpty(resourcePath, nameof(resourcePath));

            return await SetResourceValueAsync(
                deviceId,
                resourcePath,
                BitConverter.GetBytes(IPAddress.HostToNetworkOrder(resourceValue)),
                MediaTypeNames.Text.Plain).ConfigureAwait(false);
        }

        /// <summary>
        /// Sets the value for the specified binary resource.
        /// </summary>
        /// <param name="deviceId">ID of the device which contains the resource.</param>
        /// <param name="resourcePath">Full path of the resource to write.</param>
        /// <param name="resourceValue">The new value for the specified resource.</param>
        /// <returns>
        /// The ID of the asynchronous request.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="deviceId"/> is <see langword="null"/>.
        /// <br/>-or-<br/>
        /// If <paramref name="resourcePath"/> is <see langword="null"/>.
        /// <br/>-or-<br/>
        /// If <paramref name="resourceValue"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="deviceId"/> is a blank or empty string.
        /// <br/>-or-<br/>
        /// If <paramref name="resourcePath"/> is a blank or empty string.
        /// </exception>
        /// <exception cref="CloudApiException">
        /// If an error occurred while communicating with the server or if the server responsed with an error.
        /// </exception>
        public async Task<AsyncConsumer<string>> SetResourceValueAsync(string deviceId, string resourcePath, byte[] resourceValue)
        {
            ThrowIfNullOrEmpty(deviceId, nameof(deviceId));
            ThrowIfNullOrEmpty(resourcePath, nameof(resourcePath));

            if (resourceValue == null)
            {
                throw new ArgumentNullException(nameof(resourceValue));
            }

            return await SetResourceValueAsync(deviceId, resourcePath, resourceValue, MediaTypeNames.Application.Octet).ConfigureAwait(false);
        }

#pragma warning disable CC0044, CC0057, CC0097, SA1611, SA1615, IDE0022

        /// <summary>Obsolote, do not use.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("noResp parameter is now ignored, use another overload instead")]
        public string ExecuteResource(string deviceId, string resourcePath, string functionName, bool? noResp)
            => ExecuteResource(deviceId, resourcePath, functionName);

        /// <summary>Obsolote, do not use.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("noResp parameter is now ignored, use another overload instead")]
        public Task<AsyncConsumer<string>> ExecuteResourceAsync(string deviceId, string resourcePath, string functionName, bool? noResp)
            => ExecuteResourceAsync(deviceId, resourcePath, functionName);

        /// <summary>Obsolote, do not use.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("noResp parameter is now ignored, use another overload instead")]
        public string GetResourceValue(string deviceId, string resourcePath, bool? noResp)
            => GetResourceValue(deviceId, resourcePath);

        /// <summary>Obsolote, do not use.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("noResp parameter is now ignored, use another overload instead")]
        public Task<AsyncConsumer<string>> GetResourceValueAsync(string deviceId, string resourcePath, bool? noResp)
            => GetResourceValueAsync(deviceId, resourcePath);

        /// <summary>Obsolote, do not use.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("noResp parameter is now ignored, use another overload instead")]
        public string SetResourceValue(string deviceId, string resourcePath, string resourceValue, bool? noResp)
            => SetResourceValue(deviceId, resourcePath, resourceValue);

        /// <summary>Obsolote, do not use.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("noResp parameter is now ignored, use another overload instead")]
        public Task<AsyncConsumer<string>> SetResourceValueAsync(string deviceId, string resourcePath, string resourceValue, bool? noResp)
            => SetResourceValueAsync(deviceId, resourcePath, resourceValue);

#pragma warning restore CC0044, CC0057, CC0097, SA1611, SA1615, IDE0022

        private static void ThrowIfNullOrEmpty(string value, string paramName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"Parameter {paramName} cannot be an empty or blank string.", paramName);
            }
        }

        private string ExecuteSynchronously(Task<AsyncConsumer<string>> task)
        {
            var consumer = task
                .GetAwaiter()
                .GetResult();

            if (!AsyncResponses.ContainsKey(consumer.AsyncId))
            {
                throw new CloudApiException(404, "AsyncId not found.");
            }

            return AsyncResponses[consumer.AsyncId]
                .TakeAsync()
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
        }

        private async Task<AsyncConsumer<string>> SetResourceValueAsync(string deviceId, string resourcePath, byte[] resourceValue, string resourceValueMimeType)
        {
            var deviceRequest = new DeviceRequest(Method: HttpMethod.Put.Method, Uri: AddLeadingSlash(resourcePath))
            {
                ContentType = resourceValueMimeType,
                PayloadB64 = Convert.ToBase64String(resourceValue)
            };

            return await CreateAsyncRequestAsync(deviceId, deviceRequest);
        }

        private async Task<AsyncConsumer<string>> CreateAsyncRequestAsync(string deviceId, DeviceRequest request)
        {
            if (autostartNotifications)
            {
                await StartNotificationsAsync();
            }

            if (!NotificationsStarted)
            {
                throw new CloudApiException(400, "StartNotifications() needs to be called before creating an async request.");
            }

            var asyncId = $"async-{Guid.NewGuid():N}";

            try
            {
                await DeviceRequestsApi.CreateAsyncRequestAsync(deviceId, asyncId, request);
            }
            catch (mds.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }

            var collection = new AsyncCollection<string>();
            AsyncResponses.TryAdd(asyncId, collection);

            return new AsyncConsumer<string>(asyncId, collection);
        }
    }
}