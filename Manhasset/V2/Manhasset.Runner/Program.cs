using System;
using System.IO;
using System.Linq;
using Mbed.Cloud.Foundation.Common;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Manhasset.Runner
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var pathToConfig = "merged/public/sdk_gen_intermediate.json";

            var config = File.ReadAllText(pathToConfig);
            // parse to a JObject
            var jobj = JObject.Parse(config);

            var generator = new Manhasset.Generator.src.Generator(jobj);
            // add ref to SDK
            generator.CompilationContainer.AddMetadataReference(typeof(Entity));

            await generator.Run();
        }
    }
}
