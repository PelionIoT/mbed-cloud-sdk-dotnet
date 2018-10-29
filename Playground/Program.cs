
using System;
using MbedCloud.SDK;
using MbedCloud.SDK.Client;
using MbedCloud.SDK.Entities;
using Newtonsoft.Json;
using MbedCloudSDK.Common.Extensions;

namespace Playground
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            try
            {
                var user = new User
                {
                    Username = "alex",
                    TwoFactorAuthentication = true,
                };

                var serialized = JsonConvert.SerializeObject(user, Formatting.Indented, SerializationSettings.GetSettingsWithRenames());

                Console.WriteLine(serialized);

                var newUser = JsonConvert.DeserializeObject<User>(serialized, SerializationSettings.GetSettingsWithRenames());

                Console.WriteLine(newUser.DebugDump());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
