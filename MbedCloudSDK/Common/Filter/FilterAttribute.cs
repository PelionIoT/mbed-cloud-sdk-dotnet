namespace MbedCloudSDK.Common.Filter
{
    public class FilterAttribute
    {
        /// <summary>
        /// Attribute value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// operator for the query.
        /// </summary>
        public FilterOperator FilterOperator { get; set; }

        /// <summary>
        /// Create new instance of Query attribute.
        /// </summary>
        /// <param name="value">Value for the query attribute.</param>
        /// <param name="filterOperator">Operator for the query attribute.</param>
        public FilterAttribute(string value, FilterOperator filterOperator = FilterOperator.Equals)
        {
            this.Value = value;
            this.FilterOperator = filterOperator;
        }

        /// <summary>
        /// Get the suffix for the query string
        /// </summary>
        public string GetSuffix()
        {
            switch (this.FilterOperator)
            {
                case FilterOperator.Equals:
                    return "";
                case FilterOperator.NotEqual:
                    return "neq";
                case FilterOperator.LessOrEqual:
                    return "ltq";
                case FilterOperator.GreaterOrEqual:
                    return "gtq";
                default:
                    return "";
            }
        }
    }
}