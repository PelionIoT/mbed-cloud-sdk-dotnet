using mbedCloudSDK.Common;
using mbedCloudSDK.Connect.Api;
using mbedCloudSDK.Connect.Model.ConnectedDevice;
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
        public void Subscribe()
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
            //Start long polling thread
            api.StartNotifications();
            var resources = endpoints[0].ListResources();
            foreach (var resource in resources)
            {
                if (resource.Path == buttonResource)
                {
                    //Subscribe to the resource
                    AsyncConsumer<String> consumer = api.Subscribe(endpoints[0].Id, resource);
                    int counter = 0;
                    while (true)
                    {
                        //Get the value of the resource and print it
                        Task<string> t = consumer.GetValue();
                        Console.WriteLine(t.Result);
                        counter++;
                        if (counter >= 5)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
