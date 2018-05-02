using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MbedCloudSDK.Common;
using MbedCloudSDK.Connect.Api.Subscribe.Models;
using MbedCloudSDK.Connect.Model.Notifications;
using MbedCloudSDK.Connect.Model.Subscription;
using Newtonsoft.Json;

namespace MbedCloudSDK.Connect.Api.Subscribe.Observers.Subscriptions
{
    /// <summary>
    /// <see cref="SubscriptionObserver"/>
    /// </summary>
    public class SubscriptionObserver : Observer<ResourceValueChange, string>
    {
        public delegate void SubAddedRaiser();

        public event SubAddedRaiser OnSubAdded;

        public List<ResourceValuesFilter> ResourceValueSubscriptions { get; } = new List<ResourceValuesFilter>();

        public List<Func<ResourceValuesFilter, bool>> LocalFilters { get; } = new List<Func<ResourceValuesFilter, bool>>();

        public SubscriptionObserver() { }

        public SubscriptionObserver(string DeviceId, List<string> ResourcePaths)
         : this(new List<string>() { DeviceId }, ResourcePaths) { }

        public SubscriptionObserver(List<string> DeviceIds, string ResourcePath)
         : this(DeviceIds, new List<string>() { ResourcePath }) { }

        public SubscriptionObserver(string DeviceId, string ResourcePath)
         : this(new List<string>() { DeviceId }, new List<string>() { ResourcePath }) { }

        public SubscriptionObserver(List<string> DeviceIds, List<string> ResourcePaths)
        {
            DeviceIds.ForEach(r => {
                var sub = new ResourceValuesFilter() { DeviceId = r, ResourcePaths = ResourcePaths };
                ResourceValueSubscriptions.Add(sub);
            });

            OnSubAdded();
        }

        public new void Notify(NotificationData data)
        {
            if (!ResourceValueSubscriptions.Any() || ResourceValueSubscriptions.FirstOrDefault(p => p.Equals(data)) != null)
            {
                if (RunLocalFilters(data))
                {
                    base.Notify(ResourceValueChange.Map(data));
                }
            }
        }

        private bool RunLocalFilters(NotificationData data)
        {
            if (LocalFilters.Any())
            {
                return LocalFilters.TrueForAll(f => f.Invoke(new ResourceValuesFilter() { DeviceId = data.DeviceId, ResourcePaths = new List<string>() { data.Path } }));
            }

            return true;
        }

        public SubscriptionObserver Where(ResourceValuesFilter subscription)
        {
            ResourceValueSubscriptions.Add(subscription);
            OnSubAdded();
            return this;
        }

        public SubscriptionObserver Where(string DeviceId, params string[] ResourcePaths)
        {
            var sub = new ResourceValuesFilter() { DeviceId = DeviceId, ResourcePaths = ResourcePaths.ToList() };
            ResourceValueSubscriptions.Add(sub);
            OnSubAdded();
            return this;
        }

        public SubscriptionObserver Where(Func<ResourceValuesFilter, bool> predicate)
        {
            LocalFilters.Add(predicate);
            return this;
        }
    }
}