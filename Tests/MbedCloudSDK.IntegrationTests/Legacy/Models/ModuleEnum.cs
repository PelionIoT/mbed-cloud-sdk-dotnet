using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace MbedCloudSDK.IntegrationTests.Models
{
    public enum ModuleEnum
    {
        None,
        AccountManagementApi,
        CertificatesApi,
        ConnectApi,
        DeviceDirectoryApi,
        StubAPI,
        UpdateApi,
        EnrollmentApi,
        BootstrapApi,
        BillingApi,
    }

    public class ModuleEnumHelpers
    {
        public static Dictionary<string, ModuleEnum> Modules = new Dictionary<string, ModuleEnum> {
                { "account_management", ModuleEnum.AccountManagementApi},
                {"certificates", ModuleEnum.CertificatesApi},
                {"connect", ModuleEnum.ConnectApi},
                {"device_directory", ModuleEnum.DeviceDirectoryApi},
                {"enrollment", ModuleEnum.EnrollmentApi},
                {"test_stub", ModuleEnum.StubAPI},
                {"update", ModuleEnum.UpdateApi},
                {"bootstrap", ModuleEnum.BootstrapApi},
                {"billing", ModuleEnum.BillingApi},
            };
        public static ModuleEnum Map(string value)
        {
            if (Modules.ContainsKey(value))
            {
                return Modules[value];
            }

            return ModuleEnum.None;
        }

        public static string ReverseMap(ModuleEnum module)
        {
            if (Modules.ContainsValue(module))
            {
                return Modules.FirstOrDefault(m => m.Value == module).Key;
            }

            return null;
        }
    }

    public class ModuleEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var moduleString = (string)reader.Value;
            return ModuleEnumHelpers.Map(moduleString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var moduleEnum = (ModuleEnum)value;
            writer.WriteValue(ModuleEnumHelpers.ReverseMap(moduleEnum));
        }
    }
}