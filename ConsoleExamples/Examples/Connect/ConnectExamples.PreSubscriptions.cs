using System;
using System.Collections.Generic;
using System.Linq;
using MbedCloudSDK.Connect.Model.Subscription;

namespace ConsoleExamples.Examples.Connect
{
    public partial class ConnectExamples
    {
        /// <summary>
        /// Create, update and delete a presubscription
        /// </summary>
        /// <returns>A presubscription</returns>
        public Presubscription CreatePreSubscription()
        {
            var devices = api.ListConnectedDevices().Data;

            Console.WriteLine("List presubscriptions for device...");
            foreach (var item in api.ListPresubscriptions())
            {
                Console.WriteLine(item);
            }

            var deviceId = devices.FirstOrDefault()?.Id;

            var resources = api.ListResources(deviceId);

            var resourceUri = resources.Where(r => r.Observable == true).FirstOrDefault()?.Path;

            //create the presubscription
            var presubscription = new Presubscription()
            {
                DeviceId = deviceId,
                ResourcePaths = new List<string> { resourceUri }
            };
            api.UpdatePresubscriptions(new Presubscription[] { presubscription });

            Console.WriteLine("List presubscriptions for device after new presubscription added...");
            foreach (var item in api.ListPresubscriptions())
            {
                Console.WriteLine(item);
            }

            api.DeletePresubscriptions();

            Console.WriteLine("List presubscriptions for device after deleting presubscriptions...");
            foreach (var item in api.ListPresubscriptions())
            {
                Console.WriteLine(item);
            }

            return presubscription;
        }
    }
}