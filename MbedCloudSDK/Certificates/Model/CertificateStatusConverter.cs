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
        /// <param name="writer">Writer</param>
        /// <param name="value">Value</param>
        /// <param name="serializer">Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var certificateStatus = (CertificateStatus)value;
            writer.WriteValue(Utils.GetEnumMemberValue(typeof(CertificateStatus), certificateStatus.ToString()));
        }

        /// <summary>
        /// Read Json
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <param name="objectType">Object Type</param>
        /// <param name="existingValue">Existing Value</param>
        /// <param name="serializer">Serializer</param>
        /// <returns>Json Object</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;
            return Utils.GetEnumFromEnumMemberValue(typeof(CertificateStatus), enumString);
        }

        /// <summary>
        /// Can Convert
        /// </summary>
        /// <param name="objectType">Type of object</param>
        /// <returns>True if can convert</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}