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
using System.Linq;
using Mbed.Cloud.Foundation.Common;

namespace ConsoleExamples.Examples.Subscribe
{
    public class SubscribeExamples
    {
        private ConnectApi connect;

        public SubscribeExamples(Config config)
        {
            connect = new ConnectApi(config);
        }

        public async Task ResourceValues()
        {
            // subscribe to everything
            var blankSub = await connect.Subscribe.ResourceValuesAsync();

            // by default, ResourceValues() will create subscriptions for all matching resources. To turn this off set first value to "OnRegistration".
            var blankSubImmediate = await connect.Subscribe.ResourceValuesAsync(FirstValueImmediacy.OnRegistration);

            // subscribe to one resource on a device
            var deviceIdSub = await connect.Subscribe.ResourceValuesAsync("1", "3/0/1");

            // subscribe to multiple resources on a device
            var deviceIdSub2 = await connect.Subscribe.ResourceValuesAsync("1", new List<string> { "3/0/1, 3/0/2" });

            // use wildcard for resource paths
            var deviceIdSub3 = await connect.Subscribe.ResourceValuesAsync("1", "3/0/*");

            // can add further filters
            deviceIdSub3.Filter("1", "4/0/1");

            // add a local filter on the data notified
            var deviceIdSub4 = (await connect.Subscribe.ResourceValuesAsync("1")).Filter(f => int.Parse(f.Payload) > 5);

            blankSub.OnNotify += (res) => Console.WriteLine(res);

            var nextValue = await blankSub.NextAsync();

            Console.WriteLine(nextValue);
        }

        public async Task SubscribeToAll()
        {
            // create a new subscription with no filter
            var subscription = await connect.Subscribe.DeviceEventsAsync();

            subscription.OnNotify += (res) => { Console.WriteLine(res); };

            // take two values
            var firstValue = subscription.NextAsync();
            var secondValue = subscription.NextAsync();

            // mock some notification messages
            MockNotification(connect.Subscribe);

            Console.WriteLine(firstValue.Result);
            Console.WriteLine(await secondValue);

            subscription.Unsubscribe();
        }

        public async Task SubscribeToDeviceEvent()
        {
            // subscribe to Deregistration and Registration events
            var subscription = (await connect.Subscribe.DeviceEventsAsync()).Filter(f => f.Event == DeviceEvent.DeRegistration || f.Event == DeviceEvent.Registration);

            // add a callback to print message when recieved
            subscription.OnNotify += (res) => Console.WriteLine(res);

            // take two values
            var firstValue = subscription.NextAsync();
            var secondValue = subscription.NextAsync();

            // mock some notification messages
            MockNotification(connect.Subscribe);

            Console.WriteLine(firstValue.Result);
            Console.WriteLine(await secondValue);

            subscription.Unsubscribe();
        }

        public async Task SubscribeToDeviceId()
        {
            // subscribe to events from devices with id "1" and "2"
            var subscription = (await connect.Subscribe.DeviceEventsAsync()).Filter(f => f.Id == "1" || f.Id == "2");

            // add a callback to print message when recieved
            subscription.OnNotify += (res) => Console.WriteLine(res);

            // take two values
            var firstValue = subscription.NextAsync();
            var secondValue = subscription.NextAsync();

            // mock some notification messages
            MockNotification(connect.Subscribe);

            Console.WriteLine(firstValue.Result);
            Console.WriteLine(await secondValue);

            subscription.Unsubscribe();
        }

        public async Task SubscribeToDeviceIdAndDeviceEvent()
        {
            // subscribe to DeRegistration and Registration events from devices with id "1" and "2"
            var subscription = (await connect.Subscribe.DeviceEventsAsync()).Filter(f => (f.Id == "1" || f.Id == "2") && (f.Event == DeviceEvent.DeRegistration || f.Event == DeviceEvent.Registration));

            // add a callback to print message when recieved
            subscription.OnNotify += (res) => Console.WriteLine(res);

            // take two values
            var firstValue = subscription.NextAsync();
            var secondValue = subscription.NextAsync();

            // mock some notification messages
            MockNotification(connect.Subscribe);

            Console.WriteLine(firstValue.Result);
            Console.WriteLine(await secondValue);

            subscription.Unsubscribe();
        }

        public async Task SubscribeWithMultipleObserversAsync()
        {
            // create a subscription with no filter
            var firstSubscription = await connect.Subscribe.DeviceEventsAsync();

            // add a callback to print message when recieved
            firstSubscription.OnNotify += (res) => Console.WriteLine($"First observer - {res}");

            // create a second subscription with filter on device with id "1"
            var secondSubscription = (await connect.Subscribe.DeviceEventsAsync()).Filter(f => f.Id == "1");

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
                new DeviceEventData() { DeviceId = "1", State = DeviceEvent.Registration },
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