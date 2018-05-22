using System;
using System.Collections.Generic;
using System.Linq;
using MbedCloudSDK.AccountManagement.Api;
using MbedCloudSDK.Bootstrap.Api;
using MbedCloudSDK.Certificates.Api;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.DeviceDirectory.Api;
using MbedCloudSDK.Enrollment.Api;
using MbedCloudSDK.IntegrationTests.Models;
using MbedCloudSDK.IntegrationTests.Repositories;
using MbedCloudSDK.Update.Api;
using Microsoft.AspNetCore.Mvc;
using TestServer;

namespace MbedCloudSDK.IntegrationTests.Services
{
    public interface IInstanceService
    {
        void ResetInstances();
        Instance AddModuleInstance(ModuleEnum module, InstanceConfiguration instanceConfiguration);
        List<Instance> ListModuleInstances(ModuleEnum module);
        List<string> ListModules();
        List<Instance> GetAllInstances();
        Instance GetInstance(string instanceId);
        void DeleteInstance(Instance instance);
        List<SdkApi> ListInstanceMethods(Instance instance);
        object GetInstanceObject(Instance instance);
    }

    public class InstanceService : IInstanceService
    {
        public InstanceRepository _instanceRepository;

        public InstanceService()
        {
            _instanceRepository = new InstanceRepository();
        }

        public Instance AddModuleInstance(ModuleEnum module, InstanceConfiguration instanceConfiguration)
        {
            try
            {
                return _instanceRepository.AddModuleInstance(module, instanceConfiguration);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteInstance(Instance instance)
        {
            try
            {
                _instanceRepository.DeleteInstance(instance);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Instance> GetAllInstances()
        {
            try
            {
                return _instanceRepository.GetAllInstances();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Instance GetInstance(string instanceId)
        {
            try
            {
                return _instanceRepository.GetInstance(instanceId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<SdkApi> ListInstanceMethods(Instance instance)
        {
            try
            {
                switch (instance.Module)
                {
                    case ModuleEnum.AccountManagementApi:
                        return GetMethods(typeof(AccountManagementApi));
                    case ModuleEnum.CertificatesApi:
                        return GetMethods(typeof(CertificatesApi));
                    case ModuleEnum.ConnectApi:
                        return GetMethods(typeof(ConnectApi));
                    case ModuleEnum.DeviceDirectoryApi:
                        return GetMethods(typeof(DeviceDirectoryApi));
                    case ModuleEnum.StubAPI:
                        return GetMethods(typeof(StubApi));
                    case ModuleEnum.UpdateApi:
                        return GetMethods(typeof(UpdateApi));
                    case ModuleEnum.EnrollmentApi:
                        return GetMethods(typeof(EnrollmentApi));
                    case ModuleEnum.BootstrapApi:
                        return GetMethods(typeof(BootstrapApi));
                    default:
                        return Enumerable.Empty<SdkApi>().ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private List<SdkApi> GetMethods(Type type)
        {
            return type.GetMethods().Select(m => new SdkApi{ Name = Utils.CamelToSnake(m.Name)}).ToList();
        }

        public List<Instance> ListModuleInstances(ModuleEnum module)
        {
            try
            {
                return _instanceRepository.ListModuleInstances(module);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ResetInstances()
        {
            try
            {
                _instanceRepository.ResetInstances();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<string> ListModules()
        {
            return ModuleEnumHelpers.Modules.Keys.ToList();
        }

        public object GetInstanceObject(Instance instance)
        {
            try
            {
                return _instanceRepository.GetInstanceObject(instance);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}