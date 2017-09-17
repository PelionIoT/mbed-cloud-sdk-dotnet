// <copyright file="FilterOperator.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System.Runtime.Serialization;

namespace MbedCloudSDK.Common.Filter
{
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
        GreaterOrEqual
    }
}