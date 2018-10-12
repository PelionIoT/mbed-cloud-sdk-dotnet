using System;
using System.Collections.Generic;
using System.Linq;
using Manhasset.Core.src.Common;
using Manhasset.Core.src.Compile;
using Manhasset.Core.src.Containers;
using Manhasset.Generator.src.common;
using Manhasset.Generator.src.CustomContainers;
using Manhasset.Generator.src.extensions;
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
            var rootFilePath = "/Users/alelog01/git/mbed-cloud-sdk-dotnet/MbedCloudSDK/SDK/Generated";

            // generate enums
            var enums = Config["enums"];

            // namespace will be common to all enums
            var enumNamespace = "MbedCloud.SDK.Enums";

            foreach (var anEnum in enums)
            {
                var name = anEnum["enum_name"].GetStringValue().ToPascal();
                var values = anEnum["values"].Values<string>().ToList();
                var filePath = $"{rootFilePath}/Enums/{name}.cs";

                var enumContainer = new EnumContainer
                {
                    Name = name,
                    Namespace = enumNamespace,
                    Values = values,
                    FilePath = filePath,
                };

                enumContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);

                CompilationContainer.AddEnum(name, enumContainer);
            }

            // generate entities
            var entities = Config["entities"];

            foreach (var entity in entities)
            {
                var entityClass = new ClassContainer();

                // namespace
                entityClass.Namespace = "MbedCloud.SDK.Entities";

                // modifier (just public for now)
                entityClass.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);

                // name
                entityClass.Name = entity["_key"].GetStringValue().ToPascal();

                // base type
                entityClass.AddBaseType("BASE_MODEL", "BaseModel");
                entityClass.AddUsing(nameof(UsingKeys.SDK_COMMON), UsingKeys.SDK_COMMON);

                // default constructor
                var defaultConstructor = new ConstructorContainer
                {
                    Name = entityClass.Name
                };
                defaultConstructor.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
                entityClass.AddConstructor("DEFAULT", defaultConstructor);

                //config constructor
                var configConstructor = new ConfigConstructorContainer
                {
                    Name = entityClass.Name
                };
                configConstructor.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
                entityClass.AddConstructor("CONFIG", configConstructor);
                entityClass.AddUsing(nameof(UsingKeys.SDK_COMMON), UsingKeys.SDK_COMMON);

                // doc (just use the name for now)
                entityClass.DocString = entityClass.Name;

                // set the filepath root/groupId/Class/Class.cs
                entityClass.FilePath = $"{rootFilePath}/{entity["group_id"].GetStringValue().ToPascal()}/{entityClass.Name}/{entityClass.Name}.cs";

                // add rename dictionary if any
                if (entity["field_renames"].Count() > 0)
                {
                    var renameContainer = new RenameContainer();
                    foreach (var rename in entity["field_renames"])
                    {
                        var left = rename["_key"].GetStringValue().ToPascal();
                        var right = rename["api_fieldname"].GetStringValue();

                        renameContainer.AddRename(left, right);
                    }

                    entityClass.AddPrivateField("RENAMES", renameContainer);

                    entityClass.AddUsing(nameof(UsingKeys.GENERIC_COLLECTIONS), UsingKeys.GENERIC_COLLECTIONS);
                }

                // get properties
                var properties = entity["fields"];
                foreach (var property in properties)
                {
                    // extract info from config
                    var name = property["_key"].GetStringValue().ToPascal();
                    // docstring, fall back to name when no description is provided
                    // TODO restore when multiline comment issue is solved
                    // var docString = property["description"].GetStringValue() ?? property["_key"].GetStringValue();
                    var docString = property["_key"].GetStringValue();

                    // get type
                    // format or type for most methods
                    var swaggerType = property["format"].GetStringValue() ?? property["type"].GetStringValue();
                    // if peoperty is array, get inner values
                    var items = property["items"];
                    // an array of foreign keys
                    var foreignKey = property["items"] != null ? property["items"]["foreign_key"] : null;
                    var innerValues = items != null ? foreignKey != null ? foreignKey["entity"].GetStringValue().ToPascal() : property["items"]["type"].GetStringValue() : null;

                    // might be enum
                    var propertyType = property["enum"] != null ? property["enum_reference"].GetStringValue().ToPascal() : SwaggerTypeHelper.MapType(swaggerType, innerValues);

                    // check if property has custom getters and setters
                    var overrideProperty = property["_override"] != null && !property["private_field"].GetBoolValue();
                    var customGetter = property["getter_custom_method"] != null;
                    var customSetter = property["setter_custom_method"] != null;

                    var isNullable = !propertyType.Contains("List<") && !propertyType.Contains("string") && !propertyType.Contains("object");

                    if (overrideProperty) {
                        var overridePropContainer = new PropertyWithCustomGetterAndSetter
                        {
                            Name = name,
                            DocString = docString,
                            PropertyType = propertyType,
                            GetAccessor = customGetter,
                            SetAccessor = customSetter,
                            CustomGetterName = property["getter_custom_method"].GetStringValue().ToPascal(),
                            CustomSetterName = property["setter_custom_method"].GetStringValue().ToPascal(),
                            IsNullable = isNullable,
                    };

                        // can assume public
                        overridePropContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);

                        entityClass.AddProperty(name, overridePropContainer);
                    } else {
                        var propContainer = new PropertyWithSummaryContainer()
                        {
                            Name = name,
                            DocString = docString,
                            PropertyType = propertyType,
                            IsNullable = isNullable,
                        };

                        // can assume public
                        propContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);

                        entityClass.AddProperty(name, propContainer);
                    }

                    // add usings for foreign keys
                    if (foreignKey != null)
                    {
                        var foreignKeyName = foreignKey["entity"].GetStringValue().ToPascal();
                        // entityClass.AddUsing(UsingKeys.ForeignKey(foreignKeyName), $"MbedCloud.SDK.Entities.{foreignKeyName}");
                        entityClass.AddUsing("FOREIGN_KEY", $"MbedCloud.SDK.Entities");
                    }

                    // add usings for date time
                    if (propertyType == "DateTime")
                    {
                        entityClass.AddUsing(nameof(UsingKeys.SYSTEM), UsingKeys.SYSTEM);
                    }

                    // add usings for list
                    if (propertyType.Contains("List<"))
                    {
                        entityClass.AddUsing(nameof(UsingKeys.GENERIC_COLLECTIONS), UsingKeys.GENERIC_COLLECTIONS);
                    }

                    // check if property type is enum
                    if (propertyType.Contains("Enum"))
                    {
                        // entityClass.AddUsing(UsingKeys.EnumKey(propertyType), $"MbedCloud.SDK.Enums.{propertyType}");
                        entityClass.AddUsing("ENUM_KEY", $"MbedCloud.SDK.Enums");
                    }

                    // add usings for custom functions
                    if (overrideProperty)
                    {
                        entityClass.AddUsing(nameof(UsingKeys.SDK_COMMON), UsingKeys.SDK_COMMON);
                    }
                }

                // get methods
                var methods = entity["methods"];
                foreach (var method in methods)
                {
                    var methodContainer = new MethodContainer();
                    // method name
                    methodContainer.Name = method["_key"].GetStringValue().ToPascal();
                    // can assume public
                    methodContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);

                    entityClass.AddMethod(methodContainer.Name, methodContainer);
                }

                // remove Ids
                entityClass.Properties.Remove("Id");

                CompilationContainer.AddClass(entityClass.Name, entityClass);
            }

            // await CompilationContainer.Compile();
            CompilationContainer.WriteFiles();
        }
    }
}