using System.Collections.Generic;
using System.Linq;
using MbedCloudSDK.Connect.Api.Subscribe.Observers.Subscriptions;
using MbedCloudSDK.Connect.Model.Notifications;
using MbedCloudSDK.Connect.Model.Subscription;

namespace MbedCloudSDK.Connect.Api.Subscribe
{
    public partial class Subscribe
    {
        public List<SubscriptionObserver> SubscriptionObservers { get; set; } = new List<SubscriptionObserver>();

        public List<Presubscription> Presubscriptions { get; set; } = new List<Presubscription>();

        public SubscriptionObserver ResourceValueChanges()
        {
            var observer = new SubscriptionObserver();
            observer.OnPresubAdded += () => ConstructPresubArray();
            observer.OnUnsubscribed += (Id) => UnsubscribeSubscriptions(Id);
            SubscriptionObservers.Add(observer);
            StartNotifications();
            return observer;
        }

        public void Notify(NotificationData data)
        {
            SubscriptionObservers.ForEach(o =>
            {
                o.Notify(data);
            });
        }

        private void UnsubscribeSubscriptions(string Id)
        {
            SubscriptionObservers.RemoveAll(d => d.Id == Id);
            ConstructPresubArray();
        }

        private void ConstructPresubArray()
        {
            var presubs = new List<Presubscription>();
            SubscriptionObservers.ForEach(s =>
            {
                s.Presubscriptions.ForEach(p =>
                {
                    presubs.Add(p);
                });
            });

            Presubscriptions = presubs;

            if (ConnectApi != null)
            {
                ConnectApi.UpdatePresubscriptions(presubs.ToArray());
            }
        }
    }
}