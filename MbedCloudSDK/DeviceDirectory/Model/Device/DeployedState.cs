// <copyright file="DeployedState.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System.Runtime.Serialization;

namespace MbedCloudSDK.DeviceDirectory.Model.Device
{
    /// <summary>
    /// The state of the device's deployment
    /// </summary>
    public enum DeployedState
    {
        /// <summary>
        /// Enum Development for "development"
        /// </summary>
        [EnumMember(Value = "development")]
        Development,

        /// <summary>
        /// Enum Production for "production"
        /// </summary>
        [EnumMember(Value = "production")]
        Production
    }
}
