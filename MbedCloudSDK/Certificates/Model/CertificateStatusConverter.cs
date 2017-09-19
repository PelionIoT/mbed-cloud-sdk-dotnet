// <copyright file="CertificateStatusConverter.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System;
using MbedCloudSDK.Common;
using Newtonsoft.Json;

namespace MbedCloudSDK.Certificates.Model
{
    /// <summary>
    /// Converter for certificate status enum
    /// </summary>
    public class CertificateStatusConverter : JsonConverter
    {
        /// <summary>
        /// Write Json
        /// </summary>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var certificateStatus = (CertificateStatus)value;
            writer.WriteValue(Utils.GetEnumMemberValue(typeof(CertificateStatus), certificateStatus.ToString()));
        }

        /// <summary>
        /// Read Json
        /// </summary>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;
            return Utils.GetEnumFromEnumMemberValue(typeof(CertificateStatus), enumString);
        }

        /// <summary>
        /// Can Convert
        /// </summary>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}