using System.Threading.Tasks;
using connector_bootstrap.Api;
using MbedCloudSDK.Bootstrap.Model;
using MbedCloudSDK.Common;
using static MbedCloudSDK.Common.Utils;
using MbedCloudSDK.Exceptions;

namespace MbedCloudSDK.Bootstrap.Api
{
    /// <summary>
    /// Bootstrap Api
    /// </summary>
    public class BootstrapApi : BaseApi
    {
        private PreSharedKeysApi api;

        /// <summary>
        /// Bootstrap
        /// </summary>
        /// <param name="config"></param>
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
        public PreSharedKey AddPsk(PreSharedKey key)
        {
            try
            {
                return Task.Run(async () => await AddPskAsync(key)).Result;
            }
            catch (CloudApiException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Get a PreSharedKey
        /// </summary>
        /// <param name="EndpointName">The ID of PreSharedKey</param>
        /// <returns>A PreSharedKey without the SecretKey</returns>
        public async Task<PreSharedKey> GetPskAsync(string EndpointName)
        {
            try
            {
                var psk = await api.GetPreSharedKeyAsync(EndpointName);
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
        /// <param name="EndpointName">The ID of PreSharedKey</param>
        public PreSharedKey GetPsk(string EndpointName)
        {
            try
            {
                return Task.Run(async () => await GetPskAsync(EndpointName)).Result;
            }
            catch (CloudApiException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Delete a PreSharedKey
        /// </summary>
        /// <param name="EndpointName">The Id of the PreSharedKey</param>
        /// <returns>A Task</returns>
        public async Task DeletePskAsync(string EndpointName)
        {
            try
            {
                await api.DeletePreSharedKeyAsync(EndpointName);
            }
            catch (connector_bootstrap.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Delete a PreSharedKey
        /// </summary>
        /// <param name="EndpointName">The Id of the PreSharedKey</param>
        public void DeletePsk(string EndpointName)
        {
            try
            {
                Task.Run(async () => await DeletePskAsync(EndpointName)).Wait();
            }
            catch (CloudApiException e)
            {
                throw e;
            }
        }
    }
}