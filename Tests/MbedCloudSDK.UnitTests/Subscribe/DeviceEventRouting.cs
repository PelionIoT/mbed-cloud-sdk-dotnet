using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MbedCloudSDK.Common;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.Connect.Api.Subscribe.Models;
using MbedCloudSDK.Connect.Model.Notifications;
using NUnit.Framework;

namespace MbedCloudSDK.UnitTests.Subscribe
{
    [TestFixture]
    public class DeviceEventRouting
    {
        [Test]
        public async Task TestAllEventsAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<DeviceEventData>();
            var observer = await subscribe.DeviceEventsAsync();
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(72, items.Count);
        }

        [Test]
        public async Task TestUnsubscribeAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<DeviceEventData>();
            var observer1 = await subscribe.DeviceEventsAsync();
            observer1.OnNotify += res => items.Add(res);
            var observer2 = await subscribe.DeviceEventsAsync();
            observer2.OnNotify += res => items.Add(res);
            var observer3 = await subscribe.DeviceEventsAsync();
            observer3.OnNotify += res => items.Add(res);
            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(subscribe.DeviceEventObservers.Count, 3);

            Assert.AreEqual(items.Count, 216);

            items.Clear();

            observer1.Unsubscribe();

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(subscribe.DeviceEventObservers.Count, 2);

            Assert.AreEqual(items.Count, 144);
        }

        [Test]
        public async Task TestOneDeviceIdAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<DeviceEventData>();
            var observer = (await subscribe.DeviceEventsAsync()).Filter(f => f.Id == "1");
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(16, items.Count);
            Assert.AreEqual(16, items.Where(d => d.DeviceId == "1").ToList().Count);
        }

        [Test]
        public async Task TestMultipleDeviceIdAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<DeviceEventData>();
            var observer = (await subscribe.DeviceEventsAsync()).Filter(f => f.Id == "1" || f.Id == "2");

            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(32, items.Count);
            Assert.AreEqual(32, items.Where(d => d.DeviceId == "1" || d.DeviceId == "2").ToList().Count);
        }

        [Test]
        public async Task TestOneStateAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<DeviceEventData>();
            var observer = (await subscribe.DeviceEventsAsync()).Filter(f => f.Event == DeviceEvent.Registration);

            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(18, items.Count);
            Assert.AreEqual(18, items.Where(d => d.State == DeviceEvent.Registration).ToList().Count);
        }

        [Test]
        public async Task TestMultipleStatesAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<DeviceEventData>();
            var observer = (await subscribe.DeviceEventsAsync()).Filter(f => f.Event == DeviceEvent.Registration || f.Event == DeviceEvent.DeRegistration);

            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(36, items.Count);
            Assert.AreEqual(36, items.Where(d => d.State == DeviceEvent.Registration || d.State == DeviceEvent.DeRegistration).ToList().Count);
        }

        [Test]
        public async Task TestSpecificAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<DeviceEventData>();
            var observer = (await subscribe.DeviceEventsAsync()).Filter(f => f.Id == "1" && f.Event == DeviceEvent.Registration);

            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(4, items.Count);
            Assert.AreEqual(4, items.Where(d => d.State == DeviceEvent.Registration && d.DeviceId == "1").ToList().Count);
        }

        [Test]
        public async Task TestMultipleSpecificAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<DeviceEventData>();
            var observer = (await subscribe.DeviceEventsAsync()).Filter(f => (f.Id == "1" || f.Id == "2") && (f.Event == DeviceEvent.Registration || f.Event == DeviceEvent.DeRegistration));

            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(16, items.Count);
        }

        [Test]
        public async Task TestMultipleSpecificWithTwoFiltersAsync()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<DeviceEventData>();
            var observer = (await subscribe.DeviceEventsAsync()).Filter(f => f.Event == DeviceEvent.Registration || f.Event == DeviceEvent.DeRegistration)
                                                   .Filter(f => f.Id == "1" || f.Id == "2");

            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(16, items.Count);
        }

        private void MockNotification(MbedCloudSDK.Connect.Api.Subscribe.Subscribe subscribe)
        {
            var regList = new List<DeviceEventData>()
            {
                new DeviceEventData() { DeviceId = "1", State = DeviceEvent.Registration },
                new DeviceEventData() { DeviceId = "1", State = DeviceEvent.Registration },
                new DeviceEventData() { DeviceId = "2", State = DeviceEvent.Registration },
                new DeviceEventData() { DeviceId = "2", State = DeviceEvent.Registration },
                new DeviceEventData() { DeviceId = "3", State = DeviceEvent.Registration },
                new DeviceEventData() { DeviceId = "3", State = DeviceEvent.Registration },
                new DeviceEventData() { DeviceId = "4", State = DeviceEvent.Registration },
                new DeviceEventData() { DeviceId = "4", State = DeviceEvent.Registration },
                new DeviceEventData() { DeviceId = "5", State = DeviceEvent.Registration },
                new DeviceEventData() { DeviceId = "1", State = DeviceEvent.DeRegistration },
                new DeviceEventData() { DeviceId = "1", State = DeviceEvent.DeRegistration },
                new DeviceEventData() { DeviceId = "2", State = DeviceEvent.DeRegistration },
                new DeviceEventData() { DeviceId = "2", State = DeviceEvent.DeRegistration },
                new DeviceEventData() { DeviceId = "3", State = DeviceEvent.DeRegistration },
                new DeviceEventData() { DeviceId = "3", State = DeviceEvent.DeRegistration },
                new DeviceEventData() { DeviceId = "4", State = DeviceEvent.DeRegistration },
                new DeviceEventData() { DeviceId = "4", State = DeviceEvent.DeRegistration },
                new DeviceEventData() { DeviceId = "5", State = DeviceEvent.DeRegistration },
                new DeviceEventData() { DeviceId = "1", State = DeviceEvent.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "1", State = DeviceEvent.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "2", State = DeviceEvent.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "2", State = DeviceEvent.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "3", State = DeviceEvent.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "3", State = DeviceEvent.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "4", State = DeviceEvent.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "4", State = DeviceEvent.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "5", State = DeviceEvent.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "1", State = DeviceEvent.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "1", State = DeviceEvent.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "2", State = DeviceEvent.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "2", State = DeviceEvent.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "3", State = DeviceEvent.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "3", State = DeviceEvent.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "4", State = DeviceEvent.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "4", State = DeviceEvent.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "5", State = DeviceEvent.ExpiredRegistration },
            };

            foreach (var item in regList)
            {
                subscribe.Notify(item);
            }
        }
    }
}