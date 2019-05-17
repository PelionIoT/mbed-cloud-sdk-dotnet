// <copyright file="Subscribe.ResourceValues.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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
        public FirstValueImmediacy Immediacy { get; private set; }

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
                o.NotifyAsync(data);
            });
        }

        /// <summary>
        /// Resources the values.
        /// </summary>
        /// <param name="immediacy">The immediacy.</param>
        /// <returns>ResourceValueObserver</returns>
        public async Task<ResourceValuesObserver> ResourceValuesAsync(FirstValueImmediacy immediacy = FirstValueImmediacy.OnValueUpdate)
        {
            var observer = new ResourceValuesObserver();
            return await ResourceValuesCoreAsync(observer, immediacy);
        }

        /// <summary>
        /// Resources the values.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="immediacy">The immediacy.</param>
        /// <returns>ResourceValueObserver</returns>
        public async Task<ResourceValuesObserver> ResourceValuesAsync(string deviceId, FirstValueImmediacy immediacy = FirstValueImmediacy.OnValueUpdate)
        {
            var observer = new ResourceValuesObserver(deviceId, Enumerable.Empty<string>());
            return await ResourceValuesCoreAsync(observer, immediacy);
        }

        /// <summary>
        /// Resources the values.
        /// </summary>
        /// <param name="resourcePaths">The resource paths.</param>
        /// <param name="immediacy">The immediacy.</param>
        /// <returns>ResourceValueObserver</returns>
        public async Task<ResourceValuesObserver> ResourceValuesAsync(List<string> resourcePaths, FirstValueImmediacy immediacy = FirstValueImmediacy.OnValueUpdate)
        {
            var observer = new ResourceValuesObserver("*", resourcePaths);
            return await ResourceValuesCoreAsync(observer, immediacy);
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
        public async Task<ResourceValuesObserver> ResourceValuesAsync(List<string> deviceIds, List<string> resourcePaths, FirstValueImmediacy immediacy = FirstValueImmediacy.OnValueUpdate)
        {
            var observer = new ResourceValuesObserver(deviceIds, resourcePaths);
            return await ResourceValuesCoreAsync(observer, immediacy);
        }

        /// <summary>
        /// Resources the values.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="resourcePaths">The resource paths.</param>
        /// <param name="immediacy">The immediacy.</param>
        /// <returns>ResourceValueObserver</returns>
        public async Task<ResourceValuesObserver> ResourceValuesAsync(string deviceId, List<string> resourcePaths, FirstValueImmediacy immediacy = FirstValueImmediacy.OnValueUpdate)
        {
            var observer = new ResourceValuesObserver(deviceId, resourcePaths);
            return await ResourceValuesCoreAsync(observer, immediacy);
        }

        /// <summary>
        /// Resources the values.
        /// </summary>
        /// <param name="deviceIds">The device ids.</param>
        /// <param name="resourcePath">The resource path.</param>
        /// <param name="immediacy">The immediacy.</param>
        /// <returns>ResourceValueObserver</returns>
        public async Task<ResourceValuesObserver> ResourceValuesAsync(List<string> deviceIds, string resourcePath, FirstValueImmediacy immediacy = FirstValueImmediacy.OnValueUpdate)
        {
            var observer = new ResourceValuesObserver(deviceIds, resourcePath);
            return await ResourceValuesCoreAsync(observer, immediacy);
        }

        /// <summary>
        /// Resources the values.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="resourcePath">The resource path.</param>
        /// <param name="immediacy">The immediacy.</param>
        /// <returns>ResourceValueObserver</returns>
        public async Task<ResourceValuesObserver> ResourceValuesAsync(string deviceId, string resourcePath, FirstValueImmediacy immediacy = FirstValueImmediacy.OnValueUpdate)
        {
            var observer = new ResourceValuesObserver(deviceId, resourcePath);
            return await ResourceValuesCoreAsync(observer, immediacy);
        }

        private static Presubscription[] MergeLocalAndServerLists(IEnumerable<Presubscription> local, IEnumerable<Presubscription> server)
        {
            return local.Union(server, new PresubscriptionComparer()).ToArray();
        }

        private void ConstructPresubscriptionArray(string id)
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

                if (Immediacy == FirstValueImmediacy.OnValueUpdate)
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
                                        .ToList()
                                        .ForEach(async r =>
                                        {
                                            if (!s.ResourcePaths.Any() || s.ResourcePaths.Any(p => p.MatchWithWildcard(r.Path)))
                                            {
                                                await ConnectApi.AddResourceSubscriptionAsync(r.DeviceId, r.Path);
                                            }
                                        });
                                });
                    }));
                }
            }
        }

        /// <summary>
        /// Resources the values core asynchronous.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <param name="immediacy">The immediacy.</param>
        /// <returns>Resource value observer</returns>
        protected virtual async Task<ResourceValuesObserver> ResourceValuesCoreAsync(ResourceValuesObserver observer, FirstValueImmediacy immediacy)
        {
            Immediacy = immediacy;
            observer.OnFilterAdded += (id) => ConstructPresubscriptionArray(id);
            observer.OnUnsubscribed += (id) => UnsubscribeSubscriptions(id);
            ResourceValueObservers.Add(observer);
            ConstructPresubscriptionArray(observer.Id);
            await StartNotificationsAsync();
            return observer;
        }

        private void UnsubscribeSubscriptions(string id)
        {
            ResourceValueObservers.RemoveAll(d => d.Id == id);
            ConstructPresubscriptionArray(id);
        }
    }
}