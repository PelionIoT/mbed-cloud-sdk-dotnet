// <copyright file="EntityConverter.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace Mbed.Cloud.Common.CustomSerializers
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json;

    /// <summary>
    /// EntityConverter
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter" />
    public class EntityConverter : JsonConverter
    {
        private Config config;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityConverter"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public EntityConverter(Config config)
        {
            this.config = config;
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsSubclassOf(typeof(Entity));
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
        /// <exception cref="JsonSerializationException">No object created.</exception>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var value = Create(objectType);
            if (value == null)
            {
                throw new JsonSerializationException("No object created.");
            }

            serializer.Populate(reader, value);
            return value;
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Object</returns>
        public object Create(Type objectType)
        {
            var configConstructor = objectType.GetConstructors(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(c => c.GetParameters().FirstOrDefault()?.Name == nameof(config));

            if (configConstructor != null)
            {
                return Activator.CreateInstance(objectType, new object[] { config });
            }

            return Activator.CreateInstance(objectType);
        }
    }
}