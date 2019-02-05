// <copyright file="AccountManagementExamples.ListGroups.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.AccountManagement
{
    using System;
    using System.Collections.Generic;
    using Mbed.Cloud.Foundation.Common;
    using MbedCloudSDK.AccountManagement.Model.Group;

    /// <summary>
    /// Account management examples
    /// </summary>
    public partial class AccountManagementExamples
    {
        /// <summary>
        /// List all groups in an account
        /// </summary>
        /// <returns>List of groups</returns>
        public IEnumerable<Group> ListAllGroups()
        {
            var options = new QueryOptions
            {
                Limit = 5,
                Order = "DESC",
            };
            var groups = api.ListGroups(options);
            foreach (var item in groups)
            {
                Console.WriteLine(item.Name);

                // List the keys in the group
                var keys = api.ListGroupApiKeys(item.Id);
                Console.WriteLine("Keys in this group ... ");
                foreach (var key in keys)
                {
                    Console.WriteLine(key.Name);
                }

                // list the users in this group
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
