using mbedCloudSDK.Common;
using mbedCloudSDK.Connect.Api;
using mbedCloudSDK.DeviceDirectory.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamples.Examples.Connect
{
    /// @example
    public class Resource
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
            var buttonResource = "/5002/0/1";
            ConnectApi api = new ConnectApi(config);
            //List all connected endpoints
            var endpointsResp = api.ListConnectedDevices();
            if (endpointsResp == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }
            //Start long polling thread
            var endpoints = endpointsResp.ToList();
            api.StartNotifications();
            var resources = endpoints[0].ListResources();
            foreach (var resource in resources)
            {
                if (resource.Path == buttonResource)
                {
                    var resp = api.GetResourceValue(endpoints[0].Id, resource.Path);
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
            var buttonResource = "/5002/0/1";
            ConnectApi api = new ConnectApi(config);
            //List all connected endpoints
            var endpointsResp = api.ListConnectedDevices();
            if (endpointsResp == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }
            //Start long polling thread
            var endpoints = endpointsResp.ToList();
            api.StartNotifications();
            var resources = endpoints[0].ListResources();
            var resp = api.SetResourceValue(endpoints[0].Id, buttonResource, Encoding.UTF8.GetBytes("100"));
            Console.WriteLine(resp.GetValue().Result);
        }

    }
}
