using System;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pelion.Generation.src.common;
using Pelion.Generation.src.common.generators;
using YamlDotNet.Serialization;

namespace Pelion.Generation
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Too few arguments");
                Console.WriteLine("Required areguments are:");
                Console.WriteLine(" - path to yaml file");
                Console.WriteLine(" - path to target project");
                Console.WriteLine(" - name of target project");
                Console.WriteLine(" - directory of repo");
                return 1;
            }
            var pathToYaml = args[0];
            var targetProjectPath = args[1];
            var targetProjectName = args[2];
            var rootDirectory = args[3];
            var generation = new Generation(pathToYaml, targetProjectPath, targetProjectName, rootDirectory);
            return generation.RunGeneration();
        }
    }
}
