// <copyright file="ResourceValuesObserver.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe.Observers.ResourceValues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MbedCloudSDK.Connect.Api.Subscribe.Models;
    using MbedCloudSDK.Connect.Model.Notifications;

    /// <summary>
    /// <see cref="ResourceValuesObserver"/>
    /// </summary>
    public class ResourceValuesObserver : Observer<ResourceValueChange, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceValuesObserver"/> class.
        /// </summary>
        public ResourceValuesObserver()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceValuesObserver"/> class.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="resourcePaths">The resource paths.</param>
        public ResourceValuesObserver(string deviceId, List<string> resourcePaths)
         : this(new List<string> { deviceId }, resourcePaths)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceValuesObserver"/> class.
        /// </summary>
        /// <param name="deviceIds">The device ids.</param>
        /// <param name="resourcePath">The resource path.</param>
        public ResourceValuesObserver(List<string> deviceIds, string resourcePath)
         : this(deviceIds, new List<string> { resourcePath })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceValuesObserver"/> class.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="resourcePath">The resource path.</param>
        public ResourceValuesObserver(string deviceId, string resourcePath)
         : this(new List<string> { deviceId }, new List<string> { resourcePath })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceValuesObserver"/> class.
        /// </summary>
        /// <param name="deviceIds">The device ids.</param>
        /// <param name="resourcePaths">The resource paths.</param>
        public ResourceValuesObserver(List<string> deviceIds, List<string> resourcePaths)
        {
            deviceIds.ForEach(r =>
            {
                var sub = new ResourceValuesFilter { DeviceId = r, ResourcePaths = resourcePaths };
                ResourceValueSubscriptions.Add(sub);
            });

            OnSubAdded?.Invoke();
        }

        /// <summary>
        /// SubAddedRaiser
        /// </summary>
        public delegate void SubAddedRaiser();

        /// <summary>
        /// Occurs when [on sub added].
        /// </summary>
        public event SubAddedRaiser OnSubAdded;

        /// <summary>
        /// Gets the local filters.
        /// </summary>
        /// <value>
        /// The local filters.
        /// </value>
        public List<Func<ResourceValuesFilter, bool>> LocalFilters { get; } = new List<Func<ResourceValuesFilter, bool>>();

        /// <summary>
        /// Gets the resource value subscriptions.
        /// </summary>
        /// <value>
        /// The resource value subscriptions.
        /// </value>
        public List<ResourceValuesFilter> ResourceValueSubscriptions { get; } = new List<ResourceValuesFilter>();

        /// <summary>
        /// Notifies the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Notify(NotificationData data)
        {
            if (!ResourceValueSubscriptions.Any() || ResourceValueSubscriptions.FirstOrDefault(p => p.Equals(data)) != null)
            {
                if (RunLocalFilters(data))
                {
                    base.Notify(ResourceValueChange.Map(data));
                }
            }
        }

        /// <summary>
        /// Wheres the specified subscription.
        /// </summary>
        /// <param name="subscription">The subscription.</param>
        /// <returns>ResourceValueObserver</returns>
        public ResourceValuesObserver Where(ResourceValuesFilter subscription)
        {
            ResourceValueSubscriptions.Add(subscription);
            OnSubAdded?.Invoke();
            return this;
        }

        /// <summary>
        /// Wheres the specified device identifier.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="resourcePaths">The resource paths.</param>
        /// <returns>ResourceValueObserver</returns>
        public ResourceValuesObserver Where(string deviceId, params string[] resourcePaths)
        {
            var sub = new ResourceValuesFilter { DeviceId = deviceId, ResourcePaths = resourcePaths.ToList() };
            ResourceValueSubscriptions.Add(sub);
            OnSubAdded?.Invoke();
            return this;
        }

        /// <summary>
        /// Wheres the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>ResourceValueObserver</returns>
        public ResourceValuesObserver Where(Func<ResourceValuesFilter, bool> predicate)
        {
            LocalFilters.Add(predicate);
            return this;
        }

        private bool RunLocalFilters(NotificationData data)
        {
            if (LocalFilters.Any())
            {
                return LocalFilters.TrueForAll(f => f.Invoke(new ResourceValuesFilter { DeviceId = data.DeviceId, ResourcePaths = new List<string> { data.Path } }));
            }

            return true;
        }
    }
}