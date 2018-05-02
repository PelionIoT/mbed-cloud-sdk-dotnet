using System.Collections.Generic;
using MbedCloudSDK.Connect.Api.Subscribe.Models;
using MbedCloudSDK.Connect.Model.Notifications;
using MbedCloudSDK.Connect.Model.Subscription;
using NUnit.Framework;

namespace MbedCloudSDK.UnitTests.Subscribe
{
    [TestFixture]
    public class SubscriptionRouting
    {
        [Test]
        public void TestAllNotifications()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = subscribe.ResourceValues();
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(30, items.Count);
        }

        [Test]
        public void TestUnsubscribe()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer1 = subscribe.ResourceValues();
            observer1.OnNotify += res => items.Add(res);
            var observer2 = subscribe.ResourceValues();
            observer2.OnNotify += res => items.Add(res);
            var observer3 = subscribe.ResourceValues();
            observer3.OnNotify += res => items.Add(res);
            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(subscribe.SubscriptionObservers.Count, 3);

            Assert.AreEqual(items.Count, 90);

            items.Clear();

            observer1.Unsubscribe();

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(subscribe.SubscriptionObservers.Count, 2);

            Assert.AreEqual(items.Count, 60);
        }

        [Test]
        public void TestPresubscriptionRefresh()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            Assert.IsEmpty(subscribe.AllLocalSubscriptions);
            var observer1 = subscribe.ResourceValues().Where(new ResourceValuesFilter { DeviceId = "1", ResourcePaths = new List<string>() { "3/0/0", "3/0/1"}});
            var observer2 = subscribe.ResourceValues().Where(new ResourceValuesFilter { DeviceId = "2", ResourcePaths = new List<string>() { "3/0/0", "3/0/1" } })
                                                            .Where(new ResourceValuesFilter { DeviceId = "3", ResourcePaths = new List<string>() { "3/0/0", "3/0/1" } });

            Assert.AreEqual(3, subscribe.AllLocalSubscriptions.Count);

            observer1.Unsubscribe();

            Assert.AreEqual(2, subscribe.AllLocalSubscriptions.Count);
        }

        [Test]
        public void TestSubscribingToOneDevice()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = subscribe.ResourceValues().Where(new ResourceValuesFilter { DeviceId = "1" });
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(6, items.Count);
        }

        [Test]
        public void TestSubscribingToMultipleDevices()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = subscribe.ResourceValues().Where(new ResourceValuesFilter { DeviceId = "1" })
                                                           .Where(new ResourceValuesFilter { DeviceId = "2" });
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(12, items.Count);
        }

        [Test]
        public void TestSubscribingToResourcePath()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = subscribe.ResourceValues().Where(new ResourceValuesFilter { ResourcePaths = new List<string>() { "/3/0/0" } });
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(10, items.Count);
        }

        [Test]
        public void TestSubscribingToMultipleResourcePaths()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = subscribe.ResourceValues().Where(new ResourceValuesFilter { ResourcePaths = new List<string>() { "/3/0/0", "/3/0/1" } })
                                                           .Where(new ResourceValuesFilter { ResourcePaths = new List<string>() { "/3/0/2" } });
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(30, items.Count);
        }

        [Test]
        public void TestSubscribingToMultipleResourcePathsNoStacking()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = subscribe.ResourceValues().Where(new ResourceValuesFilter { ResourcePaths = new List<string>() { "/3/0/0", "/3/0/1" } })
                                                           .Where(new ResourceValuesFilter { ResourcePaths = new List<string>() { "/3/0/1" } });
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(20, items.Count);
        }

        [Test]
        public void TestSubscribingToOneDeviceAndPath()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = subscribe.ResourceValues().Where(new ResourceValuesFilter { DeviceId = "2", ResourcePaths = new List<string>() { "/3/0/0" } });
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(2, items.Count);
        }

        [Test]
        public void TestSubscribingToOneDeviceAndPaths()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = subscribe.ResourceValues().Where(new ResourceValuesFilter { DeviceId = "2", ResourcePaths = new List<string>() { "/3/0/0", "/3/0/1" } });
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(4, items.Count);
        }

        [Test]
        public void TestSubscribingToMultipleDevicesAndPath()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = subscribe.ResourceValues().Where(new ResourceValuesFilter { DeviceId = "2", ResourcePaths = new List<string>() { "/3/0/0" } })
                                                           .Where(new ResourceValuesFilter { DeviceId = "3", ResourcePaths = new List<string>() { "/3/0/0" } });
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(4, items.Count);
        }

        [Test]
        public void TestSubscribingToMultipleDevicesAndPaths()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = subscribe.ResourceValues().Where(new ResourceValuesFilter { DeviceId = "2", ResourcePaths = new List<string>() { "/3/0/0", "/3/0/2" } })
                                                           .Where(new ResourceValuesFilter { DeviceId = "3", ResourcePaths = new List<string>() { "/3/0/0", "/3/0/1" } });
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(8, items.Count);
        }

        [Test]
        public void TestSubscribingToAllWithWildcard()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = subscribe.ResourceValues().Where(new ResourceValuesFilter { DeviceId = "*" });
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(30, items.Count);
        }

        [Test]
        public void TestSubscribingToAllDevicesAndSpecificPathsWithWildcard()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = subscribe.ResourceValues().Where(new ResourceValuesFilter { DeviceId = "2", ResourcePaths = new List<string>() { "/3/*" } });
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(6, items.Count);
        }

        private void MockNotification(MbedCloudSDK.Connect.Api.Subscribe.Subscribe subscribe)
        {
            var notificationList = new List<NotificationData>()
            {
                new NotificationData() { DeviceId = "1", Path = "/3/0/0", Payload = "SGk=" },
                new NotificationData() { DeviceId = "1", Path = "/3/0/1", Payload = "SGk=" },
                new NotificationData() { DeviceId = "1", Path = "/3/0/2", Payload = "SGk=" },
                new NotificationData() { DeviceId = "2", Path = "/3/0/0", Payload = "SGk=" },
                new NotificationData() { DeviceId = "2", Path = "/3/0/1", Payload = "SGk=" },
                new NotificationData() { DeviceId = "2", Path = "/3/0/2", Payload = "SGk=" },
                new NotificationData() { DeviceId = "3", Path = "/3/0/0", Payload = "SGk=" },
                new NotificationData() { DeviceId = "3", Path = "/3/0/1", Payload = "SGk=" },
                new NotificationData() { DeviceId = "3", Path = "/3/0/2", Payload = "SGk=" },
                new NotificationData() { DeviceId = "4", Path = "/3/0/0", Payload = "SGk=" },
                new NotificationData() { DeviceId = "4", Path = "/3/0/1", Payload = "SGk=" },
                new NotificationData() { DeviceId = "4", Path = "/3/0/2", Payload = "SGk=" },
                new NotificationData() { DeviceId = "5", Path = "/3/0/0", Payload = "SGk=" },
                new NotificationData() { DeviceId = "5", Path = "/3/0/1", Payload = "SGk=" },
                new NotificationData() { DeviceId = "5", Path = "/3/0/2", Payload = "SGk=" },
            };

            notificationList.ForEach(n =>
            {
                subscribe.Notify(n);
            });
        }
    }
}