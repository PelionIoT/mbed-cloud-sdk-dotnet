using System;
using System.Collections.Generic;
using System.Linq;
using MbedCloudSDK.Connect.Model.Notifications;
using MbedCloudSDK.Connect.Model.Subscription;

namespace MbedCloudSDK.Connect.Api.Subscribe.Observers.Subscriptions
{
    /// <summary>
    /// <see cref="SubscriptionObserver"/>
    /// </summary>
    public class SubscriptionObserver : Observer<NotificationData, string>
    {
        public delegate void PresubAddedRaiser();

        public event PresubAddedRaiser OnPresubAdded;

        public List<Presubscription> Presubscriptions { get; } = new List<Presubscription>();

        public new void Notify(NotificationData data)
        {
            if (!Presubscriptions.Any() || Presubscriptions.FirstOrDefault(p => p.Equals(data)) != null)
            {
                base.Notify(data);
            }
        }

        public SubscriptionObserver Where(Presubscription subscription)
        {
            Presubscriptions.Add(subscription);
            OnPresubAdded();
            return this;
        }
    }
}