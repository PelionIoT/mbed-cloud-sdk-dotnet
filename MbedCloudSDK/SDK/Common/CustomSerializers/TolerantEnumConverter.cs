// <copyright file="TolerantEnumConverter.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace Mbed.Cloud.Foundation.Common.CustomSerializers
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Tolerant enum converter
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter" />
    public class TolerantEnumConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            var type = IsNullableType(objectType) ? Nullable.GetUnderlyingType(objectType) : objectType;
            return type.IsEnum;
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var isNullable = IsNullableType(objectType);
            var enumType = isNullable ? Nullable.GetUnderlyingType(objectType) : objectType;

            var names = Enum.GetNames(enumType);

            if (reader.TokenType == JsonToken.String)
            {
                var enumText = reader.Value.ToString();

                if (!string.IsNullOrEmpty(enumText))
                {
                    var match = names
.FirstOrDefault(n => string.Equals(n, enumText, StringComparison.OrdinalIgnoreCase))
;

                    if (match != null)
                    {
                        return Enum.Parse(enumType, match);
                    }
                }
            }
            else if (reader.TokenType == JsonToken.Integer)
            {
                var enumVal = Convert.ToInt32(reader.Value);
                var values = (int[])Enum.GetValues(enumType);
                if (values.Contains(enumVal))
                {
                    return Enum.Parse(enumType, enumVal.ToString());
                }
            }

            if (isNullable && reader.Value == null)
            {
                return null;
            }

            var defaultName = names
                    .FirstOrDefault(n => string.Equals(n, "UNKNOWN_ENUM_VALUE_RECEIVED", StringComparison.OrdinalIgnoreCase));

            if (defaultName == null)
            {
                defaultName = names.First();
            }

            Console.WriteLine($"Received unknown enum value {reader?.Value?.ToString()}");

            return Enum.Parse(enumType, defaultName);
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        private static bool IsNullableType(Type t)
        {
            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}