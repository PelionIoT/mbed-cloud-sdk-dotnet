// <copyright file="CampaignStateEnum.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System.Runtime.Serialization;

namespace MbedCloudSDK.Update.Model.Campaign
{
    /// <summary>
    /// The state of the campaign
    /// </summary>
    public enum CampaignStateEnum
    {
        /// <summary>
        /// Enum Draft for "draft"
        /// </summary>
        [EnumMember(Value = "draft")]
        draft,

        /// <summary>
        /// Enum Scheduled for "scheduled"
        /// </summary>
        [EnumMember(Value = "scheduled")]
        scheduled,

        /// <summary>
        /// Enum Devicefetch for "devicefetch"
        /// </summary>
        [EnumMember(Value = "devicefetch")]
        devicefetch,

        /// <summary>
        /// Enum Devicecopy for "devicecopy"
        /// </summary>
        [EnumMember(Value = "devicecopy")]
        devicecopy,

        /// <summary>
        /// Enum Devicecopycomplete for "devicecopycomplete"
        /// </summary>
        [EnumMember(Value = "devicecopycomplete")]
        devicecopycomplete,

        /// <summary>
        /// Enum Publishing for "publishing"
        /// </summary>
        [EnumMember(Value = "publishing")]
        publishing,

        /// <summary>
        /// Enum Deploying for "deploying"
        /// </summary>
        [EnumMember(Value = "deploying")]
        deploying,

        /// <summary>
        /// Enum Deployed for "deployed"
        /// </summary>
        [EnumMember(Value = "deployed")]
        deployed,

        /// <summary>
        /// Enum Manifestremoved for "manifestremoved"
        /// </summary>
        [EnumMember(Value = "manifestremoved")]
        manifestremoved,

        /// <summary>
        /// Enum Expired for "expired"
        /// </summary>
        [EnumMember(Value = "expired")]
        expired
    }
}
