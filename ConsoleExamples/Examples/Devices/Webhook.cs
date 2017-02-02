using mbedCloudSDK.Common;
using mbedCloudSDK.Devices.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleExamples.Examples.Devices
{
    /// @example
    public class Webhook
    {
        private Config config;

        public Webhook(Config config)
        {
            this.config = config;
        }

        /// <summary>
        /// Create a webhook for the resouce.
        /// </summary>
        public void RegisterWebhook()
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
            //webhook address
            string webhook = "http://testwebhooksdotnet.requestcatcher.com/test";
            devices.RegisterWebhook(webhook);
            Thread.Sleep(2000);
            var endpoints = endpointsResp.ToList();
            //subscribe to the resource
            var resources = endpoints[0].ListResources();
            foreach (var resource in resources)
            {
                if (resource.Uri == buttonResource)
                {
                    //Subscribe to the resource
                    devices.Subscribe(endpoints[0].Id, resource);
                    Console.WriteLine(string.Format("Webhook registered, see output on {0}", webhook));
                    //Deregister webhook after 1 minute
                    Thread.Sleep(60000);
                    devices.DeregisterWebhooks();
                    break;
                }
            }
        }
    }
}
