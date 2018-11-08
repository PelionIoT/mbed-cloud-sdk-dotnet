namespace MbedCloud.SDK.Common
{
    using System.Collections.Generic;
    using MbedCloud.SDK;
    using Newtonsoft.Json;

    /// <summary>
    /// BaseModel
    /// </summary>
    public abstract class BaseEntity
    {
        [JsonIgnore]
        private readonly Config _config;

        [JsonIgnore]
        protected readonly MbedCloud.SDK.Client.Client Client;

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        [JsonIgnore]
        public Config Config
        {
            get => _config;
        }

        /// <summary>
        /// Gets or sets gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty]
        public string Id { get; set; }

        public BaseEntity(Config config = null)
        {
            _config = config ?? new Config();
            Client = new MbedCloud.SDK.Client.Client(_config);
        }
    }
}