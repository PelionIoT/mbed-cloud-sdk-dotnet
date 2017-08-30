using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Common.Query
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryAttribute
    {
        /// <summary>
        /// Attribute value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// operator for the query.
        /// </summary>
        public QueryOperator QueryOperator { get; set; }

        /// <summary>
        /// Create new instance of Query attribute.
        /// </summary>
        /// <param name="value">Value for the query attribute.</param>
        /// <param name="queryOperator">Operator for the query attribute.</param>
        public QueryAttribute(string value, QueryOperator queryOperator = QueryOperator.Equals)
        {
            this.Value = value;
            this.QueryOperator = queryOperator;
        }

        /// <summary>
        /// Get the suffix for the query string
        /// </summary>
        public string GetSuffix()
        {
            switch (this.QueryOperator)
            {
                case QueryOperator.Equals:
                    return "";
                case QueryOperator.NotEqual:
                    return "neq";
                case QueryOperator.LessOrEqual:
                    return "ltq";
                case QueryOperator.GreaterOrEqual:
                    return "gtq";
                default:
                    return "";
            }
        }
    }
}
