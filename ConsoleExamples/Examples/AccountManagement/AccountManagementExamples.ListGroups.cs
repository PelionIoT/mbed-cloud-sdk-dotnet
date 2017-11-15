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
        /// <summary>
        /// List all groups in an account
        /// </summary>
        /// <returns>List of groups</returns>
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
                //List the keys in the group
                var keys = api.ListGroupApiKeys(item.Id);
                Console.WriteLine("Keys in this group ... ");
                foreach (var key in keys)
                {
                    Console.WriteLine(key.Name);
                }

                // list the users in thes group
                var users = api.ListGroupUsers(item.Id);
                Console.WriteLine("Users in this group ... ");
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.FullName} - {user.Email} - {user.Username}");
                }
            }

            return groups;
        }
    }
}