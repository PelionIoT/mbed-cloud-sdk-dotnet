// <copyright file="Subscribe.ResourceValues.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe
{
    using System.Collections.Generic;
    using System.Linq;
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
        public HashSet<ResourceValuesFilter> AllLocalSubscriptions { get; private set; } = new HashSet<ResourceValuesFilter>(new ResourceValuesFilterComparer());

        /// <summary>
        /// Gets the immediacy.
        /// </summary>
        /// <value>
        /// The immediacy.
        /// </value>
        public ImmediacyEnum Immediacy { get; private set; }

        /// <summary>
        /// Gets the resource value observers.
        /// </summary>
        /// <value>
        /// The resource value observers.
        /// </value>
        public List<ResourceValuesObserver> ResourceValueObservers { get; private set; } = new List<ResourceValuesObserver>();

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

        public ResourceValuesObserver ResourceValues(ImmediacyEnum immediacy = ImmediacyEnum.OnRegistration)
        {
            var observer = new ResourceValuesObserver();
            return resourceValues(observer, immediacy);
        }

        public ResourceValuesObserver ResourceValues(string deviceId, ImmediacyEnum immediacy = ImmediacyEnum.OnRegistration)
        {
            var observer = new ResourceValuesObserver(deviceId, Enumerable.Empty<string>());
            return resourceValues(observer, immediacy);
        }

        public ResourceValuesObserver ResourceValues(List<string> resourcePAths, ImmediacyEnum immediacy = ImmediacyEnum.OnRegistration)
        {
            var observer = new ResourceValuesObserver();
            return resourceValues(observer, immediacy);
        }

        /// <summary>
        /// Resources the values.
        /// </summary>
        /// <param name="immediacy">The immediacy.</param>
        /// <returns>A ResourceValueObserver</returns>
        public ResourceValuesObserver ResourceValues(List<string> deviceIds, List<string> resourcePaths, ImmediacyEnum immediacy = ImmediacyEnum.OnRegistration)
        {
            var observer = new ResourceValuesObserver(deviceIds, resourcePaths);
            return resourceValues(observer, immediacy);
        }

        public ResourceValuesObserver ResourceValues(string deviceId, List<string> resourcePaths, ImmediacyEnum immediacy = ImmediacyEnum.OnRegistration)
        {
            var observer = new ResourceValuesObserver(deviceId, resourcePaths);
            return resourceValues(observer, immediacy);
        }

        public ResourceValuesObserver ResourceValues(List<string> deviceIds, string resourcePath, ImmediacyEnum immediacy = ImmediacyEnum.OnRegistration)
        {
            var observer = new ResourceValuesObserver(deviceIds, resourcePath);
            return resourceValues(observer, immediacy);
        }

        public ResourceValuesObserver ResourceValues(string deviceId, string resourcePath, ImmediacyEnum immediacy = ImmediacyEnum.OnRegistration)
        {
            var observer = new ResourceValuesObserver(deviceId, resourcePath);
            return resourceValues(observer, immediacy);
        }

        private ResourceValuesObserver resourceValues(ResourceValuesObserver observer, ImmediacyEnum immediacy)
        {
            Immediacy = immediacy;
            observer.OnSubAdded += () => ConstructPresubArray();
            observer.OnUnsubscribed += (id) => UnsubscribeSubscriptions(id);
            ResourceValueObservers.Add(observer);
            ConstructPresubArray();
            StartNotifications();
            return observer;
        }

        private void ConstructPresubArray()
        {
            var presubs = new HashSet<ResourceValuesFilter>();
            ResourceValueObservers.ForEach(s =>
            {
                presubs = presubs.Union(s.ResourceValueSubscriptions).ToHashSet(new ResourceValuesFilterComparer());
            });

            AllLocalSubscriptions = presubs;

            if (ConnectApi != null)
            {
                var mappedSubs = presubs.Select(p => ResourceValuesFilter.Map(p)).ToArray();
                var serverSubs = ConnectApi.ListPresubscriptions();
                var merged = MergeLocalAndServerLists(mappedSubs, serverSubs);

                ConnectApi.UpdatePresubscriptions(merged);

                if (Immediacy == ImmediacyEnum.OnValueUpdate)
                {
                    AllLocalSubscriptions.ToList().ForEach(s =>
                    {
                        ConnectApi.ListConnectedDevices().Data
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
                    });
                }
            }
        }



        private void UnsubscribeSubscriptions(string id)
        {
            ResourceValueObservers.RemoveAll(d => d.Id == id);
            ConstructPresubArray();
        }

        private Presubscription[] MergeLocalAndServerLists(IEnumerable<Presubscription> local, IEnumerable<Presubscription> server)
        {
            return local.Union(server, new PresubscriptionComparer()).ToArray();
        }
    }

    public static class Extensions
    {
        public static HashSet<T> ToHashSet<T>(
            this IEnumerable<T> source,
            IEqualityComparer<T> comparer = null)
        {
            return new HashSet<T>(source, comparer);
        }
    }
}