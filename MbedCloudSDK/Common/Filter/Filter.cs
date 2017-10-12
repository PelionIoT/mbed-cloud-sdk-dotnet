// <copyright file="Filter.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Filter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using RestSharp.Extensions.MonoHttp;

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
            if (!string.IsNullOrEmpty(value))
            {
                if (Utils.IsValidJson(value))
                {
                    FilterDictionary = QueryJsonToDictionary(value);
                }
                else
                {
                    var jsonString = QueryStringToJson(value);
                    FilterDictionary = QueryJsonToDictionary(jsonString);
                }
            }
            else
            {
                FilterDictionary = new Dictionary<string, FilterAttribute[]>();
            }
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
                                    .ForEach(f => f.Value.ToList().ForEach(a => json.Add(new JProperty(f.Key, a.FilterAttributeJson))));
                    return json;
                }

                return default(JObject);
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
                case "$ne":
                    return FilterOperator.NotEqual;
                case "$lte":
                    return FilterOperator.LessOrEqual;
                case "$gte":
                    return FilterOperator.GreaterOrEqual;
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
                    return "$ne";
                case FilterOperator.LessOrEqual:
                    return "$lte";
                case FilterOperator.GreaterOrEqual:
                    return "$gte";
                default:
                    return "$eq";
            }
        }

        /// <summary>
        /// Add new query to filter
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="filterAttribute">Value</param>
        /// <returns>The filter dictionary</returns>
        public Dictionary<string, FilterAttribute[]> Add(string key, params FilterAttribute[] filterAttribute)
        {
            FilterDictionary.Add(key, filterAttribute);
            return FilterDictionary;
        }

        /// <summary>
        /// Add new query to filter
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="filterOperator">Operator, Equals if not provided</param>
        /// <returns>The filter dictionary</returns>
        public Dictionary<string, FilterAttribute[]> Add(string key, string value, FilterOperator filterOperator = FilterOperator.Equals)
        {
            var filterAttribute = new FilterAttribute(value, filterOperator);
            FilterDictionary.Add(key, new FilterAttribute[] { filterAttribute });
            return FilterDictionary;
        }

        /// <summary>
        /// Add custom query to filter
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="filterAttribute">Value</param>
        /// <returns>The filter dictionary</returns>
        public Dictionary<string, FilterAttribute[]> AddCustom(string key, params FilterAttribute[] filterAttribute)
        {
            key = $"{CustomAttributesPrefix}{key}";
            FilterDictionary.Add(key, filterAttribute);
            return FilterDictionary;
        }

        /// <summary>
        /// Remove key from filter
        /// </summary>
        /// <param name="key">Key to remove</param>
        public void Remove(string key)
        {
            FilterDictionary.Remove(key);
        }

        /// <summary>
        /// Check if filter contains key
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>True if key in filter</returns>
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
                    filterAttributes.Add(new FilterAttribute(item.Value.Value<string>(), QueryOperatorToEnum(item.Key)));
                }
            }
            catch (JsonReaderException)
            {
                filterAttributes.Add(new FilterAttribute(objStr));
            }

            return filterAttributes.ToArray();
        }

        private static string QueryStringToJson(string queryString)
        {
            queryString = HttpUtility.UrlDecode(queryString).Replace("u'", "\"").Replace("'", "\"");
            var dict = new Dictionary<string, FilterAttribute>();
            var split = queryString.Split('&');
            foreach (var part in split)
            {
                var keyValue = part.Split('=');
                if (keyValue.Length == 2)
                {
                    var val = keyValue[1];
                    var key = keyValue[0];
                    var oper = FilterOperator.Equals;

                    if (key.Contains("neq"))
                    {
                        key = key.Replace("neq", string.Empty);
                        oper = FilterOperator.NotEqual;
                    }

                    if (key.Contains("ltq"))
                    {
                        key = key.Replace("ltq", string.Empty);
                        oper = FilterOperator.LessOrEqual;
                    }

                    if (key.Contains("gtq"))
                    {
                        key = key.Replace("gtq", string.Empty);
                        oper = FilterOperator.GreaterOrEqual;
                    }

                    var queryAttribute = new FilterAttribute(val, oper);
                    dict.Add(key, queryAttribute);
                }
            }

            var json = new JObject();
            foreach (var kv in dict)
            {
                var innerJson = new JObject
                {
                    [QueryOperatorToString(kv.Value.FilterOperator)] = kv.Value.Value
                };
                json[kv.Key] = innerJson;
            }

            return json.ToString(Formatting.None);
        }

        private static JObject StringToJsonObject(string jsonString)
        {
            return JObject.Parse(jsonString);
        }

        private static Dictionary<string, FilterAttribute[]> QueryJsonToDictionary(string queryJson)
        {
            // var decodedString = HttpUtility.UrlDecode(queryJson).Replace("u'", "\"").Replace("'", "\"");
            var customAttributes = new Dictionary<string, FilterAttribute[]>();
            if (Utils.IsValidJson(queryJson))
            {
                var json = JsonConvert.DeserializeObject<Dictionary<string, object>>(queryJson);
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

        private Filter QueryStringToFilter(string queryString)
        {
            var queryJsonString = QueryStringToJson(queryString);
            FilterDictionary = QueryJsonToDictionary(queryJsonString);
            return this;
        }
    }
}