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
            foreach (var entity in entities)
            {
                var entityClass = new ClassContainer();

                // namespace
                entityClass.Namespace = "MbedCloud.SDK.Entities";

                // modifier (just public for now)
                entityClass.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);

                // name
                entityClass.Name = entity["_key"].GetStringValue().ToPascal();

                // add entity to factory
                var factoryProp = new EntityFactoryPropertyContainer
                {
                    Name = entityClass.Name,
                    PropertyType = entityClass.Name,
                    GetAccessor = true,
                    SetAccessor = false,
                    DocString = entityClass.Name,
                };
                factoryProp.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
                entityFactory.AddProperty($"{entityClass.Name}FacroryProp", factoryProp);

                // base type
                entityClass.AddBaseType("BASE_ENTITY", "BaseEntity");
                entityClass.AddUsing(nameof(UsingKeys.SDK_COMMON), UsingKeys.SDK_COMMON);

                // default constructor
                var defaultConstructor = new DefaultConfigConstructorContainer
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
                entityClass.AddUsing(nameof(UsingKeys.CLIENT), UsingKeys.CLIENT);

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

                    // if property is private
                    var isPrivate = property["private_field"] != null;

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
                        if (isPrivate)
                        {
                            propContainer.AddModifier(nameof(Modifiers.INTERNAL), Modifiers.INTERNAL);
                        }
                        else
                        {
                            propContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
                        }

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
                    // gather common info
                    var methodName = method["_key"].GetStringValue().ToPascal();
                    // the http method
                    var httpMethod = method["method"].GetStringValue()?.ToUpper();

                    // default deferToForeignKey to false
                    var deferToForeignKey = false;
                    DeferedMethodCallContainer deferedMethodCallContainer = null;
                    // if not method then defer to foreign key is true
                    if (httpMethod == null)
                    {
                        deferToForeignKey = true;
                    }

                    // the path
                    var path = method["path"].GetStringValue();

                    // is method paginated
                    var isPaginated = method["pagination"].GetBoolValue();

                    // is method private
                    var isPrivateMethod = method["private_method"] != null;

                    // is method a custom call
                    var isCustomMethodCall = method["custom_method"] != null;

                    // does method return a foreing key
                    var foreignKey = method["foreign_key"] != null ? method["foreign_key"]["entity"].GetStringValue().ToPascal() != entityClass.Name : false;

                    // return type
                    var returns = deferToForeignKey ? method["defer_to_foreign_key_field"]["foreign_key"]["entity"].GetStringValue().ToPascal() : foreignKey ? method["foreign_key"]["entity"].GetStringValue().ToPascal() : entityClass.Name;

                    // name of custom method
                    var customMethodName = method["custom_method"].GetStringValue().ToPascal();

                    if (isPaginated)
                    {
                        // add usings for paginated
                    }

                    if (foreignKey)
                    {
                        // add using for foreign key
                        entityClass.AddUsing("FOREIGN_KEY", $"MbedCloud.SDK.Entities");
                    }

                    // get method and field for defered method call
                    if (deferToForeignKey)
                    {
                        deferedMethodCallContainer = new DeferedMethodCallContainer
                        {
                            Name = methodName,
                            Method = method["defer_to_foreign_key_field"]["method"].GetStringValue().ToPascal(),
                            Field = method["defer_to_foreign_key_field"]["field"].GetStringValue().ToCamel(),
                            IsAsync = true,
                        };

                        // add using for foreign key
                        entityClass.AddUsing("FOREIGN_KEY", $"MbedCloud.SDK.Entities");
                    }

                    // gather parameters
                    var pathParams = new List<MyParameterContainer>();
                    var queryParams = new List<MyParameterContainer>();
                    var bodyParams = new List<MyParameterContainer>();
                    var fileParams = new List<MyParameterContainer>();
                    var deferedParams = new List<MyParameterContainer>();

                    foreach (var field in method["fields"])
                    {
                        // where is parameter?
                        var paramIn = field["in"].GetStringValue();
                        // is it external?
                        var external = field["external_param"].GetBoolValue();
                        // is it required?
                        var required = field["required"].GetBoolValue();
                        // the type
                        string type = null;
                        // the fieldname as it is in parameter
                        var fieldName = field["parameter_fieldname"].GetStringValue() ?? field["name"].GetStringValue();
                        // key on entity
                        var key = field["_key"].GetStringValue()?.ToPascal();
                        // replace body with other type
                        var replaceBody = field["__REPLACE_BODY"] != null;

                        if (external)
                        {
                            var internalVal = field["items"] != null ? field["items"]["type"].GetStringValue() : null;
                            type = SwaggerTypeHelper.MapType(field["type"].GetStringValue(), internalVal);
                            if (type == "Stream")
                            {
                                entityClass.AddUsing(nameof(UsingKeys.SYSTEM_IO), UsingKeys.SYSTEM_IO);
                            }
                        }

                        if (deferToForeignKey)
                        {
                            var param = new MyParameterContainer
                            {
                                Key = key,
                                ParamType = key,
                                External = external,
                                Required = required,
                                FieldName = fieldName,
                            };
                            deferedParams.Add(param);

                            // get assignments
                            foreach (var assigmnent in field["set_foreign_key_properties"])
                            {
                                var tmp = assigmnent as JProperty;
                                var externalKey = tmp.Name.ToPascal();
                                var selfKey = tmp.Value.GetStringValue().ToPascal();
                                deferedMethodCallContainer.AddAsignment(externalKey, selfKey);
                            }
                        }

                        if (paramIn == "path")
                        {
                            var param = new MyParameterContainer
                            {
                                Key = key,
                                ParamType = type,
                                External = external,
                                Required = required,
                                FieldName = fieldName,
                            };
                            pathParams.Add(param);
                        }

                        if (paramIn == "query")
                        {
                            var param = new MyParameterContainer
                            {
                                Key = key,
                                ParamType = type,
                                External = external,
                                Required = required,
                                FieldName = fieldName,
                            };
                            queryParams.Add(param);
                        }

                        if (paramIn == "body")
                        {
                            var param = new MyParameterContainer
                            {
                                Key = key,
                                ParamType = type,
                                External = external,
                                Required = required,
                                ReplaceBody = replaceBody,
                                FieldName = fieldName,
                            };
                            bodyParams.Add(param);
                        }

                        if (paramIn == "stream")
                        {
                            var param = new MyParameterContainer
                            {
                                Key = key,
                                ParamType = type,
                                External = external,
                                Required = required,
                                FieldName = fieldName,
                            };
                            fileParams.Add(param);
                        }
                    }

                    var methodParams = new MyMethodParameterContainer(deferedParams, pathParams, queryParams, bodyParams, fileParams);

                    // method is paginated, so create paginatedMethodContainer
                    if (isPaginated == true)
                    {
                        var paginatedMethodContainer = new PaginatedMethodContainer
                        {
                            EntityName = entityClass.Name,
                            Name = methodName,
                            HttpMethod = httpMethod,
                            Path = path,
                            Paginated = isPaginated,
                            Returns = returns,
                            PathParams = pathParams,
                            QueryParams = queryParams,
                            BodyParams = bodyParams,
                            FileParams = fileParams,
                            MethodParams = methodParams,
                            DeferToForeignKey = deferToForeignKey,
                            DeferedMethodCall = deferedMethodCallContainer,
                            CustomMethodCall = isCustomMethodCall,
                            CustomMethodName = customMethodName,
                            privateMethod = isPrivateMethod,
                        };

                        paginatedMethodContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);

                        entityClass.AddMethod(paginatedMethodContainer.Name, paginatedMethodContainer);
                    }
                    else if (deferToForeignKey)
                    {
                        // defered
                        deferedMethodCallContainer.MethodParams = methodParams;
                        deferedMethodCallContainer.Returns = returns;

                        deferedMethodCallContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);

                        entityClass.AddMethod(deferedMethodCallContainer.Name, deferedMethodCallContainer);
                    }
                    else if (isCustomMethodCall)
                    {
                        // custom method call
                        var customFunctionMethodContainer = new CustomFunctionMethodContainer
                        {
                            EntityName = entityClass.Name,
                            Name = methodName,
                            Returns = returns,
                            MethodParams = methodParams,
                            CustomMethodCall = isCustomMethodCall,
                            CustomMethodName = customMethodName,
                            privateMethod = isPrivateMethod,
                            IsAsync = true,
                        };

                        customFunctionMethodContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);

                        entityClass.AddMethod(customFunctionMethodContainer.Name, customFunctionMethodContainer);
                    }
                    else
                    {
                        var methodContainer = new DefaultMethodContainer()
                        {
                            EntityName = entityClass.Name,
                            Name = methodName,
                            HttpMethod = httpMethod,
                            Path = path,
                            Paginated = isPaginated,
                            Returns = returns,
                            PathParams = pathParams,
                            QueryParams = queryParams,
                            BodyParams = bodyParams,
                            FileParams = fileParams,
                            MethodParams = methodParams,
                            DeferToForeignKey = deferToForeignKey,
                            DeferedMethodCall = deferedMethodCallContainer,
                            CustomMethodCall = isCustomMethodCall,
                            CustomMethodName = customMethodName,
                            privateMethod = isPrivateMethod,
                            IsAsync = true,
                        };

                        if (isPrivateMethod)
                        {
                            methodContainer.AddModifier(nameof(Modifiers.INTERNAL), Modifiers.INTERNAL);
                        }
                        else
                        {
                            methodContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
                        }

                        entityClass.AddMethod(methodContainer.Name, methodContainer);
                    }
                }

                if (methods.Any())
                {
                    entityClass.AddUsing(nameof(UsingKeys.ASYNC), UsingKeys.ASYNC);
                    entityClass.AddUsing(nameof(UsingKeys.EXCEPTIONS), UsingKeys.EXCEPTIONS);
                    entityClass.AddUsing(nameof(UsingKeys.GENERIC_COLLECTIONS), UsingKeys.GENERIC_COLLECTIONS);
                }

                // remove Ids
                entityClass.Properties.Remove("Id");

                CompilationContainer.AddClass(entityClass.Name, entityClass);
            }

            CompilationContainer.AddClass(nameof(entityFactory), entityFactory);

            await CompilationContainer.Compile();
            CompilationContainer.WriteFiles();
        }
    }
}