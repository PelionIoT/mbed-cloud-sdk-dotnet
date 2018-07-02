namespace MbedCloudSDK.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    public static class ObjectExtensions
    {
        /// <summary>
        /// Represents the output format for <see cref="DebugDump(object, DumpFormat)"/>.
        /// </summary>
        public enum DumpFormat
        {
            /// <summary>
            /// Flat (only top-level properties) text format, it includes the type name and it's
            /// <em>compatible</em> witht he previously used format. Values are serialzied using
            /// <see cref="CultureInfo.InvariantCulture"/>.
            /// Consider to use <see cref="Json"/> if you need to serialize an object hierarchy.
            /// </summary>
            Text,

            /// <summary>
            /// JSON text format, it includes all JSON serializable properties according to their
            /// serialization attributes. All children are also serialized. Consider to use <see cref="Text"/>
            /// if you need to serialize only top-level properties.
            /// </summary>
            Json
        }

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
        /// <param name="format">
        /// Format required for the output representation. Default value is <see cref="DumpFormat.Text"/> for
        /// backward compatibility but it will change to <see cref="DumpFormat.Json"/> when migration will be completed.
        /// Specify a value if you explicitely need a specific output format.
        /// </param>
        /// <returns>
        /// A textual representation of the object <paramref name="me"/>, useful for debugging. It's always
        /// <see cref="string.Empty"/> if <paramref name="me"/> is <see langword="null"/>.
        /// </returns>
        public static string DebugDump(this object me, DumpFormat format = DumpFormat.Json)
        {
            if (me == null)
            {
                return string.Empty;
            }

            if (format == DumpFormat.Json)
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(me);
            }

            var text = new StringBuilder();
            text.AppendLine($"class {me.GetType().Name}SerializerData {{");

            foreach (var property in me.GetProperties())
            {
                text.AppendLine(string.Format(CultureInfo.InvariantCulture, "    {0}: {1}", property.Key, property.Value));
            }

            text.AppendLine("}");

            return text.ToString();
        }

        public static void Print<T>(this IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Map update object to original object.
        /// </summary>
        /// <param name="origObj">Original object</param>
        /// <param name="updateObj">Update object</param>
        /// <returns>Object</returns>
        public static object MapToUpdate(this object origObj, object updateObj)
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
    }
}