using System;
using System.Collections.Generic;
using System.Threading;
using MbedCloudSDK.Common;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.Connect.Model.Notifications;
using MbedCloudSDK.Connect.Api.Subscribe;
using MbedCloudSDK.Connect.Api.Subscribe.Models;
using MbedCloudSDK.Connect.Api.Subscribe.Observers;
using System.Threading.Tasks;
using MbedCloudSDK.Connect.Model.Subscription;

namespace ConsoleExamples.Examples.Subscribe
{
    public class SubscribeExamples
    {
        private ConnectApi connect;

        public SubscribeExamples(Config config)
        {
            connect = new ConnectApi(config);
        }

        public async Task PreSubscription()
        {
            var sub = connect.Subscribe.ResourceValues().Where(r => (r.DeviceId == "124" && r.ResourcePaths.Contains("/3/0/2")) || (r.DeviceId == "123" && r.ResourcePaths.Contains("/3/0/1")));

            var nextValue = await sub.Next();

            Console.WriteLine(nextValue);
        }

        public async Task SubscribeToAll()
        {
            // create a new subscription with no filter
            var subscription = connect.Subscribe.DeviceEvents();

            subscription.OnNotify += (res) => { Console.WriteLine(res); };

            // take two values
            var firstValue = subscription.Next();
            var secondValue = subscription.Next();

            // mock some notification messages
            MockNotification(connect.Subscribe);

            Console.WriteLine(firstValue.Result);
            Console.WriteLine(await secondValue);

            subscription.Unsubscribe();
        }

        public async Task SubscribeToDeviceEvent()
        {
            // subscribe to Deregistration and Registration events
            var subscription = connect.Subscribe.DeviceEvents().Where(f => f.Event == DeviceEventEnum.DeRegistration || f.Event == DeviceEventEnum.Registration);

            // add a callback to print message when recieved
            subscription.OnNotify += (res) => Console.WriteLine(res);

            // take two values
            var firstValue = subscription.Next();
            var secondValue = subscription.Next();

            // mock some notification messages
            MockNotification(connect.Subscribe);

            Console.WriteLine(firstValue.Result);
            Console.WriteLine(await secondValue);

            subscription.Unsubscribe();
        }

        public async Task SubscribeToDeviceId()
        {
            // subscribe to events from devices with id "1" and "2"
            var subscription = connect.Subscribe.DeviceEvents().Where(f => f.Id == "1" || f.Id == "2");

            // add a callback to print message when recieved
            subscription.OnNotify += (res) => Console.WriteLine(res);

            // take two values
            var firstValue = subscription.Next();
            var secondValue = subscription.Next();

            // mock some notification messages
            MockNotification(connect.Subscribe);

            Console.WriteLine(firstValue.Result);
            Console.WriteLine(await secondValue);

            subscription.Unsubscribe();
        }

        public async Task SubscribeToDeviceIdAndDeviceEvent()
        {
            // subscribe to DeRegistration and Registration events from devices with id "1" and "2"
            var subscription = connect.Subscribe.DeviceEvents().Where(f => (f.Id == "1" || f.Id == "2") && (f.Event == DeviceEventEnum.DeRegistration || f.Event == DeviceEventEnum.Registration));

            // add a callback to print message when recieved
            subscription.OnNotify += (res) => Console.WriteLine(res);

            // take two values
            var firstValue = subscription.Next();
            var secondValue = subscription.Next();

            // mock some notification messages
            MockNotification(connect.Subscribe);

            Console.WriteLine(firstValue.Result);
            Console.WriteLine(await secondValue);

            subscription.Unsubscribe();
        }

        public void SubscribeWithMultipleObservers()
        {
            // create a subscription with no filter
            var firstSubscription = connect.Subscribe.DeviceEvents();

            // add a callback to print message when recieved
            firstSubscription.OnNotify += (res) => Console.WriteLine($"First observer - {res}");

            // create a second subscription with filter on device with id "1"
            var secondSubscription = connect.Subscribe.DeviceEvents().Where(f => f.Id == "1");

            secondSubscription.OnNotify += (res) => Console.WriteLine($"Second observver - {res}");

            // mock some notification messages
            MockNotification(connect.Subscribe);

            // both subscriptions will be notified

            firstSubscription.Unsubscribe();
            secondSubscription.Unsubscribe();
        }

        /// <summary>
        /// Mock a notification message
        /// </summary>
        /// <param name="subscribe"></param>
        private void MockNotification(MbedCloudSDK.Connect.Api.Subscribe.Subscribe subscribe)
        {
            var regList = new List<DeviceEventData>()
            {
                new DeviceEventData() { DeviceId = "1", State = DeviceEventEnum.Registration },
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