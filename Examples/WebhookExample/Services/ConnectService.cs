using System;
using System.Collections.Generic;
using MbedCloudSDK.Common;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.Connect.Api.Subscribe.Observers.ResourceValues;
using MbedCloudSDK.Connect.Model.Webhook;
using Microsoft.AspNetCore.Hosting;

namespace WebhookExample.Services
{
    public interface IConnectService
    {
        ConnectApi connect { get; }
    }

    public class ConnectService : IConnectService
    {
        public ConnectApi connect { get; }

        public ConnectService(IApplicationLifetime applicationLifetime)
        {
            var apiKey = Environment.GetEnvironmentVariable("MBED_CLOUD_SDK_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_SDK_HOST");

            if (string.IsNullOrEmpty(apiKey))
            {
                Console.WriteLine("No api key set in environment!");
                applicationLifetime.StopApplication();
            }

            var config = string.IsNullOrEmpty(host) ? new Config(apiKey) : new Config(apiKey, host);

            var observer = connect.Subscribe.ResourceValues(deviceId, resourcePaths);
            observer.OnNotify += (res) => Console.WriteLine(res);
            return observer;
        }
    }
}