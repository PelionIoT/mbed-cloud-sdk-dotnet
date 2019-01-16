using MbedCloud.SDK.Common;

namespace MbedCloudSDK.SDK.Common
{
    public class Repository
    {
        private readonly Config _config;

        protected readonly MbedCloud.SDK.Client.Client Client;

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public Config Config
        {
            get => _config;
        }

        public Repository(Config config = null)
        {
            _config = config ?? new Config();
            Client = new MbedCloud.SDK.Client.Client(_config);
        }
    }
}