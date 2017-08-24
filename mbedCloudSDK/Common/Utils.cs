using System;
using System.Collections.Generic;
using System.Linq;
using mbedCloudSDK.Common.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace mbedCloudSDK.Common
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

        public static Dictionary<string, QueryAttribute> ParseAttributeString(string attributeString)
        {
            var json = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(attributeString);
            var dict = json.ToDictionary(k => k.Key, k => parseVal(k.Value));
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
    }
}