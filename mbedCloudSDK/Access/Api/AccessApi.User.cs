using iam.Api;
using iam.Model;
using mbedCloudSDK.Access.Model.User;
using mbedCloudSDK.Common;
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
        public List<User> ListUsers(ListParams listParams = null)
        {
            if (listParams != null)
            {
                listParams = new ListParams();
            }
            try
            {
                List<User> users = new List<User>();
                foreach (var user in adminApi.GetAllUsers().Data)
                {
                    users.Add(User.Map(user));
                }
                return users;
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// List users asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> ListUsersAsynchronously(ListParams listParams = null)
        {
            if (listParams != null)
            {
                throw new NotImplementedException();
            }
            try
            {
                List<User> users = new List<User>();
                var usersInfo = await adminApi.GetAllUsersAsync();
                foreach (var user in usersInfo.Data)
                {
                    users.Add(User.Map(user));
                }
                return users;
            }
            catch (iam.Client.ApiException e)
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
