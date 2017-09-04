using update_service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace mbedCloudSDK.Update.Model.Campaign
{
    /// <summary>
    /// Contains information about Device in Update Campaign.
    /// </summary>
    public class UpdateCampaignDeviceMetadata
    {
        /// <summary>
        /// State of the Device in Update Campaign.
        /// </summary>
        [JsonConverter(typeof(UpdateCampaignDeviceStateConverter))]
        public UpdateCampaignDeviceState? State { get; set; }
        
        /// <summary>
        /// The description of the object
        /// </summary>
        public string Description { get; private set; }
        
        /// <summary>
        /// The update campaign to which this device belongs
        /// </summary>
        public string Campaign { get; private set; }
        
        /// <summary>
        /// The time the object was created
        /// </summary>
        public DateTime? CreatedAt { get; private set; }
        
        /// <summary>
        /// The time the object was updated
        /// </summary>
        public DateTime? UpdatedAt { get; private set; }
        
        /// <summary>
        /// The ID of the channel used to communicated with the device
        /// </summary>
        public string Mechanism { get; private set; }
        
        /// <summary>
        /// The name of the object
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// The entity instance signature
        /// </summary>
        public DateTime? Etag { get; private set; }
        
        /// <summary>
        /// The address of the Connector to use
        /// </summary>
        public string MechanismUrl { get; private set; }
        
        /// <summary>
        /// The ID of the metadata concerning this device/campaign
        /// </summary>
        public string Id { get; private set; }
        
        /// <summary>
        /// The ID of the device to deploy
        /// </summary>
        public string DeviceId { get; private set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CampaignDeviceMetadataSerializer {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Campaign: ").Append(Campaign).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  Mechanism: ").Append(Mechanism).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Etag: ").Append(Etag).Append("\n");
            sb.Append("  MechanismUrl: ").Append(MechanismUrl).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  DeviceId: ").Append(DeviceId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Map to UpdateCampaignDeviceMetada object.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static UpdateCampaignDeviceMetadata Map(UpdateCampaignDeviceMetadata data)
        {
            UpdateCampaignDeviceMetadata metadata = new UpdateCampaignDeviceMetadata();
            metadata.Campaign = data.Campaign;
            metadata.CreatedAt = data.CreatedAt;
            metadata.Description = data.Description;
            metadata.DeviceId = data.DeviceId;
            metadata.Etag = data.Etag;
            metadata.Id = data.Id;
            metadata.Mechanism = data.Mechanism;
            metadata.MechanismUrl = data.MechanismUrl;
            metadata.Name = data.Name;
            metadata.UpdatedAt = data.UpdatedAt;
            metadata.State = (UpdateCampaignDeviceState)Enum.Parse(typeof(UpdateCampaignDeviceState), data.State.ToString());
            return metadata;
        }
    }
}
