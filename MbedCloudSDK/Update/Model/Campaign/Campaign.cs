// <copyright file="Campaign.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Model.Campaign
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Filter;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using update_service.Model;

    /// <summary>
    /// Update campaign object from Update API.
    /// </summary>
    public class Campaign
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Campaign"/> class.
        /// Create new update campaign object.
        /// </summary>
        /// <param name="options">Dictionary to initiate</param>
        public Campaign(IDictionary<string, object> options = null)
        {
            if (options != null)
            {
                foreach (KeyValuePair<string, object> item in options)
                {
                    if (GetType().GetProperty(item.Key) != null)
                    {
                        GetType().GetProperty(item.Key).SetValue(this, item.Value, null);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets state of the update campaign.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CampaignStateEnum? State { get; set; }

        /// <summary>
        /// Gets or sets an optional description of the campaign
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the time the object was created
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets gets or Sets RootManifestId
        /// </summary>
        public string RootManifestId { get; set; }

        /// <summary>
        /// Gets or sets dEPRECATED: The ID of the campaign
        /// </summary>
        public string CampaignId { get; set; }

        /// <summary>
        /// Gets or sets the timestamp at which update campaign scheduled to start
        /// </summary>
        public DateTime? ScheduledAt { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the update campaign finished
        /// </summary>
        public DateTime? FinishedAt { get; set; }

        /// <summary>
        /// Gets or sets gets or Sets RootManifestUrl
        /// </summary>
        public string RootManifestUrl { get; set; }

        /// <summary>
        /// Gets or sets the ID of the campaign
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the filter for the devices the campaign will target
        /// </summary>
        public Filter DeviceFilter { get; set; }

        /// <summary>
        /// Gets or sets a name for this campaign
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a when for this campaign
        /// </summary>
        public DateTime? When { get; set; }

        /// <summary>
        /// Gets or sets object
        /// </summary>
        public string Object { get; set; }

        /// <summary>
        /// Map to Update campaign object.
        /// </summary>
        /// <param name="data">Update Campaign</param>
        /// <returns>Campaign</returns>
        public static Campaign Map(update_service.Model.UpdateCampaign data)
        {
            var updateCampaignStatus = Utils.ParseEnum<CampaignStateEnum>(data.State);
            var campaign = new Campaign
            {
                CreatedAt = data.CreatedAt,
                Description = data.Description,
                DeviceFilter = new Filter(data.DeviceFilter),
                FinishedAt = data.Finished,
                Id = data.Id,
                Name = data.Name,
                RootManifestId = data.RootManifestId,
                RootManifestUrl = data.RootManifestUrl,
                State = updateCampaignStatus,
                ScheduledAt = data.When
            };
            return campaign;
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
        /// Create Post Request
        /// </summary>
        /// <returns>Update campaign post request</returns>
        public UpdateCampaignPostRequest CreatePostRequest()
        {
            var deviceFilterString = DeviceFilter.FilterString;
            var request = new UpdateCampaignPostRequest(DeviceFilter: deviceFilterString, Name: Name)
            {
                Description = Description,
                RootManifestId = RootManifestId,
                State = Utils.ParseEnum<UpdateCampaignPostRequest.StateEnum>(State),
                When = ScheduledAt
            };
            return request;
        }

        /// <summary>
        /// Create Put Request
        /// </summary>
        /// <returns>Update campaign put request</returns>
        public UpdateCampaignPutRequest CreatePutRequest()
        {
            var updateCampaignStatus = Utils.ParseEnum<UpdateCampaignPutRequest.StateEnum>(State);
            var request = new UpdateCampaignPutRequest(
                Description: Description,
                RootManifestId: RootManifestId,
                _Object: string.Empty,
                When: ScheduledAt,
                State: updateCampaignStatus,
                DeviceFilter: DeviceFilter.FilterString,
                Name: Name);

            return request;
        }
    }
}
