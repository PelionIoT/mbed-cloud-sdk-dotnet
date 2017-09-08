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
                        targetProperty.SetValue(newObj,val,null);
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

        public static Dictionary<string, QueryAttribute> ParseAttributeString(string attributeString)
        {
            var decodedString = HttpUtility.UrlDecode(attributeString).Replace("u'","\"").Replace("'","\"");
            var customAttributes = new Dictionary<string, QueryAttribute>();
            var json = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(decodedString);
            if(json.Keys.Contains("custom_attributes")){
                var f = json["custom_attributes"].ToString(Formatting.None);
                customAttributes = ParseAttributeString(f);
                json.Remove("custom_attributes");
            }
            var dict = json.ToDictionary(k => k.Key, k => parseVal(k.Value));
            if(customAttributes.Any()){
                customAttributes.ToList().ForEach(d => dict.Add($"custom_attributes__{d.Key}", d.Value));
            }
            return dict;
        }

        private static QueryAttribute parseVal(JObject val)
        {
            var oper = val.First as JProperty;
            var operName = oper.Name;
            var operValue = val.First.First.Value<string>();
            var queryAttribute = new QueryAttribute(operValue, ParseQueryOperator(operName));
            return queryAttribute;
        }

        public static QueryOperator ParseQueryOperator(string val)
        {
            switch (val)
            {
                case "$eq":
                    return QueryOperator.Equals;
                case "$neq":
                    return QueryOperator.NotEqual;
                case "$lte":
                    return QueryOperator.LessOrEqual;
                case "$gte":
                    return QueryOperator.GreaterOrEqual;
                default:
                    return QueryOperator.Equals;
            }
        }

        public static string QueryOperatorToString(QueryOperator queryOperator){
            switch (queryOperator)
            {
                case QueryOperator.Equals:
                    return "$eq";
                case QueryOperator.NotEqual:
                    return "$neq";
                case QueryOperator.LessOrEqual:
                    return "$lte";
                case QueryOperator.GreaterOrEqual:
                    return "$gte";
                default:
                    return "$eq";
            }
        }

        public static string QueryStringToJson(string queryString)
        {
            var dict = new Dictionary<string, QueryAttribute>();
            var split = queryString.Split('&');
            foreach (var b in split)
            {
                var keyValue = b.Split('=');
                var val = keyValue[1];
                var key = keyValue[0];
                var oper = QueryOperator.Equals;

                if (key.Contains("neq"))
                {
                    key = key.Replace("neq", "");
                    oper = QueryOperator.NotEqual;
                }
                if (key.Contains("ltq"))
                {
                    key = key.Replace("ltq", "");
                    oper = QueryOperator.LessOrEqual;
                }
                if (key.Contains("gtq"))
                {
                    key = key.Replace("gtq", "");
                    oper = QueryOperator.GreaterOrEqual;
                }

                var queryAttribute = new QueryAttribute(val, oper);
                dict.Add(key, queryAttribute);
            }
            var json = new JObject();
            foreach(var kv in dict){
                var innerJson = new JObject();
                innerJson[QueryOperatorToString(kv.Value.QueryOperator)] = kv.Value.Value;
                json[kv.Key] = innerJson;
            }
            return json.ToString(Formatting.None);
        }
    }
}