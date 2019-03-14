namespace Mbed.Cloud.Common.Filters
{
    public class FilterItem
    {
        public FilterOperator Operator { get; }
        public object Value { get; }

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