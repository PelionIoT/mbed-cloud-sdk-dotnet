using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Update.Model.Campaign
{
    public class UpdateCampaign
    {
        
        public UpdateCampaignState State { get; set; }
        
        /// <summary>
        /// An optional description of the campaign
        /// </summary>
        /// <value>An optional description of the campaign</value>
        public string Description { get; set; }
        
        /// <summary>
        /// The updating IAM user ID
        /// </summary>
        /// <value>The updating IAM user ID</value>
        public string UpdatingUserId { get; set; }
        
        /// <summary>
        /// The time the object was created
        /// </summary>
        /// <value>The time the object was created</value>
        public DateTime? CreatedAt { get; set; }
        
        /// <summary>
        /// Gets or Sets RootManifestId
        /// </summary>
        public string RootManifestId { get; set; }
        
        /// <summary>
        /// DEPRECATED: The ID of the campaign
        /// </summary>
        /// <value>DEPRECATED: The ID of the campaign</value>
        public string CampaignId { get; set; }
        
        /// <summary>
        /// The updating account ID
        /// </summary>
        /// <value>The updating account ID</value>
        public string UpdatingAccountId { get; set; }
        
        /// <summary>
        /// The time the object was updated
        /// </summary>
        /// <value>The time the object was updated</value>
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary>
        /// The timestamp at which update campaign scheduled to start
        /// </summary>
        /// <value>The timestamp at which update campaign scheduled to start</value>
        public DateTime? When { get; set; }
        
        /// <summary>
        /// The timestamp when the update campaign finished
        /// </summary>
        /// <value>The timestamp when the update campaign finished</value>
        public DateTime? Finished { get; set; }

        /// <summary>
        /// The entity instance signature
        /// </summary>
        /// <value>The entity instance signature</value>
        public DateTime? Etag { get; set; }
        
        /// <summary>
        /// Gets or Sets RootManifestUrl
        /// </summary>
        public string RootManifestUrl { get; set; }
        
        /// <summary>
        /// The gateway client API key
        /// </summary>
        /// <value>The gateway client API key</value>
        public string UpdatingApiKey { get; set; }
        
        /// <summary>
        /// The ID of the campaign
        /// </summary>
        /// <value>The ID of the campaign</value>
        public string Id { get; set; }
        
        /// <summary>
        /// The filter for the devices the campaign will target
        /// </summary>
        /// <value>The filter for the devices the campaign will target</value>
        public string DeviceFilter { get; set; }
        
        /// <summary>
        /// A name for this campaign
        /// </summary>
        /// <value>A name for this campaign</value>
        public string Name { get; set; }


        public UpdateCampaign(IDictionary<string, object> options = null)
        {
            if (options != null)
            {
                foreach (KeyValuePair<string, object> item in options)
                {
                    var property = this.GetType().GetProperty(item.Key);
                    if (property != null)
                    {
                        property.SetValue(this, item.Value, null);
                    }
                }
            }
        }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UpdateCampaignSerializer {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  UpdatingUserId: ").Append(UpdatingUserId).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  RootManifestId: ").Append(RootManifestId).Append("\n");
            sb.Append("  CampaignId: ").Append(CampaignId).Append("\n");
            sb.Append("  UpdatingAccountId: ").Append(UpdatingAccountId).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  When: ").Append(When).Append("\n");
            sb.Append("  Finished: ").Append(Finished).Append("\n");
            sb.Append("  Etag: ").Append(Etag).Append("\n");
            sb.Append("  RootManifestUrl: ").Append(RootManifestUrl).Append("\n");
            sb.Append("  UpdatingApiKey: ").Append(UpdatingApiKey).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  DeviceFilter: ").Append(DeviceFilter).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Map to Update campaign object.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static UpdateCampaign Map(deployment_service.Model.UpdateCampaignSerializer data)
        {
            var updateCampaignStatus = (UpdateCampaignState)Enum.Parse(typeof(UpdateCampaignState), data.State.ToString());
            var campaign = new UpdateCampaign();
            campaign.CampaignId = data.CampaignId;
            campaign.CreatedAt = data.CreatedAt;
            campaign.Description = data.Description;
            campaign.DeviceFilter = data.DeviceFilter;
            campaign.Etag = data.Etag;
            campaign.Finished = data.Finished;
            campaign.Id = data.Id;
            campaign.Name = data.Name;
            campaign.RootManifestId = data.RootManifestId;
            campaign.RootManifestUrl = data.RootManifestUrl;
            campaign.State = updateCampaignStatus;
            campaign.UpdatedAt = data.UpdatedAt;
            campaign.UpdatingAccountId = data.UpdatingAccountId;
            campaign.UpdatingApiKey = data.UpdatingApiKey;
            campaign.UpdatingUserId = data.UpdatingUserId;
            campaign.When = data.When;
            return campaign;
        }
    }
}
