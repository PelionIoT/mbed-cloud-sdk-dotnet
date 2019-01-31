using System;
using System.Collections.Generic;
using System.Linq;
using Mbed.Cloud.Foundation.Common;
using MbedCloudSDK.Exceptions;
using MbedCloudSDK.IntegrationTests.Exceptions;
using MbedCloudSDK.IntegrationTests.Models;
using MbedCloudSDK.IntegrationTests.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MbedCloudSDK.IntegrationTests.Services
{
    public interface IFoundationService
    {
        IEnumerable<FoundationSDKInstance> ListAllSDKInstances();
        FoundationSDKInstance CreateSDKInstance(Config config);
        IEnumerable<string> ListAvailableEntities();
        IEnumerable<FoundationEntityInstance> ListEntityInstances(string entityName);
        FoundationEntityInstance CreateEntityInstance(string entityName, Config config);
        IFoundationInstance GetInstanceById(string id);
        IEnumerable<IFoundationInstance> ListAllInstances();
        Dictionary<string, Method> ListInstanceMethods(string instanceId);
        void DeleteInstance(string instanceId);
        object ExecuteMethod(string instanceId, string methodId, Dictionary<string, object> parameters);
    }

    public class FoundationService : IFoundationService
    {
        private readonly FoundationCacheRepository _foundationCacheRepository;

        public FoundationService()
        {
            _foundationCacheRepository = new FoundationCacheRepository();
        }

        public void DeleteInstance(string instanceId)
        {
            try
            {
                _foundationCacheRepository.DeleteItem(instanceId);
            }
            catch (KeyNotFoundException)
            {
                throw new TestServerException("no such instance", 404);
            }
            catch (Exception e)
            {
                throw new TestServerException(e.Message, 500);
            }
        }

        public IFoundationInstance GetInstanceById(string id)
        {
            try
            {
                return _foundationCacheRepository.GetItem(id);
            }
            catch (KeyNotFoundException)
            {
                throw new TestServerException("no such instance", 404);
            }
            catch (Exception e)
            {
                throw new TestServerException(e.Message, 500);
            }
        }

        public Dictionary<string, Method> ListInstanceMethods(string instanceId)
        {
            try
            {
                return _foundationCacheRepository.GetItem(instanceId).Methods;
            }
            catch (KeyNotFoundException)
            {
                throw new TestServerException("no such instance", 404);
            }
            catch (Exception e)
            {
                throw new TestServerException(e.Message, 500);
            }
        }

        public FoundationEntityInstance CreateEntityInstance(string entityName, Config config)
        {
            try
            {
                return _foundationCacheRepository.CreateEntityInstance(entityName, config);
            }
            catch (KeyNotFoundException)
            {
                throw new TestServerException("no such instance", 404);
            }
            catch (Exception e)
            {
                throw new TestServerException(e.Message, 500);
            }
        }

        public object ExecuteMethod(string instanceId, string methodId, Dictionary<string, object> parameters)
        {
            try
            {
                return _foundationCacheRepository.GetItem(instanceId).ExecuteMethod(methodId, parameters);
            }
            catch (KeyNotFoundException e)
            {
                throw new TestServerException(e.Message, 404);
            }
            catch (CloudApiException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new TestServerException(e.Message, 500);
            }
        }

        public FoundationSDKInstance CreateSDKInstance(Config config)
        {
            try
            {
                return _foundationCacheRepository.CreateSDKInstance(config);
            }
            catch (Exception e)
            {
                throw new TestServerException(e.Message, 500);
            }
        }

        public IEnumerable<FoundationSDKInstance> ListAllSDKInstances()
        {
            try
            {
                return _foundationCacheRepository.ListSDKInstances();
            }
            catch (Exception e)
            {
                throw new TestServerException(e.Message, 500);
            }
        }

        public IEnumerable<string> ListAvailableEntities()
        {
            try
            {
                return _foundationCacheRepository.ListAvailableEntities();
            }
            catch (Exception e)
            {
                throw new TestServerException(e.Message, 500);
            }
        }

        public IEnumerable<FoundationEntityInstance> ListEntityInstances(string entityName)
        {
            try
            {
                return _foundationCacheRepository.ListEntityInstances(entityName);
            }
            catch (KeyNotFoundException)
            {
                throw new TestServerException("no such instance", 404);
            }
            catch (Exception e)
            {
                throw new TestServerException(e.Message, 500);
            }
        }

        public IEnumerable<IFoundationInstance> ListAllInstances()
        {
            try
            {
                return _foundationCacheRepository.ListItems();
            }
            catch (Exception e)
            {
                throw new TestServerException(e.Message, 500);
            }
        }
    }
}