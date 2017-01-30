using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Common.Query
{
    public class QueryAttribute
    {
        public string Value { get; set; }
        public QueryOperator QueryOperator { get; set; }

        public QueryAttribute(string value, QueryOperator queryOperator = QueryOperator.Equals)
        {
            this.Value = value;
            this.QueryOperator = queryOperator;
        }
    }
}
