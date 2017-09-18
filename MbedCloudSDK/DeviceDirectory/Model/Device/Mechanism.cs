// <copyright file="Mechanism.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System.Runtime.Serialization;

namespace MbedCloudSDK.DeviceDirectory.Model.Device
{
    /// <summary>
    /// The ID of the channel used to communicate with the device
    /// </summary>
    public enum Mechanism
    {
        /// <summary>
        /// Enum Connector for "connector"
        /// </summary>
        [EnumMember(Value = "connector")]
        Connector,

        /// <summary>
        /// Enum Direct for "direct"
        /// </summary>
        [EnumMember(Value = "direct")]
        Direct
    }
}
