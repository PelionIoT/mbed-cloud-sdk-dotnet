// <copyright file="AccountManagementExamples.ListUsers.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.AccountManagement
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MbedCloudSDK.AccountManagement.Model.User;
    using MbedCloudSDK.Common.Query;

    /// <summary>
    /// Account management examples
    /// </summary>
    public partial class AccountManagementExamples
    {
        // /// <summary>
        // /// List the active users
        // /// </summary>
        // /// <returns>List of Users</returns>
        // public IEnumerable<User> ListActiveUsers()
        // {
        //     var options = new QueryOptions
        //     {
        //         Limit = 5,
        //     };

        //     var users = api.ListUsers(options);
        //     foreach (var item in users)
        //     {
        //         Console.WriteLine(item);
        //     }

        //     return users;
        // }

        // /// <summary>
        // /// Add user
        // /// </summary>
        // /// <returns>User</returns>
        // public User AddUser()
        // {
        //     var user = new User
        //     {
        //         Email = "montybot@arm.com",
        //         FullName = "Monty Bot",
        //         Username = "xXmoBot69Xx",
        //     };
        //     var newUser = api.AddUser(user);

        //     Console.WriteLine(newUser);

        //     var updatedInfo = new User
        //     {
        //         Username = "mBot",
        //     };

        //     var updatedUser = api.UpdateUser(newUser.Id, updatedInfo);

        //     Console.WriteLine(updatedUser);

        //     api.DeleteUser(updatedUser.Id);

        //     return updatedUser;
        // }

        // /// <summary>
        // /// Add user async
        // /// </summary>
        // /// <returns>User</returns>
        // public async Task<User> AddUserAsync()
        // {
        //     var user = new User
        //     {
        //         Email = "montybot@arm.com",
        //         FullName = "Monty Bot",
        //         Username = "xXmoBot69Xx",
        //     };
        //     var newUser = await api.AddUserAsync(user);

        //     Console.WriteLine(newUser);

        //     var updatedInfo = new User
        //     {
        //         Username = "mBot",
        //     };

        //     var updatedUser = await api.UpdateUserAsync(newUser.Id, updatedInfo);

        //     Console.WriteLine(updatedUser);

        //     await api.DeleteUserAsync(updatedUser.Id);

        //     return updatedUser;
        // }
    }
}
