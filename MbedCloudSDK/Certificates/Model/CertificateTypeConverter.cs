// <copyright file="CertificateTypeConverter.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System;
using MbedCloudSDK.Common;
using Newtonsoft.Json;

namespace MbedCloudSDK.Certificates.Model
{
    /// <summary>
    /// Converter for certificate type enum
    /// </summary>
    public class CertificateTypeConverter : JsonConverter
    {
        /// <summary>
        /// Write Json
        /// </summary>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(Utils.GetEnumMemberValue(typeof(CertificateType), ((CertificateType)value).ToString()));
        }

        /// <summary>
        /// Read Json
        /// </summary>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;
            return Utils.GetEnumFromEnumMemberValue(typeof(CertificateType), enumString);
        }

        /// <summary>
        /// Can convert
        /// </summary>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}