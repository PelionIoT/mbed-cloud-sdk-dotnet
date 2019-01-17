using System;
using System.Collections.Generic;
using System.Linq;
using Manhasset.Core.src.Common;
using Manhasset.Core.src.Compile;
using Manhasset.Core.src.Containers;
using Manhasset.Generator.src.common;
using Manhasset.Generator.src.CustomContainers;
using Manhasset.Generator.src.extensions;
using Manhasset.Generator.src.Generators;
using Newtonsoft.Json.Linq;

namespace Manhasset.Generator.src
{
    public class Generator
    {
        public JObject Config { get; set; }
        public Compilation CompilationContainer { get; set; }
        public Generator(JObject config)
        {
            Config = config;
            CompilationContainer = new Compilation();
        }

        public async System.Threading.Tasks.Task Run()
        {
            // root file path
            var rootFilePath = "MbedCloudSDK/SDK/GeneratedV2POC";

            var entities = Config["entities"];

            var entityFactory = new ClassContainer()
            {
                Name = "EntityFactory",
                Namespace = "MbedCloud.SDK",
                FilePath = $"{rootFilePath}/EntityFactory.cs",
                DocString = "Entity Factory",
            };

            // var configField = new PrivateFieldContainer
            // {
            //     Name = "config",
            //     FieldType = "Config",
            // };

            // configField.AddModifier(nameof(Modifiers.PRIVATE), Modifiers.PRIVATE);

            // entityFactory.AddPrivateField(nameof(configField), configField);

            // // entity factory constructor
            // var entityFactoryConstructorContainer = new EntityFactoryConstructorContainer
            // {
            //     Name = "EntityFactory"
            // };

            // entityFactoryConstructorContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
            // entityFactory.AddConstructor(nameof(entityFactoryConstructorContainer), entityFactoryConstructorContainer);

            entityFactory.AddUsing(nameof(UsingKeys.SDK_COMMON), UsingKeys.SDK_COMMON);
            entityFactory.AddUsing(nameof(UsingKeys.ENTITIES), UsingKeys.ENTITIES);

            entityFactory.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
            entityFactory.AddModifier(nameof(Modifiers.PARTIAL), Modifiers.PARTIAL);

            // generate entities
            foreach (var entity in entities)
            {
                var entityGroup = entity["group_id"].GetStringValue().ToPascal();
                var entityNamePascal = entity["_key"].GetStringValue().ToPascal();

                // generate entity enums
                EnumGenerator.GenerateEnums(entity, rootFilePath, entityGroup, entityNamePascal, CompilationContainer);

                // generate entity class
                EntityClassGenerator.GenerateEntityClass(entity, entityNamePascal, rootFilePath, entityGroup, CompilationContainer);

                if (entity["methods"].Any())
                {
                    EntityRepositoryGenerator.GenerateRepository(entity, entityNamePascal, rootFilePath, entityGroup, CompilationContainer);
                }
            }

            CompilationContainer.AddClass(nameof(entityFactory), entityFactory);

            await CompilationContainer.Compile();
            CompilationContainer.WriteFiles();
        }
    }
}