using mbedCloudSDK.Common;
using mbedCloudSDK.Common.Query;
using mbedCloudSDK.Exceptions;
using mbedCloudSDK.Statistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Statistics.Api
{
    /// <summary>
    /// Exposing functionality to:
    /// - Manage Statistics API
    /// </summary>
    class StatisticsApi : BaseApi
    {
        private statistics.Api.StatisticsApi statisticsApi;
        private string auth;

        public StatisticsApi(Config config) : base(config)
        {
            this.auth = string.Format("{0} {1}", config.AuthorizationPrefix, config.ApiKey);

            statisticsApi = new statistics.Api.StatisticsApi(config.Host);
            statisticsApi.Configuration.ApiKey["Authorization"] = config.ApiKey;
            statisticsApi.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
        }

        /// <summary>
        /// Get Statistics Data.
        /// </summary>
        /// <param name="options">Query options.</param>
        /// <returns>List of statistics data queried using options.</returns>
        /// <exception cref="CloudApiException">Error while getting statistics.</exception>
        /// <example> 
        /// This sample shows how to call the <see cref="GetStatistics"/> method.
        /// <code>
        /// class TestClass 
        /// {
        ///     static int Main() 
        ///     {
        ///         Config config = new Config(apiKey);
        ///         config.Host = "https://lab-api.mbedcloudintegration.net";
        ///         StatisticsApi api = new StatisticsApi(config);        
        ///         try {
        ///             var statisticsData = api.GetStatistics();
        ///             foreach(var data in statisticsData) 
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
        public List<StatisticsData> GetStatistics(StatisticsQueryOptions options = null)
        {
            if (options == null)
            {
                options = new StatisticsQueryOptions();
            }
            try
            {
                var response = statisticsApi.V3MetricsGet(options.Include, options.Start, options.End, options.Period, options.Interval, this.auth);
                List<StatisticsData> statisticsList = new List<StatisticsData>();
                foreach(var data in response)
                {
                    statisticsList.Add(StatisticsData.Map(data));
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
