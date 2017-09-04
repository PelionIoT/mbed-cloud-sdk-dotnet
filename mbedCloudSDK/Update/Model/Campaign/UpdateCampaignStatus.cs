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
    /// Represents status of Update Campaign.
    /// </summary>
    public class UpdateCampaignStatus
    {

        /// <summary>
        /// State of update campaign.
        /// </summary>
        [JsonConverter(typeof(UpdateCampaignStateConverter))]
        public UpdateCampaignState? State { get; set; }
        
        /// <summary>
        /// Gets or Sets DirectDevices
        /// </summary>
        public int? DirectDevices { get; set; }
        
        /// <summary>
        /// Gets or Sets ConnectorDevices
        /// </summary>
        public int? ConnectorDevices { get; set; }
        
        /// <summary>
        /// An optional description of the campaign
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// The updating IAM user ID
        /// </summary>
        public string UpdatingUserId { get; set; }
        
        /// <summary>
        /// The time the object was created
        /// </summary>
        public DateTime? CreatedAt { get; set; }
        
        /// <summary>
        /// Gets or Sets TotalDevices
        /// </summary>
        public int? TotalDevices { get; set; }
        
        /// <summary>
        /// Gets or Sets CampaigndevicemetadataSet
        /// </summary>
        public List<UpdateCampaignDeviceMetadata> Metadata { get; set; }
        
        /// <summary>
        /// DEPRECATED: The ID of the campaign
        /// </summary>
        public string CampaignId { get; set; }
        
        /// <summary>
        /// Gets or Sets DeployedDevices
        /// </summary>
        public int? DeployedDevices { get; set; }
        
        /// <summary>
        /// The time the object was updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary>
        /// The timestamp at which campaign is scheduled to start
        /// </summary>
        public DateTime? When { get; set; }
        
        /// <summary>
        /// The timestamp when the update campaign finished
        /// </summary>
        public DateTime? Finished { get; set; }
        
        /// <summary>
        /// Gets or Sets RootManifestUrl
        /// </summary>
        public string RootManifestUrl { get; set; }
        
        /// <summary>
        /// The gateway client API key
        /// </summary>
        public string UpdatingApiKey { get; set; }
        
        /// <summary>
        /// The updating account ID
        /// </summary>
        public string UpdatingAccountId { get; set; }
        
        /// <summary>
        /// The filter for the devices the campaign will target
        /// </summary>
        public string DeviceFilter { get; set; }
        
        /// <summary>
        /// A name for this campaign
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UpdateCampaignStatusSerializer {\n");
            sb.Append("  DirectDevices: ").Append(DirectDevices).Append("\n");
            sb.Append("  ConnectorDevices: ").Append(ConnectorDevices).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  UpdatingUserId: ").Append(UpdatingUserId).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  TotalDevices: ").Append(TotalDevices).Append("\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
            sb.Append("  CampaignId: ").Append(CampaignId).Append("\n");
            sb.Append("  DeployedDevices: ").Append(DeployedDevices).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  When: ").Append(When).Append("\n");
            sb.Append("  Finished: ").Append(Finished).Append("\n");
            sb.Append("  RootManifestUrl: ").Append(RootManifestUrl).Append("\n");
            sb.Append("  UpdatingApiKey: ").Append(UpdatingApiKey).Append("\n");
            sb.Append("  UpdatingAccountId: ").Append(UpdatingAccountId).Append("\n");
            sb.Append("  DeviceFilter: ").Append(DeviceFilter).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Map to UpdateCampaignStatus class.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static UpdateCampaignStatus Map(UpdateCampaignStatus data)
        {
            UpdateCampaignStatus u = new UpdateCampaignStatus();
            u.Metadata = new List<UpdateCampaignDeviceMetadata>();
            foreach (var d in data.Metadata)
            {
                u.Metadata.Add(UpdateCampaignDeviceMetadata.Map(d));
            }
            u.ConnectorDevices = data.ConnectorDevices;
            u.CreatedAt = data.CreatedAt;
            u.DeployedDevices = data.DeployedDevices;
            u.Description = data.Description;
            u.DeviceFilter = data.DeviceFilter;
            u.DirectDevices = data.DirectDevices;
            u.Finished = data.Finished;
            u.Name = data.Name;
            u.RootManifestUrl = data.RootManifestUrl;
            u.State = (UpdateCampaignState)Enum.Parse(typeof(UpdateCampaignState), data.State.ToString());
            u.TotalDevices = data.TotalDevices;
            u.UpdatedAt = data.UpdatedAt;
            u.UpdatingAccountId = data.UpdatingAccountId;
            u.UpdatingApiKey = data.UpdatingApiKey;
            u.UpdatingUserId = data.UpdatingUserId;
            u.When = data.When;
            return u;
        }
    }
}
