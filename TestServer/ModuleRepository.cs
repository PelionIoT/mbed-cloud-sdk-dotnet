using System;
using System.Collections.Generic;
using MbedCloudSDK.AccountManagement.Api;
using MbedCloudSDK.Certificates.Api;
using MbedCloudSDK.Common;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.DeviceDirectory.Api;
using MbedCloudSDK.Update.Api;

namespace TestServer
{
    public interface IModuleRepositoryFactory 
    {
        ModuleRepository Create();
    }

    public class SingletonModuleInstance : IModuleRepositoryFactory
    {
        public ModuleRepository Create()
        {
            return ModuleRepository.Instance;
        }
    }

    public class ModuleRepository
    {
        private Dictionary<string, object> apis;

        public ModuleRepository()
        {
            apis = InitalizeModules();
        }

        public Dictionary<string, object> GetModules()
        {
            return apis;
        }

        public static ModuleRepository Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        private class Nested
        {
            static Nested(){}
            internal static readonly ModuleRepository instance = new ModuleRepository();
        }

        private Dictionary<string, object> InitalizeModules()
        {
            var apiKey = Utils.ReadSetting("ApiKey") as string;
            var config = new Config(apiKey);
            config.Host = "https://lab-api.mbedcloudintegration.net";
            
            var dict = new Dictionary<string, object>();

            dict.Add("AccountManagement", Activator.CreateInstance(typeof(AccountManagementApi), config));
            dict.Add("Certificates", Activator.CreateInstance(typeof(CertificatesApi), config));
            dict.Add("Connect", Activator.CreateInstance(typeof(ConnectApi), config));
            dict.Add("DeviceDirectory", Activator.CreateInstance(typeof(DeviceDirectoryApi), config));
            dict.Add("Update", Activator.CreateInstance(typeof(UpdateApi), config));
            return dict;
        }
    }
}