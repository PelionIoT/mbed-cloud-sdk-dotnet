using mbedCloudSDK.Common;
using mbedCloudSDK.Devices.Api;
using mbedCloudSDK.Devices.Model.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamples.Examples.Devices
{
    class Subscription
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
            var buttonResource = "/3200/0/5501";
            DevicesApi devices = new DevicesApi(config);
            //List all connected endpoints
            var endpointsResp = devices.ListConnectedDevices();
            if (endpointsResp == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }
            var endpoints = endpointsResp.ToList();
            //Start long polling thread
            devices.StartLongPolling();
            var resources = endpoints[0].ListResources();
            foreach (var resource in resources)
            {
                if (resource.Uri == buttonResource)
                {
                    //Subscribe to the resource
                    AsyncConsumer<String> consumer = devices.Subscribe(endpoints[0].Id, resource);
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
