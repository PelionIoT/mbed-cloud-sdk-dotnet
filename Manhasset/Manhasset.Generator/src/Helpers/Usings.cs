namespace Manhasset.Generator.src.Helpers
{
    public static class Usings
    {
        public static readonly string System = "System";
        public static readonly string BaseModel = "MbedCloudSDK.Common";
        public static readonly string JsonConverter = "Newtonsoft.Json";
        public static readonly string StringEnumConverter = "Newtonsoft.Json.Converters";
        public static readonly string Lists = "System.Collections.Generic";
        public static readonly string DebugDump = "MbedCloudSDK.Common.Extensions";
        public static readonly string EnumMemberValue = "System.Runtime.Serialization";
        public static readonly string Task = "System.Threading.Tasks";
        public static readonly string Client = "MbedCloudSDK.Client";
        public static readonly string Common = "MbedCloudSDK.Common";
        public static readonly string RestSharp = "RestSharp";
        public static readonly string Exceptions = "MbedCloudSDK.Exceptions";
        public static readonly string QueryOptions = "MbedCloudSDK.Common.Query";

        public static string GetForeignKey(string group, string entity)
        {
            return $"MbedCloudSDK.{group}.{entity}";
        }
    }
}