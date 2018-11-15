
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
                var myAccount = new Account().List().FirstOrDefault(a => a.DisplayName == "sdk_test_bob");

                var users = myAccount.Users();

                var myConfig = new CertificateIssuerConfig().List().All().FirstOrDefault(c => c.CertificateReference == "LWM2M");

                new Device()
                    .List()
                    .All()
                    .Where(d => d.State == DeviceStateEnum.REGISTERED)
                    .ToList()
                    .ForEach(async d => await d.RenewCertificate(myConfig.CertificateReference));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
