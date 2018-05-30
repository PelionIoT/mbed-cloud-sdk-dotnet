// <copyright file="Campaign.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Model.Campaign
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Filter;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using update_service.Model;

    /// <summary>
    /// Update campaign object from Update API.
    /// </summary>
    public class Campaign : BaseModel
    {
        /// <summary>
        /// Gets or sets state of the update campaign.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CampaignStateEnum? State { get; set; }

        /// <summary>
        /// Gets the campaign phase.
        /// </summary>
        [JsonProperty]
        public string Phase { get; private set; }

        /// <summary>
        /// Gets or sets an optional description of the campaign
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the time the object was created
        /// </summary>
        [JsonProperty]
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// Gets or sets gets or Sets RootManifestId
        /// </summary>
        public string ManifestId { get; set; }

        /// <summary>
        /// Gets or sets DEPRECATED: The ID of the campaign
        /// </summary>
        [Obsolete("This property is deprecated, use Id instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CampaignId { get; set; }

        /// <summary>
        /// Gets or sets the timestamp at which update campaign scheduled to start
        /// </summary>
        public DateTime? ScheduledAt { get; set; }

        /// <summary>
        /// Gets the timestamp when the update campaign finished
        /// </summary>
        [JsonProperty]
        public DateTime? FinishedAt { get; private set; }

        /// <summary>
        /// Gets the timestamp when the update campaign started
        /// </summary>
        [JsonProperty]
        public DateTime? StartedAt { get; private set; }

        /// <summary>
        /// Gets the timestamp when the update campaign is updated
        /// </summary>
        [JsonProperty]
        public DateTime? UpdatedAt { get; private set; }

        /// <summary>
        /// Gets ManifestUrl
        /// </summary>
        [JsonProperty]
        public string ManifestUrl { get; private set; }

        /// <summary>
        /// Gets or sets the filter for the devices the campaign will target
        /// </summary>
        public Filter DeviceFilter { get; set; }

        /// <summary>
        /// Gets or sets a name for this campaign
        /// </summary>
        public string Name { get; set; }

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
                CreatedAt = data.CreatedAt.ToNullableUniversalTime(),
                Description = data.Description,
                DeviceFilter = new Filter(data.DeviceFilter),
                FinishedAt = data.Finished,
                Id = data.Id,
                Name = data.Name,
                ManifestId = data.RootManifestId,
                ManifestUrl = data.RootManifestUrl,
                State = updateCampaignStatus,
                Phase = data.Phase,
                ScheduledAt = data.When.ToNullableUniversalTime(),
                StartedAt = data.StartedAt,
                UpdatedAt = data.UpdatedAt,
            };
            return campaign;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
            => this.DebugDump();

        /// <summary>
        /// Create Post Request
        /// </summary>
        /// <returns>Update campaign post request</returns>
        public UpdateCampaignPostRequest CreatePostRequest()
        {
            var deviceFilterString = DeviceFilter.FilterString;

            UpdateCampaignPostRequest.StateEnum? state = null;
            if (State.HasValue)
            {
                Utils.ParseEnum<UpdateCampaignPostRequest.StateEnum>(State);
            }

            var request = new UpdateCampaignPostRequest(DeviceFilter: deviceFilterString, Name: Name)
            {
                Description = Description,
                RootManifestId = ManifestId,
                State = state,
                When = ScheduledAt.ToNullableUniversalTime(),
            };
            return request;
        }

        /// <summary>
        /// Create Put Request
        /// </summary>
        /// <returns>Update campaign put request</returns>
        public UpdateCampaignPutRequest CreatePutRequest()
        {
            var updateCampaignPutRequest = new UpdateCampaignPutRequest(
                Description: Description,
                RootManifestId: ManifestId,
                When: ScheduledAt ?? DateTime.Now,
                State: Utils.ParseEnum<UpdateCampaignPutRequest.StateEnum>(State),
                DeviceFilter: DeviceFilter?.FilterString,
                Name: Name,
                _Object: string.Empty);

            return updateCampaignPutRequest;
        }
    }
}
