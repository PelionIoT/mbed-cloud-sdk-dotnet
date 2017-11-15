using System;
using System.Collections.Generic;
using MbedCloudSDK.AccountManagement.Api;
using MbedCloudSDK.AccountManagement.Model.User;
using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Query;

namespace ConsoleExamples.Examples.AccountManagement
{
    public partial class AccountManagementExamples
    {
        /// <summary>
        /// List the active users
        /// </summary>
        /// <returns>List of Users</returns>
        public List<User> ListActiveUsers()
        {
            var options = new QueryOptions()
            {
                Limit = 5
            };
            //options.Filter.Add("status", "ACTIVE");
            //Console.WriteLine(options.Filter.FilterString);
            var users = api.ListUsers(options).Data;
            foreach (var item in users)
            {
                Console.WriteLine(item);
            }
            return users;
        }
    }
}