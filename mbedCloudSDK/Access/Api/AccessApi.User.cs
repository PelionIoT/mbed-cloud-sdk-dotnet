using iam.Api;
using iam.Model;
using mbedCloudSDK.Access.Model.User;
using mbedCloudSDK.Common;
using mbedCloudSDK.Common.Query;
using mbedCloudSDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Access.Api
{
    public partial class AccessApi
    {
        /// <summary>
        /// List users.
        /// </summary>
        /// <returns></returns>
        public PaginatedResponse<User> ListUsers(QueryOptions options = null)
        {
            if (options != null)
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
                var resp = adminApi.GetAllUsers(options.Limit, options.Order, options.After, options.QueryString, options.Include);
                ResponsePage<User> respUsers = new ResponsePage<User>(resp.After, resp.HasMore, resp.Limit, null, resp.TotalCount);
                foreach (var user in resp.Data)
                {
                    respUsers.Data.Add(User.Map(user));
                }
                return respUsers;
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUser(String userId)
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
        public async Task<User> GetUserAsync(String userId)
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
        /// <param name="body"></param>
        /// <returns></returns>
        public User AddUser(User body)
        {
            try
            {
                UserInfoReq req = new UserInfoReq(body.Username, body.PhoneNumber, body.IsMarketingAccepted, body.Groups, body.IsGtcAccepted,
                    body.FullName, body.Address, body.Password, body.Email);
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
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<User> AddUserAsync(User body)
        {
            try
            {
                UserInfoReq req = new UserInfoReq(body.Username, body.PhoneNumber, body.IsMarketingAccepted, body.Groups, body.IsGtcAccepted,
                    body.FullName, body.Address, body.Password, body.Email);
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
        /// <param name="body"></param>
        /// <returns></returns>
        public User UpdateUser(User body)
        {
            try
            {
                UserUpdateReq req = new UserUpdateReq(body.Username, body.PhoneNumber, body.IsMarketingAccepted, body.IsGtcAccepted,
                    body.FullName, body.Address, body.Password, body.Email);
                return User.Map(adminApi.UpdateUser(body.Id, req));
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Update user asynchronously.
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<User> UpdateUserAsync(User body)
        {
            try
            {
                UserUpdateReq req = new UserUpdateReq(body.Username, body.PhoneNumber, body.IsMarketingAccepted, body.IsGtcAccepted,
                    body.FullName, body.Address, body.Password, body.Email);
                var user = await adminApi.UpdateUserAsync(body.Id, req);
                return User.Map(user);
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
        public void DeleteUser(String userId)
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
        public async Task DeleteUserAsync(String userId)
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
