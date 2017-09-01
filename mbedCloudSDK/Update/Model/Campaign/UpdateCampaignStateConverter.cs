using System;
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

            switch (enumString)
            {
                case "draft":
                    return UpdateCampaignState.Draft;
                case "scheduled":
                    return UpdateCampaignState.Scheduled;
                case "devicefetch":
                    return UpdateCampaignState.Devicefetch;
                case "devicecopy":
                    return UpdateCampaignState.Devicecopy;
                case "devicecopycomplete":
                    return UpdateCampaignState.Devicecopycomplete;
                case "publishing":
                    return UpdateCampaignState.Publishing;
                case "deploying":
                    return UpdateCampaignState.Deploying;
                case "deployed":
                    return UpdateCampaignState.Deployed;
                case "manifestremoved":
                    return UpdateCampaignState.Manifestremoved;
                case "expired":
                    return UpdateCampaignState.Expired;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var updateCampaignState = (UpdateCampaignState)value;

            switch(updateCampaignState)
            {
                case UpdateCampaignState.Draft:
                    writer.WriteValue("draft");
                    break;
                case UpdateCampaignState.Scheduled:
                    writer.WriteValue("scheduled");
                    break;
                case UpdateCampaignState.Devicefetch:
                    writer.WriteValue("devicefetch");
                    break;
                case UpdateCampaignState.Devicecopy:
                    writer.WriteValue("devicecopy");
                    break;
                case UpdateCampaignState.Devicecopycomplete:
                    writer.WriteValue("devicecopycomplete");
                    break;
                case UpdateCampaignState.Publishing:
                    writer.WriteValue("publishing");
                    break;
                case UpdateCampaignState.Deploying:
                    writer.WriteValue("deploying");
                    break;
                case UpdateCampaignState.Deployed:
                    writer.WriteValue("deployed");
                    break;
                case UpdateCampaignState.Manifestremoved:
                    writer.WriteValue("manifestremoved");
                    break;
                case UpdateCampaignState.Expired:
                    writer.WriteValue("expired");
                    break;
            }
        }
    }
}