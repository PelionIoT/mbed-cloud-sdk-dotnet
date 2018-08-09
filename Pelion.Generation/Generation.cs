using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using MbedCloudSDK.AccountManagement.Model.ApiKey;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pelion.Generation.src.common;
using Pelion.Generation.src.common.generators;
using Pelion.Generation.src.compile;
using YamlDotNet.Serialization;

namespace Pelion.Generation
{
    public class Generation
    {
        private readonly string filepath;
        private readonly string targetProjectPath;
        private readonly string targetProjectName;
        private readonly string rootDirectory;
        private CompilationUnitSyntax root;
        private List<NamespaceContainer> GeneratedNamespaces;
        public Generation(string filepath, string targetProjectPath, string targetProjectName, string rootDirectory)
        {
            this.filepath = filepath;
            this.targetProjectPath = targetProjectPath;
            this.targetProjectName = targetProjectName;
            this.rootDirectory = rootDirectory;
            GeneratedNamespaces = new List<NamespaceContainer>();
        }

        public int RunGeneration()
        {
            var json = LoadJsonFromFile(filepath);

            root = RootGenerators.CreateRoot();

            var entities = json[JsonKeys.entities];

            foreach (var entity in entities)
            {
                var namespaceContainer = new NamespaceContainer(entity, "AccountManagement");
                namespaceContainer.GenerateModelClass();
                namespaceContainer.GenerateAdapterClass();
                GeneratedNamespaces.Add(namespaceContainer);
            }

            GeneratedNamespaces.ForEach(n =>
            {
                root = root.AddNamespace(n.GetClasses());
            });

            Console.WriteLine(root.NormalizeWhitespace().ToFullString());

            var compile = new Compile(targetProjectPath, targetProjectName);
            var result = compile.CompileFiles(root.SyntaxTree);
            if (result == 6)
            {
                WriteClassesToFiles();
            }

            return result;
        }

        public void WriteClassesToFiles()
        {
            GeneratedNamespaces.ForEach(n =>
            {
                n.GetClasses().ForEach(c =>
                {
                    Directory.CreateDirectory($"/Pelion.Generation.Lib/src/{c.Name}/");
                    using (var file = new StreamWriter(Path.Combine(rootDirectory, $"/Pelion.Generation.Lib/src/{c.Name}/{c.Name}.cs")))
                    {
                        file.Write(c.ToFullString());
                    }
                });
            });
        }

        private JObject LoadJsonFromFile(string filepath)
        {
            using (var readYaml = new StreamReader(filepath) as TextReader)
            {
                var deserializer = new Deserializer();
                // deserialize the yaml
                var yamlObject = deserializer.Deserialize(readYaml);
                // covnert to json
                var json = JsonConvert.SerializeObject(yamlObject);
                // parse to a JObject
                var jobj = JObject.Parse(json);
                return jobj;
            }
        }
    }
}