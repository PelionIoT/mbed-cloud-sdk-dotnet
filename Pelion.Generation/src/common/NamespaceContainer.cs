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
        private readonly string entityName;
        private readonly string namespaceName;
        private List<ClassContainer> Classes;
        private readonly string tagName;
        private JToken EntityJson;
        private NamespaceDeclarationSyntax parentNamespace;

        public NamespaceContainer(string tagName, JToken entityJson)
        {
            this.tagName = tagName;
            EntityJson = entityJson;
            entityName = entityJson[JsonKeys.key].Value<string>();
            namespaceName = $"MbedCloudSDK.{tagName}.{entityName}";
            parentNamespace = NamespaceGenerators.CreateNamespace(namespaceName);
            Classes = new List<ClassContainer>();
        }

        public void GenerateModelClass()
        {
            Classes.Add(new ClassContainer(entityName, EntityJson).GenerateModelClass());
        }

        public void GenerateEnum()
        {
            var entityEnum = EnumGenerators.CreateEnum($"{entityName}Enum");
            parentNamespace = parentNamespace.AddEnum(entityEnum);
            parentNamespace.ToFullString();
        }

        public List<NamespaceDeclarationSyntax> GetClasses()
        {
            var classes = new List<NamespaceDeclarationSyntax>();
            Classes.ForEach(c =>
            {
                var localNamespace = CreateLocalNamespace(c);

                classes.Add(localNamespace);
            });

            return classes;
        }

        private NamespaceDeclarationSyntax CreateLocalNamespace(ClassContainer c)
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

            return localNamespace;
        }

        public void WriteFiles(string rootDirectory)
        {
            Classes.ForEach(c =>
            {
                var localNamespace = CreateLocalNamespace(c);
                var dir = $"{rootDirectory}/src/{namespaceName}/";
                Directory.CreateDirectory(dir);
                using (var file = new StreamWriter($"{dir}/{c.ClassName}.cs"))
                {
                    file.Write(localNamespace.ToFullString());
                }
            });
        }
    }
}