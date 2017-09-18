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

    public partial class AccountManagementApi
    {
        /// <summary>
        /// List users.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Lists the device logs.
        /// </summary>
        /// <returns>The device logs.</returns>
        /// <param name="options">Query options.</param>
        private ResponsePage<User> ListUsersFunc(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                var resp = adminApi.GetAllUsers(options.Limit, options.Order, options.After, options.Include, options.Filter.FilterString);
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
        /// Get user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
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
        /// <param name="userId"></param>
        /// <returns></returns>
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
        /// <param name="user"></param>
        /// <returns></returns>
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
        /// <param name="user"></param>
        /// <returns></returns>
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
        /// <param name="user"></param>
        /// <returns></returns>
        public User UpdateUser(User user)
        {
            try
            {
                var req = user.CreatePutRequest();
                return User.Map(adminApi.UpdateUser(user.Id, req));
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Update user asynchronously.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> UpdateUserAsync(User user)
        {
            try
            {
                var req = user.CreatePutRequest();
                var userData = await adminApi.UpdateUserAsync(user.Id, req);
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
        /// <param name="userId"></param>
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
        /// <param name="userId"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
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
