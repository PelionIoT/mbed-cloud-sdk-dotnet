using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MbedCloudSDK.ExampleTests
{
    public class SetEnvironment
    {
        public static void SetEnvironmentVariables()
        {
            try
            {
                if (Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY") == null)
                {
                    using (var file = File.OpenText("mbedKeys.json"))
                    {
                        var reader = new JsonTextReader(file);
                        var jObject = JObject.Load(reader);
                        var key = jObject.GetValue("MBED_CLOUD_API_KEY");
                        var host = jObject.GetValue("MBED_CLOUD_HOST");

                        Environment.SetEnvironmentVariable("MBED_CLOUD_API_KEY", key.Value<string>());
                        Environment.SetEnvironmentVariable("MBED_CLOUD_HOST", host.Value<string>());
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("no file");
            }
        }
    }
}
