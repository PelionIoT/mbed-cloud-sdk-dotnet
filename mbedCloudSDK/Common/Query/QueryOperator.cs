using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Common.Query
{
    /// <summary>
    /// Operators used to query data.
    /// </summary>
    public enum QueryOperator
    {
        /// <summary>
        /// Equal operator.
        /// </summary>
        [EnumMember(Value = "")]
        Equals,
        /// <summary>
        /// Not Equal operator.
        /// </summary>
        [EnumMember(Value = "neq")]
        NotEqual,
        /// <summary>
        /// Less or Equal operator.
        /// </summary>
        [EnumMember(Value = "lte")]
        LessOrEqual,
        /// <summary>
        /// Greater or Equal.
        /// </summary>
        [EnumMember(Value = "gte")]
        GreaterOrEqual

    }
}
