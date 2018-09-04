// <copyright file="Subscribe.ResourceValues.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe
{
    using System.Collections.Generic;
    using System.Linq;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using MbedCloudSDK.Connect.Api.Subscribe.Models;
    using MbedCloudSDK.Connect.Api.Subscribe.Observers.ResourceValues;
    using MbedCloudSDK.Connect.Model.Notifications;
    using MbedCloudSDK.Connect.Model.Subscription;

    /// <summary>
    /// Subscribe
    /// </summary>
    public partial class Subscribe
    {
        /// <summary>
        /// Gets all local subscriptions.
        /// </summary>
        /// <value>
        /// All local subscriptions.
        /// </value>
        internal HashSet<ResourceValuesFilter> AllLocalSubscriptions { get; private set; } = new HashSet<ResourceValuesFilter>(new ResourceValuesFilterComparer());

        /// <summary>
        /// Gets the immediacy.
        /// </summary>
        /// <value>
        /// The immediacy.
        /// </value>
        public FirstValueEnum Immediacy { get; private set; }

        /// <summary>
        /// Gets the resource value observers.
        /// </summary>
        /// <value>
        /// The resource value observers.
        /// </value>
        internal List<ResourceValuesObserver> ResourceValueObservers { get; private set; } = new List<ResourceValuesObserver>();

        /// <summary>
        /// Notifies the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Notify(NotificationData data)
        {
            ResourceValueObservers.ForEach(o =>
            {
                o.Notify(data);
            });
        }

        /// <summary>
        /// Resources the values.
        /// </summary>
        /// <param name="immediacy">The immediacy.</param>
        /// <returns>ResourceValueObserver</returns>
        public ResourceValuesObserver ResourceValues(FirstValueEnum immediacy = FirstValueEnum.OnValueUpdate)
        {
            var observer = new ResourceValuesObserver();
            return ResourceValues(observer, immediacy);
        }

        /// <summary>
        /// Resources the values.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="immediacy">The immediacy.</param>
        /// <returns>ResourceValueObserver</returns>
        public ResourceValuesObserver ResourceValues(string deviceId, FirstValueEnum immediacy = FirstValueEnum.OnValueUpdate)
        {
            var observer = new ResourceValuesObserver(deviceId, Enumerable.Empty<string>());
            return ResourceValues(observer, immediacy);
        }

        /// <summary>
        /// Resources the values.
        /// </summary>
        /// <param name="resourcePaths">The resource paths.</param>
        /// <param name="immediacy">The immediacy.</param>
        /// <returns>ResourceValueObserver</returns>
        public ResourceValuesObserver ResourceValues(List<string> resourcePaths, FirstValueEnum immediacy = FirstValueEnum.OnValueUpdate)
        {
            var observer = new ResourceValuesObserver("*", resourcePaths);
            return ResourceValues(observer, immediacy);
        }

        /// <summary>
        /// Resources the values.
        /// </summary>
        /// <param name="deviceIds">The device ids.</param>
        /// <param name="resourcePaths">The resource paths.</param>
        /// <param name="immediacy">The immediacy.</param>
        /// <returns>
        /// A ResourceValueObserver
        /// </returns>
        public ResourceValuesObserver ResourceValues(List<string> deviceIds, List<string> resourcePaths, FirstValueEnum immediacy = FirstValueEnum.OnValueUpdate)
        {
            var observer = new ResourceValuesObserver(deviceIds, resourcePaths);
            return ResourceValues(observer, immediacy);
        }

        /// <summary>
        /// Resources the values.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="resourcePaths">The resource paths.</param>
        /// <param name="immediacy">The immediacy.</param>
        /// <returns>ResourceValueObserver</returns>
        public ResourceValuesObserver ResourceValues(string deviceId, List<string> resourcePaths, FirstValueEnum immediacy = FirstValueEnum.OnValueUpdate)
        {
            var observer = new ResourceValuesObserver(deviceId, resourcePaths);
            return ResourceValues(observer, immediacy);
        }

        /// <summary>
        /// Resources the values.
        /// </summary>
        /// <param name="deviceIds">The device ids.</param>
        /// <param name="resourcePath">The resource path.</param>
        /// <param name="immediacy">The immediacy.</param>
        /// <returns>ResourceValueObserver</returns>
        public ResourceValuesObserver ResourceValues(List<string> deviceIds, string resourcePath, FirstValueEnum immediacy = FirstValueEnum.OnValueUpdate)
        {
            var observer = new ResourceValuesObserver(deviceIds, resourcePath);
            return ResourceValues(observer, immediacy);
        }

        /// <summary>
        /// Resources the values.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="resourcePath">The resource path.</param>
        /// <param name="immediacy">The immediacy.</param>
        /// <returns>ResourceValueObserver</returns>
        public ResourceValuesObserver ResourceValues(string deviceId, string resourcePath, FirstValueEnum immediacy = FirstValueEnum.OnValueUpdate)
        {
            var observer = new ResourceValuesObserver(deviceId, resourcePath);
            return ResourceValues(observer, immediacy);
        }

        private static Presubscription[] MergeLocalAndServerLists(IEnumerable<Presubscription> local, IEnumerable<Presubscription> server)
        {
            return local.Union(server, new PresubscriptionComparer()).ToArray();
        }

        private void ConstructPresubArray(string id)
        {
            // get the union of all the local subscriptions
            var presubs = new HashSet<ResourceValuesFilter>();
            ResourceValueObservers.ForEach(s =>
            {
                presubs = presubs.Union(s.ResourceValueSubscriptions).ToHashSet();
            });

            AllLocalSubscriptions = presubs;

            if (ConnectApi != null)
            {
                // get the union of the local subscriptions and the online subscriptions
                var mappedSubs = presubs.Select(p => ResourceValuesFilter.Map(p)).ToArray();
                var serverSubs = ConnectApi.ListPresubscriptions();
                var merged = MergeLocalAndServerLists(mappedSubs, serverSubs);

                ConnectApi.UpdatePresubscriptions(merged);

                if (Immediacy == FirstValueEnum.OnValueUpdate)
                {
                    var connectedDevices = ConnectApi.ListConnectedDevices();
                    ResourceValueObservers.Where(v => v.Id == id).ToList().ForEach(v => v.ResourceValueSubscriptions.ToList().ForEach(s =>
                    {
                        // add resource subscriptions for all matching resources on connected devices
                        connectedDevices
                            .Where(d => s.DeviceId.MatchWithWildcard(d.Id))
                                .ToList()
                                .ForEach(m =>
                                {
                                    m.ListResources()
                                        .ForEach(r =>
                                        {
                                            if (!s.ResourcePaths.Any() || s.ResourcePaths.Any(p => p.MatchWithWildcard(r.Path)))
                                            {
                                                ConnectApi.AddResourceSubscription(r.DeviceId, r.Path);
                                            }
                                        });
                                });
                    }));
                }
            }
        }

        private ResourceValuesObserver ResourceValues(ResourceValuesObserver observer, FirstValueEnum immediacy)
        {
            Immediacy = immediacy;
            observer.OnSubAdded += (id) => ConstructPresubArray(id);
            observer.OnUnsubscribed += (id) => UnsubscribeSubscriptions(id);
            ResourceValueObservers.Add(observer);
            ConstructPresubArray(observer.Id);
            StartNotifications();
            return observer;
        }

        private void UnsubscribeSubscriptions(string id)
        {
            ResourceValueObservers.RemoveAll(d => d.Id == id);
            ConstructPresubArray(id);
        }
    }
}