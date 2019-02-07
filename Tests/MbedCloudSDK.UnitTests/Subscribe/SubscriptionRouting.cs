using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task TestAllNotifications()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = await subscribe.ResourceValuesAsync();
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(30, items.Count);
        }

        [Test]
        public async Task TestUnsubscribeAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer1 = await subscribe.ResourceValuesAsync();
            observer1.OnNotify += res => items.Add(res);
            var observer2 = await subscribe.ResourceValuesAsync();
            observer2.OnNotify += res => items.Add(res);
            var observer3 = await subscribe.ResourceValuesAsync();
            observer3.OnNotify += res => items.Add(res);
            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(subscribe.ResourceValueObservers.Count, 3);

            Assert.AreEqual(items.Count, 90);

            items.Clear();

            observer1.Unsubscribe();

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(subscribe.ResourceValueObservers.Count, 2);

            Assert.AreEqual(items.Count, 60);
        }

        [Test]
        public async Task TestPresubscriptionRefreshAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            Assert.IsEmpty(subscribe.AllLocalSubscriptions);
            var observer1 = (await subscribe.ResourceValuesAsync()).Where(new ResourceValuesFilter { DeviceId = "1", ResourcePaths = new List<string>() { "3/0/0", "3/0/1"}});
            var observer2 = (await subscribe.ResourceValuesAsync()).Where(new ResourceValuesFilter { DeviceId = "2", ResourcePaths = new List<string>() { "3/0/0", "3/0/1" } })
                                                      .Where(new ResourceValuesFilter { DeviceId = "3", ResourcePaths = new List<string>() { "3/0/0", "3/0/1" } });

            Assert.AreEqual(3, subscribe.AllLocalSubscriptions.Count);

            observer1.Unsubscribe();

            Assert.AreEqual(2, subscribe.AllLocalSubscriptions.Count);
        }

        [Test]
        public async Task TestSubscribingToOneDeviceAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = (await subscribe.ResourceValuesAsync()).Where(new ResourceValuesFilter { DeviceId = "1" });
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(6, items.Count);
        }

        [Test]
        public async Task TestSubscribingToMultipleDevicesAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = (await subscribe.ResourceValuesAsync()).Where(new ResourceValuesFilter { DeviceId = "1" })
                                                           .Where(new ResourceValuesFilter { DeviceId = "2" });
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(12, items.Count);
        }

        [Test]
        public async Task TestSubscribingToResourcePathAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = (await subscribe.ResourceValuesAsync()).Where(new ResourceValuesFilter { ResourcePaths = new List<string>() { "/3/0/0" } });
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(10, items.Count);
        }

        [Test]
        public async Task TestSubscribingToMultipleResourcePathsAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = (await subscribe.ResourceValuesAsync()).Where(new ResourceValuesFilter { ResourcePaths = new List<string>() { "/3/0/0", "/3/0/1" } })
                                                           .Where(new ResourceValuesFilter { ResourcePaths = new List<string>() { "/3/0/2" } });
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(30, items.Count);
        }

        [Test]
        public async Task TestSubscribingToMultipleResourcePathsNoStackingAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = (await subscribe.ResourceValuesAsync()).Where(new ResourceValuesFilter { ResourcePaths = new List<string>() { "/3/0/0", "/3/0/1" } })
                                                           .Where(new ResourceValuesFilter { ResourcePaths = new List<string>() { "/3/0/1" } });
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(20, items.Count);
        }

        [Test]
        public async Task TestSubscribingToOneDeviceAndPathAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = (await subscribe.ResourceValuesAsync()).Where(new ResourceValuesFilter { DeviceId = "2", ResourcePaths = new List<string>() { "/3/0/0" } });
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(2, items.Count);
        }

        [Test]
        public async Task TestSubscribingToOneDeviceAndPathsAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = (await subscribe.ResourceValuesAsync()).Where(new ResourceValuesFilter { DeviceId = "2", ResourcePaths = new List<string>() { "/3/0/0", "/3/0/1" } });
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(4, items.Count);
        }

        [Test]
        public async Task TestSubscribingToMultipleDevicesAndPathAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = (await subscribe.ResourceValuesAsync()).Where(new ResourceValuesFilter { DeviceId = "2", ResourcePaths = new List<string>() { "/3/0/0" } })
                                                           .Where(new ResourceValuesFilter { DeviceId = "3", ResourcePaths = new List<string>() { "/3/0/0" } });
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(4, items.Count);
        }

        [Test]
        public async Task TestSubscribingToMultipleDevicesAndPathsAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = (await subscribe.ResourceValuesAsync()).Where(new ResourceValuesFilter { DeviceId = "2", ResourcePaths = new List<string>() { "/3/0/0", "/3/0/2" } })
                                                           .Where(new ResourceValuesFilter { DeviceId = "3", ResourcePaths = new List<string>() { "/3/0/0", "/3/0/1" } });
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(8, items.Count);
        }

        [Test]
        public async Task TestSubscribingToAllWithWildcardAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = (await subscribe.ResourceValuesAsync()).Where(new ResourceValuesFilter { DeviceId = "*" });
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(30, items.Count);
        }

        [Test]
        public async Task TestSubscribingToAllDevicesAndSpecificPathsWithWildcardAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<ResourceValueChange>();
            var observer = (await subscribe.ResourceValuesAsync()).Where(new ResourceValuesFilter { DeviceId = "2", ResourcePaths = new List<string>() { "/3/*" } });
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