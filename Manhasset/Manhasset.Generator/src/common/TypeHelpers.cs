using System;
using Manhasset.Core.src.Common;
using Manhasset.Core.src.Containers;
using Manhasset.Generator.src.extensions;
using Newtonsoft.Json.Linq;

namespace Manhasset.Generator.src.common
{
    public static class TypeHelpers
    {
        public static readonly string DateTimeFormatString = "yyyy-MM-dd'T'HH:mm:ss.fffZ";
        public static readonly string PythonDateFormatString = "yyyy-MM-dd";
        public static string GetPropertyType(JToken property, ClassContainer container = null)
        {
            // format or type for most methods
            var swaggerType = property["format"].GetStringValue() ?? property["type"].GetStringValue();
            // if peoperty is array, get inner values
            var items = property["items"];
            // an array of foreign keys
            var foreignKey = items != null ? items["foreign_key"] : null;
            var innerValues = items != null ? foreignKey != null ? foreignKey["entity"].GetStringValue().ToPascal() : items["type"].GetStringValue() : null;

            // might be enum
            var propertyType = (property["enum"] != null && property["enum_reference"] != null) ?
                property["enum_reference"].GetStringValue().ToPascal() :
                TypeHelpers.GetForeignKeyType(property) ??
                TypeHelpers.GetAdditionalProperties(property) ??
                TypeHelpers.MapType(swaggerType, innerValues);

            // check if property type is enum
            if (propertyType.Contains("Enum"))
            {
                // hacky but remove enum name from type
                propertyType = propertyType.Replace("Enum", "");
                if (container != null)
                {
                    container.AddUsing("ENUM_KEY", UsingKeys.ENUMS);
                }
            }

            return propertyType;
        }
        public static string MapType(string swaggerType, string internalValue = null)
        {
            // var type = getType() ?? swaggerType.ToPascal();

            return getType();

            string getType()
            {
                switch (swaggerType)
                {
                    case "boolean":
                        return "bool";
                    case "string":
                    case "uri":
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
                    case "filter":
                        return "Filter";
                    default:
                        return null;
                }
            };
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

        public static string MapFilterName(string filterOperator)
        {
            switch (filterOperator)
            {
                case "eq":
                    return "EqualTo";
                case "neq":
                    return "NotEqualTo";
                case "gte":
                    return "GreaterThan";
                case "lte":
                    return "LessThan";
                case "in":
                    return "In";
                case "nin":
                    return "NotIn";
                case "like":
                    return "Like";
                default:
                    return "EqualTo";
            }
        }
    }
}