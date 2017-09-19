// <copyright file="FilterAttribute.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Filter
{
    /// <summary>
    /// Filter Attribute
    /// </summary>
    public class FilterAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterAttribute"/> class.
        /// Create new instance of Query attribute.
        /// </summary>
        /// <param name="value">Value for the query attribute.</param>
        /// <param name="filterOperator">Operator for the query attribute.</param>
        public FilterAttribute(string value, FilterOperator filterOperator = FilterOperator.Equals)
        {
            Value = value;
            FilterOperator = filterOperator;
        }

        /// <summary>
        /// Gets or sets attribute value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets operator for the query.
        /// </summary>
        public FilterOperator FilterOperator { get; set; }

        /// <summary>
        /// Get the suffix for the query string
        /// </summary>
        /// <returns>Suffix of query string</returns>
        public string GetSuffix()
        {
            switch (FilterOperator)
            {
                case FilterOperator.Equals:
                    return string.Empty;
                case FilterOperator.NotEqual:
                    return "neq";
                case FilterOperator.LessOrEqual:
                    return "ltq";
                case FilterOperator.GreaterOrEqual:
                    return "gtq";
                default:
                    return string.Empty;
            }
        }
    }
}