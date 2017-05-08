using mbedCloudSDK.Connect.Model.Metric;
using mbedCloudSDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Connect.Api
{
    public partial class ConnectApi
    {
        /// <summary>
        /// Get Metrics.
        /// </summary>
        /// <param name="options">Query options.</param>
        /// <returns>List of statistics data queried using options.</returns>
        /// <exception cref="CloudApiException">Error while getting statistics.</exception>
        /// <example> 
        /// This sample shows how to call the <see cref="GetMetrics"/> method.
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
        public List<Metric> GetMetrics(MetricQueryOptions options = null)
        {
            if (options == null)
            {
                options = new MetricQueryOptions();
            }
            try
            {
                var response = statisticsApi.V3MetricsGet(options.Include, options.Start, options.End, options.Period, options.Interval, this.auth);
                List<Metric> statisticsList = new List<Metric>();
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
                var response = this.accountApi.V3MetricsGet(options.Include, options.Start, options.End, options.Period, options.Interval, this.auth);
                List<Metric> statisticsList = new List<Metric>();
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
    }
}
