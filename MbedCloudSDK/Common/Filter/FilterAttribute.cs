// <copyright file="FilterAttribute.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Filter
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

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
        [JsonConstructor]
        public FilterAttribute(string value, FilterOperator filterOperator = FilterOperator.Equals)
        {
            Value = value;
            FilterOperator = filterOperator;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterAttribute"/> class.
        /// Create new instance of Query attribute.
        /// </summary>
        /// <param name="value">Value for the query attribute as datetime.</param>
        /// <param name="filterOperator">Operator for the query attribute.</param>
        public FilterAttribute(DateTime value, FilterOperator filterOperator = FilterOperator.Equals)
        {
            Value = value.ToString("yyyy-MM-dd'T'HH:mm:ss.fffZ");
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
        /// Gets Json representaion of Filter Attribute
        /// </summary>
        /// <returns>JObject of Filter Attribute</returns>
        public JObject FilterAttributeJson
        {
            get
            {
                return new JObject(new JProperty(Filter.QueryOperatorToString(FilterOperator), Value));
            }
        }

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
                    return "__neq";
                case FilterOperator.LessOrEqual:
                    return "__lte";
                case FilterOperator.GreaterOrEqual:
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