using System;
using MbedCloudSDK.Common.Extensions;
using Newtonsoft.Json;

namespace Mbed.Cloud.Common.Filters
{
    public class FilterItem
    {
        [JsonProperty]
        public FilterOperator Operator { get; private set; }
        [JsonProperty]
        public object Value { get; private set; }

        public FilterItem()
        { }

        public FilterItem(object value)
            : this(value, FilterOperator.Equals)
        { }

        public FilterItem(object value, FilterOperator filterOperator)
        {
            Value = value;
            Operator = filterOperator;
        }

        /// <summary>
        /// Get the suffix for the query string
        /// </summary>
        /// <returns>Suffix of query string</returns>
        internal string GetSuffix()
        {
            switch (Operator)
            {
                case FilterOperator.Equals:
                    return string.Empty;
                case FilterOperator.NotEqual:
                    return "__neq";
                case FilterOperator.LessThan:
                    return "__lte";
                case FilterOperator.GreaterThan:
                    return "__gte";
                case FilterOperator.In:
                    return "__in";
                case FilterOperator.NotIn:
                    return "__nin";
                default:
                    return string.Empty;
            }
        }
    }
}