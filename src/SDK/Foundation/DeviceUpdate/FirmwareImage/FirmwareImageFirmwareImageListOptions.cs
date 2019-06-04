// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="FirmwareImageFirmwareImageListOptions.cs" company="Arm">
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
    /// FirmwareImageFirmwareImageListOptions
    /// </summary>
    public class FirmwareImageFirmwareImageListOptions : QueryOptions, IFirmwareImageFirmwareImageListOptions
    {
        public FirmwareImageFirmwareImageListOptions()
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

        public FirmwareImageFirmwareImageListOptions CreatedAtIn(params DateTime[] value)
        {
            this.Filter.AddFilterItem("created_at", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions CreatedAtNotIn(params DateTime[] value)
        {
            this.Filter.AddFilterItem("created_at", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions CreatedAtLessThan(DateTime value)
        {
            this.Filter.AddFilterItem("created_at", new FilterItem(value, FilterOperator.LessThan));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions CreatedAtGreaterThan(DateTime value)
        {
            this.Filter.AddFilterItem("created_at", new FilterItem(value, FilterOperator.GreaterThan));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions DatafileUrlEqualTo(string value)
        {
            this.Filter.AddFilterItem("datafile_url", new FilterItem(value, FilterOperator.Equals));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions DatafileUrlNotEqualTo(string value)
        {
            this.Filter.AddFilterItem("datafile_url", new FilterItem(value, FilterOperator.NotEqual));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions DatafileUrlIn(params string[] value)
        {
            this.Filter.AddFilterItem("datafile_url", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions DatafileUrlNotIn(params string[] value)
        {
            this.Filter.AddFilterItem("datafile_url", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions DatafileChecksumEqualTo(string value)
        {
            this.Filter.AddFilterItem("datafile_checksum", new FilterItem(value, FilterOperator.Equals));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions DatafileChecksumNotEqualTo(string value)
        {
            this.Filter.AddFilterItem("datafile_checksum", new FilterItem(value, FilterOperator.NotEqual));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions DatafileChecksumIn(params string[] value)
        {
            this.Filter.AddFilterItem("datafile_checksum", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions DatafileChecksumNotIn(params string[] value)
        {
            this.Filter.AddFilterItem("datafile_checksum", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions DatafileSizeEqualTo(long value)
        {
            this.Filter.AddFilterItem("datafile_size", new FilterItem(value, FilterOperator.Equals));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions DatafileSizeNotEqualTo(long value)
        {
            this.Filter.AddFilterItem("datafile_size", new FilterItem(value, FilterOperator.NotEqual));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions DatafileSizeIn(params long[] value)
        {
            this.Filter.AddFilterItem("datafile_size", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions DatafileSizeNotIn(params long[] value)
        {
            this.Filter.AddFilterItem("datafile_size", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions DescriptionEqualTo(string value)
        {
            this.Filter.AddFilterItem("description", new FilterItem(value, FilterOperator.Equals));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions DescriptionNotEqualTo(string value)
        {
            this.Filter.AddFilterItem("description", new FilterItem(value, FilterOperator.NotEqual));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions DescriptionIn(params string[] value)
        {
            this.Filter.AddFilterItem("description", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions DescriptionNotIn(params string[] value)
        {
            this.Filter.AddFilterItem("description", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions IdEqualTo(string value)
        {
            this.Filter.AddFilterItem("id", new FilterItem(value, FilterOperator.Equals));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions IdNotEqualTo(string value)
        {
            this.Filter.AddFilterItem("id", new FilterItem(value, FilterOperator.NotEqual));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions IdIn(params string[] value)
        {
            this.Filter.AddFilterItem("id", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions IdNotIn(params string[] value)
        {
            this.Filter.AddFilterItem("id", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions NameEqualTo(string value)
        {
            this.Filter.AddFilterItem("name", new FilterItem(value, FilterOperator.Equals));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions NameNotEqualTo(string value)
        {
            this.Filter.AddFilterItem("name", new FilterItem(value, FilterOperator.NotEqual));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions NameIn(params string[] value)
        {
            this.Filter.AddFilterItem("name", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions NameNotIn(params string[] value)
        {
            this.Filter.AddFilterItem("name", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions UpdatedAtIn(params DateTime[] value)
        {
            this.Filter.AddFilterItem("updated_at", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions UpdatedAtNotIn(params DateTime[] value)
        {
            this.Filter.AddFilterItem("updated_at", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions UpdatedAtLessThan(DateTime value)
        {
            this.Filter.AddFilterItem("updated_at", new FilterItem(value, FilterOperator.LessThan));
            return this;
        }

        public FirmwareImageFirmwareImageListOptions UpdatedAtGreaterThan(DateTime value)
        {
            this.Filter.AddFilterItem("updated_at", new FilterItem(value, FilterOperator.GreaterThan));
            return this;
        }
    }
}