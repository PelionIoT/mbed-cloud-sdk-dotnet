﻿// <copyright file="CampaignStateEnum.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Model.Campaign
{
    using System.Runtime.Serialization;

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
        Expired,

        /// <summary>
        /// Enum Allocatingquota for "Allocatingquota"
        /// </summary>
        [EnumMember(Value = "allocatingquota")]
        Allocatingquota,

        /// <summary>
        /// Enum Allocatedquota for "Allocatedquota"
        /// </summary>
        [EnumMember(Value = "allocatedquota")]
        Allocatedquota,

        /// <summary>
        /// Enum Checkingmanifest for "Checkingmanifest"
        /// </summary>
        [EnumMember(Value = "checkingmanifest")]
        Checkingmanifest,

        /// <summary>
        /// Enum Checkedmanifest for "Checkedmanifest"
        /// </summary>
        [EnumMember(Value = "checkedmanifest")]
        Checkedmanifest,

        /// <summary>
        /// Enum Devicecheck for "Devicecheck"
        /// </summary>
        [EnumMember(Value = "devicecheck")]
        Devicecheck,

        /// <summary>
        /// Enum Stopping for "Stopping"
        /// </summary>
        [EnumMember(Value = "stopping")]
        Stopping,

        /// <summary>
        /// Enum Autostopped for "Autostopped"
        /// </summary>
        [EnumMember(Value = "autostopped")]
        Autostopped,

        /// <summary>
        /// Enum Userstopped for "Userstopped"
        /// </summary>
        [EnumMember(Value = "userstopped")]
        Userstopped,

        /// <summary>
        /// Enum Conflict for "Conflict"
        /// </summary>
        [EnumMember(Value = "conflict")]
        Conflict,

        /// <summary>
        /// Enum Quotaallocationfailed for "quotaallocationfailed"
        /// </summary>
        [EnumMember(Value = "quotaallocationfailed")]
        Quotaallocationfailed,
    }
}
