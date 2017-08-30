using mbedCloudSDK.AccountManagement.Model.ApiKey;
using mbedCloudSDK.AccountManagement.Model.Group;
using mbedCloudSDK.AccountManagement.Model.User;
using mbedCloudSDK.Common;
using mbedCloudSDK.Common.Query;
using mbedCloudSDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.AccountManagement.Api
{
    public partial class AccountManagementApi
    {
        /// <summary>
        /// List groups.
        /// </summary>
        /// <returns></returns>
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
                var resp = this.developerApi.GetAllGroups(options.Limit, options.After, options.Order, options.Include);
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
                var groupData = this.developerApi.GetGroupSummary(groupId);
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
        /// <param name="groupId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
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
                var resp = this.adminApi.GetUsersOfGroup(options.Id, options.Limit, options.After, options.Order, options.Include);
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
        /// <param name="groupId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
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
                var resp = this.developerApi.GetApiKeysOfGroup(options.Id, options.Limit, options.After, options.Order, options.Include);
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
