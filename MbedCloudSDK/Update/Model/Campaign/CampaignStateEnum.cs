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
        Draft,

        /// <summary>
        /// Enum Scheduled for "scheduled"
        /// </summary>
        [EnumMember(Value = "scheduled")]
        Scheduled,

        /// <summary>
        /// Enum Devicefetch for "devicefetch"
        /// </summary>
        [EnumMember(Value = "devicefetch")]
        Devicefetch,

        /// <summary>
        /// Enum Devicecopy for "devicecopy"
        /// </summary>
        [EnumMember(Value = "devicecopy")]
        Devicecopy,

        /// <summary>
        /// Enum Devicecopycomplete for "devicecopycomplete"
        /// </summary>
        [EnumMember(Value = "devicecopycomplete")]
        Devicecopycomplete,

        /// <summary>
        /// Enum Publishing for "publishing"
        /// </summary>
        [EnumMember(Value = "publishing")]
        Publishing,

        /// <summary>
        /// Enum Deploying for "deploying"
        /// </summary>
        [EnumMember(Value = "deploying")]
        Deploying,

        /// <summary>
        /// Enum Deployed for "deployed"
        /// </summary>
        [EnumMember(Value = "deployed")]
        Deployed,

        /// <summary>
        /// Enum Manifestremoved for "manifestremoved"
        /// </summary>
        [EnumMember(Value = "manifestremoved")]
        Manifestremoved,

        /// <summary>
        /// Enum Expired for "expired"
        /// </summary>
        [EnumMember(Value = "expired")]
        Expired
    }
}
