using Mbed.Cloud.Foundation.Common;
using MbedCloudSDK.Connect.Model;

namespace MbedCloudSDK.Connect.Api
{
    public class ConnectApiConfig : Config
    {
        public DeliveryMethod DeliveryMethod { get; } = DeliveryMethod.CLIENT_INITIATED;

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

        public ConnectApiConfig(string apiKey, string host, DeliveryMethod deliveryMethod) :
            base(apiKey, host)
        {
            DeliveryMethod = deliveryMethod;
        }
    }
}