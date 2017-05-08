using mbedCloudSDK.Common;
using mbedCloudSDK.Common.Query;
using mbedCloudSDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Update.Api
{
    public partial class UpdateApi
    {
        /// <summary>
        /// List update campaigns.
        /// </summary>
        /// <param name="options">Query options.</param>
        /// <returns></returns>
        public PaginatedResponse<Model.Campaign.UpdateCampaign> ListUpdateCampaigns(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }
            try
            {
                return new PaginatedResponse<Model.Campaign.UpdateCampaign>(ListUpdateCampaignsFunc, options);
            }
            catch (CloudApiException e)
            {
                throw e;
            }
        }

        private ResponsePage<Model.Campaign.UpdateCampaign> ListUpdateCampaignsFunc(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }
            try
            {
                var resp = updateApi.UpdateCampaignList(options.Limit, options.Order, options.After, options.QueryString, options.Include);
                ResponsePage<Model.Campaign.UpdateCampaign> respDevices = new ResponsePage<Model.Campaign.UpdateCampaign>(resp.After, resp.HasMore, resp.Limit, resp.Order, resp.TotalCount);
                foreach (var device in resp.Data)
                {
                    respDevices.Data.Add(Model.Campaign.UpdateCampaign.Map(device));
                }
                return respDevices;
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get update campaign.
        /// </summary>
        /// <param name="campaignId">Id of the update campaign.</param>
        /// <returns></returns>
        public Model.Campaign.UpdateCampaign GetUpdateCampaign(string campaignId)
        {
            try
            {
                var resp = updateApi.UpdateCampaignRetrieve(campaignId);
                return Model.Campaign.UpdateCampaign.Map(resp);
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /*
        /// <summary>
        /// Get status of the update campaign.
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public UpdateCampaignStatus GetUpdateCampaignStatus(string campaignId)
        {
            try
            {
                var resp = updateApi.UpdateCampaignStatus(campaignId);
                return UpdateCampaignStatus.Map(resp);
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
        */

        /// <summary>
        /// Create update campaign.
        /// </summary>
        /// <param name="updateCampaign">Update campaign that will be created.</param>
        /// <returns></returns>
        public Model.Campaign.UpdateCampaign AddUpdateCampaign(Model.Campaign.UpdateCampaign updateCampaign)
        {
            try
            {
                var resp = updateApi.UpdateCampaignCreate(updateCampaign.CreatePostRequest());
                return Model.Campaign.UpdateCampaign.Map(resp);
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Start update campaign.
        /// </summary>
        /// <param name="updateCampaign">Update campaign to be started.</param>
        /// <returns></returns>
        public Model.Campaign.UpdateCampaign StartUpdateCampaign(Model.Campaign.UpdateCampaign updateCampaign)
        {
            try
            {
                var resp = updateApi.UpdateCampaignUpdate(updateCampaign.Id, updateCampaign.CreatePutRequest());
                return Model.Campaign.UpdateCampaign.Map(resp);
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Delete Update campaign.
        /// </summary>
        /// <param name="upateCampaignId">Id of the update campaign.</param>
        public void DeleteUpdateCampaign(string upateCampaignId)
        {
            try
            {
                updateApi.UpdateCampaignDestroy(upateCampaignId);
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
