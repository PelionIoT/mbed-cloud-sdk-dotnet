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
        private Config config;

        [JsonIgnore]
        protected MbedCloud.SDK.Client.Client Client;

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        [JsonIgnore]
        public Config Config
        {
            get => config ?? SDK.Config;
            set => config = value;
        }

        /// <summary>
        /// Gets or sets gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty]
        public string Id { get; set; }
    }
}