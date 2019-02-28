using Mbed.Cloud.Common;

namespace MbedCloudSDK.Connect.Api
{
    public class ConnectApiConfig : Config
    {
        public bool SkipCleanup { get; }
        public ConnectApiConfig() :
            base(null, null)
        {
        }

        public ConnectApiConfig(string apiKey) :
            base(apiKey, null)
        {
        }

        public ConnectApiConfig(string apiKey, string host) :
            base(apiKey, host)
        {
        }
    }
}