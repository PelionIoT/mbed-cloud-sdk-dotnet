using Mbed.Cloud.Foundation.RestClient;

namespace Mbed.Cloud.Foundation.Common
{
    public class Repository
    {
        private readonly Config _config;

        protected readonly Client Client;

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

        public Repository(Config config = null, Client client = null)
        {
            _config = config ?? new Config();
            Client = client ?? new Client(_config);
        }
    }
}