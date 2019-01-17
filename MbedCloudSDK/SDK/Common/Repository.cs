using MbedCloud.SDK.Common;
using MbedCloud.SDK.Client;

namespace MbedCloud.SDK.Common
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

        public Repository(Config config = null, Client.Client client = null)
        {
            _config = config ?? new Config();
            Client = client ?? new Client.Client(_config);
        }
    }
}