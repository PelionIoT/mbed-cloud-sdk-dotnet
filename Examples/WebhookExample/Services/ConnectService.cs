using System;
using System.Collections.Generic;
using MbedCloudSDK.Common;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.Connect.Api.Subscribe.Observers;
using MbedCloudSDK.Connect.Api.Subscribe.Observers.ResourceValues;
using MbedCloudSDK.Connect.Model.Webhook;

namespace WebhookExample.Services
{
    public interface IConnectService
    {
        ConnectApi connect { get; }
        ResourceValuesObserver SubscribeToResourceValues(string deviceId, List<string> resourcePaths);
    }

    public class ConnectService : IConnectService
    {
        public List<ResourceValuesObserver> observers { get; private set; } = new List<ResourceValuesObserver>();

        public ConnectApi connect { get; }

        public ConnectService()
        {
            var config = new Config(Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY"));

            connect = new ConnectApi(config);
        }

        public ResourceValuesObserver SubscribeToResourceValues(string deviceId, List<string> resourcePaths)
        {
            connect.UpdateWebhook(new Webhook("http://29c953ff.ngrok.io"));

            var observer = connect.Subscribe.ResourceValues(deviceId, resourcePaths);
            observer.OnNotify += (res) => Console.WriteLine(res);
            observers.Add(observer);

            return observer;
        }
    }
}