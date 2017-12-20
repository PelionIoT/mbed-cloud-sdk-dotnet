// <copyright file="AccountManagementApi.User.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.AccountManagement.Api
{
    using System;
    using System.Threading.Tasks;
    using MbedCloudSDK.AccountManagement.Model.User;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Query;
    using MbedCloudSDK.Exceptions;

    /// <summary>
    /// Account Management Api
    /// </summary>
    public partial class AccountManagementApi
    {
        /// <summary>
        /// List users.
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.ListUsers(QueryOptions)"/> method.
        /// <code>
        /// try
        /// {
        ///     var options = new QueryOptions
        ///     {
        ///         Limit = 5,
        ///     };
        ///     var users = api.ListUsers(options).Data;
        ///     foreach (var item in users)
        ///     {
        ///         Console.WriteLine(item);
        ///     }
        ///     return users;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="options"><see cref="QueryOptions"/></param>
        /// <returns>Paginated Response of <see cref="User"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public PaginatedResponse<User> ListUsers(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                return new PaginatedResponse<User>(ListUsersFunc, options);
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        private ResponsePage<User> ListUsersFunc(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                var resp = adminApi.GetAllUsers(limit: options.Limit, order: options.Order, after: options.After, include: options.Include, statusEq: options.Filter?.FilterString);
                var respUsers = new ResponsePage<User>(resp.After, resp.HasMore, resp.Limit, null, resp.TotalCount);
                foreach (var user in resp.Data)
                {
                    respUsers.Data.Add(User.Map(user));
                }

                return respUsers;
            }
            catch (device_directory.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get details of a user
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.GetUser(string)"/> method.
        /// <code>
        /// try
        /// {
        ///     var user = accountApi.GetUser("015c3c46514802420a010b1000000000");
        ///     return user;
        /// }
        /// catch (Exception)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="userId"><see cref="User.Id"/></param>
        /// <returns><see cref="User"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public User GetUser(string userId)
        {
            try
            {
                return User.Map(adminApi.GetUser(userId));
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get user asynchronously.
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.GetUserAsync(string)"/> method.
        /// <code>
        /// try
        /// {
        ///     var user = await accountApi.GetUser("015c3c46514802420a010b1000000000");
        ///     return user;
        /// }
        /// catch (Exception)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="userId"><see cref="User.Id"/></param>
        /// <returns><see cref="Task"/> with <see cref="User"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public async Task<User> GetUserAsync(string userId)
        {
            try
            {
                var user = await adminApi.GetUserAsync(userId);
                return User.Map(user);
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.AddUser(User)"/> method.
        /// <code>
        /// try
        /// {
        ///     var user = new User
        ///     {
        ///         Email = "montybot@arm.com",
        ///         FullName = "monty bot",
        ///         Username = "montybot1",
        ///     }
        ///     var newUser = accountApi.AddUser(user);
        ///     return newUser;
        /// }
        /// catch (Exception)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="user"><see cref="User"/></param>
        /// <returns><see cref="User"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public User AddUser(User user)
        {
            try
            {
                var req = user.CreatePostRequest();
                return User.Map(adminApi.CreateUser(req));
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.AddUserAsync(User)"/> method.
        /// <code>
        /// try
        /// {
        ///     var user = new User
        ///     {
        ///         Email = "montybot@arm.com",
        ///         FullName = "monty bot",
        ///         Username = "montybot1",
        ///     }
        ///     var newUser = await accountApi.AddUserAsync(user);
        ///     return newUser;
        /// }
        /// catch (Exception)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="user"><see cref="User"/></param>
        /// <returns><see cref="Task"/> with <see cref="User"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public async Task<User> AddUserAsync(User user)
        {
            try
            {
                var req = user.CreatePostRequest();
                return User.Map(await adminApi.CreateUserAsync(req));
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.UpdateUser(string, User)"/> method.
        /// <code>
        /// try
        /// {
        ///     var updatedInfo = new User
        ///     {
        ///         FullName = "Sir Monty Bot",
        ///         Username = "montybot2",
        ///     }
        ///     var updatedUser = accountApi.UpdateUser("015c3c46514802420a010b1000000000", updatedInfo);
        ///     return updatedUser;
        /// }
        /// catch (Exception)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="userId"><see cref="User.Id"/></param>
        /// <param name="user"><see cref="User"/></param>
        /// <returns><see cref="User"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public User UpdateUser(string userId, User user)
        {
            try
            {
                var req = user.CreatePutRequest();
                return User.Map(adminApi.UpdateUser(userId, req));
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Update user asynchronously.
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.UpdateUserAsync(string, User)"/> method.
        /// <code>
        /// try
        /// {
        ///     var updatedInfo = new User
        ///     {
        ///         FullName = "Sir Monty Bot",
        ///         Username = "montybot2",
        ///     }
        ///     var updatedUser = await accountApi.UpdateUserAsync("015c3c46514802420a010b1000000000", updatedInfo);
        ///     return updatedUser;
        /// }
        /// catch (Exception)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="userId"><see cref="User.Id"/></param>
        /// <param name="user"><see cref="User"/></param>
        /// <returns><see cref="User"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public async Task<User> UpdateUserAsync(string userId, User user)
        {
            try
            {
                var req = user.CreatePutRequest();
                var userData = await adminApi.UpdateUserAsync(userId, req);
                return User.Map(userData);
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Delete user.
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.DeleteUser(string)"/> method.
        /// <code>
        /// try
        /// {
        ///     accountApi.DeleteUser("015c3c46514802420a010b1000000000");
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="userId"><see cref="User.Id"/></param>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public void DeleteUser(string userId)
        {
            try
            {
                adminApi.DeleteUser(userId);
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Delete user asynchronously.
        /// </summary>
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.DeleteUserAsync(string)"/> method.
        /// <code>
        /// try
        /// {
        ///     accountApi.DeleteUser("015c3c46514802420a010b1000000000");
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="userId"><see cref="User.Id"/></param>
        /// <returns><see cref="Task"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public async Task DeleteUserAsync(string userId)
        {
            try
            {
                await adminApi.DeleteUserAsync(userId);
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
