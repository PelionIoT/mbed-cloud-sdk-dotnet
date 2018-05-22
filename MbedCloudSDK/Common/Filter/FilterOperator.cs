// <copyright file="FilterOperator.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Filter
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Filter operator
    /// </summary>
    public enum FilterOperator
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
        GreaterOrEqual,

        /// <summary>
        /// Greater or Equal.
        /// </summary>
        [EnumMember(Value = "in")]
        In,

        /// <summary>
        /// Greater or Equal.
        /// </summary>
        [EnumMember(Value = "nin")]
        NotIn,
    }
}