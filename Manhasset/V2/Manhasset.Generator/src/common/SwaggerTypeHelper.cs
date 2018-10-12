using Manhasset.Core.src.Common;

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
                    return "DateTime";
                case "array":
                    return $"List<{internalValue}>";
                default:
                    return "object";
            }
        }
    }
}