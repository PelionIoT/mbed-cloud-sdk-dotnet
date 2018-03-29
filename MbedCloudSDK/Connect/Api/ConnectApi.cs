// <copyright file="ConnectApi.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using device_directory.Client;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Connect.Model.ConnectedDevice;
    using MbedCloudSDK.Connect.Model.Notifications;
    using MbedCloudSDK.Connect.Model.Resource;
    using mds.Api;

    /// <summary>
    /// Connect Api
    /// <example>
    /// This API is intialized with a <see cref="Config"/> object.
    /// <code>
    /// using MbedCloudSDK.Common;
    /// var config = new config(apiKey);
    /// var connectApi = new ConnectApi(config);
    /// </code>
    /// </example>
    /// <example>
    /// Some methods require a notification channel to be set up before they will work.
    /// <code>
    /// connectApi.StartNotifications();
    /// var resource = connectApi.GetResourceValue("", "5001/0/1");
    /// connectApi.StopNotifications();
    /// </code>
    /// </example>
    /// </summary>
    public partial class ConnectApi : BaseApi, IDisposable
    {
        private Task notificationTask;
        private CancellationTokenSource cancellationToken;
        internal device_directory.Api.DefaultApi deviceDirectoryApi;
        internal statistics.Api.StatisticsApi statisticsApi;
        internal EndpointsApi endpointsApi;
        internal statistics.Api.AccountApi accountApi;
        internal SubscriptionsApi subscriptionsApi;
        internal ResourcesApi resourcesApi;
        private string auth;
        internal NotificationsApi notificationsApi;
        internal DeviceRequestsApi deviceRequestsApi;
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectApi"/> class.
        /// </summary>
        /// <param name="config"><see cref="Config"/></param>
        public ConnectApi(Config config)
            : base(config)
        {
            ResourceSubscribtions = new Dictionary<string, Resource>();
            SetUpApi(config);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectApi"/> class.
        /// </summary>
        /// <param name="config"><see cref="Config"/></param>
        internal ConnectApi(Config config, statistics.Client.Configuration statsConfig = null, mds.Client.Configuration mdsConfig = null, device_directory.Client.Configuration deviceConfig = null)
            : base(config)
        {
            ResourceSubscribtions = new Dictionary<string, Resource>();
            SetUpApi(config, statsConfig, mdsConfig, deviceConfig);
        }

        /// <summary>
        /// Gets async responses
        /// </summary>
        public Dictionary<string, AsyncProducerConsumerCollection<string>> AsyncResponses { get; } = new Dictionary<string, AsyncProducerConsumerCollection<string>>();

        /// <summary>
        /// Gets resource Subscriptions
        /// </summary>
        public Dictionary<string, Resource> ResourceSubscribtions { get; } = new Dictionary<string, Resource>();

        /// <summary>
        /// Gets NotificationQueue
        /// </summary>
        public Dictionary<string, AsyncProducerConsumerCollection<string>> NotificationQueue { get; } = new Dictionary<string, AsyncProducerConsumerCollection<string>>();

        /// <summary>
        /// Gets or sets the SubscribeManager
        /// </summary>
        public MbedCloudSDK.Connect.Api.Subscribe.Subscribe Subscribe { get; set; }

        /// <summary>
        /// Get meta data for the last Mbed Cloud API call
        /// </summary>
        /// <returns><see cref="ApiMetadata"/></returns>
        public static ApiMetadata GetLastApiMetadata()
        {
            var lastMds = mds.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault()?.Headers?.Where(m => m.Name == "Date")?.Select(d => DateTime.Parse(d.Value.ToString()))?.FirstOrDefault();
            var lastStats = statistics.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault()?.Headers?.Where(m => m.Name == "Date")?.Select(d => DateTime.Parse(d.Value.ToString()))?.FirstOrDefault();
            if (Nullable.Compare(lastMds, lastStats) > 0)
            {
                return ApiMetadata.Map(mds.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault());
            }
            else
            {
                return ApiMetadata.Map(statistics.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault());
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Virtual dispose
        /// </summary>
        /// <param name="disposing">dispose</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            disposed = true;
            if (disposing)
            {
                cancellationToken?.Dispose();
            }
        }

        /// <summary>
        /// Throw if disposed
        /// </summary>
        protected virtual void ThrowIfDisposed()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }

        private void SetUpApi(Config config, statistics.Client.Configuration statsConfig = null, mds.Client.Configuration mdsConfig = null, device_directory.Client.Configuration deviceConfig = null)
        {
            var dateFormat = "yyyy-MM-dd'T'HH:mm:ss.fffZ";
            auth = string.Format("{0} {1}", config.AuthorizationPrefix, config.ApiKey);

            if (statsConfig == null)
            {
                statsConfig = new statistics.Client.Configuration
                {
                    BasePath = config.Host,
                    DateTimeFormat = dateFormat,
                    UserAgent = UserAgent,
                };
                statsConfig.AddApiKey("Authorization", config.ApiKey);
                statsConfig.AddApiKeyPrefix("Authorization", config.AuthorizationPrefix);
                statsConfig.CreateApiClient();
            }

            if (mdsConfig == null)
            {
                mdsConfig = new mds.Client.Configuration
                {
                    BasePath = config.Host,
                    DateTimeFormat = dateFormat,
                    UserAgent = UserAgent,
                };
                mdsConfig.AddApiKey("Authorization", config.ApiKey);
                mdsConfig.AddApiKeyPrefix("Authorization", config.AuthorizationPrefix);
                mdsConfig.CreateApiClient();
            }

            if (deviceConfig == null)
            {
                deviceConfig = new device_directory.Client.Configuration
                {
                    BasePath = config.Host,
                    DateTimeFormat = dateFormat,
                    UserAgent = UserAgent,
                };
                deviceConfig.AddApiKey("Authorization", config.ApiKey);
                deviceConfig.AddApiKeyPrefix("Authorization", config.AuthorizationPrefix);
                deviceConfig.CreateApiClient();
            }

            deviceDirectoryApi = new device_directory.Api.DefaultApi(deviceConfig);
            statisticsApi = new statistics.Api.StatisticsApi(statsConfig);
            subscriptionsApi = new SubscriptionsApi(mdsConfig);
            resourcesApi = new ResourcesApi(mdsConfig);
            endpointsApi = new EndpointsApi(mdsConfig);
            accountApi = new statistics.Api.AccountApi(statsConfig);
            notificationsApi = new NotificationsApi(mdsConfig);
            deviceRequestsApi = new DeviceRequestsApi(mdsConfig);
        }

        private static string RemoveLeadingSlash(string path)
        {
            if (path.StartsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                path = path.Substring(1);
            }

            return path;
        }

        private static string AddLeadingSlash(string path)
        {
            if (!path.StartsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                path = $"/{path}";
            }

            return path;
        }
    }
}
