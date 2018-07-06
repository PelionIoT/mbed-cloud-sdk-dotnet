// <copyright file="EnumExtensions.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Extensions
{
    using System;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// EnumExtensions
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Get enum from enum member string
        /// </summary>
        /// <param name="value">Enum member string</param>
        /// <param name="type">Type of enum</param>
        /// <returns>
        /// Enum
        /// </returns>
        public static object GetEnumFromEnumMemberValue(this string value, Type type)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                foreach (var name in Enum.GetNames(type))
                {
                    var attr = ((EnumMemberAttribute[])type.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
                    if (attr.Value == value)
                    {
                        return Enum.Parse(type, name);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Parse an enum
        /// </summary>
        /// <typeparam name="T">Type of Enum</typeparam>
        /// <param name="enumValue">Enum</param>
        /// <returns>Enum of type T</returns>
        public static T ParseEnum<T>(this object enumValue)
            where T : struct, IComparable
        {
            var value = Convert.ToString(enumValue);
            if (string.IsNullOrEmpty(value))
            {
                return default;
            }

            return Enum.TryParse(value, true, out T result) ? result : default;
        }

        /// <summary>
        /// Get string value of enum member value from enum.
        /// </summary>
        /// <param name="value">Enum member string</param>
        /// <param name="type">Enum type</param>
        /// <returns>
        /// Value of Enum member attribute
        /// </returns>
        public static string GetEnumMemberValue(this string value, Type type)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var memInfo = type.GetMember(value);
                if (memInfo.Any())
                {
                    var attributes = memInfo[0].GetCustomAttributes(typeof(EnumMemberAttribute), false);
                    return ((EnumMemberAttribute)attributes.FirstOrDefault()).Value;
                }
            }

            return null;
        }
    }
}