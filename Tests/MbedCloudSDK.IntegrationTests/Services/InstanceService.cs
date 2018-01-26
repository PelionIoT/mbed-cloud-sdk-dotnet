using System;
using System.Collections.Generic;
using System.Linq;
using MbedCloudSDK.AccountManagement.Api;
using MbedCloudSDK.Certificates.Api;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.DeviceDirectory.Api;
using MbedCloudSDK.IntegrationTests.Models;
using MbedCloudSDK.IntegrationTests.Repositories;
using MbedCloudSDK.Update.Api;

namespace MbedCloudSDK.IntegrationTests.Services
{
    public interface IInstanceService
    {
        void ResetInstances();
        Instance AddModuleInstance(ModuleEnum module, InstanceConfiguration instanceConfiguration);
        List<Instance> ListModuleInstances(ModuleEnum module);
        List<Instance> GetAllInstances();
        Instance GetInstance(string instanceId);
        void DeleteInstance(Instance instance);
        List<string> ListInstanceMethods(Instance instance);
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

        public List<string> ListInstanceMethods(Instance instance)
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
                        return Enumerable.Empty<string>().ToList();
                    case ModuleEnum.UpdateApi:
                        return GetMethods(typeof(UpdateApi));
                    default:
                        return Enumerable.Empty<string>().ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private List<string> GetMethods(Type type)
        {
            return type.GetMethods().Select(m => m.Name).ToList();
            /*
            var methodList = new List<string>();
            foreach (var method in type.GetMethods())
            {
                var parameters = method.GetParameters();
                var parameterDescriptions = string.Join(", ", parameters.Select(p => $"{p.ParameterType} {p.Name}").ToArray());
                methodList.Add($"{method.ReturnType} {method.Name} {parameterDescriptions}");
            }
            return methodList;
            */
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
    }
}