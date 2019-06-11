// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="IDeviceGroupListOptions.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation
{
    using Mbed.Cloud.Common;
    using Mbed.Cloud.Common.Filters;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// DeviceGroupListOptions
    /// </summary>
    public interface IDeviceGroupListOptions : IQueryOptions
    {
        /// <summary>
        /// Filter object
        /// </summary>
        Filter Filter
        {
            get;
            set;
        }

        DeviceGroupListOptions IdEqualTo(string value);
        DeviceGroupListOptions IdNotEqualTo(string value);
        DeviceGroupListOptions IdIn(params string[] value);
        DeviceGroupListOptions IdNotIn(params string[] value);
        DeviceGroupListOptions DevicesCountEqualTo(int value);
        DeviceGroupListOptions DevicesCountNotEqualTo(int value);
        DeviceGroupListOptions DevicesCountIn(params int[] value);
        DeviceGroupListOptions DevicesCountNotIn(params int[] value);
        DeviceGroupListOptions DevicesCountLessThan(int value);
        DeviceGroupListOptions DevicesCountGreaterThan(int value);
        DeviceGroupListOptions NameEqualTo(string value);
        DeviceGroupListOptions NameNotEqualTo(string value);
        DeviceGroupListOptions NameIn(params string[] value);
        DeviceGroupListOptions NameNotIn(params string[] value);
        DeviceGroupListOptions CreatedAtIn(params DateTime[] value);
        DeviceGroupListOptions CreatedAtNotIn(params DateTime[] value);
        DeviceGroupListOptions CreatedAtLessThan(DateTime value);
        DeviceGroupListOptions CreatedAtGreaterThan(DateTime value);
        DeviceGroupListOptions UpdatedAtIn(params DateTime[] value);
        DeviceGroupListOptions UpdatedAtNotIn(params DateTime[] value);
        DeviceGroupListOptions UpdatedAtLessThan(DateTime value);
        DeviceGroupListOptions UpdatedAtGreaterThan(DateTime value);
    }
}