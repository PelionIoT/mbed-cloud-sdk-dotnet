// <copyright file="Filter.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Filter
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using MbedCloudSDK.Common.Extensions;
    using MbedCloudSDK.Common.Filter.Maps;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Filter object
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// Prefix for custom attributes.
        /// </summary>
        public static readonly string CustomAttributesPrefix = "custom_attribute__";

        /// <summary>
        /// Initializes a new instance of the <see cref="Filter"/> class.
        /// Default constructor
        /// </summary>
        public Filter()
        {
            FilterDictionary = new Dictionary<string, FilterAttribute[]>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Filter"/> class.
        /// Create new filter object from json or query string
        /// </summary>
        /// <param name="value">Json or query string.</param>
        /// <param name="isBlank">If true, Filter will not be mapped during update</param>
        public Filter(string value, bool isBlank = false)
        {
            IsBlank = isBlank;
            FilterDictionary = !string.IsNullOrEmpty(value) ? value.IsValidJson() ? QueryJsonToDictionary(value) : QueryStringToDictionary(value) : new Dictionary<string, FilterAttribute[]>();
        }

        /// <summary>
        /// Gets string representation of Filter.
        /// </summary>
        public string FilterString
        {
            get
            {
                if (FilterDictionary.Any())
                {
                    var fString = new List<string>();
                    FilterDictionary.ToList().ForEach(k => k.Value.ToList().ForEach(f => fString.Add($"{k.Key}{f.GetSuffix()}={f.Value}")));
                    var stringVal = string.Join("&", fString);
                    return stringVal;
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Gets dictionary containing key-value pairs of filters
        /// </summary>
        [JsonProperty]
        public Dictionary<string, FilterAttribute[]> FilterDictionary { get; private set; }

        /// <summary>
        /// Gets json representation of filter
        /// </summary>
        [JsonProperty]
        public JObject FilterJson
        {
            get
            {
                if (FilterDictionary.Any())
                {
                    var json = new JObject();
                    FilterDictionary.ToList()
                                    .ForEach(f => f.Value.ToList().ForEach(a =>
                                    {
                                        if (json.Properties().Select(p => p.Name).Contains(f.Key))
                                        {
                                            var currentJson = json[f.Key] as JObject;
                                            currentJson.Merge(a.FilterAttributeJson);
                                            json[f.Key] = currentJson;
                                        }
                                        else
                                        {
                                            json.Add(new JProperty(f.Key, a.FilterAttributeJson));
                                        }
                                    }));
                    return json;
                }

                return default;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether if true, filter will not be mapped during an update
        /// </summary>
        public bool IsBlank { get; set; }

        /// <summary>
        /// Return enum from Query Operator
        /// </summary>
        /// <param name="val">String to convert</param>
        /// <returns>Filter Operator enum</returns>
        public static FilterOperator QueryOperatorToEnum(string val)
        {
            switch (val)
            {
                case "$eq":
                    return FilterOperator.Equals;
                case "$neq":
                    return FilterOperator.NotEqual;
                case "$lte":
                    return FilterOperator.LessOrEqual;
                case "$gte":
                    return FilterOperator.GreaterOrEqual;
                case "$in":
                    return FilterOperator.In;
                case "$nin":
                    return FilterOperator.NotIn;
                default:
                    return FilterOperator.Equals;
            }
        }

        /// <summary>
        /// Return string from Query Operator Enum
        /// </summary>
        /// <param name="queryOperator">Query Operator enum</param>
        /// <returns>String value of Query Operator</returns>
        public static string QueryOperatorToString(FilterOperator queryOperator)
        {
            switch (queryOperator)
            {
                case FilterOperator.Equals:
                    return "$eq";
                case FilterOperator.NotEqual:
                    return "$neq";
                case FilterOperator.LessOrEqual:
                    return "$lte";
                case FilterOperator.GreaterOrEqual:
                    return "$gte";
                case FilterOperator.In:
                    return "$in";
                case FilterOperator.NotIn:
                    return "$nin";
                default:
                    return "$eq";
            }
        }

        /// <summary>
        /// Add new query to filter
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="filterAttributes">Value</param>
        /// <returns>The filter dictionary</returns>
        /// <example>
        /// <code>
        /// var filter = new Filter();
        /// filter.Add("name", new FilterAttribute("alex"), new FilterAttrtibute("dan", FilterOperator.NotEqual));
        /// var filterString = filter.FilterString;
        /// var filterJson = filter.FilterJson;
        /// </code>
        /// </example>
        public Dictionary<string, FilterAttribute[]> Add(string key, params FilterAttribute[] filterAttributes)
        {
            return AddFilters(key, filterAttributes);
        }

        /// <summary>
        /// Add a filter with a DeviceFilterUpdateEnum for the key.
        /// </summary>
        /// <param name="key">DeviceFilterUpdateEnum. The enum provides mapping to the filter keys expected in the api.</param>
        /// <param name="filterAttributes">Filter attributes</param>
        /// <returns>The filter dictionary</returns>
        /// <example>
        /// <code>
        /// var filter = new Filter();
        /// filter.Add(DeviceFilterMapEnum.BootstrapCertificateExpiration, new FilterAttribute("true"), new FilterAttrtibute("false", FilterOperator.NotEqual));
        /// var filterString = filter.FilterString;
        /// var filterJson = filter.FilterJson;
        /// </code>
        /// </example>
        public Dictionary<string, FilterAttribute[]> Add(DeviceFilterMapEnum key, params FilterAttribute[] filterAttributes)
        {
            return AddFilters(Convert.ToString(key)?.GetEnumMemberValue(typeof(DeviceFilterMapEnum)), filterAttributes);
        }

        /// <summary>
        /// Add a filter with a UpdateFilterMapEnum for the key.
        /// </summary>
        /// <param name="key">UpdateFilterMapEnum. The enum provides mapping to the filter keys expected in the api.</param>
        /// <param name="filterAttributes">Filter attributes</param>
        /// <returns>The filter dictionary</returns>
        /// <example>
        /// <code>
        /// var filter = new Filter();
        /// filter.Add(UpdateFilterMapEnum.ManifestUrl, new FilterAttribute("www.manifest.com"), new FilterAttrtibute("www.badmanifest", FilterOperator.NotEqual));
        /// var filterString = filter.FilterString;
        /// var filterJson = filter.FilterJson;
        /// </code>
        /// </example>
        public Dictionary<string, FilterAttribute[]> Add(UpdateFilterMapEnum key, params FilterAttribute[] filterAttributes)
        {
            return AddFilters(Convert.ToString(key)?.GetEnumMemberValue(typeof(UpdateFilterMapEnum)), filterAttributes);
        }

        /// <summary>
        /// Add new query to filter
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="filterOperator">Operator, Equals if not provided</param>
        /// <returns>The filter dictionary</returns>
        /// <example>
        /// <code>
        /// var filter = new Filter();
        /// filter.Add("name", "alex");
        /// var filterString = filter.FilterString;
        /// var filterJson = filter.FilterJson;
        /// </code>
        /// </example>
        public Dictionary<string, FilterAttribute[]> Add(string key, string value, FilterOperator filterOperator = FilterOperator.Equals)
        {
            var filterAttribute = new FilterAttribute(value, filterOperator);
            return AddFilters(key, new FilterAttribute[] { filterAttribute });
        }

        /// <summary>
        /// Add new query to filter
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value as datetime</param>
        /// <param name="filterOperator">Operator, Equals if not provided</param>
        /// <returns>The filter dictionary</returns>
        /// <example>
        /// <code>
        /// var filter = new Filter();
        /// filter.Add("date", new DateTime(2017, 1, 1), FilterOperator.GreaterOrEqual);
        /// filter.Add("date", new DateTime(2018, 1, 1), FilterOperator.LessOrEqual);
        /// var filterString = filter.FilterString;
        /// var filterJson = filter.FilterJson;
        /// </code>
        /// </example>
        public Dictionary<string, FilterAttribute[]> Add(string key, DateTime value, FilterOperator filterOperator = FilterOperator.Equals)
        {
            var filterAttribute = new FilterAttribute(value, filterOperator);
            return AddFilters(key, new FilterAttribute[] { filterAttribute });
        }

        /// <summary>
        /// Add a filter with a DeviceFilterMapEnum for the key.
        /// </summary>
        /// <param name="key">The enum provides mapping to the filter keys expected in the api.</param>
        /// <param name="value">Value</param>
        /// <param name="filterOperator">Operator, Equals if not provided</param>
        /// <returns>The filter dictionary</returns>
        /// <example>
        /// <code>
        /// var filter = new Filter();
        /// filter.Add(DeviceFilterMapEnum.BootstrapCertificateExpiration, "false");
        /// var filterString = filter.FilterString;
        /// var filterJson = filter.FilterJson;
        /// </code>
        /// </example>
        public Dictionary<string, FilterAttribute[]> Add(DeviceFilterMapEnum key, string value, FilterOperator filterOperator = FilterOperator.Equals)
        {
            var filterAttribute = new FilterAttribute(value, filterOperator);
            return AddFilters(Convert.ToString(key)?.GetEnumMemberValue(typeof(DeviceFilterMapEnum)), new FilterAttribute[] { filterAttribute });
        }

        /// <summary>
        /// Add a filter with a UpdateFilterMapEnum for the key.
        /// </summary>
        /// <param name="key">The enum provides mapping to the filter keys expected in the api.</param>
        /// <param name="value">Value</param>
        /// <param name="filterOperator">Operator, Equals if not provided</param>
        /// <returns>The filter dictionary</returns>
        /// <example>
        /// <code>
        /// var filter = new Filter();
        /// filter.Add(UpdateFilterMapEnum.ManifestUrl, "www.manifest.com");
        /// var filterString = filter.FilterString;
        /// var filterJson = filter.FilterJson;
        /// </code>
        /// </example>
        public Dictionary<string, FilterAttribute[]> Add(UpdateFilterMapEnum key, string value, FilterOperator filterOperator = FilterOperator.Equals)
        {
            var filterAttribute = new FilterAttribute(value, filterOperator);
            return AddFilters(Convert.ToString(key)?.GetEnumMemberValue(typeof(UpdateFilterMapEnum)), new FilterAttribute[] { filterAttribute });
        }

        /// <summary>
        /// Add custom query to filter
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="filterAttributes">Value</param>
        /// <returns>The filter dictionary</returns>
        /// <example>
        /// <code>
        /// var filter = new Filter();
        /// filter.AddCustom("custom", new FilterAttribute("true"), new FilterAttribute("false", FilterOperator.NotEqual));
        /// var filterString = filter.FilterString;
        /// var filterJson = filter.FilterJson;
        /// </code>
        /// </example>
        public Dictionary<string, FilterAttribute[]> AddCustom(string key, params FilterAttribute[] filterAttributes)
        {
            key = $"{CustomAttributesPrefix}{key}";
            return AddFilters(key, filterAttributes);
        }

        /// <summary>
        /// Add custom query to filter
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="filterOperator">The Operator</param>
        /// <returns>The filter dictionary</returns>
        /// <example>
        /// <code>
        /// var filter = new Filter();
        /// filter.AddCustom("custom", "false", FilterOperator.NotEqual);
        /// var filterString = filter.FilterString;
        /// var filterJson = filter.FilterJson;
        /// </code>
        /// </example>
        public Dictionary<string, FilterAttribute[]> AddCustom(string key, string value, FilterOperator filterOperator = FilterOperator.Equals)
        {
            key = $"{CustomAttributesPrefix}{key}";
            var filterAttribute = new FilterAttribute(value, filterOperator);
            return AddFilters(key, new FilterAttribute[] { filterAttribute });
        }

        /// <summary>
        /// Add custom query to filter
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value as datetime</param>
        /// <param name="filterOperator">The Operator</param>
        /// <returns>The filter dictionary</returns>
        /// <example>
        /// <code>
        /// var filter = new Filter();
        /// filter.AddCustom("custom", new Date(2017, 1, 1), FilterOperator.NotEqual);
        /// var filterString = filter.FilterString;
        /// var filterJson = filter.FilterJson;
        /// </code>
        /// </example>
        public Dictionary<string, FilterAttribute[]> AddCustom(string key, DateTime value, FilterOperator filterOperator = FilterOperator.Equals)
        {
            key = $"{CustomAttributesPrefix}{key}";
            var filterAttribute = new FilterAttribute(value, filterOperator);
            return AddFilters(key, new FilterAttribute[] { filterAttribute });
        }

        /// <summary>
        /// Get the first value from a filter by key.
        /// </summary>
        /// <param name="key">They key of the filter</param>
        /// <param name="filterOperator">The filter operator.</param>
        /// <returns>
        /// The first value in the filter
        /// </returns>
        public string GetFirstValueByKey(string key, FilterOperator filterOperator = FilterOperator.Equals)
        {
            if (FilterDictionary.ContainsKey(key))
            {
                var attr = FilterDictionary[key];
                return attr.FirstOrDefault(a => a.FilterOperator == filterOperator)?.Value;
            }

            return null;
        }

        /// <summary>
        /// Remove key from filter
        /// </summary>
        /// <param name="key">Key to remove</param>
        /// <example>
        /// <code>
        /// var filter = new Filter();
        /// filter.Add("date", new Date(2017, 1, 1), FilterOperator.NotEqual);
        /// filter.Remove("date");
        /// </code>
        /// </example>
        public void Remove(string key)
        {
            if (FilterDictionary.ContainsKey(key))
            {
                FilterDictionary.Remove(key);
            }
        }

        /// <summary>
        /// Check if filter contains key
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>True if key in filter</returns>
        /// <example>
        /// <code>
        /// var filter = new Filter();
        /// filter.Add("date", new Date(2017, 1, 1), FilterOperator.NotEqual);
        /// var contains = filter.Contains("date"); // = true
        /// </code>
        /// </example>
        public bool Contains(string key)
        {
            return FilterDictionary.ContainsKey(key);
        }

        private static FilterAttribute[] GetQueryAttribute(object val)
        {
            var filterAttributes = new List<FilterAttribute>();
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

                    filterAttributes.Add(new FilterAttribute(value, QueryOperatorToEnum(item.Key)));
                }
            }
            catch (JsonReaderException)
            {
                filterAttributes.Add(new FilterAttribute(objStr));
            }

            return filterAttributes.ToArray();
        }

        private static Dictionary<string, FilterAttribute[]> QueryStringToDictionary(string queryString)
        {
            var dict = new Dictionary<string, FilterAttribute[]>();
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
                        oper = FilterOperator.LessOrEqual;
                    }

                    if (key.Contains("__gte"))
                    {
                        key = key.Replace("__gte", string.Empty);
                        oper = FilterOperator.GreaterOrEqual;
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

                    var queryAttribute = new FilterAttribute(val, oper);
                    if (dict.ContainsKey(key))
                    {
                        var tmp = dict[key].ToList();
                        tmp.Add(queryAttribute);
                        dict.Remove(key);
                        dict.Add(key, tmp.ToArray());
                    }
                    else
                    {
                        dict.Add(key, new FilterAttribute[] { queryAttribute });
                    }
                }
            }

            return dict;
        }

        /// <summary>
        /// Encode a key to its mapped value
        /// </summary>
        /// <param name="key">Key to map</param>
        /// <returns>The mapped key</returns>
        public static string EncodeKey(string key)
        {
            var deviceMapValue = key.GetEnumMemberValue(typeof(DeviceFilterMapEnum));
            var updateMapValue = key.GetEnumMemberValue(typeof(UpdateFilterMapEnum));
            if (deviceMapValue != null)
            {
                key = deviceMapValue;
            }

            if (updateMapValue != null)
            {
                key = updateMapValue;
            }

            return key;
        }

        /// <summary>
        /// Decode a key from its mapped value
        /// </summary>
        /// <param name="key">Mapped key</param>
        /// <returns>Original value of key</returns>
        public static string DecodeKey(string key)
        {
            var deviceMapValue = key.GetEnumFromEnumMemberValue(typeof(DeviceFilterMapEnum));
            var updateMapValue = key.GetEnumFromEnumMemberValue(typeof(UpdateFilterMapEnum));
            if (deviceMapValue != null)
            {
                key = Convert.ToString((DeviceFilterMapEnum)deviceMapValue);
            }

            if (updateMapValue != null)
            {
                key = Convert.ToString((UpdateFilterMapEnum)updateMapValue);
            }

            return key;
        }

        private static Dictionary<string, FilterAttribute[]> QueryJsonToDictionary(string queryJson)
        {
            var customAttributes = new Dictionary<string, FilterAttribute[]>();
            if (queryJson.IsValidJson())
            {
                var tempJson = JsonConvert.DeserializeObject<Dictionary<string, object>>(queryJson);
                var json = new Dictionary<string, object>();
                foreach (var key in tempJson.Keys)
                {
                    var val = tempJson[key];
                    var map = MapKeys.Map(key);
                    json.Add(map, val);
                }

                if (json.Keys.Contains("custom_attributes"))
                {
                    var customAttributeJson = json["custom_attributes"].ToString();
                    customAttributes = QueryJsonToDictionary(customAttributeJson);
                    json.Remove("custom_attributes");
                }

                var dict = json.ToDictionary(k => k.Key, k => GetQueryAttribute(k.Value));
                if (customAttributes.Any())
                {
                    customAttributes.ToList().ForEach(d => dict.Add($"{CustomAttributesPrefix}{d.Key}", d.Value));
                }

                return dict;
            }

            return new Dictionary<string, FilterAttribute[]>();
        }

        private Dictionary<string, FilterAttribute[]> AddFilters(string key, params FilterAttribute[] filterAttributes)
        {
            if (FilterDictionary.ContainsKey(key))
            {
                var tmp = FilterDictionary.FirstOrDefault(t => t.Key == key).Value.ToList();
                foreach (var item in filterAttributes)
                {
                    tmp.Add(item);
                }

                FilterDictionary.Remove(key);
                FilterDictionary.Add(key, tmp.ToArray());
                return FilterDictionary;
            }
            else
            {
                FilterDictionary.Add(key, filterAttributes);
                return FilterDictionary;
            }
        }
    }
}