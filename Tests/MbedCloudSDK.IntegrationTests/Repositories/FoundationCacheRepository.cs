using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mbed.Cloud;
using Mbed.Cloud.Foundation.Common;
using MbedCloudSDK.IntegrationTests.Models;

namespace MbedCloudSDK.IntegrationTests.Repositories
{
    public class FoundationCacheRepository : CacheRepository<IFoundationInstance>
    {
        public IEnumerable<FoundationEntityInstance> ListEntityInstances(string entityName)
        {
            if (ListAvailableEntities().Any(e => e == entityName))
            {
                throw new KeyNotFoundException();
            }

            return base.ListItems()
                .Where(e => e.GetType() == typeof(FoundationEntityInstance))
                .Cast<FoundationEntityInstance>()
                .Where(e => e.Name == entityName);
        }

        public FoundationEntityInstance CreateEntityInstance(string name, Config config)
        {
            if (!ListAvailableEntities().Any(e => e == name))
            {
                throw new KeyNotFoundException();
            }

            var repo = Assembly.GetAssembly(typeof(SDK))
                                        .GetTypes()
                                        .FirstOrDefault(t => t.IsClass && t.Name == $"{name}Repository" && t.Namespace == "Mbed.Cloud.Foundation.Entities");

            var newInstance = (Repository)Activator.CreateInstance(repo, config, null);

            var instance = new FoundationEntityInstance(name, newInstance);
            base.AddItem(instance.Id, instance);
            return instance;
        }

        public IEnumerable<FoundationSDKInstance> ListSDKInstances()
        {
            return base.ListItems().Where(e => e.GetType() == typeof(FoundationSDKInstance)).Cast<FoundationSDKInstance>();
        }

        public FoundationSDKInstance CreateSDKInstance(Config config)
        {
            var sdk = new SDK(config);
            var instance = new FoundationSDKInstance(sdk);
            base.AddItem(instance.Id, instance);
            return instance;
        }

        public IEnumerable<string> ListAvailableEntities()
        {
            return Assembly.GetAssembly(typeof(SDK))
                .GetTypes()
                .Where(t => t.IsClass && t.Namespace == "Mbed.Cloud.Foundation.Entities" && !t.Name.Contains("Repository"))
                .Select(t => t.Name);
        }
    }
}