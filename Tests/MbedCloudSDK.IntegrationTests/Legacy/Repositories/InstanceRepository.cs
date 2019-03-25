using System;
using System.Collections.Generic;
using System.Linq;
using Mbed.Cloud.Common;
using MbedCloudSDK.AccountManagement.Api;
using MbedCloudSDK.Billing.Api;
using MbedCloudSDK.Bootstrap.Api;
using MbedCloudSDK.Certificates.Api;
using MbedCloudSDK.Common;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.DeviceDirectory.Api;
using MbedCloudSDK.Enrollment.Api;
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

        public Instance AddModuleInstance(ModuleEnum module, InstanceConfiguration instanceConfiguration)
        {
            var additionalProperties = instanceConfiguration.GetHashtable();
            var config = new Config(
                apiKey: instanceConfiguration.ApiKey,
                host: instanceConfiguration.Host)
            {
                AutostartNotifications = instanceConfiguration.AutostartDaemon,
                ForceClear = true,
            };

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
                    var stubApi = new StubApi(config);
                    Instances.Add(instance, stubApi);
                    break;
                case ModuleEnum.UpdateApi:
                    var updateApi = new UpdateApi(config);
                    Instances.Add(instance, updateApi);
                    break;
                case ModuleEnum.EnrollmentApi:
                    var enrollmentApi = new EnrollmentApi(config);
                    Instances.Add(instance, enrollmentApi);
                    break;
                case ModuleEnum.BootstrapApi:
                    var bootstrapApi = new BootstrapApi(config);
                    Instances.Add(instance, bootstrapApi);
                    break;
                case ModuleEnum.BillingApi:
                    var billingApi = new BillingApi(config);
                    Instances.Add(instance, billingApi);
                    break;
            }

            return instance;
        }

        internal void DeleteInstance(Instance instance)
        {
            Instances.Remove(instance);
        }

        internal Instance GetInstance(string instanceId)
        {
            return Instances.Keys.Where(k => k.Id == instanceId).FirstOrDefault();
        }

        public List<Instance> GetAllInstances()
        {
            return Instances.Keys.ToList();
        }

        public List<Instance> ListModuleInstances(ModuleEnum module)
        {
            return Instances.Keys.Where(k => k.Module == module).ToList();
        }

        public object GetInstanceObject(Instance instance)
        {
            return Instances[instance];
        }
    }
}