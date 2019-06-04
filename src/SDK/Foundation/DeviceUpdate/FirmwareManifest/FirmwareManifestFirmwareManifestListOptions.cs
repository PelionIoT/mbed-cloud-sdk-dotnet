// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="FirmwareManifestFirmwareManifestListOptions.cs" company="Arm">
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
    /// FirmwareManifestFirmwareManifestListOptions
    /// </summary>
    public class FirmwareManifestFirmwareManifestListOptions : QueryOptions, IFirmwareManifestFirmwareManifestListOptions
    {
        public FirmwareManifestFirmwareManifestListOptions()
        {
            Filter = new Filter();
        }

        /// <summary>
        /// Filter object
        /// </summary>
        public Filter Filter
        {
            get;
            set;
        }

        public FirmwareManifestFirmwareManifestListOptions CreatedAtIn(params DateTime[] value)
        {
            this.Filter.AddFilterItem("created_at", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions CreatedAtNotIn(params DateTime[] value)
        {
            this.Filter.AddFilterItem("created_at", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions CreatedAtLessThan(DateTime value)
        {
            this.Filter.AddFilterItem("created_at", new FilterItem(value, FilterOperator.LessThan));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions CreatedAtGreaterThan(DateTime value)
        {
            this.Filter.AddFilterItem("created_at", new FilterItem(value, FilterOperator.GreaterThan));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions DatafileUrlEqualTo(string value)
        {
            this.Filter.AddFilterItem("datafile_url", new FilterItem(value, FilterOperator.Equals));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions DatafileUrlNotEqualTo(string value)
        {
            this.Filter.AddFilterItem("datafile_url", new FilterItem(value, FilterOperator.NotEqual));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions DatafileUrlIn(params string[] value)
        {
            this.Filter.AddFilterItem("datafile_url", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions DatafileUrlNotIn(params string[] value)
        {
            this.Filter.AddFilterItem("datafile_url", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions DatafileSizeEqualTo(long value)
        {
            this.Filter.AddFilterItem("datafile_size", new FilterItem(value, FilterOperator.Equals));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions DatafileSizeNotEqualTo(long value)
        {
            this.Filter.AddFilterItem("datafile_size", new FilterItem(value, FilterOperator.NotEqual));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions DatafileSizeIn(params long[] value)
        {
            this.Filter.AddFilterItem("datafile_size", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions DatafileSizeNotIn(params long[] value)
        {
            this.Filter.AddFilterItem("datafile_size", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions DescriptionEqualTo(string value)
        {
            this.Filter.AddFilterItem("description", new FilterItem(value, FilterOperator.Equals));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions DescriptionNotEqualTo(string value)
        {
            this.Filter.AddFilterItem("description", new FilterItem(value, FilterOperator.NotEqual));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions DescriptionIn(params string[] value)
        {
            this.Filter.AddFilterItem("description", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions DescriptionNotIn(params string[] value)
        {
            this.Filter.AddFilterItem("description", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions DeviceClassEqualTo(string value)
        {
            this.Filter.AddFilterItem("device_class", new FilterItem(value, FilterOperator.Equals));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions DeviceClassNotEqualTo(string value)
        {
            this.Filter.AddFilterItem("device_class", new FilterItem(value, FilterOperator.NotEqual));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions DeviceClassIn(params string[] value)
        {
            this.Filter.AddFilterItem("device_class", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions DeviceClassNotIn(params string[] value)
        {
            this.Filter.AddFilterItem("device_class", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions IdEqualTo(string value)
        {
            this.Filter.AddFilterItem("id", new FilterItem(value, FilterOperator.Equals));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions IdNotEqualTo(string value)
        {
            this.Filter.AddFilterItem("id", new FilterItem(value, FilterOperator.NotEqual));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions IdIn(params string[] value)
        {
            this.Filter.AddFilterItem("id", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions IdNotIn(params string[] value)
        {
            this.Filter.AddFilterItem("id", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions NameEqualTo(string value)
        {
            this.Filter.AddFilterItem("name", new FilterItem(value, FilterOperator.Equals));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions NameNotEqualTo(string value)
        {
            this.Filter.AddFilterItem("name", new FilterItem(value, FilterOperator.NotEqual));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions NameIn(params string[] value)
        {
            this.Filter.AddFilterItem("name", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions NameNotIn(params string[] value)
        {
            this.Filter.AddFilterItem("name", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions TimestampIn(params DateTime[] value)
        {
            this.Filter.AddFilterItem("timestamp", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions TimestampNotIn(params DateTime[] value)
        {
            this.Filter.AddFilterItem("timestamp", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions TimestampLessThan(DateTime value)
        {
            this.Filter.AddFilterItem("timestamp", new FilterItem(value, FilterOperator.LessThan));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions TimestampGreaterThan(DateTime value)
        {
            this.Filter.AddFilterItem("timestamp", new FilterItem(value, FilterOperator.GreaterThan));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions UpdatedAtIn(params DateTime[] value)
        {
            this.Filter.AddFilterItem("updated_at", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions UpdatedAtNotIn(params DateTime[] value)
        {
            this.Filter.AddFilterItem("updated_at", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions UpdatedAtLessThan(DateTime value)
        {
            this.Filter.AddFilterItem("updated_at", new FilterItem(value, FilterOperator.LessThan));
            return this;
        }

        public FirmwareManifestFirmwareManifestListOptions UpdatedAtGreaterThan(DateTime value)
        {
            this.Filter.AddFilterItem("updated_at", new FilterItem(value, FilterOperator.GreaterThan));
            return this;
        }
    }
}