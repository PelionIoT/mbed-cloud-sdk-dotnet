// <copyright file="TypesEnum.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Tlv
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Types Enum
    /// </summary>
    public enum TypesEnum
    {
        /// <summary>
        /// Object Instance.
        /// </summary>
        [EnumMember(Value = "00000000")]
        OBJECT_INSTAN,

        /// <summary>
        /// Resource Instance.
        /// </summary>
        [EnumMember(Value = "01000000")]
        RESOURCE_INST,

        /// <summary>
        /// Multi Resource.
        /// </summary>
        [EnumMember(Value = "10000000")]
        MULT_RESOURCE,

        /// <summary>
        /// Resource Value.
        /// </summary>
        [EnumMember(Value = "11000000")]
        RESOURCE_VALU
    }
}