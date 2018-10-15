using System;
using System.IO;
using System.Linq;
using MbedCloud.SDK.Common;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Manhasset.Runner
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var pathToConfig = "/Users/alelog01/git/mbed-cloud-api-contract/out/sdk_gen_intermediate.json";

            var config = File.ReadAllText(pathToConfig);
            // parse to a JObject
            var jobj = JObject.Parse(config);

            var generator = new Manhasset.Generator.src.Generator(jobj);
            // add ref to SDK
            generator.CompilationContainer.AddMetadataReference(typeof(BaseModel));
            await generator.Run();

            // foreach (var classContainer in generator.Classes)
            // {
            //     // Console.WriteLine(JsonConvert.SerializeObject(classContainer.Value.Properties, Formatting.Indented));

            //     // foreach (var prop in classContainer.Value.Properties)
            //     // {
            //     //     Console.WriteLine(prop.Value.GetSyntax().NormalizeWhitespace().ToFullString());
            //     // }

            //     Console.WriteLine(classContainer.Value.GetSyntaxWithNamespace().NormalizeWhitespace().ToFullString());
            // }

            foreach (var item in generator.CompilationContainer.Classes.Values)
            {
                foreach (var method in item.Methods)
                {
                    Console.WriteLine(method.Value.GetSyntax().NormalizeWhitespace().ToFullString());
                }
                // Console.WriteLine(item.GetSyntaxWithNamespace().NormalizeWhitespace().ToFullString());
            }
            // Console.WriteLine(generator.CompilationContainer.Classes.Values.LastOrDefault().GetSyntaxWithNamespace().NormalizeWhitespace().ToFullString());
        }
    }
}
