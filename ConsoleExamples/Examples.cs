using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using mbedCloudSDK.Access;
using mbedCloudSDK.Common;
using mbedCloudSDK.Devices;

namespace ConsoleExamples
{
    public class Examples
    {
        private Config config;
        public Examples(Config config)
        {
            this.config = config;
        }
        
        public void RunExample(int example)
        {
            switch (example)
            {
                case 1:
                    runIAMExample();    
                    break;
                case 2:
                    runDevicesExample();    
                    break;
                case 3:
                    runEndpointsExample();    
                    break;
                case 4:
                    runSubscriptionExample();    
                    break;
                case 5:
                    runWebhookExample();    
                    break;
                case 6:
                    runDeviceQueryExample();    
                    break;
            }
        } 

        private void runIAMExample()
        {
            AccessApi access = new AccessApi(config);
            var keys = access.ListApiKeys();
            foreach (var key in keys)
            {
                Console.WriteLine(key);
            }
        }

        private void runEndpointsExample()
        {
            DevicesApi devices = new DevicesApi(config);
            foreach (var endpoint in devices.ListEndpoints())
            {
                Console.WriteLine(endpoint);
            }
        }

        private void runDevicesExample(){
            DevicesApi devices = new DevicesApi(config);
            foreach (var device in devices.ListDevices())
            {
                Console.WriteLine(device.ToString());
            }
        }

        private void runSubscriptionExample()
        {
            var buttonResource = "/3200/0/5501";
            DevicesApi devices = new DevicesApi(config);
            var endpoints = devices.ListEndpoints();
            if (endpoints == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }
            devices.StartLongPolling();
            AsyncConsumer<String> consumer =  devices.Subscribe(endpoints[0].Name, buttonResource);
            while (true)
            {
                Task<string> t = consumer.GetValue();
                Console.WriteLine(t.Result);
            }
        }

        private void runWebhookExample()
        {
            var buttonResource = "/3200/0/5501";
            DevicesApi devices = new DevicesApi(config);
            var endpoints = devices.ListEndpoints();
            if (endpoints == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }
            string webhook = "http://testwebhooks.requestcatcher.com/test";
            devices.RegisterWebhook(webhook);
            Thread.Sleep(2000);
            devices.Subscribe(endpoints[0].Name, buttonResource);
            Console.WriteLine(string.Format("Webhook registered, see output on {0}", webhook));
            Thread.Sleep(50000);
            devices.DeregisterWebhooks();
        }

        private void runDeviceQueryExample()
        {
            DevicesApi devices = new DevicesApi(config);
            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("auto_update", "true");
            Dictionary<string, string> customAttributes = new Dictionary<string, string>();
            customAttributes.Add("att1", "val1");
            customAttributes.Add("att2", "val2");
            devices.CreateFilter("test", query, customAttributes);
        }
    }
}
