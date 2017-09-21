// <copyright file="CampaignDeviceState.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Model.Campaign
{
    using System;
    using System.Text;
    using Newtonsoft.Json;

    /// <summary>
    /// Contains information about Device in Update Campaign.
    /// </summary>
    public class CampaignDeviceState
    {
        /// <summary>
        /// Gets or sets state of the Device in Update Campaign.
        /// </summary>
        [JsonConverter(typeof(CampaignDeviceStateEnumConverter))]
        public CampaignDeviceStateEnum? State { get; set; }

        /// <summary>
        /// Gets the description of the object
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the update campaign to which this device belongs
        /// </summary>
        public string CampaignId { get; private set; }

        /// <summary>
        /// Gets the time the object was created
        /// </summary>
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// Gets the time the object was updated
        /// </summary>
        public DateTime? UpdatedAt { get; private set; }

        /// <summary>
        /// Gets the ID of the channel used to communicated with the device
        /// </summary>
        public string Mechanism { get; private set; }

        /// <summary>
        /// Gets the name of the object
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the entity instance signature
        /// </summary>
        public string Etag { get; private set; }

        /// <summary>
        /// Gets the address of the Connector to use
        /// </summary>
        public string MechanismUrl { get; private set; }

        /// <summary>
        /// Gets the ID of the metadata concerning this device/campaign
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the ID of the device to deploy
        /// </summary>
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
                CreatedAt = data.CreatedAt,
                Description = data.Description,
                DeviceId = data.DeviceId,
                Etag = data.Etag,
                Id = data.Id,
                Mechanism = data.Mechanism,
                MechanismUrl = data.MechanismUrl,
                Name = data.Name,
                UpdatedAt = data.UpdatedAt,
                State = (CampaignDeviceStateEnum)Enum.Parse(typeof(CampaignDeviceStateEnum), data.DeploymentState.ToString())
            };
            return state;
        }

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
            sb.Append("  _Object: ").Append(Object).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  Mechanism: ").Append(Mechanism).Append("\n");
            sb.Append("  MechanismUrl: ").Append(MechanismUrl).Append("\n");
            sb.Append("  _Object: ").Append(Object).Append("\n");
            sb.Append("  Etag: ").Append(Etag).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
