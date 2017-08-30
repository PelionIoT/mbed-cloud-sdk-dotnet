using System;
using Newtonsoft.Json;

namespace mbedCloudSDK.Certificates.Model
{
    public class CertificateStatusConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var certificateStatus = (CertificateStatus)value;

            switch (certificateStatus)
            {
                case CertificateStatus.Active:
                    writer.WriteValue("active");
                    break;
                case CertificateStatus.Inactive:
                    writer.WriteValue("inactive");
                    break;
                default:
                    break;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;

            switch (enumString)
            {
                case "active":
                    return CertificateStatus.Active;
                case "inactive":
                    return CertificateStatus.Inactive;
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