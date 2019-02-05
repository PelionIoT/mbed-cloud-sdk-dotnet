// <copyright file="ConnectApi.Statistics.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Mbed.Cloud.Foundation.Common;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Connect.Model.Metric;
    using MbedCloudSDK.Exceptions;

    /// <summary>
    /// Connect Api
    /// </summary>
    public partial class ConnectApi
    {
        /// <summary>
        /// Get Metrics.
        /// </summary>
        /// <param name="options">Query options.</param>
        /// <returns>List of statistics data queried using options.</returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// This sample shows how to call the <see cref="ListMetrics"/> method.
        /// <code>
        /// try
        /// {
        ///     var options = new MetricQueryOptions()
        ///     {
        ///         Interval = "1d",
        ///         Period = "30d",
        ///     };
        ///     var metricsData = api.ListMetrics(options);
        ///     foreach(var data in metricsData)
        ///     {
        ///         Console.WriteLine(data);
        ///     }
        /// }
        /// catch (CloudApiException) {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public PaginatedResponse<MetricQueryOptions, Metric> ListMetrics(MetricQueryOptions options = null)
        {
            if (options == null)
            {
                options = new MetricQueryOptions();
            }

            if (string.IsNullOrEmpty(options.Include))
            {
                options.Include = "transactions,bootstraps_successful,bootstraps_pending,bootstraps_failed,connect_rest_api_success,connect_rest_api_error,device_proxy_request_success,device_proxy_request_error,device_subscription_request_success,device_subscription_request_error,device_observations";
            }

            try
            {
                return new PaginatedResponse<MetricQueryOptions, Metric>(ListMetricsFunc, options);
            }
            catch (CloudApiException)
            {
                throw;
            }
        }

        private async Task<ResponsePage<Metric>> ListMetricsFunc(MetricQueryOptions options)
        {
            try
            {
                var resp = await StatisticsApi.V3MetricsGetAsync(
                    include: options.Include,
                        interval: options.Interval,
                        start: options.Start,
                        end: options.End,
                        period: options.Period,
                        limit: options.Limit,
                        after: options.After,
                        order: options.Order);
                var responsePage = new ResponsePage<Metric>(after: resp.After, hasMore: resp.HasMore, totalCount: resp.TotalCount);
                responsePage.MapData<statistics.Model.Metric>(resp.Data, Metric.Map);
                return responsePage;
            }
            catch (statistics.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}