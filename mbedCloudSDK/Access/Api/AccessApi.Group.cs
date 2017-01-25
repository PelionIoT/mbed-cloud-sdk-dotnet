using iam.Api;
using mbedCloudSDK.Access.Model.Group;
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
        /// List groups.
        /// </summary>
        /// <returns></returns>
        public List<Group> ListGroups(ListParams listParams = null)
        {
            if (listParams != null)
            {
                listParams = new ListParams();
            }
            try
            {
                List<Group> groups = new List<Group>();
                foreach (var group in developerApi.GetAllGroups().Data)
                {
                    groups.Add(Group.Map(group));
                }
                return groups;
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// List groups.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Group>> ListGroupsAsync(ListParams listParams = null)
        {
            if (listParams != null)
            {
                listParams = new ListParams();
            }
            try
            {
                var groupsInfo = await developerApi.GetAllGroupsAsync();
                List<Group> groups = new List<Group>();
                foreach (var group in groupsInfo.Data)
                {
                    groups.Add(Group.Map(group));
                }
                return groups;
            }
            catch (iam.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
