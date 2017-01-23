using deployment_service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Update.Model.Campaign
{
    public class UpdateCampaignDeviceMetada
    {
        public UpdateCampaignDeviceState State { get; set; }
        
        /// <summary>
        /// The description of the object
        /// </summary>
        /// <value>The description of the object</value>
        public string Description { get; private set; }
        
        /// <summary>
        /// The update campaign to which this device belongs
        /// </summary>
        /// <value>The update campaign to which this device belongs</value>
        public string Campaign { get; private set; }
        
        /// <summary>
        /// The time the object was created
        /// </summary>
        /// <value>The time the object was created</value>
        public DateTime? CreatedAt { get; private set; }
        
        /// <summary>
        /// The time the object was updated
        /// </summary>
        /// <value>The time the object was updated</value>
        public DateTime? UpdatedAt { get; private set; }
        
        /// <summary>
        /// The ID of the channel used to communicated with the device
        /// </summary>
        /// <value>The ID of the channel used to communicated with the device</value>
        public string Mechanism { get; private set; }
        
        /// <summary>
        /// The name of the object
        /// </summary>
        /// <value>The name of the object</value>
        public string Name { get; private set; }
        
        /// <summary>
        /// The entity instance signature
        /// </summary>
        /// <value>The entity instance signature</value>
        public DateTime? Etag { get; private set; }
        
        /// <summary>
        /// The address of the Connector to use
        /// </summary>
        /// <value>The address of the Connector to use</value>
        public string MechanismUrl { get; private set; }
        
        /// <summary>
        /// The ID of the metadata concerning this device/campaign
        /// </summary>
        /// <value>The ID of the metadata concerning this device/campaign</value>
        public string Id { get; private set; }
        
        /// <summary>
        /// The ID of the device to deploy
        /// </summary>
        /// <value>The ID of the device to deploy</value>
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

        public static UpdateCampaignDeviceMetada Map(CampaignDeviceMetadataSerializer data)
        {
            UpdateCampaignDeviceMetada metadata = new UpdateCampaignDeviceMetada();
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
            metadata.State = (UpdateCampaignDeviceState)Enum.Parse(typeof(UpdateCampaignDeviceState), data.DeploymentState.ToString());
            return metadata;
        }
    }
}
