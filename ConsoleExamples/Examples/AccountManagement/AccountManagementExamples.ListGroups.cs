using System;
using System.Collections.Generic;
using MbedCloudSDK.AccountManagement.Api;
using MbedCloudSDK.AccountManagement.Model.Group;
using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Query;

namespace ConsoleExamples.Examples.AccountManagement
{
    public partial class AccountManagementExamples
    {
        public List<Group> ListAllGroups()
        {
            var options = new QueryOptions()
            {
                Limit = 5,
                Order = "DESC"
            };
            var groups = api.ListGroups(options).Data;
            foreach (var item in groups)
            {
                Console.WriteLine(item.Name);
                var keys = api.ListGroupApiKeys(item.Id);
                foreach (var key in keys)
                {
                    Console.WriteLine(key.Name);
                }

                var users = api.ListGroupUsers(item.Id);
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.FullName} - {user.Email} - {user.Username}");
                }
            }

            return groups;
        }
    }
}