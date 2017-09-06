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
    public class CampaignDeviceState
    {
        /// <summary>
        /// State of the Device in Update Campaign.
        /// </summary>
        [JsonConverter(typeof(CampaignDeviceStateEnumConverter))]
        public CampaignDeviceStateEnum? State { get; set; }

        /// <summary>
        /// The description of the object
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// The update campaign to which this device belongs
        /// </summary>
        public string CampaignId { get; private set; }

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
        public string Etag { get; private set; }

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
        /// Entity name: always &#39;update-campaign-device-metadata&#39;
        /// </summary>
        public string _Object { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CampaignDeviceState {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  DeviceId: ").Append(DeviceId).Append("\n");
            sb.Append("  CampaignId: ").Append(CampaignId).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  _Object: ").Append(_Object).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  Mechanism: ").Append(Mechanism).Append("\n");
            sb.Append("  MechanismUrl: ").Append(MechanismUrl).Append("\n");
            sb.Append("  _Object: ").Append(_Object).Append("\n");
            sb.Append("  Etag: ").Append(Etag).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Map to UpdateCampaignDeviceMetada object.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static CampaignDeviceState Map(update_service.Model.CampaignDeviceMetadata data)
        {
            CampaignDeviceState state = new CampaignDeviceState();
            state.CampaignId = data.Campaign;
            state.CreatedAt = data.CreatedAt;
            state.Description = data.Description;
            state.DeviceId = data.DeviceId;
            state.Etag = data.Etag;
            state.Id = data.Id;
            state.Mechanism = data.Mechanism;
            state.MechanismUrl = data.MechanismUrl;
            state.Name = data.Name;
            state.UpdatedAt = data.UpdatedAt;
            state.State = (CampaignDeviceStateEnum)Enum.Parse(typeof(CampaignDeviceStateEnum), data.DeploymentState.ToString());
            return state;
        }
    }
}
