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
        {}

        public FilterItem(object value)
            : this(value, FilterOperator.Equals)
        {}

        public FilterItem(object value, FilterOperator filterOperator)
        {
            Value = value;
            Operator = filterOperator;
        }
    }
}