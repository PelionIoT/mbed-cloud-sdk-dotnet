using MbedCloudSDK.Common;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.DeviceDirectory.Api;
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
        }

        /// <summary>
        /// Get the value of the resource.
        /// </summary>
        public string GetResourceValue()
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
                    Console.WriteLine(resp);
                    return resp;
                }
            }
            return "no resource found";
        }

        /// <summary>
        /// Set the value on the resource.
        /// </summary>
        public string SetResourceValue()
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
            var resp = api.SetResourceValue(endpoints[0].Id, buttonResource, "100");
            var value = resp.GetValue().Result;
            Console.WriteLine(value);
            return value;
        }
    }
}
