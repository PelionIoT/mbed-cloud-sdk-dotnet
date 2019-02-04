// <copyright file="CampaignDeviceState.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Model.Campaign
{
    using System;
    using System.Text;
    using Mbed.Cloud.Foundation.Common;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using Newtonsoft.Json;

    /// <summary>
    /// Contains information about Device in Update Campaign.
    /// </summary>
    public class CampaignDeviceState : Entity
    {
        /// <summary>
        /// Gets or sets state of the Device in Update Campaign.
        /// </summary>
        [JsonConverter(typeof(CampaignDeviceStateEnumConverter))]
        [JsonProperty]
        public CampaignDeviceStateEnum? State { get; set; }

        /// <summary>
        /// Gets the description of the object
        /// </summary>
        [JsonProperty]
        public string Description { get; private set; }

        /// <summary>
        /// Gets the update campaign to which this device belongs
        /// </summary>
        [JsonProperty]
        public string CampaignId { get; private set; }

        /// <summary>
        /// Gets the time the object was created
        /// </summary>
        [JsonProperty]
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// Gets the time the object was updated
        /// </summary>
        [JsonProperty]
        public DateTime? UpdatedAt { get; private set; }

        /// <summary>
        /// Gets the ID of the channel used to communicated with the device
        /// </summary>
        [JsonProperty]
        public string Mechanism { get; private set; }

        /// <summary>
        /// Gets the name of the object
        /// </summary>
        [JsonProperty]
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the entity instance signature
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// Gets the address of the Connector to use
        /// </summary>
        [JsonProperty]
        public string MechanismUrl { get; private set; }

        /// <summary>
        /// Gets the ID of the device to deploy
        /// </summary>
        [JsonProperty]
        public string DeviceId { get; private set; }

        /// <summary>
        /// Gets or sets entity name: always &#39;update-campaign-device-metadata&#39;
        /// </summary>
        public string Object { get; set; }

        /// <summary>
        /// Map to UpdateCampaignDeviceMetada object.
        /// </summary>
        /// <param name="data">Device metadata</param>
        /// <returns>Campaign Device State</returns>
        public static CampaignDeviceState Map(update_service.Model.CampaignDeviceMetadata data)
        {
            var state = new CampaignDeviceState
            {
                CampaignId = data.Campaign,
                CreatedAt = data.CreatedAt.ToNullableUniversalTime(),
                Description = data.Description,
                DeviceId = data.DeviceId,
                Etag = data.Etag,
                Id = data.Id,
                Mechanism = data.Mechanism,
                MechanismUrl = data.MechanismUrl,
                Name = data.Name,
                UpdatedAt = data.UpdatedAt.ToNullableUniversalTime(),
                State = data.DeploymentState.ParseEnum<CampaignDeviceStateEnum>(),
            };
            return state;
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();
    }
}
