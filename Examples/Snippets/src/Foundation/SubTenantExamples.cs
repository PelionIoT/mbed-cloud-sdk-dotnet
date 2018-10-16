using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MbedCloud.SDK.Common;
using MbedCloud.SDK.Entities;
using NUnit.Framework;

namespace Snippets.src.Foundation
{
    [TestFixture]
    public class SubTenantExamples
    {
        private static Random random = new Random();

        [Test]
        public async Task SubTenantFlow()
        {
            // an example: creating and managing a subtenant account
            var newSubtenant = new SubtenantAccount
            {
                DisplayName = "sdk test dan",
                Aliases = new List<string> { $"sdk_test_dan_{randomString()}" },
                EndMarket = "connected warrens",
                AdminFullName = "dan the wombat",
                AdminEmail = "dan@example.com",
            };

            // when creating a new subtenant, this is the only opportunity to obtain
            // the `admin_key` for that subtenant account
            await newSubtenant.Create();

            // now log in as this subtenant using the `admin_key`
            var config = new Config(apiKey: newSubtenant.AdminKey);

            // and add another user
            var user = await new User(config)
            {
                FullName = "tommi the wombat",
                Username = $"tommi_{randomString()}",
                PhoneNumber = "0800001066",
                Email = $"tommi_{randomString()}@example.com",
            }.Create();

            // back as the aggregator again ...
            var users = newSubtenant.List();
            users.ToList().ForEach(u => Console.WriteLine(u));
            // end of example

            Assert.GreaterOrEqual(users.Count(), 2);
        }

        private string randomString(int length = 16)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}