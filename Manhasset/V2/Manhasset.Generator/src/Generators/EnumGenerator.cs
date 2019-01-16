using System.Collections.Generic;
using System.Linq;
using Manhasset.Core.src.Common;
using Manhasset.Core.src.Compile;
using Manhasset.Core.src.Containers;
using Manhasset.Generator.src.extensions;
using Newtonsoft.Json.Linq;

namespace Manhasset.Generator.src.Generators
{
    public class EnumGenerator
    {
        public static void GenerateEnums(JToken entity, string rootFilePath, string group, string entityName, Compilation compilationContainer)
        {
            var enums = entity["fields"].Where(f => f["enum_reference"] != null);

            // namespace will be common to all enums
            var enumNamespace = "MbedCloud.SDK.Enums";

            foreach (var anEnum in enums)
            {
                var values = new List<string>() { "UNKNOWN_ENUM_VALUE_RECEIVED" };
                var name = anEnum["enum_reference"].GetStringValue().ToPascal();
                values.AddRange(anEnum["enum"].Values<string>().ToList());
                var filePath = $"{rootFilePath}/{group}/{entityName}/{name}.cs";

                var enumContainer = new EnumContainer
                {
                    Name = name,
                    Namespace = enumNamespace,
                    Values = values,
                    FilePath = filePath,
                };

                enumContainer.AddModifier(nameof(Modifiers.PUBLIC), Modifiers.PUBLIC);

                compilationContainer.AddEnum(name, enumContainer);
            }
        }
    }
}