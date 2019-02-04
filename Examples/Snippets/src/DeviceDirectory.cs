// using System;
// using System.Linq;
// using MbedCloudSDK.Common;
// using Mbed.Cloud.Foundation.Common;
// using MbedCloudSDK.DeviceDirectory.Api;

// namespace Snippets.src
// {
//     public class DeviceDirectory
//     {
//         public void ListDevices()
//         {
//             // an example: list devices in Mbed Cloud
//             var config = new Config("An MbedCloud Api  Key", "custom host url");

//             var deviceDirectory = new DeviceDirectoryApi(config);

//             var data = deviceDirectory.ListDevices(new QueryOptions { Order = "ASC" });

//             data.Select(device => $"{device.Id} [{device.State.ToString()}]")
//                 .ToList()
//                 .ForEach(device => Console.WriteLine(device));
//             // end of example
//         }

//         public void ListDevicesWithFilters()
//         {
//             // an example: list deregistered devices in Mbed Cloud
//             var config = new Config("An MbedCloud Api  Key", "custom host url");

//             var deviceDirectory = new DeviceDirectoryApi(config);

//             var options = new QueryOptions();
//             options.Filter.Add("state", "deregistered");

//             var data = deviceDirectory.ListDevices(options);

//             data.Select(device => $"{device.Id} [{device.State.ToString()}]")
//                 .ToList()
//                 .ForEach(device => Console.WriteLine(device));
//             // end of example
//         }
//     }
// }