// <copyright file="State.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System.Runtime.Serialization;

namespace MbedCloudSDK.DeviceDirectory.Model.Device
{
    /// <summary>
    /// The current state of the device
    /// </summary>
    public enum State
    {
        /// <summary>
        /// Enum Unenrolled for "unenrolled"
        /// </summary>
        [EnumMember(Value = "unenrolled")]
        Unenrolled,

        /// <summary>
        /// Enum Cloudenrolling for "cloud_enrolling"
        /// </summary>
        [EnumMember(Value = "cloud_enrolling")]
        Cloud_enrolling,

        /// <summary>
        /// Enum Bootstrapped for "bootstrapped"
        /// </summary>
        [EnumMember(Value = "bootstrapped")]
        Bootstrapped,

        /// <summary>
        /// Enum Registered for "registered"
        /// </summary>
        [EnumMember(Value = "registered")]
        Registered,

        /// <summary>
        /// Enum Deregistered for "deregistered"
        /// </summary>
        [EnumMember(Value = "deregistered")]
        Deregistered
    }
}
