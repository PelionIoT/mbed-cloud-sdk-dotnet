// <copyright file="Utils.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MbedCloudSDK.Common
{
    /// <summary>
    /// Utils
    /// A set of utility functions
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Map update object to original object.
        /// </summary>
        /// <param name="origObj">Original object</param>
        /// <param name="updateObj">Update object</param>
        /// <returns></returns>
        public static object MapToUpdate(object origObj, object updateObj)
        {
            var type = updateObj.GetType();
            var props = type.GetProperties();
            var newObj = Activator.CreateInstance(type);

            foreach (var prop in props)
            {
                var targetProperty = type.GetProperty(prop.Name);
                if (targetProperty.GetSetMethod(true) == null)
                {
                    continue;
                }
                else
                {
                    var val = prop.GetValue(updateObj, null);
                    if (val != null)
                    {
                        if (typeof(Filter.Filter) == val.GetType())
                        {
                            var filter = val as MbedCloudSDK.Common.Filter.Filter;
                            if (filter.IsBlank)
                            {
                                targetProperty.SetValue(newObj, prop.GetValue(origObj, null));
                            }
                            else
                            {
                                targetProperty.SetValue(newObj, val, null);
                            }
                        }
                        else
                        {
                            targetProperty.SetValue(newObj, val, null);
                        }
                    }
                    else
                    {
                        targetProperty.SetValue(newObj, prop.GetValue(origObj, null));
                    }
                }
            }

            return newObj;
        }

        /// <summary>
        /// Parse an enum
        /// </summary>
        public static T ParseEnum<T>(object enumValue)
            where T : struct, IComparable
        {
            var value = Convert.ToString(enumValue);
            if (string.IsNullOrEmpty(value))
            {
                return default(T);
            }

            return Enum.TryParse<T>(value, true, out T result) ? result : default(T);
        }

        /// <summary>
        /// Get string value of enum member value from enum.
        /// </summary>
        /// <param name="type">Enum type</param>
        /// <param name="value">Enum member string</param>
        /// <returns></returns>
        public static string GetEnumMemberValue(Type type, string value)
        {
            var memInfo = type.GetMember(value);
            if (memInfo.Any())
            {
                var attributes = memInfo[0].GetCustomAttributes(typeof(EnumMemberAttribute), false);
                return ((EnumMemberAttribute)attributes.FirstOrDefault()).Value;
            }

            return null;
        }

        /// <summary>
        /// Get enum from enum member string
        /// </summary>
        /// <param name="type">Type of enum</param>
        /// <param name="value">Enum member string</param>
        /// <returns></returns>
        public static object GetEnumFromEnumMemberValue(Type type, string value)
        {
            foreach (var name in Enum.GetNames(type))
            {
                var attr = ((EnumMemberAttribute[])type.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
                if (attr.Value == value)
                {
                    return Enum.Parse(type, name);
                }
            }

            return null;
        }

        /// <summary>
        /// Check if string is valid Json
        /// </summary>
        public static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) ||
                (strInput.StartsWith("[") && strInput.EndsWith("]")))
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException)
                {
                    // Exception in parsing json
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}