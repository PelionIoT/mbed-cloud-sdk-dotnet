using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mbed.Cloud.Common.Filters
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FilterOperator
    {
        [EnumMember(Value = "$eq")]
        Equals,
        [EnumMember(Value = "$neq")]
        NotEqual,
        [EnumMember(Value = "$gte")]
        GreaterThan,
        [EnumMember(Value = "$lte")]
        LessThan,
        [EnumMember(Value = "$in")]
        In,
        [EnumMember(Value = "$nin")]
        NotIn,
        [EnumMember(Value = "$like")]
        Like,
    }
}