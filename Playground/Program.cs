
using System;
using Newtonsoft.Json;
using MbedCloudSDK.Common.Extensions;
using System.Linq;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Threading;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.Common;
using System.Collections.Generic;
using Mbed.Cloud.Common;
using MbedCloudSDK.Connect.Api.Subscribe.Observers;
using Mbed.Cloud.Foundation;
using Mbed.Cloud.Foundation.Enums;
using Mbed.Cloud.RestClient;

namespace Playground
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var stats = new CampaignStatisticsRepository();

                var statsList = stats.Events("01616622693a00000000000100100019", "fail", new CampaignStatisticsEventsListOptions{ MaxResults = 3 }).All();

                Console.WriteLine(statsList.Count);

                // var device = new DeviceRepository();

                // var deviceList = device.List(new DeviceListOptions { MaxResults = 2 }).All();

                // Console.WriteLine(deviceList.Count);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception...");
                Console.WriteLine(e);
            }
        }
    }
}
