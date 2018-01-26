using System;
using MbedCloudSDK.IntegrationTests.Models;
using MbedCloudSDK.IntegrationTests.Repositories;

namespace MbedCloudSDK.IntegrationTests.Services
{
    public interface IInstanceService
    {
        void ResetInstances();
        Instance AddModuleInstance(ModuleEnum module, InstanceConfiguration instanceConfiguration);
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