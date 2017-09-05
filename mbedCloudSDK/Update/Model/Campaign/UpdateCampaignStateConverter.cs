using System;
using mbedCloudSDK.Common;
using Newtonsoft.Json;

namespace mbedCloudSDK.Update.Model.Campaign
{
    public class UpdateCampaignStateConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;
            return Utils.GetEnumMemberValue(typeof(UpdateCampaignState), enumString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var updateCampaignState = (UpdateCampaignState)value;
            writer.WriteValue(Utils.GetEnumMemberValue(typeof(UpdateCampaignState), updateCampaignState.ToString()));
        }
    }
}