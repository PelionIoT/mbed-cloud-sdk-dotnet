using System;
using System.Collections.Generic;
using System.Linq;
using MbedCloudSDK.Common.Extensions;
using MbedCloudSDK.Connect.Api.Subscribe.Models;
using MbedCloudSDK.Connect.Api.Subscribe.Observers.ResourceValues;
using MbedCloudSDK.Connect.Model.Notifications;
using MbedCloudSDK.Connect.Model.Subscription;

namespace MbedCloudSDK.Connect.Api.Subscribe
{
    public partial class Subscribe
    {
        public List<ResourceValuesObserver> ResourceValueObservers { get; private set; } = new List<ResourceValuesObserver>();

        public List<ResourceValuesFilter> AllLocalSubscriptions { get; private set; } = new List<ResourceValuesFilter>();

        public ImmediacyEnum Immediacy { get; private set; }

        public ResourceValuesObserver ResourceValues(ImmediacyEnum Immediacy = ImmediacyEnum.OnRegistration)
        {
            this.Immediacy = Immediacy;
            var observer = new ResourceValuesObserver();
            observer.OnSubAdded += () => ConstructPresubArray();
            observer.OnUnsubscribed += (Id) => UnsubscribeSubscriptions(Id);
            ResourceValueObservers.Add(observer);
            StartNotifications();
            return observer;
        }

        public void Notify(NotificationData data)
        {
            ResourceValueObservers.ForEach(o =>
            {
                o.Notify(data);
            });
        }

        private void UnsubscribeSubscriptions(string Id)
        {
            ResourceValueObservers.RemoveAll(d => d.Id == Id);
            ConstructPresubArray();
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
    }
}