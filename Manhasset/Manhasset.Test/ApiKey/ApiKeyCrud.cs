using System.Linq;
using System.Threading.Tasks;
using MbedCloudSDK.Accounts.PolicyGroup;
using NUnit.Framework;
using MbedCloudSDK.Accounts.ApiKey;
using System.Collections.Generic;
using System;
using MbedCloudSDK.Common.Extensions;

namespace Manhasset.Test
{
    [TestFixture]
    public class ApiKeyCrud
    {
        private ApiKey createdApiKey;

        private ApiKey NewApiKey()
        {
            return new ApiKey
            {
                Name = "testApiKey",
            };
        }

        [TearDown]
        public async Task TearDown()
        {
            if (createdApiKey != null)
            {
                await createdApiKey.Delete();
            }
        }

        [Test]
        public async Task CrudSequence()
        {
            var group = new PolicyGroup().List().FirstOrDefault();
            //Assert.IsFalse(true);

            var newApiKey = NewApiKey();

            newApiKey.GroupIds = new List<string>() { group.Id };

            await newApiKey.Create();

            createdApiKey = newApiKey;

            Assert.AreEqual("testApiKey", newApiKey.Name);
            Assert.GreaterOrEqual(newApiKey?.GroupIds?.Count, 1);

            // var getApiKey = await new ApiKey { Id = newApiKey.Id }.Get();

            // Assert.AreEqual(newApiKey, getApiKey);

            //var newName = "updatedTestApiKey";

            //newApiKey.Name = newName;

            //await newApiKey.Update();

            //Assert.AreEqual(newName, newApiKey.Name);

            var allApiKeys = new ApiKey().List();

            var found = allApiKeys.FirstOrDefault(k => k.Id == newApiKey.Id);

            Assert.AreEqual(newApiKey.Id, found.Id);

            var keyGroups = newApiKey.Groups();
            foreach (var item in keyGroups)
            {
                Assert.GreaterOrEqual(item.ApikeyCount, 1);
            }
        }
    }
}