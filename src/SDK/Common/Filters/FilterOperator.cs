using System.Runtime.Serialization;

namespace Mbed.Cloud.Common.Filters
{
    public enum FilterOperator
    {
        [EnumMember(Value = "eq")]
        Equals,
        [EnumMember(Value = "neq")]
        NotEqual,
        [EnumMember(Value = "gte")]
        GreaterThan,
        [EnumMember(Value = "lte")]
        LessThan,
        [EnumMember(Value = "in")]
        In,
        [EnumMember(Value = "nin")]
        NotIn,
        [EnumMember(Value = "like")]
        Like,
    }
}