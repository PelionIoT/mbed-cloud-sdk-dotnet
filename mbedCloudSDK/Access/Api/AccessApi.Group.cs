using iam.Api;
using mbedCloudSDK.Access.Model.Group;
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
                options = new DeviceQueryOptions();
            }
            try
            {
                var resp = developerApi.GetAllGroups(options.Limit, options.Order, options.After, options.Include);
                ResponsePage<Group> respGroups = new ResponsePage<Group>(resp.After, resp.HasMore, resp.Limit, null, resp.TotalCount);
                foreach (var group in resp.Data)
                {
                    respGroups.Data.Add(Group.Map(group));
                }
                return respGroups;
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
