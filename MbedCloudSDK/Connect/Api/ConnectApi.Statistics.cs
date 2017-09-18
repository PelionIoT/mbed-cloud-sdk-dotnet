// <copyright file="ConnectApi.Statistics.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api
{
    using System.Collections.Generic;
    using MbedCloudSDK.Connect.Model.Metric;
    using MbedCloudSDK.Exceptions;

    public partial class ConnectApi
    {
        /// <summary>
        /// Get Metrics.
        /// </summary>
        /// <param name="options">Query options.</param>
        /// <returns>List of statistics data queried using options.</returns>
        /// <exception cref="CloudApiException">Error while getting statistics.</exception>
        /// <example>
        /// This sample shows how to call the <see cref="ListMetrics"/> method.
        /// <code>
        /// class TestClass
        /// {
        ///     static int Main()
        ///     {
        ///         Config config = new Config(apiKey);
        ///         config.Host = "https://lab-api.mbedcloudintegration.net";
        ///         ConnectApi api = new ConnectApi(config);
        ///         try {
        ///             var metricsData = api.GetMetrics();
        ///             foreach(var data in metricsData)
        ///             {
        ///                 Console.WriteLine(data);
        ///             }
        ///         }
        ///         catch (CloudApiException ex) {
        ///             Console.WriteLine(ex.Message);
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        public List<Metric> ListMetrics(MetricQueryOptions options = null)
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
                var response = statisticsApi.V3MetricsGet(
                    include: options.Include,
                    interval: options.Interval,
                    start: options.Start,
                    end: options.End,
                    period: options.Period,
                    limit: options.Limit,
                    after: options.After,
                    order: options.Order);
                var statisticsList = new List<Metric>();
                foreach (var data in response.Data)
                {
                    statisticsList.Add(Metric.Map(data));
                }

                return statisticsList;
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get account-specific metrics.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public List<Metric> GetAccountMetrics(MetricQueryOptions options = null)
        {
            if (options == null)
            {
                options = new MetricQueryOptions();
            }

            try
            {
                var statisticsList = new List<Metric>();
                foreach (var data in accountApi.V3MetricsGet(include: options.Include, interval: options.Interval, start: options.Start, end: options.End, period: options.Period).Data)
                {
                    statisticsList.Add(Metric.Map(data));
                }

                return statisticsList;
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}