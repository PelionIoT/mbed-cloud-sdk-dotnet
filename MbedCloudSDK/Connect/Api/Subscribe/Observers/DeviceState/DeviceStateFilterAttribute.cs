// <copyright file="DeviceStateFilterAttribute.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe.Observers.DeviceState
{
    using MbedCloudSDK.Connect.Api.Subscribe.Filters;

    /// <summary>
    /// The device state filter attribute
    /// </summary>
    public class DeviceStateFilterAttribute : FilterAttribute<string, DeviceStateFilterOperator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceStateFilterAttribute"/> class.
        /// </summary>
        /// <param name="value">value of filter attribute</param>
        /// <param name="filterOperator">operator</param>
        public DeviceStateFilterAttribute(string value, DeviceStateFilterOperator filterOperator = DeviceStateFilterOperator.Equals)
        {
            Value = value;
            Operator = filterOperator;
        }
    }
}