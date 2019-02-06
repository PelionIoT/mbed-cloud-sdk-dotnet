using Mbed.Cloud.Foundation.Common;
using MbedCloudSDK.Connect.Model;

namespace MbedCloudSDK.Connect.Api
{
    public class ConnectApiConfig : Config
    {
        public DeliveryMethod DeliveryMethod { get; } = DeliveryMethod.CLIENT_INITIATED;

        public ConnectApiConfig() :
            base(null, null, false, false)
        {
        }

        public ConnectApiConfig(string apiKey) :
            base(apiKey, null, false, false)
        {
        }

        public ConnectApiConfig(string apiKey, string host) :
            base(apiKey, host, false, false)
        {
        }

        public ConnectApiConfig(string apiKey, string host, DeliveryMethod deliveryMethod) :
            base(apiKey, host, false, false)
        {
            DeliveryMethod = deliveryMethod;
        }

        public ConnectApiConfig(string apiKey, string host, DeliveryMethod deliveryMethod, bool forceClear) :
            base(apiKey, host, forceClear, false)
        {
            DeliveryMethod = deliveryMethod;
        }

        public ConnectApiConfig(string apiKey, string host, bool forceClear) :
            base(apiKey, host, forceClear, false)
        {
        }
    }
}