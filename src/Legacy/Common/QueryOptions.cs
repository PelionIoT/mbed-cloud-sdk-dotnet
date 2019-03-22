namespace MbedCloudSDK.Common
{
    using MbedCloudSDK.Common.Filter;
    public class QueryOptions : Mbed.Cloud.Common.QueryOptions
    {
        public Filter.Filter Filter { get; set; }
    }
}