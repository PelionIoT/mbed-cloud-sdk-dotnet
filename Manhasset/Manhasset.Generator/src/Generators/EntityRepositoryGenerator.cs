using System;
using System.Collections.Generic;
using System.Linq;
using Manhasset.Core.src.Common;
using Manhasset.Core.src.Compile;
using Manhasset.Core.src.Containers;
using Manhasset.Core.src.Extensions;
using Manhasset.Generator.src.common;
using Manhasset.Generator.src.CustomContainers;
using Manhasset.Generator.src.extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Manhasset.Generator.src.Generators
{
    public class EntityRepositoryGenerator
    {
        public static void GenerateRepository(JToken entity, string entityPascalName, string rootFilePath, string entityGroup, Compilation compilation)
        {
            var entityRepository = new ClassContainer();

            // namespace
            entityRepository.Namespace = UsingKeys.FOUNDATION;

            // modifier
            entityRepository.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);

            // name
            entityRepository.Name = $"{entityPascalName}Repository";

            // base type
            entityRepository.AddBaseType("BASE_ENTITY", "Repository");
            entityRepository.AddUsing(nameof(UsingKeys.SDK_COMMON), UsingKeys.SDK_COMMON);

            // add interface
            entityRepository.AddBaseType("INTERFACE", $"I{entityRepository.Name}");

            // doc (just use the name for now)
            entityRepository.DocString = entityRepository.Name;

            // set the filepath root/groupId/Class/Class.cs
            entityRepository.FilePath = $"{rootFilePath}/{entityGroup}/{entityPascalName}/";
            entityRepository.FileName = $"{entityRepository.Name}.cs";

            //default constructor
            var defaultConstructor = new ConstructorContainer
            {
                Name = entityRepository.Name,
            };
            defaultConstructor.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
            entityRepository.AddConstructor("DEFAULT", defaultConstructor);

            // config constructor
            var configConstructor = new DefaultConfigConstructorContainer
            {
                Name = entityRepository.Name
            };
            configConstructor.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
            entityRepository.AddConstructor("CONFIG", configConstructor);

            // get methods
            var methods = entity["methods"];

            foreach (var method in methods)
            {
                // gather common info
                var methodName = method["_key"].GetStringValue().ToPascal();
                // the http method
                var httpMethod = method["method"].GetStringValue()?.ToUpper() ?? "GET";

                // if method return type is void
                var isVoid = httpMethod == "DELETE" ? true : false;

                // the path
                var path = method["path"].GetStringValue();

                // is method paginated
                var isPaginated = method["pagination"].GetBoolValue();

                // is method private
                var isPrivateMethod = method["private_method"] != null;

                // is method a custom call
                var isCustomMethodCall = method["custom_method"] != null;

                // does method return a foreing key
                var foreignKey = method["return_info"]["self"].GetBoolValue() == false && TypeHelpers.MapType(method["return_info"]["type"].GetStringValue()) == null;

                // return type
                var returns = TypeHelpers.MapType(method["return_info"]["type"].GetStringValue()) ?? method["return_info"]["type"].GetStringValue().ToPascal();

                // name of custom method
                var customMethodName = method["custom_method"].GetStringValue().ToPascal();

                if (isPaginated)
                {
                    // add usings for paginated
                }

                if (foreignKey)
                {
                    // add using for foreign key
                    entityRepository.AddUsing("FOREIGN_KEY", UsingKeys.FOUNDATION);
                }

                var hasRequest = false;

                // gather internal parameters
                var pathParams = new List<MyParameterContainer>();
                var queryParams = new List<MyParameterContainer>();
                var bodyParams = new List<MyParameterContainer>();
                var fileParams = new List<MyParameterContainer>();
                var formParams = new List<MyParameterContainer>();

                // does method need a request param
                if (method["fields"].Any(f => f["in"].GetStringValue() == "body"))
                {
                    var requestParam = new MyParameterContainer
                    {
                        Key = "request",
                        ParamType = returns ?? "string",
                        External = true,
                        Required = true,
                        FieldName = "request",
                    };
                    bodyParams.Add(requestParam);
                    hasRequest = true;
                }

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

                    var internalVal = field["items"] != null ? field["items"]["type"].GetStringValue() : null;
                    type = TypeHelpers.GetAdditionalProperties(field) ?? TypeHelpers.MapType(field["type"].GetStringValue(), internalVal) ?? "string";
                    if (type == "Stream")
                    {
                        entityRepository.AddUsing(nameof(UsingKeys.SYSTEM_IO), UsingKeys.SYSTEM_IO);
                    }

                    if (paramIn == "path")
                    {
                        var param = new MyParameterContainer
                        {
                            Key = key,
                            ParamType = type,
                            External = true,
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
                            External = true,
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
                            CallContext = "request",
                        };
                        bodyParams.Add(param);
                    }

                    if (paramIn == "stream")
                    {
                        if (field["type"].GetStringValue() == "file")
                        {
                            var param = new MyParameterContainer
                            {
                                Key = key,
                                ParamType = type,
                                External = true,
                                Required = required,
                                FieldName = fieldName,
                            };
                            fileParams.Add(param);
                        }
                        else
                        {
                            var param = new MyParameterContainer
                            {
                                Key = key,
                                ParamType = type,
                                External = true,
                                Required = required,
                                FieldName = fieldName,
                            };
                            formParams.Add(param);
                        }
                    }
                }

                var filter = method["x_filter"];

                if (filter.Any())
                {
                    foreach (var filterValue in filter)
                    {
                        if (filterValue is JProperty filterValueProperty)
                        {
                            var filterValueName = filterValueProperty.Name;
                            var apiFilterName = filterValueName;

                            var correspondingField = entity["fields"].FirstOrDefault(f => f["_key"].GetStringValue() == filterValueName);
                            if (correspondingField != null)
                            {
                                apiFilterName = correspondingField["api_fieldname"].GetStringValue();
                            }

                            var filterOperators = filterValueProperty.Children().FirstOrDefault();
                            if (filterOperators != null)
                            {
                                filterOperators.Children().ToList().ForEach(f =>
                                {
                                    var filterOperator = f.GetStringValue();
                                    var filterQueryKey = $"{apiFilterName}__{filterOperator}";
                                    var filterParam = new MyParameterContainer
                                    {
                                        Key = $"Filter.GetEncodedValue(\"{filterValueName}\", \"${filterOperator}\")",
                                        ParamType = "string",
                                        Required = false,
                                        FieldName = filterQueryKey,
                                        External = false,
                                    };
                                    queryParams.Add(filterParam);
                                });
                            }
                        }
                    }
                }

                var methodParams = new MyMethodParameterContainer(pathParams, isPaginated ? new List<MyParameterContainer>() : queryParams, bodyParams, fileParams, formParams);

                // method is paginated, so create paginatedMethodContainer
                if (isPaginated == true)
                {
                    var listOptionsName = CustomQueryOptionsGenerator.GenerateCustomQueryOptions(method, entity["fields"], entityPascalName, returns, rootFilePath, entityGroup, compilation);

                    methodParams.Parameters.Insert(0, new MyParameterContainer
                    {
                        Key = "options",
                        ParamType = $"I{listOptionsName}",
                        Required = false,
                    });
                    var paginatedMethodContainer = new PaginatedMethodContainer
                    {
                        EntityName = entityPascalName,
                        Name = methodName,
                        HttpMethod = httpMethod,
                        Path = path,
                        Paginated = isPaginated,
                        Returns = returns,
                        PathParams = pathParams,
                        QueryParams = queryParams,
                        BodyParams = bodyParams,
                        FileParams = fileParams,
                        FormParams = formParams,
                        MethodParams = methodParams,
                        CustomMethodCall = isCustomMethodCall,
                        CustomMethodName = customMethodName,
                        privateMethod = isPrivateMethod,
                        ListOptionsName = $"I{listOptionsName}",
                    };

                    paginatedMethodContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);

                    entityRepository.AddMethod(paginatedMethodContainer.Name, paginatedMethodContainer);
                }
                else if (isCustomMethodCall)
                {
                    var customMethodParams = new MethodParameterContainer();
                    customMethodParams.Parameters = new List<ParameterContainer>()
                    {
                        new MyParameterContainer
                        {
                            Key = "model",
                            ParamType = entityPascalName,
                            Required = true,
                            External = true,
                            FieldName = "model",
                        }
                    };
                    // custom method call
                    var customFunctionMethodContainer = new CustomFunctionMethodContainer
                    {
                        EntityName = entityPascalName,
                        Name = methodName,
                        Returns = returns,
                        MethodParams = customMethodParams,
                        CustomMethodCall = isCustomMethodCall,
                        CustomMethodName = customMethodName,
                        privateMethod = isPrivateMethod,
                        IsAsync = true,
                    };

                    customFunctionMethodContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);

                    entityRepository.AddMethod(customFunctionMethodContainer.Name, customFunctionMethodContainer);
                }
                else
                {
                    var methodContainer = new DefaultMethodContainer()
                    {
                        EntityName = entityPascalName,
                        Name = methodName,
                        HttpMethod = httpMethod,
                        Path = path,
                        Paginated = isPaginated,
                        Returns = returns,
                        PathParams = pathParams,
                        QueryParams = queryParams,
                        BodyParams = bodyParams,
                        FileParams = fileParams,
                        FormParams = formParams,
                        MethodParams = methodParams,
                        CustomMethodCall = isCustomMethodCall,
                        CustomMethodName = customMethodName,
                        privateMethod = isPrivateMethod,
                        IsAsync = true,
                        HasRequest = hasRequest,
                        IsVoidTask = isVoid,
                    };

                    if (isPrivateMethod)
                    {
                        methodContainer.AddModifier(nameof(Modifiers.INTERNAL), Modifiers.INTERNAL);
                    }
                    else
                    {
                        methodContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
                    }

                    entityRepository.AddMethod(methodContainer.Name, methodContainer);
                }
            }

            if (methods.Any())
            {
                entityRepository.AddUsing(nameof(UsingKeys.ASYNC), UsingKeys.ASYNC);
                entityRepository.AddUsing(nameof(UsingKeys.EXCEPTIONS), UsingKeys.EXCEPTIONS);
                entityRepository.AddUsing(nameof(UsingKeys.GENERIC_COLLECTIONS), UsingKeys.GENERIC_COLLECTIONS);
                entityRepository.AddUsing(nameof(UsingKeys.SYSTEM), UsingKeys.SYSTEM);
                entityRepository.AddUsing(nameof(UsingKeys.CLIENT), UsingKeys.CLIENT);
            }

            compilation.AddClass(entityRepository.Name, entityRepository);

            var entityRepositoryInterface = entityRepository.Copy();
            // entityRepositoryInterface.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
            entityRepositoryInterface.Name = $"I{entityRepository.Name}";
            entityRepositoryInterface.FilePath = $"{rootFilePath}/{entityGroup}/{entityPascalName}/";
            entityRepositoryInterface.FileName = $"I{entityRepository.FileName}";
            entityRepositoryInterface.BaseTypes.Clear();
            entityRepositoryInterface.IsInterface = true;

            compilation.AddClass(entityRepositoryInterface.Name, entityRepositoryInterface);
        }
    }
}