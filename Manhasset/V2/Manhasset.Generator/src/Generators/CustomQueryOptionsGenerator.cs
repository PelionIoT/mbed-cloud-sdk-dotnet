using System;
using System.Linq;
using Manhasset.Core.src.Common;
using Manhasset.Core.src.Compile;
using Manhasset.Core.src.Containers;
using Manhasset.Generator.src.common;
using Manhasset.Generator.src.CustomContainers;
using Manhasset.Generator.src.extensions;
using Newtonsoft.Json.Linq;

namespace Manhasset.Generator.src.Generators
{
    public class CustomQueryOptionsGenerator
    {
        public static string GenerateCustomQueryOptions(JToken method, string entityName, string returns, string rootFilePath, string entityGroup, Compilation compilation)
        {
            var optionsName = $"{returns}ListOptions";

            var extraQueryParams = method["fields"].Where(
                q => q["in"].GetStringValue() == "query" &&
                q["_key"].GetStringValue() != "after" &&
                q["_key"].GetStringValue() != "include" &&
                q["_key"].GetStringValue() != "limit" &&
                q["_key"].GetStringValue() != "order"
            ).ToList();

            var customQueryOptions = new ClassContainer();

            // namespace
            customQueryOptions.Namespace = $"MbedCloud.SDK.Entities.ListOptions";

            // modifier (just public for now)
            customQueryOptions.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);

            // name
            customQueryOptions.Name = optionsName;

            // base type
            customQueryOptions.AddBaseType("BASE_LIST_OPTIONS", "QueryOptions");
            customQueryOptions.AddUsing(nameof(UsingKeys.SDK_COMMON), UsingKeys.SDK_COMMON);

            // doc (just use the name for now)
            customQueryOptions.DocString = customQueryOptions.Name;

            // set the filepath root/groupId/Class/Class.cs
            customQueryOptions.FilePath = $"{rootFilePath}/{entityGroup}/{entityName}/{customQueryOptions.Name}.cs";

            if(extraQueryParams.Count > 0) {
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

            compilation.AddClass($"{entityGroup}-{entityName}-{returns}", customQueryOptions);

            return optionsName;
        }
    }
}