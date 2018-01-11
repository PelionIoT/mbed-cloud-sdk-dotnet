// <copyright file="MetricQueryOptions.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Model.Metric
{
    using System;
    using MbedCloudSDK.Common.Query;

    /// <summary>
    /// Metric query options
    /// </summary>
    public class MetricQueryOptions : QueryOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricQueryOptions"/> class.
        /// </summary>
        public MetricQueryOptions()
        {
            Include = "transactions,bootstraps_successful,bootstraps_pending,bootstraps_failed,connect_rest_api_success,connect_rest_api_error,device_proxy_request_success,device_proxy_request_error,device_subscription_request_success,device_subscription_request_error,device_observations";
            Interval = "1d";
        }

        /// <summary>
        /// Gets or sets uTC time/year/date in RFC3339 format. Fetch data with timestamp greater than or equal to this value. Sample values: 20170207T092056990Z / 2017-02-07T09:20:56.990Z / 2017 / 20170207. The parameter is not mandatory, if period specified.
        /// </summary>
        public DateTime? Start { get; set; }

        /// <summary>
        /// Gets or sets UTC time / year / date in RFC3339 format. Fetch data with timestamp less than this value.Sample values: 20170207T092056990Z / 2017-02-07T09:20:56.990Z / 2017 / 20170207.The parameter is not mandatory, if period specified.
        /// </summary>
        public DateTime? End { get; set; }

        /// <summary>
        /// Gets or sets period. Fetch data for the period in days, weeks, hours or minutes. Sample values: 2h, 3w, 4d, 5m. The parameter is not mandatory, if start and end time are specified.
        /// </summary>
        public string Period { get; set; }

        /// <summary>
        /// Gets or sets group data by this interval in days, weeks, hours or minutes. Sample values: 2h, 3w, 4d, 5m.
        /// </summary>
        public string Interval { get; set; }
    }
}
