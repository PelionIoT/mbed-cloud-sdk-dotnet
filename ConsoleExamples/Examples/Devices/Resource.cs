using mbedCloudSDK.Common;
using mbedCloudSDK.Devices.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamples.Examples.Devices
{
    class Resource
    {
        Config config;

        public Resource(Config config)
        {
            this.config = config;
            GetResourceValue();
        }

        /// <summary>
        /// Get the value of the resource.
        /// </summary>
        public void GetResourceValue()
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
            //Start long polling thread
            var endpoints = endpointsResp.ToList();
            devices.StartLongPolling();
            var resources = endpoints[0].ListResources();
            foreach (var resource in resources)
            {
                if (resource.Uri == buttonResource)
                {
                    var resp = devices.GetResourceValue(endpoints[0].Id, resource.Uri);
                    Console.WriteLine(resp.GetValue().Result);
                }
            }
        }

        /// <summary>
        /// Set the value on the resource.
        /// </summary>
        public void SetResourceValue()
        {
            //Resource path
            var buttonResource = "3200/0/5501";
            DevicesApi devices = new DevicesApi(config);
            //List all connected endpoints
            var endpointsResp = devices.ListConnectedDevices();
            if (endpointsResp == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }
            //Start long polling thread
            var endpoints = endpointsResp.ToList();
            devices.StartLongPolling();
            var resources = endpoints[0].ListResources();
            var resp = devices.SetResourceValue(endpoints[0].Id, buttonResource, "100");
            Console.WriteLine(resp.GetValue().Result);
        }

    }
}
