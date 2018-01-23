// <copyright file="ObjectExtensions.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Object Extensions
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Get object properties as dictionary
        /// </summary>
        /// <param name="me">The object</param>
        /// <returns>Dictionary with object properties</returns>
        public static Dictionary<string, object> GetProperties(this object me)
        {
            var result = new Dictionary<string, object>();
            foreach (var property in me.GetType().GetProperties())
            {
                result.Add(property.Name, property.GetValue(me));
            }

            return result;
        }

        /// <summary>
        /// Convert a nullable date to universal time
        /// </summary>
        /// <param name="date">The date to convert</param>
        /// <returns>The date in universal time or null</returns>
        public static DateTime? ToNullableUniversalTime(this DateTime? date)
        {
            if (date.HasValue)
            {
                return date.Value.ToUniversalTime();
            }

            return null;
        }
    }
}