// <copyright file="TypesHelper.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Tlv
{
    using System;
    using MbedCloudSDK.Exceptions;

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
        /// Get type enum value from int
        /// </summary>
        /// <param name="value">imnt value</param>
        /// <returns>Types enum</returns>
        public static TypesEnum GetTypeEnumValue(int value)
        {
            var idType = Convert.ToInt32(Utils.GetEnumMemberValue(typeof(MaskEnum), MaskEnum.ID_TYPE.ToString()), 2);
            var stringValue = Convert.ToString(value & idType, 2).PadLeft(8, '0');
            var enumVal = Utils.GetEnumFromEnumMemberValue(typeof(TypesEnum), stringValue);
            if (enumVal != null)
            {
                return (TypesEnum)enumVal;
            }
            else
            {
                throw new DecodingException($"Unknown type value {Convert.ToString(value, 2)}");
            }
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

        /// <summary>
        /// Get type enum value from int
        /// </summary>
        /// <param name="value">imnt value</param>
        /// <returns>Types enum</returns>
        public static LengthTypeEnum GetLengthTypeEnumValue(int value)
        {
            var idType = Convert.ToInt32(Utils.GetEnumMemberValue(typeof(MaskEnum), MaskEnum.LENGTH_TYPE.ToString()), 2);
            var stringValue = Convert.ToString(value & idType, 2).PadLeft(8, '0');
            var enumVal = Utils.GetEnumFromEnumMemberValue(typeof(LengthTypeEnum), stringValue);
            if (enumVal != null)
            {
                return (LengthTypeEnum)enumVal;
            }
            else
            {
                throw new DecodingException($"Unknown type value {Convert.ToString(value, 2)}");
            }
        }
    }
}