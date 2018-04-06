// <copyright file="DeviceStateEnum.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe.Models
{
    /// <summary>
    /// Enum describing the device states
    /// </summary>
    public enum DeviceStateEnum
    {
        /// <summary>
        /// Registration
        /// </summary>
        Registration,

        /// <summary>
        /// Registration Update
        /// </summary>
        RegistrationUpdate,

        /// <summary>
        /// DeRegistration
        /// </summary>
        DeRegistration,

        /// <summary>
        /// Expired Registration
        /// </summary>
        ExpiredRegistration,
    }
}