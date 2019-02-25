// <copyright file="Resource.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Model.Resource
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Threading.Tasks;
    using Mbed.Cloud.Foundation.Common;
    using MbedCloudSDK.Common.Extensions;
    using MbedCloudSDK.Connect.Api;
    using MbedCloudSDK.Connect.Model.ConnectedDevice;
    using MbedCloudSDK.Connect.Model.Notifications;
    using Newtonsoft.Json;
    using Nito.AsyncEx;

    /// <summary>
    /// Resource.
    /// </summary>
    public class Resource : Entity
    {
        private readonly ConnectApi api;

        /// <summary>
        /// Initializes a new instance of the <see cref="Resource"/> class.
        /// Initializes new Resource.
        /// </summary>
        /// <param name="deviceId">Id of the device that the resource belongs to.</param>
        /// <param name="api">DeviceDirectory API.</param>
        public Resource(string deviceId, ConnectApi api = null)
        {
            this.api = api;
            DeviceId = deviceId;
            NotificationQueue = new AsyncCollection<string>();
        }

        /// <summary>
        /// Gets ID of the device this resource belongs to.
        /// </summary>
        [JsonProperty]
        public string DeviceId { get; private set; }

        /// <summary>
        /// Gets resource&#39;s type
        /// </summary>
        [JsonProperty]
        public string Type { get; private set; }

        /// <summary>
        /// Gets the content type of the resource. You are encouraged to use the resource types listed in the LWM2M specification: http://technical.openmobilealliance.org/Technical/technical-information/omna/lightweight-m2m-lwm2m-object-registry
        /// </summary>
        [JsonProperty]
        public string ContentType { get; private set; }

        /// <summary>
        /// Gets resource URL.
        /// </summary>
        /// <value>Resource&#39;s url.</value>
        [JsonProperty]
        public string Path { get; private set; }

        /// <summary>
        /// Gets observable determines whether you can subscribe to changes for this resource.
        /// </summary>
        [JsonProperty]
        public bool? Observable { get; private set; }

        /// <summary>
        /// Gets or sets the NotificationQueue values.
        /// </summary>
        public AsyncCollection<string> NotificationQueue { get; set; }

        /// <summary>
        /// Map to Resource object.
        /// </summary>
        /// <param name="deviceId">Id of the devi</param>
        /// <param name="res">resource</param>
        /// <param name="api">Api</param>
        /// <returns>Resource</returns>
        public static Resource Map(string deviceId, mds.Model.Resource res, ConnectApi api)
        {
            var resource = new Resource(deviceId, api)
            {
                Type = res.Rt,
                ContentType = res.Type,
                Path = res.Uri,
                Observable = res.Obs,
            };
            return resource;
        }

        /// <summary>
        /// Gets the value of the resource.
        /// </summary>
        /// <returns>Resource value</returns>
        public string GetResourceValue()
        {
            return api.GetResourceValue(DeviceId, Path);
        }

        /// <summary>
        /// Set value of the resource.
        /// </summary>
        /// <param name="resourceValue">Value to set.</param>
        /// <returns>Async consumer with string</returns>
        public string SetResourceValue(string resourceValue)
        {
            return api.SetResourceValue(DeviceId, Path, resourceValue);
        }

        /// <summary>
        /// Subscribe to this resource.
        /// </summary>
        /// <returns>Async consumer with string</returns>
        public async Task<Resource> Subscribe()
        {
            return await api.AddResourceSubscriptionAsync(DeviceId, Path);
        }

        /// <summary>
        /// Unsubscribe this resource.
        /// </summary>
        public void Unsubscribe()
        {
            api.DeleteResourceSubscription(DeviceId, Path);
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();
    }
}
