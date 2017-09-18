// <copyright file="CampaignDeviceStateEnumConverter.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System;
using MbedCloudSDK.Common;
using Newtonsoft.Json;

namespace MbedCloudSDK.Update.Model.Campaign
{
    /// <summary>
    /// Campaign Device State Enum Converter
    /// </summary>
    public class CampaignDeviceStateEnumConverter : JsonConverter
    {
        /// <summary>
        /// Can convert
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
            return Utils.GetEnumFromEnumMemberValue(typeof(CampaignDeviceStateEnum), enumString);
        }

        /// <summary>
        /// Write Json
        /// </summary>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var campaignDeviceStateEnum = (CampaignDeviceStateEnum)value;
            writer.WriteValue(Utils.GetEnumMemberValue(typeof(CampaignDeviceStateEnum), campaignDeviceStateEnum.ToString()));
        }
    }
}