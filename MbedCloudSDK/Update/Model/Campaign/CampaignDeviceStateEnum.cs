// <copyright file="CampaignDeviceStateEnum.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Model.Campaign
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Device state in update campaign.
    /// </summary>
    public enum CampaignDeviceStateEnum
    {
        /// <summary>
        /// Enum Pending for "pending"
        /// </summary>
        [EnumMember(Value = "pending")]
        Pending,

        /// <summary>
        /// Enum Updateddevicecatalog for "updated_device_catalog"
        /// </summary>
        [EnumMember(Value = "updated_device_catalog")]
        Updated_device_catalog,

        /// <summary>
        /// Enum Updatedconnectorchannel for "updated_connector_channel"
        /// </summary>
        [EnumMember(Value = "updated_connector_channel")]
        Updated_connector_channel,

        /// <summary>
        /// Enum Deployed for "deployed"
        /// </summary>
        [EnumMember(Value = "deployed")]
        Deployed,

        /// <summary>
        /// Enum Manifestremoved for "manifestremoved"
        /// </summary>
        [EnumMember(Value = "manifestremoved")]
        Manifestremoved
    }
}
