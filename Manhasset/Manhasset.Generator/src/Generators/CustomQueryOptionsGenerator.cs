using System;
using System.Collections.Generic;
using System.Linq;
using Manhasset.Core.src.Common;
using Manhasset.Core.src.Compile;
using Manhasset.Core.src.Containers;
using Manhasset.Core.src.Extensions;
using Manhasset.Generator.src.common;
using Manhasset.Generator.src.CustomContainers;
using Manhasset.Generator.src.CustomContainers.Methods;
using Manhasset.Generator.src.extensions;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Compilation = Manhasset.Core.src.Compile.Compilation;

namespace Manhasset.Generator.src.Generators
{
    public class CustomQueryOptionsGenerator
    {
        public static string GenerateCustomQueryOptions(JToken method, JToken fields, string entityName, string returns, string rootFilePath, string entityGroup, Compilation compilation)
        {
            var optionsName = $"{TypeHelpers.GetListOptionsName(entityName, returns)}ListOptions";

            var extraQueryParams = method["fields"].Where(
                q => q["in"].GetStringValue() == "query" &&
                q["_key"].GetStringValue() != "after" &&
                q["_key"].GetStringValue() != "include" &&
                q["_key"].GetStringValue() != "limit" &&
                q["_key"].GetStringValue() != "order"
            ).ToList();

            var customQueryOptions = new ClassContainer();

            // namespace
            customQueryOptions.Namespace = UsingKeys.FOUNDATION;

            // modifier (just public for now)
            customQueryOptions.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);

            // name
            customQueryOptions.Name = optionsName;

            // base type
            customQueryOptions.AddBaseType("BASE_LIST_OPTIONS", "QueryOptions");
            customQueryOptions.AddUsing(nameof(UsingKeys.SDK_COMMON), UsingKeys.SDK_COMMON);

            // interface
            customQueryOptions.AddBaseType("BASE_LIST_OPTIONS_INTERFACE", $"I{customQueryOptions.Name}");

            // doc (just use the name for now)
            customQueryOptions.DocString = customQueryOptions.Name;

            // set the filepath root/groupId/Class/Class.cs
            customQueryOptions.FilePath = $"{rootFilePath}/{entityGroup}/{entityName}/";
            customQueryOptions.FileName = $"{customQueryOptions.Name}.cs";

            if (extraQueryParams.Count > 0)
            {
                extraQueryParams.ForEach(e =>
                {
                    var propContainer = new PropertyWithSummaryContainer
                    {
                        Name = e["_key"].GetStringValue().ToPascal(),
                        PropertyType = "string",
                    };
                    propContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
                    customQueryOptions.AddProperty(propContainer.Name, propContainer);
                });
            }

            var filter = method["x_filter"];

            if (filter.Any())
            {
                var filterPropertyContainer = new PropertyWithSummaryContainer
                {
                    Name = "Filter",
                    PropertyType = "Filter",
                    DocString = "Filter object",
                };
                filterPropertyContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
                customQueryOptions.AddUsing(nameof(UsingKeys.FILTERS), UsingKeys.FILTERS);
                customQueryOptions.AddProperty(filterPropertyContainer.Name, filterPropertyContainer);

                foreach (var filterValue in filter)
                {
                    if (filterValue is JProperty filterValueProperty)
                    {
                        var filterValueName = filterValueProperty.Name;
                        var filterType = "string";

                        var correspondingField = fields.FirstOrDefault(f => f["_key"].GetStringValue() == filterValueName);
                        if (correspondingField != null)
                        {
                            filterType = TypeHelpers.GetPropertyType(correspondingField, customQueryOptions);
                            if (filterType == "DateTime")
                            {
                                customQueryOptions.AddUsing(nameof(UsingKeys.SYSTEM), UsingKeys.SYSTEM);
                            }
                            // add usings for list
                            if (filterType.Contains("List<") || filterType.Contains("Dictionary<"))
                            {
                                customQueryOptions.AddUsing(nameof(UsingKeys.GENERIC_COLLECTIONS), UsingKeys.GENERIC_COLLECTIONS);
                            }
                        }

                        var filterOperators = filterValueProperty.Children().FirstOrDefault();
                        if (filterOperators != null)
                        {
                            filterOperators.Children().ToList().ForEach(f =>
                            {
                                var filterOperator = f.GetStringValue();
                                string enumerableFilterType = null;
                                if (filterOperator == "in" || filterOperator == "nin")
                                {
                                    enumerableFilterType = $"{filterType}[]";
                                    customQueryOptions.AddUsing(nameof(UsingKeys.GENERIC_COLLECTIONS), UsingKeys.GENERIC_COLLECTIONS);
                                }
                                var methodName = $"{filterValueName}{TypeHelpers.MapFilterName(filterOperator)}".ToPascal();
                                var filterMethodParams = new MethodParameterContainer
                                {
                                    Parameters = new List<ParameterContainer>()
                                    {
                                        new ParameterContainer
                                        {
                                            Key = "value",
                                            ParamType = enumerableFilterType ?? filterType,
                                            Required = true,
                                            MyModifiers = !string.IsNullOrEmpty(enumerableFilterType)
                                                            ? new Dictionary<string, SyntaxToken> { { nameof(Modifiers.PARAMS), Modifiers.PARAMS } }
                                                            : new Dictionary<string, SyntaxToken>(),
                                        }
                                    }
                                };

                                var filterMethodContainer = new FilterExtensionMethodContainer
                                {
                                    Name = methodName,
                                    Returns = optionsName,
                                    MethodParams = filterMethodParams,
                                    FilterKey = filterValueName,
                                    FilterOperator = filterOperator,
                                };
                                filterMethodContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
                                customQueryOptions.AddMethod(methodName, filterMethodContainer);
                            });
                        }
                    }
                }

                var customQueryOptionsConstructor = new ListOptionsConstructor
                {
                    Name = customQueryOptions.Name,
                };
                customQueryOptionsConstructor.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
                customQueryOptions.AddConstructor(nameof(customQueryOptionsConstructor), customQueryOptionsConstructor);
            }

            compilation.AddClass($"{entityGroup}-{entityName}-{returns}", customQueryOptions);

            var customQueryOptionsInterface = customQueryOptions.Copy();
            // entityRepositoryInterface.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);
            customQueryOptionsInterface.Name = $"I{optionsName}";
            customQueryOptionsInterface.FilePath = $"{rootFilePath}/{entityGroup}/{entityName}/";
            customQueryOptionsInterface.FileName = $"I{customQueryOptions.FileName}";
            customQueryOptionsInterface.IsInterface = true;
            customQueryOptionsInterface.BaseTypes.Clear();
            customQueryOptionsInterface.AddBaseType("BASE_LIST_OPTIONS_INTERFACE", "IQueryOptions");

            compilation.AddClass($"{entityGroup}-{entityName}-{returns}-interface", customQueryOptionsInterface);

            return optionsName;
        }
    }
}