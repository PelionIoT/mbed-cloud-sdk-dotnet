using System;
using System.IO;
using System.Linq;
using Mbed.Cloud.Common;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace Manhasset.Runner
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var pathToConfig = "api_specifications/public/sdk_foundation_definition.json";

            var config = File.ReadAllText(pathToConfig);
            // parse to a JObject
            var jobj = JObject.Parse(config);

            var generator = new Manhasset.Generator.src.Generator(jobj);
            // add ref to SDK
            generator.CompilationContainer.AddMetadataReference(typeof(Entity));
            generator.CompilationContainer.AddMetadataReference(typeof(EnumMemberAttribute));

            await generator.Run();
        }
    }
}
