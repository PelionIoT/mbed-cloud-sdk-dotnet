using MbedCloudSDK.Common;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.DeviceDirectory.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleExamples.Examples.Connect
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
        public MbedCloudSDK.Connect.Model.Webhook.Webhook RegisterWebhook()
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
            //webhook address
            var webhook = new MbedCloudSDK.Connect.Model.Webhook.Webhook("http://testwebhooksdotnet.requestcatcher.com/test");
            api.UpdateWebhook(webhook);
            Thread.Sleep(2000);
            var endpoints = endpointsResp.ToList();
            //subscribe to the resource
            var resources = endpoints[0].ListResources();
            foreach (var resource in resources)
            {
                if (resource.Path == buttonResource)
                {
                    //Subscribe to the resource
                    api.AddResourceSubscription(endpoints[0].Id, resource.Path);
                    Console.WriteLine(string.Format("Webhook registered, see output on {0}", webhook));
                    //Deregister webhook after 1 minute
                    Thread.Sleep(10000);
                    api.DeleteWebhook();
                    break;
                }
            }
            return webhook;
        }
    }
}