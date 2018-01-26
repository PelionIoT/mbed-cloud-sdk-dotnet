using System;
using System.Collections.Generic;
using MbedCloudSDK.AccountManagement.Api;
using MbedCloudSDK.Certificates.Api;
using MbedCloudSDK.Common;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.DeviceDirectory.Api;
using MbedCloudSDK.IntegrationTests.Models;
using MbedCloudSDK.Update.Api;

namespace MbedCloudSDK.IntegrationTests.Repositories
{
    public class InstanceRepository
    {
        public Dictionary<Instance, object> Instances { get; set; }

        public InstanceRepository()
        {
            Instances = new Dictionary<Instance, object>();
        }

        public void ResetInstances()
        {
            try
            {
                Instances.Clear();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        internal Instance AddModuleInstance(ModuleEnum module, InstanceConfiguration instanceConfiguration)
        {
            var config = new Config(instanceConfiguration.ApiKey, instanceConfiguration.Host, autostartNotifications: instanceConfiguration.AutostartDaemon);
            var instance = new Instance { Id = Guid.NewGuid().ToString(), Module = module, CreatedAt = DateTime.Now };
            switch (module)
            {
                case ModuleEnum.AccountManagementApi:
                    var accountApi = new AccountManagementApi(config);
                    Instances.Add(instance, accountApi);
                    break;
                case ModuleEnum.CertificatesApi:
                    var certApi = new CertificatesApi(config);
                    Instances.Add(instance, certApi);
                    break;
                case ModuleEnum.ConnectApi:
                    var connectApi = new ConnectApi(config);
                    Instances.Add(instance, connectApi);
                    break;
                case ModuleEnum.DeviceDirectoryApi:
                    var deviceApi = new DeviceDirectoryApi(config);
                    Instances.Add(instance, deviceApi);
                    break;
                case ModuleEnum.StubAPI:
                    break;
                case ModuleEnum.UpdateApi:
                    var updateApi = new UpdateApi(config);
                    Instances.Add(instance, updateApi);
                    break;
            }

            return instance;
        }
    }
}