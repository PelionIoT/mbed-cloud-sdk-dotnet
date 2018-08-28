using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Manhasset.Core.src.Generators;
using Manhasset.Generator.src.Containers;
using Manhasset.Generator.src.Helpers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;

namespace Manhasset.Generator.src.Compilers
{
    public class NamespaceContainer
    {
        private readonly string entityName;
        private readonly string namespaceName;
        private List<ClassContainer> Classes;
        private List<EnumContainer> Enums;
        private readonly string tagName;
        private JToken EntityJson;
        private NamespaceDeclarationSyntax parentNamespace;

        public NamespaceContainer(string tagName, string entityName, JToken entityJson)
        {
            this.tagName = tagName;
            EntityJson = entityJson;
            this.entityName = entityName;
            namespaceName = $"MbedCloudSDK.{tagName}.{entityName}";
            parentNamespace = NamespaceGenerators.CreateNamespace(namespaceName);
            Classes = new List<ClassContainer>();
            Enums = new List<EnumContainer>();
        }

        public void GenerateModelClass()
        {
            Classes.Add(new ClassContainer(entityName, EntityJson).GenerateModelClass());
        }

        public void GenerateEnums()
        {
            var properties = EntityJson[JsonKeys.fields];

            foreach (var item in properties)
            {
                if (item["enum"] != null)
                {
                    Enums.Add(new EnumContainer(item));
                }
            }
        }

        public List<NamespaceDeclarationSyntax> GetClasses()
        {
            var classes = new List<NamespaceDeclarationSyntax>();
            Classes.ForEach(c =>
            {
                var localNamespace = CreateLocalNamespace(c);

                classes.Add(localNamespace);
            });

            Enums.ForEach(e =>
            {
                var localNamespace = parentNamespace;

                localNamespace = localNamespace.AddEnum(e.GeneratedEnum);

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
                    file.Write(CodePrinter.PrintCodeNamespace(localNamespace));
                }
            });

            Enums.ForEach(e =>
            {
                var localNamespace = parentNamespace;

                localNamespace = localNamespace.AddEnum(e.GeneratedEnum);

                var dir = $"{rootDirectory}/src/{namespaceName}/";
                Directory.CreateDirectory(dir);
                using (var file = new StreamWriter($"{dir}/{e.EnumName}.cs"))
                {
                    file.Write(CodePrinter.PrintCodeNamespace(localNamespace));
                }
            });
        }
    }
}