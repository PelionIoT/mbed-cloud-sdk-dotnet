using Newtonsoft.Json;

namespace MbedCloudSDK.IntegrationTests.Models
{
    public class InstanceConfiguration
    {
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }
        public string Host { get; set; }
        [JsonProperty("autostart_daemon")]
        public bool AutostartDaemon { get; set; }
    }
}