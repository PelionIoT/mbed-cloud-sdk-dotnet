// <copyright file="Resource.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Model.Resource
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Text;
    using MbedCloudSDK.Connect.Api;
    using MbedCloudSDK.Connect.Model.ConnectedDevice;
    using MbedCloudSDK.Connect.Model.Notifications;
    using Newtonsoft.Json;

    /// <summary>
    /// Resource.
    /// </summary>
    public class Resource
    {
        private Connect.Api.ConnectApi api;

        /// <summary>
        /// Initializes a new instance of the <see cref="Resource"/> class.
        /// Initializes new Resource.
        /// </summary>
        /// <param name="deviceId">Id of the device that the resource belongs to.</param>
        /// <param name="options">Dictionary used to initialize Resource.</param>
        /// <param name="api">DeviceDirectory API.</param>
        /// <param name="notificationHandler">Handler</param>
        /// <param name="registrationHandler">Handler</param>
        /// <param name="registrationUpdateHandler">Handler</param>
        /// <param name="deRegistrationHandler">Handler</param>
        /// <param name="registrationExpiredHandler">Handler</param>
        public Resource(
            string deviceId,
            IDictionary<string, object> options = null,
            ConnectApi api = null,
            Action<string> notificationHandler = null,
            Action<EndpointData> registrationHandler = null,
            Action<EndpointData> registrationUpdateHandler = null,
            Action<string> deRegistrationHandler = null,
            Action<string> registrationExpiredHandler = null)
        {
            this.api = api;
            DeviceId = deviceId;

            NotificationHandler = notificationHandler;
            RegistrationHandler = registrationHandler;
            RegistrationUpdateHandler = registrationUpdateHandler;
            DeRegistrationHandler = deRegistrationHandler;
            RegistrationExpiredHandler = registrationExpiredHandler;

            if (options != null)
            {
                foreach (KeyValuePair<string, object> item in options)
                {
                    var property = GetType().GetProperty(item.Key);
                    if (property != null)
                    {
                        property.SetValue(this, item.Value, null);
                    }
                }
            }

            RegisterHandlers();
        }

        /// <summary>
        /// Gets id of the device this resource belongs to.
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
        public string ConentType { get; private set; }

        /// <summary>
        /// Gets resource url.
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
        public AsyncProducerConsumerCollection<string> NotificationQueue { get; set; }

        /// <summary>
        /// Gets or sets the NotificationHandler
        /// </summary>
        public Action<string> NotificationHandler { get; set; }

        /// <summary>
        /// Gets or sets the RegistrationQueue values.
        /// </summary>
        public AsyncProducerConsumerCollection<EndpointData> RegistrationQueue { get; set; }

        /// <summary>
        /// Gets or sets the RegistrationHandler
        /// </summary>
        public Action<EndpointData> RegistrationHandler { get; set; }

        /// <summary>
        /// Gets or sets the RegistrationUpdateQueue values.
        /// </summary>
        public AsyncProducerConsumerCollection<EndpointData> RegistrationUpdateQueue { get; set; }

        /// <summary>
        /// Gets or sets the RegistrationUpdateHandler
        /// </summary>
        public Action<EndpointData> RegistrationUpdateHandler { get; set; }

        /// <summary>
        /// Gets or sets the DeRegistrationQueue values.
        /// </summary>
        public AsyncProducerConsumerCollection<string> DeRegistrationQueue { get; set; }

        /// <summary>
        /// Gets or sets the DeRegistrationHandler
        /// </summary>
        public Action<string> DeRegistrationHandler { get; set; }

        /// <summary>
        /// Gets or sets the RegistrationExpiredQueue values.
        /// </summary>
        public AsyncProducerConsumerCollection<string> RegistrationExpiredQueue { get; set; }

        /// <summary>
        /// Gets or sets the RegistrationExpiredHandler
        /// </summary>
        public Action<string> RegistrationExpiredHandler { get; set; }

        /// <summary>
        /// Map to Resource object.
        /// </summary>
        /// <param name="deviceId">Id of the devi</param>
        /// <param name="res">resource</param>
        /// <param name="api">Api</param>
        /// <returns>Resource</returns>
        public static Resource Map(string deviceId, mds.Model.Resource res, ConnectApi api)
        {
            var resource = new Resource(deviceId, null, api)
            {
                Type = res.Rt,
                ConentType = res.Type,
                Path = res.Uri,
                Observable = res.Obs,
            };
            resource.RegisterHandlers();
            return resource;
        }

        private void NotificationEventHandler(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var res = NotificationQueue.Take().Result;
                if (NotificationHandler != null)
                {
                    NotificationHandler(res);
                }
            }
        }

        private void RegistrationEventHandler(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var res = RegistrationQueue.Take().Result;
                if (RegistrationHandler != null)
                {
                    RegistrationHandler(res);
                }
            }
        }

        private void RegistrationUpdateEventHandler(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var res = RegistrationUpdateQueue.Take().Result;
                if (RegistrationUpdateHandler != null)
                {
                    RegistrationUpdateHandler(res);
                }
            }
        }

        private void DeRegistrationEventHandler(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var res = DeRegistrationQueue.Take().Result;
                if (DeRegistrationHandler != null)
                {
                    DeRegistrationHandler(res);
                }
            }
        }

        private void RegistrationExpiredEventHandler(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var res = RegistrationExpiredQueue.Take().Result;
                if (RegistrationExpiredHandler != null)
                {
                    RegistrationExpiredHandler(res);
                }
            }
        }

        private void RegisterHandlers()
        {
            NotificationQueue = new AsyncProducerConsumerCollection<string>();
            RegistrationQueue = new AsyncProducerConsumerCollection<EndpointData>();
            RegistrationUpdateQueue = new AsyncProducerConsumerCollection<EndpointData>();
            DeRegistrationQueue = new AsyncProducerConsumerCollection<string>();
            RegistrationExpiredQueue = new AsyncProducerConsumerCollection<string>();

            NotificationQueue.AddHandler(NotificationEventHandler);
            RegistrationQueue.AddHandler(RegistrationEventHandler);
            RegistrationUpdateQueue.AddHandler(RegistrationUpdateEventHandler);
            DeRegistrationQueue.AddHandler(DeRegistrationEventHandler);
            RegistrationExpiredQueue.AddHandler(RegistrationExpiredEventHandler);
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
        /// <param name="noResponse">Don't get a response.</param>
        /// <returns>Async consumer with string</returns>
        public string SetResourceValue(string resourceValue, bool? noResponse = null)
        {
            return api.SetResourceValue(DeviceId, Path, resourceValue, noResponse);
        }

        /// <summary>
        /// Subscribe to this resource.
        /// </summary>
        /// <returns>Async consumer with string</returns>
        public Resource Subscribe()
        {
            return api.AddResourceSubscription(DeviceId, Path);
        }

        /// <summary>
        /// Desubscribe this resource.
        /// </summary>
        public void Unsubscribe()
        {
            api.DeleteResourceSubscription(DeviceId, Path);
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Resource {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Content Type: ").Append(ConentType).Append("\n");
            sb.Append("  Uri: ").Append(Path).Append("\n");
            sb.Append("  Observable: ").Append(Observable).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}