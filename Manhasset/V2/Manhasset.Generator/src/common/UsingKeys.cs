namespace Manhasset.Generator.src.common
{
    public static class UsingKeys
    {
        public static readonly string SYSTEM = "System";
        public static readonly string GENERIC_COLLECTIONS = "System.Collections.Generic";

        public static readonly string SDK_COMMON = "MbedCloud.SDK.Common";

        public static readonly string OLD_SDK_COMMON = "MbedCloudSDK.Common";

        public static string ForeignKey(string entity)
        {
            return $"FOREIGN_KEY_{entity.ToUpper()}";
        }

        public static string EnumKey(string enumName)
        {
            return $"ENUM_KEY_{enumName}";
        }
    }
}