using System.Collections.Generic;

namespace MbedCloudSDK.Connect.Api.Subscribe.Observers.Subscriptions
{
    public class ResourceValueChangeFilter
    {
        public string DeviceId { get; set; }

        public List<string> ResourcePaths { get; set; }
    }
}