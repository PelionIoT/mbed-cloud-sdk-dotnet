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
            var observer = subscribe.DeviceState();
            observer.AddCallback((res) => items.Add(res));

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(72, items.Count);
        }

        [Test]
        public void TestOneDeviceId()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<DeviceEventData>();
            var observer = subscribe.DeviceState();
            observer.Filter.Add("1");
            observer.AddCallback((res) => items.Add(res));

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
            var observer = subscribe.DeviceState();
            observer.Filter.Add("1").Add("2");

            observer.AddCallback((res) => items.Add(res));

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
            var observer = subscribe.DeviceState();
            observer.Filter.Add(DeviceStateEnum.Registration);

            observer.AddCallback((res) => items.Add(res));

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(18, items.Count);
            Assert.AreEqual(18, items.Where(d => d.State == DeviceStateEnum.Registration).ToList().Count);
        }

        [Test]
        public void TestMultipleStates()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<DeviceEventData>();
            var observer = subscribe.DeviceState();
            observer.Filter.Add(DeviceStateEnum.Registration)
                           .Add(DeviceStateEnum.DeRegistration);

            observer.AddCallback((res) => items.Add(res));

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(36, items.Count);
            Assert.AreEqual(36, items.Where(d => d.State == DeviceStateEnum.Registration || d.State == DeviceStateEnum.DeRegistration).ToList().Count);
        }

        [Test]
        public void TestSpecific()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<DeviceEventData>();
            var observer = subscribe.DeviceState();
            observer.Filter.Add(DeviceStateEnum.Registration)
                           .Add("1");

            observer.AddCallback((res) => items.Add(res));

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(4, items.Count);
            Assert.AreEqual(4, items.Where(d => d.State == DeviceStateEnum.Registration && d.DeviceId == "1").ToList().Count);
        }

        [Test]
        public void TestMultipleSpecific()
        {
            var subscribe = new MbedCloudSDK.Connect.Api.Subscribe.Subscribe();
            var items = new List<DeviceEventData>();
            var observer = subscribe.DeviceState();
            observer.Filter.Add(DeviceStateEnum.Registration)
                           .Add("1")
                           .Add(DeviceStateEnum.DeRegistration)
                           .Add("3");

            observer.AddCallback((res) => items.Add(res));

            MockNotification(subscribe);
            MockNotification(subscribe);

            Assert.AreEqual(16, items.Count);
        }

        private void MockNotification(MbedCloudSDK.Connect.Api.Subscribe.Subscribe subscribe)
        {
            var regList = new List<DeviceEventData>()
            {
                new DeviceEventData() { DeviceId = "1", State = DeviceStateEnum.Registration },
                new DeviceEventData() { DeviceId = "1", State = DeviceStateEnum.Registration },
                new DeviceEventData() { DeviceId = "2", State = DeviceStateEnum.Registration },
                new DeviceEventData() { DeviceId = "2", State = DeviceStateEnum.Registration },
                new DeviceEventData() { DeviceId = "3", State = DeviceStateEnum.Registration },
                new DeviceEventData() { DeviceId = "3", State = DeviceStateEnum.Registration },
                new DeviceEventData() { DeviceId = "4", State = DeviceStateEnum.Registration },
                new DeviceEventData() { DeviceId = "4", State = DeviceStateEnum.Registration },
                new DeviceEventData() { DeviceId = "5", State = DeviceStateEnum.Registration },
                new DeviceEventData() { DeviceId = "1", State = DeviceStateEnum.DeRegistration },
                new DeviceEventData() { DeviceId = "1", State = DeviceStateEnum.DeRegistration },
                new DeviceEventData() { DeviceId = "2", State = DeviceStateEnum.DeRegistration },
                new DeviceEventData() { DeviceId = "2", State = DeviceStateEnum.DeRegistration },
                new DeviceEventData() { DeviceId = "3", State = DeviceStateEnum.DeRegistration },
                new DeviceEventData() { DeviceId = "3", State = DeviceStateEnum.DeRegistration },
                new DeviceEventData() { DeviceId = "4", State = DeviceStateEnum.DeRegistration },
                new DeviceEventData() { DeviceId = "4", State = DeviceStateEnum.DeRegistration },
                new DeviceEventData() { DeviceId = "5", State = DeviceStateEnum.DeRegistration },
                new DeviceEventData() { DeviceId = "1", State = DeviceStateEnum.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "1", State = DeviceStateEnum.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "2", State = DeviceStateEnum.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "2", State = DeviceStateEnum.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "3", State = DeviceStateEnum.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "3", State = DeviceStateEnum.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "4", State = DeviceStateEnum.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "4", State = DeviceStateEnum.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "5", State = DeviceStateEnum.RegistrationUpdate },
                new DeviceEventData() { DeviceId = "1", State = DeviceStateEnum.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "1", State = DeviceStateEnum.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "2", State = DeviceStateEnum.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "2", State = DeviceStateEnum.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "3", State = DeviceStateEnum.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "3", State = DeviceStateEnum.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "4", State = DeviceStateEnum.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "4", State = DeviceStateEnum.ExpiredRegistration },
                new DeviceEventData() { DeviceId = "5", State = DeviceStateEnum.ExpiredRegistration },
            };

            foreach (var item in regList)
            {
                subscribe.Notify(item);
            }
        }
    }
}