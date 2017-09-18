// <copyright file="CampaignStateEnumConverter.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System;
using MbedCloudSDK.Common;
using Newtonsoft.Json;

namespace MbedCloudSDK.Update.Model.Campaign
{
    /// <summary>
    /// Campaign State Enum Converter
    /// </summary>
    public class CampaignStateEnumConverter : JsonConverter
    {
        /// <summary>
        /// Can Convert
        /// </summary>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        /// <summary>
        /// Read Json
        /// </summary>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;
            return Utils.GetEnumMemberValue(typeof(CampaignStateEnum), enumString);
        }

        /// <summary>
        /// Write Json
        /// </summary>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var campaignStateEnum = (CampaignStateEnum)value;
            writer.WriteValue(Utils.GetEnumMemberValue(typeof(CampaignStateEnum), campaignStateEnum.ToString()));
        }
    }
}