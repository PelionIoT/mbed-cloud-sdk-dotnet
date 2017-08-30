using System;
using Newtonsoft.Json;

namespace mbedCloudSDK.Certificates.Model
{
    public class CertificateTypeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var certificateType = (CertificateType)value;

            switch (certificateType)
            {
                case CertificateType.Bootstrap:
                    writer.WriteValue("bootstrap");
                    break;
                case CertificateType.Developer:
                    writer.WriteValue("developer");
                    break;
                case CertificateType.Lwm2m:
                    writer.WriteValue("lwm2m");
                    break;
                default:
                    break;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;

            switch(enumString)
            {
                case "bootstrap":
                    return CertificateType.Bootstrap;
                case "developer":
                    return CertificateType.Developer;
                case "lwm2m":
                    return CertificateType.Lwm2m;
                default:
                    return null;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}