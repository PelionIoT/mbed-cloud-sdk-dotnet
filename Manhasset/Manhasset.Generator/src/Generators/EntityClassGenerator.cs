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
                var propertyType = TypeHelpers.GetPropertyType(property, entityClass);

                var customGetter = property["getter_custom_method"] != null;
                var customSetter = property["setter_custom_method"] != null;

                var isNullable = isNullableType(propertyType, property);

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
                    entityClass.AddUsing(nameof(UsingKeys.JSON), UsingKeys.JSON);

                    var backingField = new PrivateFieldContainer
                    {
                        Name = name.PascalToCamel(),
                        FieldType = propertyType,
                    };
                    backingField.AddModifier(nameof(Modifiers.INTERNAL), Modifiers.INTERNAL);

                    entityClass.AddPrivateField($"{name}_BACKING_FIELD", backingField);
                }
                else if (propertyType == "DateTime")
                {
                    var format = property["format"].GetStringValue();

                    var propContainer = new DateTimePropertyContainer()
                    {
                        Name = name,
                        DocString = docString,
                        PropertyType = propertyType,
                        IsNullable = isNullable,
                        SetAccessorModifier = isReadOnly ? Modifiers.INTERNAL : Modifiers.PUBLIC,
                        DateFormat = format,
                    };

                    propContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);

                    entityClass.AddProperty(name, propContainer);
                    entityClass.AddUsing(nameof(UsingKeys.JSON), UsingKeys.JSON);
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
                var foreignKey = property["items"] != null ? property["items"]["foreign_key"] : null;
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

                // add usings for date time
                if (propertyType == "Filter")
                {
                    entityClass.AddUsing(nameof(UsingKeys.FILTERS), UsingKeys.FILTERS);
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

        private static bool isNullableType(string propertyType, JToken property)
        {
            return !propertyType.Contains("List<")
                && !propertyType.Contains("Dictionary<")
                && !propertyType.Contains("string")
                && !propertyType.Contains("object")
                // && !propertyType.Contains("int")
                && !propertyType.Contains("Filter")
                && !(TypeHelpers.GetForeignKeyType(property) != null);
        }
    }
}