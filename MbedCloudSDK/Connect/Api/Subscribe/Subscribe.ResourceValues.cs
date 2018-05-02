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
        public List<ResourceValuesFilter> AllLocalSubscriptions { get; private set; } = new List<ResourceValuesFilter>();

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

        /// <summary>
        /// Resources the values.
        /// </summary>
        /// <param name="immediacy">The immediacy.</param>
        /// <returns>A ResourceValueObserver</returns>
        public ResourceValuesObserver ResourceValues(ImmediacyEnum immediacy = ImmediacyEnum.OnRegistration)
        {
            Immediacy = immediacy;
            var observer = new ResourceValuesObserver();
            observer.OnSubAdded += () => ConstructPresubArray();
            observer.OnUnsubscribed += (id) => UnsubscribeSubscriptions(id);
            ResourceValueObservers.Add(observer);
            StartNotifications();
            return observer;
        }

        private void ConstructPresubArray()
        {
            var presubs = new List<ResourceValuesFilter>();
            ResourceValueObservers.ForEach(s =>
            {
                s.ResourceValueSubscriptions.ForEach(p =>
                {
                    presubs.Add(p);
                });
            });

            AllLocalSubscriptions = presubs;

            if (Immediacy == ImmediacyEnum.OnValueUpdate)
            {
                if (ConnectApi != null)
                {
                    ConnectApi.UpdatePresubscriptions(presubs.Select(p => ResourceValuesFilter.Map(p)).ToArray());

                    AllLocalSubscriptions.ForEach(s =>
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
    }
}