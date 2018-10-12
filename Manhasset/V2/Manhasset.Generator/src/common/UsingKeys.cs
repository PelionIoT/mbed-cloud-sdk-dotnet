namespace Manhasset.Generator.src.common
{
    public static class UsingKeys
    {
        public static readonly string SYSTEM = "System";
        public static readonly string LISTS = "System.Collections.Generic";

        public static readonly string CUSTOM_FUNCTIONS = "MbedCloud.SDK.Common";

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