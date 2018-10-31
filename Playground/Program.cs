
using System;
using MbedCloud.SDK;
using MbedCloud.SDK.Client;
using MbedCloud.SDK.Entities;
using Newtonsoft.Json;
using MbedCloudSDK.Common.Extensions;
using System.Linq;
using MbedCloud.SDK.Enums;

namespace Playground
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            try
            {
                var myConfig = new CertificateIssuerConfig().List().All().FirstOrDefault(c => c.Reference == "LWM2M");

                new Device()
                    .List()
                    .All()
                    .Where(d => d.State == DeviceStateEnum.REGISTERED)
                    .ToList()
                    .ForEach(async d => await d.RenewCertificate(myConfig.Reference));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
