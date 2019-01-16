
using System;
using Newtonsoft.Json;
using MbedCloudSDK.Common.Extensions;
using System.Linq;
using MbedCloud.SDK.GeneratedV2.Accounts.ApiKey;

namespace Playground
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            try
            {
                var apiKeyContext = new ApiKeyRepository();

                var me = await apiKeyContext.Me();

                Console.WriteLine(me.DebugDump());

                var apiKey = new ApiKey
                {
                    Name = "Alex test api key",
                };

                await apiKeyContext.Create(apiKey);

                Console.WriteLine(apiKey.Name);
                Console.WriteLine(apiKey.Id);

                apiKey.Name = "Alex updated test apiKey";

                await apiKeyContext.Update(apiKey.Id, apiKey);

                Console.WriteLine(apiKey.Name);

                apiKeyContext.Delete(apiKey.Id);

                var first = apiKeyContext.List().FirstOrDefault();

                Console.WriteLine(first.DebugDump());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
