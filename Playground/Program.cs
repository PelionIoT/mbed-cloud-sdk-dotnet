
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
                var repo = new DeviceRepository();

                var deviceRequest = new Device
                {
                    AutoUpdate = true,
                    BootstrapExpirationDate = new DateTime(1986, 11, 8),
                    CaId = "fSQgZNIVdVMxpVvtEpBP",
                    ConnectorExpirationDate = new DateTime(2002, 8, 3),
                    Description = "some long description",
                    DeviceClass = "NHCACKaeRazNoZZuBIij",
                    DeviceExecutionMode = 1,
                    DeviceKey = "ylVJZwoLqVrtRUNTIHAF",
                    EndpointType = "jkYgufdZxaHETxxlhPNV",
                    HostGateway = "69365650-230d-4648-9824-2864042f465d",
                    Mechanism = DeviceMechanism.DIRECT,
                    MechanismUrl = "https://www.examplea03502a1-204b-446e-9aef-59ed02b4e62f.com",
                    Name = "AUTOTEST-IPG30C",
                    SerialNumber = "HTjSZbmOYIdvvRIfmvFi",
                    State = DeviceState.BOOTSTRAPPED,
                    VendorId = "bhKjKuQIAKOLhdiQBpKT",
                };

                var deviceString = JsonConvert.SerializeObject(deviceRequest, SerializationSettings.GetSerializationSettings());

                var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(deviceString);

                // var device = await repo.Create(deviceRequest, "timestamp", "checksum");

                Console.WriteLine(deviceString);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception...");
                Console.WriteLine(e);
            }
        }
    }

    public class TestObserver<T, F> : Observer<T, F>
    {
    }
}
