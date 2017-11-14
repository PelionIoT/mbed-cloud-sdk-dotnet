using MbedCloudSDK.Common;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.Connect.Model.ConnectedDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamples.Examples.Connect
{
    /// @example
    public class Subscription
    {
        private Config config;

        public Subscription(Config config)
        {
            this.config = config;
        }

        /// <summary>
        /// Subscribe Resources.
        /// </summary>
        public AsyncConsumer<String> Subscribe()
        {
            //Resource path
            var buttonResource = "/5002/0/1";
            ConnectApi api = new ConnectApi(config);
            //List all connected endpoints
            var endpointsResp = api.ListConnectedDevices();
            if (endpointsResp == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }
            var endpoints = endpointsResp.ToList();
            //Start pull notifications
            api.StartNotifications();
            var device = endpoints[0];
            var resources = device.ListResources();
            foreach (var resource in resources)
            {
                if (resource.Path == buttonResource)
                {
                    //Subscribe to the resource
                    var consumer = api.AddResourceSubscription(endpoints[0].Id, resource.Path);
                    int counter = 0;
                    while (true)
                    {
                        //Get the value of the resource and print it
                        var t = consumer.GetValue();
                        Console.WriteLine(t.Result);
                        counter++;
                        if (counter >= 2)
                        {
                            break;
                        }
                    }
                    return consumer;
                }
            }
            return null;
        }
    }
}