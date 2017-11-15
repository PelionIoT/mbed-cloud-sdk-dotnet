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
    public partial class ConnectExamples
    {
        /// <summary>
        /// Create a webhook for the resouce.
        /// </summary>
        public MbedCloudSDK.Connect.Model.Webhook.Webhook RegisterWebhook()
        {
            //Resource path
            var buttonResource = "/5002/0/1";
            //List all connected endpoints
            var connectedDevices = api.ListConnectedDevices();
            if (connectedDevices == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }
            var device = connectedDevices.FirstOrDefault();
            api.DeleteDeviceSubscriptions(device.Id);
            //webhook address
            var webhook = new MbedCloudSDK.Connect.Model.Webhook.Webhook("http://testwebhooksdotnet.requestcatcher.com/test");
            api.UpdateWebhook(webhook);
            Thread.Sleep(2000);
            //Subscribe to the resource
            api.AddResourceSubscription(device.Id, buttonResource);
            Console.WriteLine(string.Format("Webhook registered, see output on {0}", webhook));
            //Deregister webhook after 1 minute
            Thread.Sleep(60000);
            api.DeleteWebhook();

            return webhook;
        }
    }
}