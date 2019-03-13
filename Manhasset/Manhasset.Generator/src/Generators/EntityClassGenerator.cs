using System.Linq;
using Manhasset.Core.src.Common;
using Manhasset.Core.src.Compile;
using Manhasset.Core.src.Containers;
using Manhasset.Core.src.Extensions;
using Manhasset.Generator.src.common;
using Manhasset.Generator.src.CustomContainers;
using Manhasset.Generator.src.extensions;
using Newtonsoft.Json.Linq;

namespace Manhasset.Generator.src.Generators
{
    public class EntityClassGenerator
    {
        public static void GenerateEntityClass(JToken entity, string entityPascalName, string rootFilePath, string entityGroup, Compilation compilation)
        {
            var entityClass = new ClassContainer();

            // namespace
            entityClass.Namespace = UsingKeys.FOUNDATION;

            // modifier (just public for now)
            entityClass.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);

            // name
            entityClass.Name = entityPascalName;

            // base type
            entityClass.AddBaseType("BASE_ENTITY", "Entity");
            entityClass.AddUsing(nameof(UsingKeys.SDK_COMMON), UsingKeys.SDK_COMMON);

            // add interface
            entityClass.AddBaseType("Interface", $"I{entityClass.Name}");

            // doc (just use the name for now)
            entityClass.DocString = entityClass.Name;

            // set the filepath root/groupId/Class/Class.cs
            entityClass.FilePath = $"{rootFilePath}/{entityGroup}/{entityClass.Name}/";
            entityClass.FileName = $"{entityClass.Name}.cs";

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
            var properties = entity["fields"].Where(p => p["_key"].GetStringValue() != "id");
            foreach (var property in properties)
            {
                // extract info from config
                var name = property["_key"].GetStringValue().ToPascal();
                // docstring, fall back to name when no description is provided
                // TODO restore when multiline comment issue is solved
                // var docString = property["description"].GetStringValue() ?? property["_key"].GetStringValue();
                var docString = property["_key"].GetStringValue();

                var isReadOnly = property["readOnly"].GetBoolValue();

                // get type
                // format or type for most methods
                var swaggerType = property["format"].GetStringValue() ?? property["type"].GetStringValue();
                // if peoperty is array, get inner values
                var items = property["items"];
                // an array of foreign keys
                var foreignKey = property["items"] != null ? property["items"]["foreign_key"] : null;
                var innerValues = items != null ? foreignKey != null ? foreignKey["entity"].GetStringValue().ToPascal() : property["items"]["type"].GetStringValue() : null;

                // might be enum
                var propertyType = (property["enum"] != null && property["enum_reference"] != null) ?
                    property["enum_reference"].GetStringValue().ToPascal() :
                    SwaggerTypeHelper.GetForeignKeyType(property) ??
                    SwaggerTypeHelper.GetAdditionalProperties(property) ??
                    SwaggerTypeHelper.MapType(swaggerType, innerValues);

                // check if property type is enum
                if (propertyType.Contains("Enum"))
                {
                    // hacky but remove enum name from type
                    propertyType = propertyType.Replace("Enum", "");
                    entityClass.AddUsing("ENUM_KEY", UsingKeys.ENUMS);
                }

                var customGetter = property["getter_custom_method"] != null;
                var customSetter = property["setter_custom_method"] != null;

                var isNullable = !propertyType.Contains("List<") && !propertyType.Contains("Dictionary<") && !propertyType.Contains("string") && !propertyType.Contains("object") && !(SwaggerTypeHelper.GetForeignKeyType(property) != null);

                if (customGetter || customSetter)
                {
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
                    // need common for custom functions
                    entityClass.AddUsing(nameof(UsingKeys.SDK_COMMON), UsingKeys.SDK_COMMON);
                }
                else
                {
                    var propContainer = new PropertyWithSummaryContainer()
                    {
                        Name = name,
                        DocString = docString,
                        PropertyType = propertyType,
                        IsNullable = isNullable,
                        SetAccessorModifier = isReadOnly ? Modifiers.INTERNAL : Modifiers.PUBLIC,
                    };

                    propContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);

                    entityClass.AddProperty(name, propContainer);
                }

                // add usings for foreign keys
                if (foreignKey != null)
                {
                    var foreignKeyName = foreignKey["entity"].GetStringValue().ToPascal();
                    entityClass.AddUsing("FOREIGN_KEY", UsingKeys.FOUNDATION);
                }

                // add usings for date time
                if (propertyType == "DateTime")
                {
                    entityClass.AddUsing(nameof(UsingKeys.SYSTEM), UsingKeys.SYSTEM);
                }

                // add usings for list
                if (propertyType.Contains("List<") || propertyType.Contains("Dictionary<"))
                {
                    entityClass.AddUsing(nameof(UsingKeys.GENERIC_COLLECTIONS), UsingKeys.GENERIC_COLLECTIONS);
                }
            }

            compilation.AddClass(entityClass.Name, entityClass);

            var entityClassInterface = entityClass.Copy();
            // entityRepositoryInterface.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
            entityClassInterface.Name = $"I{entityClass.Name}";
            entityClassInterface.FilePath = $"{rootFilePath}/{entityGroup}/{entityPascalName}/";
            entityClassInterface.FileName = $"I{entityClass.FileName}";
            entityClassInterface.BaseTypes.Clear();
            entityClassInterface.IsInterface = true;

            compilation.AddClass(entityClassInterface.Name, entityClassInterface);
        }
    }
}