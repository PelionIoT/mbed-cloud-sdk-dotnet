using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using mbedCloudSDK.Access;
using mbedCloudSDK.Access.Model.ApiKey;
using mbedCloudSDK.Common;
using mbedCloudSDK.Devices;

namespace ConsoleExamples
{
    /// @example
    public class Examples
    {
        private Config config;
        public Examples(Config config)
        {
            this.config = config;
        }
        
        /// <summary>
        /// Runs the IAM example. List all Api keys.
        /// </summary>
        public void runIAMExample()
        {
            AccessApi access = new AccessApi(config);
            var keys = access.ListApiKeys();
            foreach (var key in keys)
            {
                Console.WriteLine(key);
            }
        }
        
        /// <summary>
        /// Runs the endpoints example. List all endpoints.
        /// </summary>
        public void runEndpointsExample()
        {
            DevicesApi devices = new DevicesApi(config);
            foreach (var endpoint in devices.ListEndpoints())
            {
                Console.WriteLine(endpoint);
            }
        }
        
        /// <summary>
        /// Runs the devices example. List all devices in device catalog.
        /// </summary>
        public void runDevicesExample(){
            DevicesApi devices = new DevicesApi(config);
            foreach (var device in devices.ListDevices())
            {
                Console.WriteLine(device.ToString());
            }
        }
        
        /// <summary>
        /// Runs the subscription example. Subscribe to the resource.
        /// </summary>
        public void runSubscriptionExample()
        {
            //Resource path
            var buttonResource = "/3200/0/5501";
            DevicesApi devices = new DevicesApi(config);
            //List all connected endpoints
            var endpoints = devices.ListEndpoints();
            if (endpoints == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }
            //Start long polling thread
            devices.StartLongPolling();
            //Subscribe to the resource
            AsyncConsumer<String> consumer =  devices.Subscribe(endpoints[0].Name, buttonResource);
            while (true)
            {
                //Get the value of the resource and print it
                Task<string> t = consumer.GetValue();
                Console.WriteLine(t.Result);
            }
        }
        
        /// <summary>
        /// Runs the webhook example. Create a webhook for the resouce.
        /// </summary>
        public void runWebhookExample()
        {
            //Resource path
            var buttonResource = "/3200/0/5501";
            DevicesApi devices = new DevicesApi(config);
            //List all connected endpoints
            var endpoints = devices.ListEndpoints();
            if (endpoints == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }
            //webhook address
            string webhook = "http://testwebhooks.requestcatcher.com/test";
            devices.RegisterWebhook(webhook);
            Thread.Sleep(2000);
            //subscribe to the resource
            devices.Subscribe(endpoints[0].Name, buttonResource);
            Console.WriteLine(string.Format("Webhook registered, see output on {0}", webhook));
            //Deregister webhook after 1 minute
            Thread.Sleep(60000);
            devices.DeregisterWebhooks();
        }
        
        /// <summary>
        /// Runs the device query example. Create new filter.
        /// </summary>
        public void runDeviceQueryExample()
        {
            DevicesApi devices = new DevicesApi(config);
            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("auto_update", "true");
            devices.CreateFilter("test", query, null);
        }
        
        public async void runAsyncExample()
        {
            AccessApi access = new AccessApi(config);
            var keysTask = access.ListApiKeysAsync();
            Console.WriteLine("Dont wait for response");
            List<ApiKeyResp> keys = keysTask.Result;
            foreach (var key in keys)
            {
                Console.WriteLine(key);
            }
        }
    }
}
