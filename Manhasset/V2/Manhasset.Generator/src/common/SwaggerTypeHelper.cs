using Manhasset.Core.src.Common;
using Manhasset.Generator.src.extensions;
using Newtonsoft.Json.Linq;

namespace Manhasset.Generator.src.common
{
    public static class SwaggerTypeHelper
    {
        public static string MapType(string swaggerType, string internalValue = null)
        {
            switch (swaggerType)
            {
                case "boolean":
                    return "bool";
                case "string":
                    return "string";
                case "integer":
                case "int32":
                    return "int";
                case "int64":
                    return "long";
                case "object":
                    return "object";
                case "file":
                    return "Stream";
                case "date-time":
                case "date":
                    return "DateTime";
                case "array":
                    return $"List<{internalValue}>";
                default:
                    return "object";
            }
        }

        public static string GetForeignKeyType(JToken field)
        {
            if (field["foreign_key"] != null)
            {
                return field["foreign_key"]["entity"].GetStringValue().ToPascal();
            }

            return default(string);
        }

        public static string GetAdditionalProperties(JToken field)
        {
            if (field["additionalProperties"] != null)
            {
                return "Dictionary<string, string>";
            }

            return default(string);
        }
    }
}