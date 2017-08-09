﻿using deployment_service.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Update.Model.Campaign
{
    /// <summary>
    /// Update campaign object from Update API.
    /// </summary>
    public class UpdateCampaign
    {

        /// <summary>
        /// State of the update campaign.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public UpdateCampaignState State { get; set; }
        
        /// <summary>
        /// An optional description of the campaign
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// The time the object was created
        /// </summary>
        public string CreatedAt { get; set; }
        
        /// <summary>
        /// Gets or Sets RootManifestId
        /// </summary>
        public string RootManifestId { get; set; }
        
        /// <summary>
        /// DEPRECATED: The ID of the campaign
        /// </summary>
        public string CampaignId { get; set; }
        
        /// <summary>
        /// The timestamp at which update campaign scheduled to start
        /// </summary>
        public string ScheduledAt { get; set; }
        
        /// <summary>
        /// The timestamp when the update campaign finished
        /// </summary>
        public string FinishedAt { get; set; }

        /// <summary>
        /// Gets or Sets RootManifestUrl
        /// </summary>
        public string RootManifestUrl { get; set; }
        
        /// <summary>
        /// The ID of the campaign
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// The filter for the devices the campaign will target
        /// </summary>
        public string DeviceFilter { get; set; }
        
        /// <summary>
        /// A name for this campaign
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Create new update campaign object.
        /// </summary>
        /// <param name="options">Dictionary to initiate</param>
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
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  RootManifestId: ").Append(RootManifestId).Append("\n");
            sb.Append("  CampaignId: ").Append(CampaignId).Append("\n");
            sb.Append("  ScheduledAt: ").Append(ScheduledAt).Append("\n");
            sb.Append("  FinishedAt: ").Append(FinishedAt).Append("\n");
            sb.Append("  RootManifestUrl: ").Append(RootManifestUrl).Append("\n");
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
        public static UpdateCampaign Map(deployment_service.Model.UpdateCampaign data)
        {
            var updateCampaignStatus = (UpdateCampaignState)Enum.Parse(typeof(UpdateCampaignState), data.State.ToString());
            var campaign = new UpdateCampaign();
            campaign.CreatedAt = data.CreatedAt;
            campaign.Description = data.Description;
            campaign.DeviceFilter = data.DeviceFilter;
            campaign.FinishedAt = data.Finished;
            campaign.Id = data.Id;
            campaign.Name = data.Name;
            campaign.RootManifestId = data.RootManifestId;
            campaign.RootManifestUrl = data.RootManifestUrl;
            campaign.State = updateCampaignStatus;
            campaign.ScheduledAt = data.When;
            return campaign;
        }

        public UpdateCampaignPostRequest CreatePostRequest()
        {
            UpdateCampaignPostRequest request = new UpdateCampaignPostRequest(DeviceFilter:DeviceFilter, Name:Name);
            request.Description = this.Description;
            request.RootManifestId = this.RootManifestId;
            var updateCampaignStatus = (UpdateCampaignPostRequest.StateEnum)Enum.Parse(typeof(UpdateCampaignPostRequest.StateEnum), this.State.ToString());
            request.State = updateCampaignStatus;
            request.When = this.ScheduledAt;
            return request;
        }

        public UpdateCampaignPutRequest CreatePutRequest()
        {
            var updateCampaignStatus = (UpdateCampaignPutRequest.StateEnum)Enum.Parse(typeof(UpdateCampaignPutRequest.StateEnum), this.State.ToString());
            UpdateCampaignPutRequest request = new UpdateCampaignPutRequest(
                Description:Description, RootManifestId:RootManifestId, _Object:"", 
                When:ScheduledAt, State:updateCampaignStatus, DeviceFilter:DeviceFilter, Name:Name);

            return request;
        }
    }
}
