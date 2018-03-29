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

namespace ConsoleExamples.Examples.Subscribe
{
    public class SubscribeExamples
    {
        private ConnectApi connect;

        public SubscribeExamples(Config config)
        {
            connect = new ConnectApi(config);
        }

        public async Task SubscribeToAll()
        {
            // create a new subscription with no filter
            var subscription = connect.Subscribe.DeviceState();
            // add a callback to print message when recieved
            subscription.AddCallback((res) => Console.WriteLine(res));

            // take two values
            var firstValue = subscription.Take();
            var secondValue = subscription.Take();

            // mock some notification messages
            MockNotification(connect.Subscribe);

            Console.WriteLine(firstValue.Result);
            Console.WriteLine(await secondValue);

            subscription.Unsubscribe();
        }

        public async Task SubscribeToDeviceEvent()
        {
            var subscription = connect.Subscribe.DeviceState();

            // subscribe to Deregistration and Registration events
            subscription.Filter.Add(DeviceStateEnum.DeRegistration)
                               .Add(DeviceStateEnum.Registration);

            // add a callback to print message when recieved
            subscription.AddCallback((res) => Console.WriteLine(res));

            // take two values
            var firstValue = subscription.Take();
            var secondValue = subscription.Take();

            // mock some notification messages
            MockNotification(connect.Subscribe);

            Console.WriteLine(firstValue.Result);
            Console.WriteLine(await secondValue);

            subscription.Unsubscribe();
        }

        public async Task SubscribeToDeviceId()
        {
            var subscription = connect.Subscribe.DeviceState();

            // subscribe to events from devices with id "1" and "2"
            subscription.Filter.Add("1")
                               .Add("2");

            // add a callback to print message when recieved
            subscription.AddCallback((res) => Console.WriteLine(res));

            // take two values
            var firstValue = subscription.Take();
            var secondValue = subscription.Take();

            // mock some notification messages
            MockNotification(connect.Subscribe);

            Console.WriteLine(firstValue.Result);
            Console.WriteLine(await secondValue);

            subscription.Unsubscribe();
        }

        public async Task SubscribeToDeviceIdAndDeviceEvent()
        {
            var subscription = connect.Subscribe.DeviceState();

            // subscribe to DeRegistration and Registration events from devices with id "1" and "2"
            subscription.Filter.Add("1")
                               .Add("2")
                               .Add(DeviceStateEnum.DeRegistration)
                               .Add(DeviceStateEnum.Registration);

            // add a callback to print message when recieved
            subscription.AddCallback((res) => Console.WriteLine(res));

            // take two values
            var firstValue = subscription.Take();
            var secondValue = subscription.Take();

            // mock some notification messages
            MockNotification(connect.Subscribe);

            Console.WriteLine(firstValue.Result);
            Console.WriteLine(await secondValue);

            subscription.Unsubscribe();
        }

        public void SubscribeWithMultipleObservers()
        {
            // create a subscription with no filter
            var firstSubscription = connect.Subscribe.DeviceState();

            // add a callback to print message when recieved
            firstSubscription.AddCallback((res) => Console.WriteLine($"First observer - {res}"));

            // create a second subscription with filter on device with id "1"
            var secondSubscription = connect.Subscribe.DeviceState();
            secondSubscription.Filter.Add("1");

            secondSubscription.AddCallback((res) => Console.WriteLine($"Second observver - {res}"));

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
                new DeviceEventData() { DeviceId = "1", State = DeviceStateEnum.Registration },
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