// <copyright file="MetricQueryOptions.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System;

namespace MbedCloudSDK.Connect.Model.Metric
{
    /// <summary>
    /// Metric query options
    /// </summary>
    public class MetricQueryOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricQueryOptions"/> class.
        /// </summary>
        public MetricQueryOptions()
        {
            Include = "transactions,bootstraps_successful,bootstraps_pending,bootstraps_failed,connect_rest_api_success,connect_rest_api_error,device_proxy_request_success,device_proxy_request_error,device_subscription_request_success,device_subscription_request_error,device_observations";
            Interval = "1d";
            Period = "1m";
        }

        /// <summary>
        /// Gets or sets comma-separated list of requested metrics.Supported values are bootstraps_successful, bootstraps_failed, bootstraps_pending, bootstrap_certificate_create, bootstrap_certificate_delete, connector_certificate_create, connector_certificate_delete, bootstrap_credentials_get, bootstrap_full_credentials_get, connector_credentials_get, connector_full_credentials_get, connector_ca_rest_api_count, connector_ca_rest_api_error_count
        /// </summary>
        public string Include { get; set; }

        /// <summary>
        /// Gets or sets uTC time/year/date in RFC3339 format. Fetch data with timestamp greater than or equal to this value. Sample values: 20170207T092056990Z / 2017-02-07T09:20:56.990Z / 2017 / 20170207. The parameter is not mandatory, if period specified.
        /// </summary>
        public DateTime? Start { get; set; }

        /// <summary>
        /// Gets or sets uTC time / year / date in RFC3339 format. Fetch data with timestamp less than this value.Sample values: 20170207T092056990Z / 2017-02-07T09:20:56.990Z / 2017 / 20170207.The parameter is not mandatory, if period specified.
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

        /// <summary>
        /// Gets or sets the number of results to return. Default value is 50, minimum value is 2 and maximum value is 1000.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Gets or sets the metric ID after which to start fetching.
        /// </summary>
        public string After { get; set; }

        /// <summary>
        /// Gets or sets the order of the records to return. Available values are ASC and DESC. The default value is ASC.
        /// </summary>
        public string Order { get; set; }
    }
}