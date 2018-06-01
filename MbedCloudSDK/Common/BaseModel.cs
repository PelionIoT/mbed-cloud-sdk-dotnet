using Newtonsoft.Json;

namespace MbedCloudSDK.Common
{
    public abstract class BaseModel
    {
        [JsonProperty]
        public string Id { get; internal set; }
    }
}