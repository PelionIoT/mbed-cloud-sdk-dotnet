using System;
using System.Threading;
using MbedCloudSDK.Common;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.Connect.Api.Subscribe.Models;

namespace Snippets.src
{
    public class Connect
    {
        public void SubscribeToDeviceStateChanges()
        {
            // an example: subscribing to device state changes
            var config = new Config("An MbedCloud Api  Key", "custom host url");

            using (var connect = new ConnectApi(config))
            {

                connect.Subscribe.DeviceEvents().Where(d => d.Event == DeviceEventEnum.Registration).OnNotify += (res) => Console.WriteLine(res);

                Thread.Sleep(120000);
            }
            // end of example
        }

        public void SubscribeToResourceVslueChanges()
        {
            // an example: subscribing to resource value changes
            var config = new Config("An MbedCloud Api  Key", "custom host url");

            using (var connect = new ConnectApi(config))
            {

                connect.Subscribe.ResourceValues("016*", "/3/0/*").OnNotify += (res) => Console.WriteLine(res);

                Thread.Sleep(120000);
            }
            // end of example
        }
    }
}