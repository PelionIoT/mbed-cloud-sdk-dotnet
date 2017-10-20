// <copyright file="AccountManagementApi.Group.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.AccountManagement.Api
{
    using MbedCloudSDK.AccountManagement.Model.ApiKey;
    using MbedCloudSDK.AccountManagement.Model.Group;
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
        /// List groups.
        /// </summary>
        /// <param name="options">Query options</param>
        /// <returns>Paginated Response of Groups</returns>
        public PaginatedResponse<Group> ListGroups(QueryOptions options = null)
        {
            if (options != null)
            {
                options = new QueryOptions();
            }

            try
            {
                return new PaginatedResponse<Group>(ListGroupsFunc, options);
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        private ResponsePage<Group> ListGroupsFunc(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                var resp = developerApi.GetAllGroups(limit: options.Limit, after: options.After, order: options.Order, include: options.Include);
                var respGroups = new ResponsePage<Group>(resp.After, resp.HasMore, resp.Limit, null, resp.TotalCount);
                foreach (var group in resp.Data)
                {
                    respGroups.Data.Add(Group.Map(group));
                }

                return respGroups;
            }
            catch (device_directory.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get details of a group.
        /// </summary>
        /// <param name="groupId">The group ID</param>
        /// <returns>Group</returns>
        public Group GetGroup(string groupId)
        {
            try
            {
                var groupData = developerApi.GetGroupSummary(groupId);
                return Group.Map(groupData);
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// List users of a group
        /// </summary>
        /// <param name="groupId">Group Id</param>
        /// <param name="options">Query Options</param>
        /// <returns>Paginated Respoinse with Users</returns>
        public PaginatedResponse<User> ListGroupUsers(string groupId, QueryOptions options = null)
        {
            if (options != null)
            {
                options = new QueryOptions();
            }

            options.Id = groupId;
            try
            {
                return new PaginatedResponse<User>(ListGroupUsersFunc, options);
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        private ResponsePage<User> ListGroupUsersFunc(QueryOptions options)
        {
            try
            {
                var resp = adminApi.GetUsersOfGroup(groupID: options.Id, limit: options.Limit, after: options.After, order: options.Order, include: options.Include);
                var respGroupUsers = new ResponsePage<User>(resp.After, resp.HasMore, resp.Limit, null, resp.TotalCount);
                foreach (var user in resp.Data)
                {
                    respGroupUsers.Data.Add(User.Map(user));
                }

                return respGroupUsers;
            }
            catch (device_directory.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// List API keys of a group.
        /// </summary>
        /// <param name="groupId">Group Id</param>
        /// <param name="options">Query Options</param>
        /// <returns>Paginated Response of Api Keys</returns>
        public PaginatedResponse<ApiKey> ListGroupApiKeys(string groupId, QueryOptions options = null)
        {
            if (options != null)
            {
                options = new QueryOptions();
            }

            options.Id = groupId;
            try
            {
                return new PaginatedResponse<ApiKey>(ListGroupApiKeysFunc, options);
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        private ResponsePage<ApiKey> ListGroupApiKeysFunc(QueryOptions options)
        {
            try
            {
                var resp = developerApi.GetApiKeysOfGroup(groupID: options.Id, limit: options.Limit, after: options.After, order: options.Order, include: options.Include);
                var respGroupKeys = new ResponsePage<ApiKey>(resp.After, resp.HasMore, resp.Limit, null, resp.TotalCount);
                foreach (var apiKey in resp.Data)
                {
                    respGroupKeys.Data.Add(ApiKey.Map(apiKey));
                }

                return respGroupKeys;
            }
            catch (device_directory.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
