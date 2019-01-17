using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace Mbed.Cloud.Foundation.Common.CustomSerializers
{
    public class EntityConverter : JsonConverter
    {
        private Config _config;

        public EntityConverter(Config config)
        {
            _config = config;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsSubclassOf(typeof(Entity));
        }

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

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public object Create(Type objectType)
        {
            var configConstructor = objectType.GetConstructors(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(c => c.GetParameters().FirstOrDefault()?.Name == "config");

            if (configConstructor != null)
            {
                return Activator.CreateInstance(objectType, new object[] { _config });
            }

            return Activator.CreateInstance(objectType);
        }
    }
}