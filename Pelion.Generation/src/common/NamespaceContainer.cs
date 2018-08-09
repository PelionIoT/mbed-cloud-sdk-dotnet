using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;
using Pelion.Generation.src.common.generators;

namespace Pelion.Generation.src.common
{
    public class NamespaceContainer
    {
        private readonly string module;
        private readonly string entityName;
        private List<ClassContainer> Classes;
        private JToken EntityJson;
        private NamespaceDeclarationSyntax parentNamespace;

        public NamespaceContainer(JToken entityJson, string module)
        {
            EntityJson = entityJson;
            this.module = module;
            entityName = entityJson[JsonKeys.key].Value<string>();
            parentNamespace = NamespaceGenerators.CreateNamespace(entityName);
            Classes = new List<ClassContainer>();
        }

        public void GenerateModelClass()
        {
            Classes.Add(new ClassContainer(entityName, EntityJson).GenerateModelClass());
        }

        public void GenerateAdapterClass()
        {
            var adapterClass = ClassGenerators.CreateClass($"{entityName}Adapter", Modifiers.InternalMod);

            var @class = new ClassContainer($"{entityName}Adapter", adapterClass);
            @class.AddUsing(Usings.JsonConverter);
            @class.AddUsing(Usings.DebugDump);

            Classes.Add(@class);
        }

        public string GetSDKNamespacePath(string className)
        {
            return $"MbedCloudSDK.{module}.Model.{className}";
        }

        public string GetFilePath(string className)
        {
            var currentDir = Directory.GetCurrentDirectory();
            var parent = Directory.GetParent(currentDir);
            var newDir = Path.Join(parent.FullName, $"Pelion.Generation.Lib/src/{module}/{entityName}/{className}.cs");
            Directory.CreateDirectory(Directory.GetParent(newDir).FullName);
            return newDir;
        }

        public List<NamespaceDeclarationSyntax> GetClasses()
        {
            var classes = new List<NamespaceDeclarationSyntax>();
            Classes.ForEach(c =>
            {
                var localNamespace = parentNamespace;
                localNamespace = localNamespace.AddClass(c.GeneratedClass);
                if (c.Usings.Any())
                {
                    c.Usings.ForEach(u =>
                    {
                        localNamespace = localNamespace.AddUsing(u);
                    });
                }
                localNamespace = localNamespace.AddFileHeader(c.ClassName);

                classes.Add(localNamespace);
            });

            return classes;
        }

        public void WriteFiles()
        {
            // GetClasses().ForEach(c => {
            //     using (var file = new StreamWriter(GetFilePath(c  .ClassName)))
            //     {
            //         file.Write(localNamespace.ToFullString());
            //     }
            // });
        }
    }
}