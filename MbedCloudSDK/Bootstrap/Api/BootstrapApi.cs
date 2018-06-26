// <copyright file="BootstrapApi.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Bootstrap.Api
{
    using System.Threading.Tasks;
    using connector_bootstrap.Api;
    using MbedCloudSDK.Bootstrap.Model;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Query;
    using MbedCloudSDK.Exceptions;
    using static MbedCloudSDK.Common.Utils;

    /// <summary>
    /// Bootstrap Api
    /// </summary>
    public class BootstrapApi : BaseApi
    {
        private readonly PreSharedKeysApi api;

        /// <summary>
        /// Initializes a new instance of the <see cref="BootstrapApi"/> class.
        /// Bootstrap
        /// </summary>
        /// <param name="config">config</param>
        public BootstrapApi(Config config)
            : base(config)
        {
            var bootstrapConfig = new connector_bootstrap.Client.Configuration
            {
                BasePath = config.Host,
                DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss.fffZ",
                UserAgent = UserAgent,
            };
            bootstrapConfig.AddApiKey("Authorization", config.ApiKey);
            bootstrapConfig.AddApiKeyPrefix("Authorization", config.AuthorizationPrefix);
            bootstrapConfig.CreateApiClient();

            api = new connector_bootstrap.Api.PreSharedKeysApi(bootstrapConfig);
        }

        /// <summary>
        /// ListPsks
        /// </summary>
        /// <param name="options">Query options</param>
        /// <returns>List of Psks</returns>
        public PaginatedResponse<QueryOptions, PreSharedKey> ListPsks(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                return new PaginatedResponse<QueryOptions, PreSharedKey>(ListPreSharedKeysFunc, options);
            }
            catch (CloudApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        private ResponsePage<PreSharedKey> ListPreSharedKeysFunc(QueryOptions options)
        {
            try
            {
                var resp = api.ListPreSharedKeys(limit: options.Limit, after: options.After);
                var psks = new ResponsePage<PreSharedKey>(resp.ContinuationMarker, resp.HasMore, resp.Limit, resp.Order, null);
                resp.Data.ForEach(psk => psks.Data.Add(PreSharedKey.Map(psk)));
                return psks;
            }
            catch (connector_bootstrap.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Add a PSK
        /// </summary>
        /// <param name="key">A PreSharedKey</param>
        /// <returns>A Task</returns>
        public async Task<PreSharedKey> AddPskAsync(PreSharedKey key)
        {
            try
            {
                await api.UploadPreSharedKeyAsync(PreSharedKey.CreateRequest(key));
                return key;
            }
            catch (connector_bootstrap.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Add a PSK
        /// </summary>
        /// <param name="key">A PreSharedKey</param>
        /// <returns>PreSharedKey</returns>
        public PreSharedKey AddPsk(PreSharedKey key)
        {
            try
            {
                return Task.Run(async () => await AddPskAsync(key)).Result;
            }
            catch (CloudApiException)
            {
                throw;
            }
        }

        /// <summary>
        /// Get a PreSharedKey
        /// </summary>
        /// <param name="endpointName">The ID of PreSharedKey</param>
        /// <returns>A PreSharedKey without the SecretKey</returns>
        public async Task<PreSharedKey> GetPskAsync(string endpointName)
        {
            try
            {
                var psk = await api.GetPreSharedKeyAsync(endpointName);
                return PreSharedKey.Map(psk);
            }
            catch (connector_bootstrap.Client.ApiException e)
            {
                return HandleNotFound<PreSharedKey, connector_bootstrap.Client.ApiException>(e);
            }
        }

        /// <summary>
        /// Get a PreSharedKey
        /// </summary>
        /// <param name="endpointName">The ID of PreSharedKey</param>
        /// <returns>PreSharedKey</returns>
        public PreSharedKey GetPsk(string endpointName)
        {
            try
            {
                return Task.Run(async () => await GetPskAsync(endpointName)).Result;
            }
            catch (CloudApiException)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete a PreSharedKey
        /// </summary>
        /// <param name="endpointName">The Id of the PreSharedKey</param>
        /// <returns>A Task</returns>
        public async Task DeletePskAsync(string endpointName)
        {
            try
            {
                await api.DeletePreSharedKeyAsync(endpointName);
            }
            catch (connector_bootstrap.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Delete a PreSharedKey
        /// </summary>
        /// <param name="endpointName">The Id of the PreSharedKey</param>
        public void DeletePsk(string endpointName)
        {
            try
            {
                Task.Run(async () => await DeletePskAsync(endpointName)).Wait();
            }
            catch (CloudApiException)
            {
                throw;
            }
        }
    }
}