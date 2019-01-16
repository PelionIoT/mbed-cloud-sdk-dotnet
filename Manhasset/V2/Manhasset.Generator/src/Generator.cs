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
            }

            //     // get methods
            //     var methods = entity["methods"];
            //     foreach (var method in methods)
            //     {
            //         // gather common info
            //         var methodName = method["_key"].GetStringValue().ToPascal();
            //         // the http method
            //         var httpMethod = method["method"].GetStringValue()?.ToUpper() ?? "GET";

            //         // default deferToForeignKey to false
            //         var deferToForeignKey = false;
            //         DeferedMethodCallContainer deferedMethodCallContainer = null;
            //         // if not method then defer to foreign key is true
            //         if (method["defer_to_foreign_key_field"] != null)
            //         {
            //             deferToForeignKey = true;
            //         }

            //         // the path
            //         var path = method["path"].GetStringValue();

            //         // is method paginated
            //         var isPaginated = method["pagination"].GetBoolValue();

            //         // is method private
            //         var isPrivateMethod = method["private_method"] != null;

            //         // is method a custom call
            //         var isCustomMethodCall = method["custom_method"] != null;

            //         // does method return a foreing key
            //         // var foreignKey = method["foreign_key"] != null ? method["foreign_key"]["entity"].GetStringValue().ToPascal() != entityClass.Name : false;
            //         var foreignKey = method["return_info"]["self"].GetBoolValue() == false && SwaggerTypeHelper.MapType(method["return_info"]["type"].GetStringValue()) == null;

            //         // return type
            //         // var returns = deferToForeignKey ? method["defer_to_foreign_key_field"]["foreign_key"]["entity"].GetStringValue().ToPascal() : foreignKey ? method["foreign_key"]["entity"].GetStringValue().ToPascal() : method["return_type"] != null ? SwaggerTypeHelper.MapType(method["return_type"].GetStringValue()) ?? entityClass.Name : entityClass.Name;
            //         var returns = deferToForeignKey ?
            //         method["defer_to_foreign_key_field"]["foreign_key"]["entity"].GetStringValue().ToPascal() :
            //         SwaggerTypeHelper.MapType(method["return_info"]["type"].GetStringValue()) ?? method["return_info"]["type"].GetStringValue().ToPascal();


            //         // name of custom method
            //         var customMethodName = method["custom_method"].GetStringValue().ToPascal();

            //         if (isPaginated)
            //         {
            //             // add usings for paginated
            //         }

            //         if (foreignKey)
            //         {
            //             // add using for foreign key
            //             entityClass.AddUsing("FOREIGN_KEY", $"MbedCloud.SDK.Entities");
            //         }

            //         // get method and field for defered method call
            //         if (deferToForeignKey)
            //         {
            //             deferedMethodCallContainer = new DeferedMethodCallContainer
            //             {
            //                 Name = methodName,
            //                 Method = method["defer_to_foreign_key_field"]["method"].GetStringValue().ToPascal(),
            //                 Field = method["defer_to_foreign_key_field"]["field"].GetStringValue().ToCamel(),
            //                 IsAsync = true,
            //             };

            //             // add using for foreign key
            //             entityClass.AddUsing("FOREIGN_KEY", $"MbedCloud.SDK.Entities");
            //         }

            //         // gather parameters
            //         var pathParams = new List<MyParameterContainer>();
            //         var queryParams = new List<MyParameterContainer>();
            //         var bodyParams = new List<MyParameterContainer>();
            //         var fileParams = new List<MyParameterContainer>();
            //         var deferedParams = new List<MyParameterContainer>();

            //         foreach (var field in method["fields"])
            //         {
            //             // where is parameter?
            //             var paramIn = field["in"].GetStringValue();
            //             // is it external?
            //             var external = field["external_param"].GetBoolValue();
            //             // is it required?
            //             var required = field["required"].GetBoolValue();
            //             // the type
            //             string type = null;
            //             // the fieldname as it is in parameter
            //             var fieldName = field["parameter_fieldname"].GetStringValue() ?? field["name"].GetStringValue();
            //             // key on entity
            //             var key = field["_key"].GetStringValue()?.ToPascal();
            //             // replace body with other type
            //             var replaceBody = field["__REPLACE_BODY"] != null;

            //             if (external)
            //             {
            //                 var internalVal = field["items"] != null ? field["items"]["type"].GetStringValue() : null;
            //                 type = SwaggerTypeHelper.GetAdditionalProperties(field) ?? SwaggerTypeHelper.MapType(field["type"].GetStringValue(), internalVal);
            //                 if (type == "Stream")
            //                 {
            //                     entityClass.AddUsing(nameof(UsingKeys.SYSTEM_IO), UsingKeys.SYSTEM_IO);
            //                 }
            //             }

            //             if (deferToForeignKey)
            //             {
            //                 var param = new MyParameterContainer
            //                 {
            //                     Key = key,
            //                     ParamType = key,
            //                     External = external,
            //                     Required = required,
            //                     FieldName = fieldName,
            //                 };
            //                 deferedParams.Add(param);

            //                 // get assignments
            //                 foreach (var assigmnent in field["set_foreign_key_properties"])
            //                 {
            //                     var tmp = assigmnent as JProperty;
            //                     var externalKey = tmp.Name.ToPascal();
            //                     var selfKey = tmp.Value.GetStringValue().ToPascal();
            //                     deferedMethodCallContainer.AddAsignment(externalKey, selfKey);
            //                 }
            //             }

            //             if (paramIn == "path")
            //             {
            //                 var param = new MyParameterContainer
            //                 {
            //                     Key = key,
            //                     ParamType = type,
            //                     External = external,
            //                     Required = required,
            //                     FieldName = fieldName,
            //                 };
            //                 pathParams.Add(param);
            //             }

            //             if (paramIn == "query")
            //             {
            //                 var param = new MyParameterContainer
            //                 {
            //                     Key = key,
            //                     ParamType = type,
            //                     External = external,
            //                     Required = required,
            //                     FieldName = fieldName,
            //                 };
            //                 queryParams.Add(param);
            //             }

            //             if (paramIn == "body")
            //             {
            //                 var param = new MyParameterContainer
            //                 {
            //                     Key = key,
            //                     ParamType = type,
            //                     External = external,
            //                     Required = required,
            //                     ReplaceBody = replaceBody,
            //                     FieldName = fieldName,
            //                 };
            //                 bodyParams.Add(param);
            //             }

            //             if (paramIn == "stream")
            //             {
            //                 var param = new MyParameterContainer
            //                 {
            //                     Key = key,
            //                     ParamType = type,
            //                     External = external,
            //                     Required = required,
            //                     FieldName = fieldName,
            //                 };
            //                 fileParams.Add(param);
            //             }
            //         }

            //         var methodParams = new MyMethodParameterContainer(deferedParams, pathParams, queryParams, bodyParams, fileParams);

            //         // method is paginated, so create paginatedMethodContainer
            //         if (isPaginated == true)
            //         {
            //             var paginatedMethodContainer = new PaginatedMethodContainer
            //             {
            //                 EntityName = entityClass.Name,
            //                 Name = methodName,
            //                 HttpMethod = httpMethod,
            //                 Path = path,
            //                 Paginated = isPaginated,
            //                 Returns = returns,
            //                 PathParams = pathParams,
            //                 QueryParams = queryParams,
            //                 BodyParams = bodyParams,
            //                 FileParams = fileParams,
            //                 MethodParams = methodParams,
            //                 DeferToForeignKey = deferToForeignKey,
            //                 DeferedMethodCall = deferedMethodCallContainer,
            //                 CustomMethodCall = isCustomMethodCall,
            //                 CustomMethodName = customMethodName,
            //                 privateMethod = isPrivateMethod,
            //             };

            //             paginatedMethodContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);

            //             entityClass.AddMethod(paginatedMethodContainer.Name, paginatedMethodContainer);
            //         }
            //         else if (deferToForeignKey)
            //         {
            //             // defered
            //             deferedMethodCallContainer.MethodParams = methodParams;
            //             deferedMethodCallContainer.Returns = returns;

            //             deferedMethodCallContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);

            //             entityClass.AddMethod(deferedMethodCallContainer.Name, deferedMethodCallContainer);
            //         }
            //         else if (isCustomMethodCall)
            //         {
            //             // custom method call
            //             var customFunctionMethodContainer = new CustomFunctionMethodContainer
            //             {
            //                 EntityName = entityClass.Name,
            //                 Name = methodName,
            //                 Returns = returns,
            //                 MethodParams = methodParams,
            //                 CustomMethodCall = isCustomMethodCall,
            //                 CustomMethodName = customMethodName,
            //                 privateMethod = isPrivateMethod,
            //                 IsAsync = true,
            //             };

            //             customFunctionMethodContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);

            //             entityClass.AddMethod(customFunctionMethodContainer.Name, customFunctionMethodContainer);
            //         }
            //         else
            //         {
            //             var methodContainer = new DefaultMethodContainer()
            //             {
            //                 EntityName = entityClass.Name,
            //                 Name = methodName,
            //                 HttpMethod = httpMethod,
            //                 Path = path,
            //                 Paginated = isPaginated,
            //                 Returns = returns,
            //                 PathParams = pathParams,
            //                 QueryParams = queryParams,
            //                 BodyParams = bodyParams,
            //                 FileParams = fileParams,
            //                 MethodParams = methodParams,
            //                 DeferToForeignKey = deferToForeignKey,
            //                 DeferedMethodCall = deferedMethodCallContainer,
            //                 CustomMethodCall = isCustomMethodCall,
            //                 CustomMethodName = customMethodName,
            //                 privateMethod = isPrivateMethod,
            //                 IsAsync = true,
            //             };

            //             if (isPrivateMethod)
            //             {
            //                 methodContainer.AddModifier(nameof(Modifiers.INTERNAL), Modifiers.INTERNAL);
            //             }
            //             else
            //             {
            //                 methodContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
            //             }

            //             entityClass.AddMethod(methodContainer.Name, methodContainer);
            //         }
            //     }

            //     if (methods.Any())
            //     {
            //         entityClass.AddUsing(nameof(UsingKeys.ASYNC), UsingKeys.ASYNC);
            //         entityClass.AddUsing(nameof(UsingKeys.EXCEPTIONS), UsingKeys.EXCEPTIONS);
            //         entityClass.AddUsing(nameof(UsingKeys.GENERIC_COLLECTIONS), UsingKeys.GENERIC_COLLECTIONS);
            //     }

            //     // remove Ids
            //     entityClass.Properties.Remove("Id");

            //     CompilationContainer.AddClass(entityClass.Name, entityClass);
            // }

            CompilationContainer.AddClass(nameof(entityFactory), entityFactory);

            await CompilationContainer.Compile();
            CompilationContainer.WriteFiles();
        }
    }
}