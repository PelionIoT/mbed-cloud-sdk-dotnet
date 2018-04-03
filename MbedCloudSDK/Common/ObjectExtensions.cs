// <copyright file="ObjectExtensions.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Object Extensions
    /// </summary>
    internal static class ObjectExtensions
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
                // Skip properties without or with non-public getters and with indexed parameters
                // (which can't be inferred).
                if (property.GetGetMethod() != null && property.GetIndexParameters().Length == 0)
                {
                    result.Add(property.Name, property.GetValue(me));
                }
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

        /// <summary>
        /// Creates a text dump for all the properties of the specified object.
        /// </summary>
        /// <param name="me">An instance of an object to dump as its textual representation.</param>
        /// <returns>
        /// A textual representation of the object <paramref name="me"/>, useful for debugging.
        /// </returns>
        public static string DebugDump(this object me)
        {
            if (me == null)
            {
                return string.Empty;
            }

            var text = new StringBuilder();
            text.AppendLine($"class {me.GetType().Name}SerializerData {{");

            foreach (var property in me.GetProperties())
            {
                text.AppendLine($"    {property.Key}: {property.Value}");
            }

            text.AppendLine("}");

            return text.ToString();
        }
    }
}