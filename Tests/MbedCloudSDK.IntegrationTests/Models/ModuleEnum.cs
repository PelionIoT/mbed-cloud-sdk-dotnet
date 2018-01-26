using System.Collections.Generic;

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
        UpdateApi
    }

    public class ModuleEnumHelpers
    {
        public static ModuleEnum Map(string value)
        {
            var dict = new Dictionary<string, ModuleEnum> {
                { "account_management", ModuleEnum.AccountManagementApi},
                {"certificates", ModuleEnum.CertificatesApi},
                {"connect", ModuleEnum.ConnectApi},
                {"device_directory", ModuleEnum.DeviceDirectoryApi},
                {"test_stub", ModuleEnum.StubAPI},
                {"update", ModuleEnum.UpdateApi}
            };

            if (dict.ContainsKey(value))
            {
                return dict[value];
            }

            return ModuleEnum.None;
        }
    }
}