using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using device_query_service.Model;
using mbedCloudSDK.Common;
using mbedCloudSDK.Exceptions;
using RestSharp;
using mbedCloudSDK.Devices.Model;
using mbedCloudSDK.Devices.Model.Device;
using mbedCloudSDK.Devices.Model.Resource;
using mbedCloudSDK.Devices.Model.Query;

namespace mbedCloudSDK.Devices.Api
{
    /// <summary>
    /// Exposing functionality from the following underlying services:
    /// - Connector / mDS
    /// - Device query service
    /// - Device catalog
    /// </summary>
    public partial class DevicesApi : BaseApi
    {

        #region Variables

        private Task longPollingTask;
        private CancellationTokenSource cancellationToken;

        /// <summary>
        /// Resources that are currently subscribed.
        /// </summary>
        public static Dictionary<String, Resource> resourceSubscribtions = new Dictionary<string, Resource>();

        /// <summary>
        /// Responses to async requests.
        /// </summary>
        public static Dictionary<String, AsyncProducerConsumerCollection<String>> asyncResponses = new Dictionary<string, AsyncProducerConsumerCollection<String>>();

        #endregion

        #region Contructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.Devices.Devices"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
        public DevicesApi(Config config) : base(config)
        {
            cancellationToken = new CancellationTokenSource();
            longPollingTask = new Task(new Action(LongPolling), cancellationToken.Token, TaskCreationOptions.LongRunning);
            resourceSubscribtions = new Dictionary<string, Resource>();
        }

        #endregion

        #region Utils

        private string FixedPath(string path)
        {
            if (path.StartsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                path = path.Substring(1);
            }
            return path;
        }

        #endregion
    }
}
