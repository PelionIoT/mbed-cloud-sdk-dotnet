using System;
using Newtonsoft.Json;

namespace mbedCloudSDK.Update.Model.Campaign
{
    public class UpdateCampaignDeviceStateConverter : JsonConverter
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
                case "pending":
                    return UpdateCampaignDeviceState.Pending;
                case "updated_device_catalog":
                    return UpdateCampaignDeviceState.Updateddevicecatalog;
                case "updated_connector_channel":
                    return UpdateCampaignDeviceState.Updatedconnectorchannel;
                case "deployed":
                    return UpdateCampaignDeviceState.Deployed;
                case "manifestremoved":
                    return UpdateCampaignDeviceState.Manifestremoved;
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var updateCampaignDeviceState = (UpdateCampaignDeviceState)value;

            switch (updateCampaignDeviceState)
            {
                case UpdateCampaignDeviceState.Pending:
                    writer.WriteValue("pending");
                    break;
                case UpdateCampaignDeviceState.Updateddevicecatalog:
                    writer.WriteValue("updated_device_catalog");
                    break;
                case UpdateCampaignDeviceState.Updatedconnectorchannel:
                    writer.WriteValue("updated_connector_channel");
                    break;
                case UpdateCampaignDeviceState.Deployed:
                    writer.WriteValue("deployed");
                    break;
                case UpdateCampaignDeviceState.Manifestremoved:
                    writer.WriteValue("manifestremoved");
                    break;
                default:
                    break;
            }
        }
    }
}