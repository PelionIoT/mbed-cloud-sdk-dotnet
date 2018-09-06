using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MbedCloudSDK.Entities.SubtenantAccount;
using MbedCloudSDK.Entities.User;
using MbedCloudSDK.Common;

namespace Snippets.src.Foundation
{
    public class SubTenantExamples
    {
        private static Random random = new Random();

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

            await newSubtenant.Create();

            var config = new Config(apiKey: newSubtenant.AdminKey);

            var user = await new User(config)
            {
                FullName = "tommi the wombat",
                Username = $"tommi_the_wombat_{randomString()}",
                PhoneNumber = "0800001066",
                Email = $"tommi_{randomString()}@example.com",
            }.Create();

            newSubtenant.List().ToList().ForEach(u => Console.WriteLine(u));
            // end of example
        }

        private string randomString(int length = 16)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}