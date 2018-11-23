using System;
using System.Collections.Generic;
using System.IO;
using Manhasset.Core.src.Generators;
using Manhasset.Generator.src.Compilers;
using Manhasset.Generator.src.Helpers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YamlDotNet.Serialization;

namespace Manhasset.Generator
{
    public class Generator
    {
        private readonly string filepath;
        private readonly string targetProjectName;
        private readonly string rootDirectory;
        private readonly string targetProjectFile;
        private readonly string targetProjectOutputDirectory;
        private CompilationUnitSyntax root;
        private List<NamespaceContainer> GeneratedNamespaces;
        public Generator(string filepath, string targetProjectName, string rootDirectory)
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

            var renames = new Dictionary<string, Dictionary<string, string>>();

            var entities = json[JsonKeys.entities];

            foreach (var entity in entities)
            {
                var entityName = entity[JsonKeys.key][JsonKeys.pascal].Value<string>();
                var tag = entity[JsonKeys.groupId][JsonKeys.pascal].Value<string>();
                var namespaceContainer = new NamespaceContainer(tag, entityName, entity);
                namespaceContainer.GenerateEnums();
                namespaceContainer.GenerateModelClass();

                var entityRenames = namespaceContainer.GenerateRenames();
                renames.Add($"{namespaceContainer.namespaceName}.{entityName}", entityRenames);

                GeneratedNamespaces.Add(namespaceContainer);
            }

            var commonNamespace = new NamespaceContainer("Common", "Renames", null);
            commonNamespace.GenerateRenameClass(renames);
            GeneratedNamespaces.Add(commonNamespace);

            var globalEntityNamespace = new NamespaceContainer("Global", "SDK", entities, true);
            globalEntityNamespace.GenerateSDKEntityClass();
            GeneratedNamespaces.Add(globalEntityNamespace);

            GeneratedNamespaces.ForEach(n =>
            {
                root = root.AddNamespace(n.GetClasses());
            });

            var compile = new Compile(targetProjectFile, targetProjectName);
            var result = compile.CompileFiles(root.SyntaxTree);

            WriteClassesToFiles();

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