using System;
using System.Collections.Generic;
using System.Linq;
using MbedCloudSDK.Common;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.Connect.Api.Subscribe.Models;
using MbedCloudSDK.Connect.Model.Notifications;
using NUnit.Framework;

namespace MbedCloudSDK.UnitTests.Subscribe
{
    [TestFixture]
    public class Routing
    {
        [Test]
        public void TestAllEvents()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<DeviceEventData>();
            var observer = subscribe.DeviceEvents();
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(72, items.Count);
        }

        [Test]
        public void TestOneDeviceId()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<DeviceEventData>();
            var observer = subscribe.DeviceEvents().Where(f => f.Id == "1");
            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(16, items.Count);
            Assert.AreEqual(16, items.Where(d => d.DeviceId == "1").ToList().Count);
        }

        [Test]
        public void TestMultipleDeviceId()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<DeviceEventData>();
            var observer = subscribe.DeviceEvents().Where(f => f.Id == "1" || f.Id == "2");

            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(32, items.Count);
            Assert.AreEqual(32, items.Where(d => d.DeviceId == "1" || d.DeviceId == "2").ToList().Count);
        }

        [Test]
        public void TestOneState()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<DeviceEventData>();
            var observer = subscribe.DeviceEvents().Where(f => f.Event == DeviceEventEnum.Registration);

            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(18, items.Count);
            Assert.AreEqual(18, items.Where(d => d.State == DeviceEventEnum.Registration).ToList().Count);
        }

        [Test]
        public void TestMultipleStates()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<DeviceEventData>();
            var observer = subscribe.DeviceEvents().Where(f => f.Event == DeviceEventEnum.Registration || f.Event == DeviceEventEnum.DeRegistration);

            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(36, items.Count);
            Assert.AreEqual(36, items.Where(d => d.State == DeviceEventEnum.Registration || d.State == DeviceEventEnum.DeRegistration).ToList().Count);
        }

        [Test]
        public void TestSpecific()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<DeviceEventData>();
            var observer = subscribe.DeviceEvents().Where(f => f.Id == "1" && f.Event == DeviceEventEnum.Registration);

            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(4, items.Count);
            Assert.AreEqual(4, items.Where(d => d.State == DeviceEventEnum.Registration && d.DeviceId == "1").ToList().Count);
        }

        [Test]
        public void TestMultipleSpecific()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<DeviceEventData>();
            var observer = subscribe.DeviceEvents().Where(f => (f.Id == "1" || f.Id == "2") && (f.Event == DeviceEventEnum.Registration || f.Event == DeviceEventEnum.DeRegistration));

            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(16, items.Count);
        }

        [Test]
        public void TestMultipleSpecificWithTwoFilters()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<DeviceEventData>();
            var observer = subscribe.DeviceEvents().Where(f => f.Event == DeviceEventEnum.Registration || f.Event == DeviceEventEnum.DeRegistration)
                                                   .Where(f => f.Id == "1" || f.Id == "2");

            observer.OnNotify += res => items.Add(res);

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(16, items.Count);
        }

        private void MockNotification(MbedCloudSDK.Connect.Api.Subscribe.Subscribe subscribe)
        {
            var regList = new List<DeviceEventData>()
            {
                new DeviceEventData() { DeviceId = "1", State = DeviceEventEnum.Registration },
                new DeviceEventData() { DeviceId = "1", State = DeviceEventEnum.Registration },
                new DeviceEventData() { DeviceId = "2", State = DeviceEventEnum.Registration },
                new DeviceEventData() { DeviceId = "2", State = DeviceEventEnum.Registration },
                new DeviceEventData() { DeviceId = "3", State = DeviceEventEnum.Registration },
                new DeviceEventData() { DeviceId = "3", State = DeviceEventEnum.Registration },
                new DeviceEventData() { DeviceId = "4", State = DeviceEventEnum.Registration },
                new DeviceEventData() { DeviceId = "4", State = DeviceEventEnum.Registration },
                new DeviceEventData() { DeviceId = "5", State = DeviceEventEnum.Registration },
                new DeviceEventData() { DeviceId = "1", State = DeviceEventEnum.DeRegistration },
                new DeviceEventData() { DeviceId = "1", State = DeviceEventEnum.DeRegistration },
                new DeviceEventData() { DeviceId = "2", State = DeviceEventEnum.DeRegistration },
                new DeviceEventData() { DeviceId = "2", State = DeviceEventEnum.DeRegistration },
                new DeviceEventData() { DeviceId = "3", State = DeviceEventEnum.DeRegistration },
                new DeviceEventData() { DeviceId = "3", State = DeviceEventEnum.DeRegistration },
                new DeviceEventData() { DeviceId = "4", State = DeviceEventEnum.DeRegistration },
                new DeviceEventData() { DeviceId = "4", State = DeviceEventEnum.DeRegistration },
                new DeviceEventData() { DeviceId = "5", State = DeviceEventEnum.DeRegistration },
                new DeviceEventData() { DeviceId = "1", State = DeviceEventEnum.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "1", State = DeviceEventEnum.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "2", State = DeviceEventEnum.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "2", State = DeviceEventEnum.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "3", State = DeviceEventEnum.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "3", State = DeviceEventEnum.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "4", State = DeviceEventEnum.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "4", State = DeviceEventEnum.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "5", State = DeviceEventEnum.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "1", State = DeviceEventEnum.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "1", State = DeviceEventEnum.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "2", State = DeviceEventEnum.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "2", State = DeviceEventEnum.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "3", State = DeviceEventEnum.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "3", State = DeviceEventEnum.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "4", State = DeviceEventEnum.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "4", State = DeviceEventEnum.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "5", State = DeviceEventEnum.ExpiredRegistration },
            };

            foreach (var item in regList)
            {
                subscribe.Notify(item);
            }
        }
    }
}