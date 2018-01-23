// <copyright file="MaskEnum.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Tlv
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Mask Enum
    /// </summary>
    public enum MaskEnum
    {
        /// <summary>
        /// ID type.
        /// </summary>
        [EnumMember(Value = "11000000")]
        ID_TYPE,

        /// <summary>
        /// ID length
        /// </summary>
        [EnumMember(Value = "00100000")]
        ID_LENGTH,

        /// <summary>
        /// Length type.
        /// </summary>
        [EnumMember(Value = "00011000")]
        LENGTH_TYPE,

        /// <summary>
        /// Length.
        /// </summary>
        [EnumMember(Value = "00000111")]
        LENGTH
    }
}
