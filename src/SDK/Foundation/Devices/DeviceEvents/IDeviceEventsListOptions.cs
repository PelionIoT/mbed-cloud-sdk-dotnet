// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="IDeviceEventsListOptions.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation
{
    using Mbed.Cloud.Common;
    using Mbed.Cloud.Common.Filters;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// DeviceEventsListOptions
    /// </summary>
    public interface IDeviceEventsListOptions : IQueryOptions
    {
        /// <summary>
        /// Filter object
        /// </summary>
        Filter Filter
        {
            get;
            set;
        }

        DeviceEventsListOptions DateTimeIn(params DateTime[] value);
        DeviceEventsListOptions DateTimeNotIn(params DateTime[] value);
        DeviceEventsListOptions DateTimeLessThan(DateTime value);
        DeviceEventsListOptions DateTimeGreaterThan(DateTime value);
        DeviceEventsListOptions DescriptionEqualTo(string value);
        DeviceEventsListOptions DescriptionNotEqualTo(string value);
        DeviceEventsListOptions DescriptionIn(params string[] value);
        DeviceEventsListOptions DescriptionNotIn(params string[] value);
        DeviceEventsListOptions IdEqualTo(string value);
        DeviceEventsListOptions IdNotEqualTo(string value);
        DeviceEventsListOptions IdIn(params string[] value);
        DeviceEventsListOptions IdNotIn(params string[] value);
        DeviceEventsListOptions DeviceIdEqualTo(string value);
        DeviceEventsListOptions DeviceIdNotEqualTo(string value);
        DeviceEventsListOptions DeviceIdIn(params string[] value);
        DeviceEventsListOptions DeviceIdNotIn(params string[] value);
        DeviceEventsListOptions EventTypeEqualTo(string value);
        DeviceEventsListOptions EventTypeNotEqualTo(string value);
        DeviceEventsListOptions EventTypeIn(params string[] value);
        DeviceEventsListOptions EventTypeNotIn(params string[] value);
        DeviceEventsListOptions StateChangeEqualTo(bool value);
        DeviceEventsListOptions StateChangeNotEqualTo(bool value);
    }
}