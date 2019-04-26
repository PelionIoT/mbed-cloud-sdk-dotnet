using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Mbed.Cloud.RestClient;
using MbedCloudSDK.Common.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mbed.Cloud.Common.Filters
{
    public class Filter
    {
        private Dictionary<string, FilterItemList> filterCollection;

        public Filter()
        {
            filterCollection = new Dictionary<string, FilterItemList>();
        }

        internal Filter(string value, ParameterInfo paramInfo = null)
        {
            filterCollection = !string.IsNullOrEmpty(value) ? value.IsValidJson() ? QueryJsonToDictionary(value, paramInfo) : QueryStringToDictionary(value) : new Dictionary<string, FilterItemList>();
        }

        [JsonProperty]
        public ReadOnlyDictionary<string, FilterItemList> FilterCollection
        {
            get
            {
                return new ReadOnlyDictionary<string, FilterItemList>(filterCollection);
            }

            private set
            {
                filterCollection = value.ToDictionary(kv => kv.Key, kv => kv.Value);
            }
        }

        /// <summary>
        /// Gets string representation of Filter.
        /// </summary>
        internal string CampaignFilterString
        {
            get
            {
                if (filterCollection.Any())
                {
                    var fString = new List<string>();
                    filterCollection.ToList().ForEach(k => k.Value.ToList().ForEach(f => fString.Add($"{k.Key}{f.GetSuffix()}={f.Value}")));
                    var stringVal = string.Join("&", fString);
                    return stringVal;
                }

                return string.Empty;
            }
        }

        public void AddFilterItem(string key, FilterItem item)
        {
            if (filterCollection.ContainsKey(key))
            {
                filterCollection[key].Add(item);
            }
            else
            {
                filterCollection.Add(key, new FilterItemList { item });
            }
        }

        public void AddFilterItem(string key, IEnumerable<FilterItem> items)
        {
            if (filterCollection.ContainsKey(key))
            {
                filterCollection[key].AddRange(items);
            }
            else
            {
                var filterItemList = new FilterItemList();
                filterItemList.AddRange(items);
                filterCollection.Add(key, filterItemList);
            }
        }

        public void RemoveFilterItem(string key)
        {
            if (filterCollection.ContainsKey(key))
            {
                filterCollection.Remove(key);
            }
        }

        public object GetEncodedValue(string key, string filterOperatorString = "$eq")
        {
            var filterOperator = (FilterOperator)filterOperatorString.GetEnumFromEnumMemberValue(typeof(FilterOperator));
            var filterItem = filterCollection.FirstOrDefault(f => f.Key == key);

            if (filterItem.Value != null)
            {
                var filterValue = filterItem.Value.FirstOrDefault(f => f.Operator == filterOperator)?.Value;

                if (filterValue == null)
                {
                    return null;
                }

                if (filterValue is bool filterValueBool)
                {
                    // tostring returns True or False, needs to be true or false
                    return filterValueBool.ToString().ToLower();
                }

                if (filterValue is DateTime filterValueDateTime)
                {
                    return filterValueDateTime.ToString(SerializationSettings.DateFormatString);
                }

                if (typeof(IEnumerable<string>).IsAssignableFrom(filterValue.GetType()))
                {
                    var filterValueList = (filterValue as IEnumerable).OfType<string>();
                    return string.Join(",", filterValueList);
                }

                if (filterValue is Entity filterValueEntity)
                {
                    return filterValueEntity.Id;
                }

                if (typeof(IDictionary).IsAssignableFrom(filterValue.GetType()))
                {
                    return JsonConvert.SerializeObject(filterValue);
                }

                return filterValue;
            }

            return null;
        }

        private static Dictionary<string, FilterItemList> QueryJsonToDictionary(string queryJson, ParameterInfo paramInfo)
        {
            var customAttributes = new Dictionary<string, FilterItemList>();
            if (queryJson.IsValidJson())
            {
                var tempJson = JsonConvert.DeserializeObject<Dictionary<string, object>>(queryJson);
                var json = new Dictionary<string, object>();
                foreach (var key in tempJson.Keys)
                {
                    var val = tempJson[key];
                    json.Add(key, val);
                }

                return json.ToDictionary(k => k.Key, k => GetQueryAttribute(k.Value, k.Key, paramInfo));
            }

            return new Dictionary<string, FilterItemList>();
        }

        private static FilterItemList GetQueryAttribute(object val, string key, ParameterInfo paramInfo)
        {
            var filterAttributes = new FilterItemList();
            var objStr = Convert.ToString(val);
            try
            {
                var jobj = JObject.Parse(objStr);
                foreach (var item in jobj)
                {
                    var value = item.Value.Value<string>();
                    var isDate = DateTime.TryParseExact(value, "MM/dd/yyyy HH:mm:ss", null, DateTimeStyles.None, out DateTime dateValue);
                    if (isDate)
                    {
                        var dateWithMilli = item.Value.Value<DateTime>();
                        value = dateWithMilli.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                    }

                    var filterOperator = (FilterOperator)item.Key.GetEnumFromEnumMemberValue(typeof(FilterOperator));

                    if (paramInfo != null)
                    {
                        var correspondingValueType = paramInfo.ParameterType
                            .GetMethods()
                            .FirstOrDefault(m => m.Name.StartsWith(key.SnakeToCamel()))
                            .GetParameters()
                            .FirstOrDefault()
                            .ParameterType;

                        if (correspondingValueType.IsEnum)
                        {
                            var enumValue = value.GetEnumMemberValue(correspondingValueType);

                            if (!string.IsNullOrEmpty(enumValue))
                            {
                                value = enumValue;
                            }
                        }
                    }

                    filterAttributes.Add(new FilterItem(value, filterOperator));
                }
            }
            catch (JsonReaderException)
            {
                filterAttributes.Add(new FilterItem(objStr));
            }

            return filterAttributes;
        }

        private static Dictionary<string, FilterItemList> QueryStringToDictionary(string queryString)
        {
            var dict = new Dictionary<string, FilterItemList>();
            var split = queryString.Split('&');
            foreach (var part in split)
            {
                var keyValue = part.Split('=');
                if (keyValue.Length == 2)
                {
                    var val = keyValue[1];
                    var key = keyValue[0];
                    var oper = FilterOperator.Equals;

                    if (key.Contains("__neq"))
                    {
                        key = key.Replace("__neq", string.Empty);
                        oper = FilterOperator.NotEqual;
                    }

                    if (key.Contains("__lte"))
                    {
                        key = key.Replace("__lte", string.Empty);
                        oper = FilterOperator.LessThan;
                    }

                    if (key.Contains("__gte"))
                    {
                        key = key.Replace("__gte", string.Empty);
                        oper = FilterOperator.GreaterThan;
                    }

                    if (key.Contains("__in"))
                    {
                        key = key.Replace("__in", string.Empty);
                        oper = FilterOperator.In;
                    }

                    if (key.Contains("__nin"))
                    {
                        key = key.Replace("__nin", string.Empty);
                        oper = FilterOperator.NotIn;
                    }

                    var queryAttribute = new FilterItem(val, oper);
                    if (dict.ContainsKey(key))
                    {
                        var tmp = dict[key];
                        tmp.Add(queryAttribute);
                        dict.Remove(key);
                        dict.Add(key, tmp);
                    }
                    else
                    {
                        dict.Add(key, new FilterItemList { queryAttribute });
                    }
                }
            }

            return dict;
        }
    }
}