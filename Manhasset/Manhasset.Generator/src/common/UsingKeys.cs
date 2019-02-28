namespace Manhasset.Generator.src.common
{
    public static class UsingKeys
    {
        public static readonly string SYSTEM = "System";
        public static readonly string GENERIC_COLLECTIONS = "System.Collections.Generic";

        public static readonly string SDK_COMMON = "Mbed.Cloud.Common";

        public static readonly string EXCEPTIONS = "MbedCloudSDK.Exceptions";

        public static readonly string ASYNC = "System.Threading.Tasks";

        public static readonly string CLIENT = "Mbed.Cloud.RestClient";

        public static readonly string SYSTEM_IO = "System.IO";

        public static readonly string ENTITIES = "Mbed.Cloud.Foundation";
        public static readonly string ENUMS = "Mbed.Cloud.Foundation.Enums";
        public static readonly string HOME = "Mbed.Cloud";
        public static readonly string ListOptions = "Mbed.Cloud.Foundation";
        public static readonly string FOUNDATION_FACTORY_CLASS = "Mbed.Cloud.Foundation.Factories";
        public static readonly string EnumMemberValue = "System.Runtime.Serialization";

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