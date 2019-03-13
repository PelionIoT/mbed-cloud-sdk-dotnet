// <copyright file="ResourceValuesObserver.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe.Observers.ResourceValues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using MbedCloudSDK.Connect.Api.Subscribe.Models;
    using MbedCloudSDK.Connect.Model.Notifications;
    using MbedCloudSDK.Connect.Model.Subscription;

    /// <summary>
    /// <see cref="ResourceValuesObserver"/>
    /// </summary>
    public class ResourceValuesObserver : Observer<ResourceValueChange, ResourceValueChange>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceValuesObserver"/> class.
        /// </summary>
        public ResourceValuesObserver()
        {
            OnFilterAdded?.Invoke(Id);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceValuesObserver"/> class.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="resourcePaths">The resource paths.</param>
        public ResourceValuesObserver(string deviceId, IEnumerable<string> resourcePaths)
         : this(new List<string> { deviceId }, resourcePaths)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceValuesObserver"/> class.
        /// </summary>
        /// <param name="deviceIds">The device ids.</param>
        /// <param name="resourcePath">The resource path.</param>
        public ResourceValuesObserver(IEnumerable<string> deviceIds, string resourcePath)
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
        public ResourceValuesObserver(IEnumerable<string> deviceIds, IEnumerable<string> resourcePaths)
        {
            deviceIds.ToList().ForEach(r =>
            {
                var resourceValueFilter = new ResourceValuesFilter { DeviceId = r, ResourcePaths = resourcePaths };
                ResourceValueSubscriptions.Add(resourceValueFilter);
            });

            OnFilterAdded?.Invoke(Id);
        }

        /// <summary>
        /// SubAddedRaiser
        /// </summary>
        /// <param name="id">The identifier.</param>
        public delegate void FilterAddedRaiser(string id);

        /// <summary>
        /// Occurs when [on sub added].
        /// </summary>
        public event FilterAddedRaiser OnFilterAdded;

        /// <summary>
        /// Gets the resource value subscriptions.
        /// </summary>
        /// <value>
        /// The resource value subscriptions.
        /// </value>
        public HashSet<ResourceValuesFilter> ResourceValueSubscriptions { get; } = new HashSet<ResourceValuesFilter>();

        /// <summary>
        /// Notifies the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task NotifyAsync(NotificationData data)
        {
            if (!ResourceValueSubscriptions.Any() || ResourceValueSubscriptions.FirstOrDefault(p => p.Equals(data)) != null)
            {
                if (RunLocalFilters(data))
                {
                    await base.NotifyAsync(ResourceValueChange.Map(data));
                }
            }
        }

        /// <summary>
        /// Wheres the specified subscription.
        /// </summary>
        /// <param name="subscription">The subscription.</param>
        /// <returns>ResourceValueObserver</returns>
        public ResourceValuesObserver Filter(ResourceValuesFilter subscription)
        {
            ResourceValueSubscriptions.Add(subscription);
            OnFilterAdded?.Invoke(Id);
            return this;
        }

        /// <summary>
        /// Wheres the specified device identifier.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="resourcePaths">The resource paths.</param>
        /// <returns>ResourceValueObserver</returns>
        public ResourceValuesObserver Filter(string deviceId, params string[] resourcePaths)
        {
            var sub = new ResourceValuesFilter { DeviceId = deviceId, ResourcePaths = resourcePaths.ToList() };
            ResourceValueSubscriptions.Add(sub);
            OnFilterAdded?.Invoke(Id);
            return this;
        }

        /// <summary>
        /// Wheres the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>ResourceValueObserver</returns>
        public ResourceValuesObserver Filter(Func<ResourceValueChange, bool> predicate)
        {
            FilterFuncs.Add(predicate);
            return this;
        }

        private bool RunLocalFilters(NotificationData data)
        {
            if (FilterFuncs.Any())
            {
                return FilterFuncs.TrueForAll(f => f.Invoke(ResourceValueChange.Map(data)));
            }

            return true;
        }
    }
}