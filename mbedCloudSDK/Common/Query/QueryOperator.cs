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
        [EnumMember(Value = "equals")]
        Equals
    }
}
