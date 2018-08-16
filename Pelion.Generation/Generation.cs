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
        private readonly string targetProjectName;
        private readonly string rootDirectory;
        private readonly string targetProjectFile;
        private readonly string targetProjectOutputDirectory;
        private CompilationUnitSyntax root;
        private List<NamespaceContainer> GeneratedNamespaces;
        public Generation(string filepath, string targetProjectName, string rootDirectory)
        {
            this.filepath = filepath;
            this.targetProjectName = targetProjectName;
            this.rootDirectory = rootDirectory;
            GeneratedNamespaces = new List<NamespaceContainer>();
            targetProjectFile = $"{rootDirectory}/{targetProjectName}/{targetProjectName}.csproj";
            targetProjectOutputDirectory = $"{rootDirectory}/{targetProjectName}";
        }

        public int RunGeneration()
        {
            var json = LoadJsonFromFile(filepath);

            root = RootGenerators.CreateRoot();

            var entities = json[JsonKeys.entities];

            foreach (var entity in entities)
            {
                var namespaceContainer = new NamespaceContainer(entity);
                namespaceContainer.GenerateModelClass();
                namespaceContainer.GenerateAdapterClass();
                GeneratedNamespaces.Add(namespaceContainer);
            }

            GeneratedNamespaces.ForEach(n =>
            {
                root = root.AddNamespace(n.GetClasses());
            });

            Console.WriteLine(root.NormalizeWhitespace().ToFullString());

            var compile = new Compile(targetProjectFile, targetProjectName);
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
                n.WriteFiles(targetProjectOutputDirectory);
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