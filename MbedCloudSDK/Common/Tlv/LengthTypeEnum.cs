// <copyright file="LengthTypeEnum.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Tlv
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Length type enum
    /// </summary>
    public enum LengthTypeEnum
    {
        /// <summary>
        /// One Byte.
        /// </summary>
        [EnumMember(Value = "00001000")]
        ONE_BYTE,

        /// <summary>
        /// Two Byte
        /// </summary>
        [EnumMember(Value = "00010000")]
        TWO_BYTE,

        /// <summary>
        /// Three Byte.
        /// </summary>
        [EnumMember(Value = "00011000")]
        TRE_BYTE,

        /// <summary>
        /// Zero Byte.
        /// </summary>
        [EnumMember(Value = "00000000")]
        OTR_BYTE
    }
}