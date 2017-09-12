using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using MbedCloudSDK.Common.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp.Extensions.MonoHttp;

namespace MbedCloudSDK.Common
{
    public static class Utils{
        /// <summary>
        /// Map update object to original object.
        /// </summary>
        /// <param name="origObj">Original object</param>
        /// <param name="updateObj">Update object</param>
        public static object MapToUpdate(object origObj, object updateObj){
            var type = updateObj.GetType();
            var props = type.GetProperties();
            var newObj = Activator.CreateInstance(type);

            foreach(var prop in props){
                var targetProperty = type.GetProperty(prop.Name);
                if(targetProperty.GetSetMethod(true) == null){
                    continue;
                }else{
                    var val = prop.GetValue(updateObj,null);
                    if(val != null){
                        if(typeof(MbedCloudSDK.Common.Filter.Filter) == val.GetType())
                        {
                            var filter = val as MbedCloudSDK.Common.Filter.Filter;
                            if (filter.IsBlank)
                            {
                                targetProperty.SetValue(newObj, prop.GetValue(origObj, null));
                            }
                            else{
                                targetProperty.SetValue(newObj, val, null);
                            }
                        }
                        else
                        {
                            targetProperty.SetValue(newObj, val, null);
                        }
                    }else{
                        targetProperty.SetValue(newObj,prop.GetValue(origObj,null));
                    }
                }
            }
            return newObj;
        }

        /// <summary>
        /// Get string value of enum member value from enum.
        /// </summary>
        /// <param name="type">Enum type</param>
        /// <param name="value">Enum member string</param>
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
        public static object GetEnumFromEnumMemberValue(Type type, string value)
        {
            foreach (var name in Enum.GetNames(type))
            {
                var attr = ((EnumMemberAttribute[])type.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
                if(attr.Value == value) return Enum.Parse(type, name);
            }
            return null;
        }

        public static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
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