// <copyright file="FilterAttribute.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe.Filters
{
    /// <summary>
    /// Filter Attribute
    /// </summary>
    /// <typeparam name="T">The type of value</typeparam>
    /// <typeparam name="U">The type of operator</typeparam>
    public class FilterAttribute<T, U>
    {
        /// <summary>
        /// Gets or sets the value
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public T Value { get; set; }

        /// <summary>
        /// Gets or sets the value
        /// </summary>
        /// <value>
        /// The operator.
        /// </value>
        public U Operator { get; set; }
    }
}