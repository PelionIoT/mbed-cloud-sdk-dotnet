using System;
using System.Collections.Generic;
using System.Linq;
using MbedCloudSDK.Common;
using MbedCloudSDK.Connect.Api.Subscribe.Models;
using MbedCloudSDK.Connect.Model.Notifications;
using MbedCloudSDK.Connect.Model.Subscription;

namespace MbedCloudSDK.Connect.Api.Subscribe.Observers.Subscriptions
{
    /// <summary>
    /// <see cref="SubscriptionObserver"/>
    /// </summary>
    public class SubscriptionObserver : Observer<PresubscriptionReturnPlaceholder, string>
    {
        public delegate void PresubAddedRaiser();

        public event PresubAddedRaiser OnPresubAdded;

        public List<PresubscriptionPlaceholder> Presubscriptions { get; } = new List<PresubscriptionPlaceholder>();

        public new void Notify(NotificationData data)
        {
            if (!Presubscriptions.Any() || Presubscriptions.FirstOrDefault(p => p.Equals(data)) != null)
            {
                base.Notify(PresubscriptionReturnPlaceholder.Map(data));
            }
        }

        public SubscriptionObserver Where(PresubscriptionPlaceholder subscription)
        {
            Presubscriptions.Add(subscription);
            OnPresubAdded();
            return this;
        }
    }
}