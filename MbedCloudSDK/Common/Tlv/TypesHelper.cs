// <copyright file="TypesHelper.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Tlv
{
    using System;

    /// <summary>
    /// Types Helper
    /// </summary>
    public static class TypesHelper
    {
        /// <summary>
        /// Get Binary from type enum
        /// </summary>
        /// <param name="value">Enum value</param>
        /// <returns>Int of type</returns>
        public static int GetTypeBinary(TypesEnum value)
        {
            var enumValue = Utils.GetEnumMemberValue(typeof(TypesEnum), Convert.ToString(value));
            return Convert.ToInt32(enumValue, 2);
        }

        /// <summary>
        /// Gets binary value of length type
        /// </summary>
        /// <param name="value">Length type enum</param>
        /// <returns>Int of binary value</returns>
        public static int GetLengthTypeBinary(LengthTypeEnum value)
        {
            var enumValue = Utils.GetEnumMemberValue(typeof(LengthTypeEnum), Convert.ToString(value));
            return Convert.ToInt32(enumValue, 2);
        }
    }
}