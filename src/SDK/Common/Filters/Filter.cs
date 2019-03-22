using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
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

        internal Filter(string value)
        {
            filterCollection = !string.IsNullOrEmpty(value) ? QueryJsonToDictionary(value) : new Dictionary<string, FilterItemList>();
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

        private static Dictionary<string, FilterItemList> QueryJsonToDictionary(string queryJson)
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

                return json.ToDictionary(k => k.Key, k => GetQueryAttribute(k.Value));
            }

            return new Dictionary<string, FilterItemList>();
        }

        private static FilterItemList GetQueryAttribute(object val)
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
                    filterAttributes.Add(new FilterItem(value, filterOperator));
                }
            }
            catch (JsonReaderException)
            {
                filterAttributes.Add(new FilterItem(objStr));
            }

            return filterAttributes;
        }
    }
}