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
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.ListGroups(QueryOptions)"/> method.
        /// <code>
        /// try
        /// {
        ///     var options = new QueryOptions
        ///     {
        ///         Limit = 5,
        ///     };
        ///     var groups = accountApi.ListGroups(options);
        ///     foreach (item in groups)
        ///     {
        ///         Console.WriteLine(item);
        ///     }
        ///     return groups;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="options"><see cref="QueryOptions"/></param>
        /// <returns>Paginated Response of <see cref="Group"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public PaginatedResponse<QueryOptions, Group> ListGroups(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                return new PaginatedResponse<QueryOptions, Group>(ListGroupsFunc, options);
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
                var resp = DeveloperApi.GetAllGroups(limit: options.Limit, after: options.After, order: options.Order, include: options.Include);
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
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.GetGroup(string)"/> method.
        /// <code>
        /// try
        /// {
        ///     var group = accountApi.GetGroup("015b5c9279ee02420a01041200000000");
        ///     return group;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="groupId">Id</param>
        /// <returns><see cref="Group"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public Group GetGroup(string groupId)
        {
            try
            {
                var groupData = DeveloperApi.GetGroupSummary(groupId);
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
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.ListGroupUsers(string, QueryOptions)"/> method.
        /// <code>
        /// try
        /// {
        ///     var options = new QueryOptions
        ///     {
        ///         Limit = 5,
        ///     };
        ///     var users = accountApi.ListGroupUsers("015b5c9279ee02420a01041200000000", options);
        ///     foreach (item in users)
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
        /// <param name="groupId">Id</param>
        /// <param name="options"><see cref="QueryOptions"/></param>
        /// <returns>Paginated Respoinse with <see cref="User"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public PaginatedResponse<QueryOptions, User> ListGroupUsers(string groupId, QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            options.Id = groupId;
            try
            {
                return new PaginatedResponse<QueryOptions, User>(ListGroupUsersFunc, options);
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
                var resp = AdminApi.GetUsersOfGroup(groupID: options.Id, limit: options.Limit, after: options.After, order: options.Order, include: options.Include);
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
        /// <example>
        /// This example shows how to use the <see cref="AccountManagementApi.ListGroupApiKeys(string, QueryOptions)"/> method.
        /// <code>
        /// try
        /// {
        ///     var options = new QueryOptions
        ///     {
        ///         Limit = 5,
        ///     };
        ///     var keys = accountApi.ListGroupApiKeys("015b5c9279ee02420a01041200000000", options);
        ///     foreach (item in keys)
        ///     {
        ///         Console.WriteLine(item);
        ///     }
        ///     return keys;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <param name="groupId">Id</param>
        /// <param name="options"><see cref="QueryOptions"/></param>
        /// <returns>Paginated Response of <see cref="ApiKey"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public PaginatedResponse<QueryOptions, ApiKey> ListGroupApiKeys(string groupId, QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            options.Id = groupId;
            try
            {
                return new PaginatedResponse<QueryOptions, ApiKey>(ListGroupApiKeysFunc, options);
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
                var resp = DeveloperApi.GetApiKeysOfGroup(groupID: options.Id, limit: options.Limit, after: options.After, order: options.Order, include: options.Include);
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
