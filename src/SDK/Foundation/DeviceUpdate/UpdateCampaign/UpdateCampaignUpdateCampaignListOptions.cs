// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="UpdateCampaignUpdateCampaignListOptions.cs" company="Arm">
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
    /// UpdateCampaignUpdateCampaignListOptions
    /// </summary>
    public class UpdateCampaignUpdateCampaignListOptions : QueryOptions, IUpdateCampaignUpdateCampaignListOptions
    {
        public UpdateCampaignUpdateCampaignListOptions()
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

        public UpdateCampaignUpdateCampaignListOptions CreatedAtIn(params DateTime[] value)
        {
            this.Filter.AddFilterItem("created_at", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions CreatedAtNotIn(params DateTime[] value)
        {
            this.Filter.AddFilterItem("created_at", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions CreatedAtLessThan(DateTime value)
        {
            this.Filter.AddFilterItem("created_at", new FilterItem(value, FilterOperator.LessThan));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions CreatedAtGreaterThan(DateTime value)
        {
            this.Filter.AddFilterItem("created_at", new FilterItem(value, FilterOperator.GreaterThan));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions DescriptionEqualTo(string value)
        {
            this.Filter.AddFilterItem("description", new FilterItem(value, FilterOperator.Equals));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions DescriptionNotEqualTo(string value)
        {
            this.Filter.AddFilterItem("description", new FilterItem(value, FilterOperator.NotEqual));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions DescriptionIn(params string[] value)
        {
            this.Filter.AddFilterItem("description", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions DescriptionNotIn(params string[] value)
        {
            this.Filter.AddFilterItem("description", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions DeviceFilterEqualTo(string value)
        {
            this.Filter.AddFilterItem("device_filter", new FilterItem(value, FilterOperator.Equals));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions DeviceFilterNotEqualTo(string value)
        {
            this.Filter.AddFilterItem("device_filter", new FilterItem(value, FilterOperator.NotEqual));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions DeviceFilterIn(params string[] value)
        {
            this.Filter.AddFilterItem("device_filter", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions DeviceFilterNotIn(params string[] value)
        {
            this.Filter.AddFilterItem("device_filter", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions FinishedIn(params DateTime[] value)
        {
            this.Filter.AddFilterItem("finished", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions FinishedNotIn(params DateTime[] value)
        {
            this.Filter.AddFilterItem("finished", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions FinishedLessThan(DateTime value)
        {
            this.Filter.AddFilterItem("finished", new FilterItem(value, FilterOperator.LessThan));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions FinishedGreaterThan(DateTime value)
        {
            this.Filter.AddFilterItem("finished", new FilterItem(value, FilterOperator.GreaterThan));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions IdEqualTo(string value)
        {
            this.Filter.AddFilterItem("id", new FilterItem(value, FilterOperator.Equals));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions IdNotEqualTo(string value)
        {
            this.Filter.AddFilterItem("id", new FilterItem(value, FilterOperator.NotEqual));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions IdIn(params string[] value)
        {
            this.Filter.AddFilterItem("id", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions IdNotIn(params string[] value)
        {
            this.Filter.AddFilterItem("id", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions NameEqualTo(string value)
        {
            this.Filter.AddFilterItem("name", new FilterItem(value, FilterOperator.Equals));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions NameNotEqualTo(string value)
        {
            this.Filter.AddFilterItem("name", new FilterItem(value, FilterOperator.NotEqual));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions NameIn(params string[] value)
        {
            this.Filter.AddFilterItem("name", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions NameNotIn(params string[] value)
        {
            this.Filter.AddFilterItem("name", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions RootManifestIdEqualTo(string value)
        {
            this.Filter.AddFilterItem("root_manifest_id", new FilterItem(value, FilterOperator.Equals));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions RootManifestIdNotEqualTo(string value)
        {
            this.Filter.AddFilterItem("root_manifest_id", new FilterItem(value, FilterOperator.NotEqual));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions RootManifestIdIn(params string[] value)
        {
            this.Filter.AddFilterItem("root_manifest_id", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions RootManifestIdNotIn(params string[] value)
        {
            this.Filter.AddFilterItem("root_manifest_id", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions StartedAtIn(params DateTime[] value)
        {
            this.Filter.AddFilterItem("started_at", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions StartedAtNotIn(params DateTime[] value)
        {
            this.Filter.AddFilterItem("started_at", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions StartedAtLessThan(DateTime value)
        {
            this.Filter.AddFilterItem("started_at", new FilterItem(value, FilterOperator.LessThan));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions StartedAtGreaterThan(DateTime value)
        {
            this.Filter.AddFilterItem("started_at", new FilterItem(value, FilterOperator.GreaterThan));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions StateEqualTo(string value)
        {
            this.Filter.AddFilterItem("state", new FilterItem(value, FilterOperator.Equals));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions StateNotEqualTo(string value)
        {
            this.Filter.AddFilterItem("state", new FilterItem(value, FilterOperator.NotEqual));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions StateIn(params string[] value)
        {
            this.Filter.AddFilterItem("state", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions StateNotIn(params string[] value)
        {
            this.Filter.AddFilterItem("state", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions UpdatedAtIn(params DateTime[] value)
        {
            this.Filter.AddFilterItem("updated_at", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions UpdatedAtNotIn(params DateTime[] value)
        {
            this.Filter.AddFilterItem("updated_at", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions UpdatedAtLessThan(DateTime value)
        {
            this.Filter.AddFilterItem("updated_at", new FilterItem(value, FilterOperator.LessThan));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions UpdatedAtGreaterThan(DateTime value)
        {
            this.Filter.AddFilterItem("updated_at", new FilterItem(value, FilterOperator.GreaterThan));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions WhenIn(params DateTime[] value)
        {
            this.Filter.AddFilterItem("when", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions WhenNotIn(params DateTime[] value)
        {
            this.Filter.AddFilterItem("when", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions WhenLessThan(DateTime value)
        {
            this.Filter.AddFilterItem("when", new FilterItem(value, FilterOperator.LessThan));
            return this;
        }

        public UpdateCampaignUpdateCampaignListOptions WhenGreaterThan(DateTime value)
        {
            this.Filter.AddFilterItem("when", new FilterItem(value, FilterOperator.GreaterThan));
            return this;
        }
    }
}