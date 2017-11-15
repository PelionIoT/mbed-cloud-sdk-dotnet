using System;
using System.Collections.Generic;
using System.Linq;
using MbedCloudSDK.Connect.Model.Subscription;

namespace ConsoleExamples.Examples.Connect
{
    public partial class ConnectExamples
    {
        public Presubscription CreatePreSubscription()
        {
            var devices = api.ListConnectedDevices().Data;

            foreach (var item in api.ListPresubscriptions())
            {
                Console.WriteLine(item);
            }

            var deviceId = devices.FirstOrDefault()?.Id;

            var resources = api.ListResources(deviceId);

            var resourceUri = resources.Where(r => r.Observable == true).FirstOrDefault()?.Path;

            var presubscription = new Presubscription()
            {
                DeviceId = deviceId,
                ResourcePaths = new List<string> { resourceUri }
            };
            api.UpdatePresubscriptions(new Presubscription[] { presubscription });

            foreach (var item in api.ListPresubscriptions())
            {
                Console.WriteLine(item);
            }

            api.DeletePresubscriptions();

            foreach (var item in api.ListPresubscriptions())
            {
                Console.WriteLine(item);
            }

            return presubscription;
        }
    }
}