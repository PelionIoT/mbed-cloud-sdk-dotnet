using mbedCloudSDK.Common;
using mbedCloudSDK.Common.Query;
using mbedCloudSDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mbedCloudSDK.Update.Model.Campaign;

namespace mbedCloudSDK.Update.Api
{
    public partial class UpdateApi
    {
        /// <summary>
        /// List update campaigns.
        /// </summary>
        /// <param name="options">Query options.</param>
        /// <returns></returns>
        public PaginatedResponse<Model.Campaign.UpdateCampaign> ListCampaigns(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }
            try
            {
                return new PaginatedResponse<Model.Campaign.UpdateCampaign>(ListCampaignsFunc, options);
            }
            catch (CloudApiException e)
            {
                throw e;
            }
        }

        private ResponsePage<Model.Campaign.UpdateCampaign> ListCampaignsFunc(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }
            try
            {
                var resp = deploymentApi.UpdateCampaignList(options.Limit, options.Order, options.After, options.QueryString, options.Include);
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
        public Model.Campaign.UpdateCampaign GetCampaign(string campaignId)
        {
            try
            {
                var resp = deploymentApi.UpdateCampaignRetrieve(campaignId);
                return Model.Campaign.UpdateCampaign.Map(resp);
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Create update campaign.
        /// </summary>
        /// <param name="updateCampaign">Update campaign that will be created.</param>
        /// <returns></returns>
        public Model.Campaign.UpdateCampaign AddCampaign(Model.Campaign.UpdateCampaign updateCampaign)
        {
            try
            {
                var resp = deploymentApi.UpdateCampaignCreate(updateCampaign.CreatePostRequest());
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
        public Model.Campaign.UpdateCampaign StartCampaign(Model.Campaign.UpdateCampaign updateCampaign)
        {
            try
            {
                var resp = deploymentApi.UpdateCampaignUpdate(updateCampaign.Id, updateCampaign.CreatePutRequest());
                return Model.Campaign.UpdateCampaign.Map(resp);
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Update update campaign.
        /// </summary>
        /// <param name="updateCampaign">Update campaign to be updated.</param>
        public UpdateCampaign UpdateCampaign(UpdateCampaign updateCampaign)
        {
            try
            {
                var stateEnum = (deployment_service.Model.UpdateCampaignPatchRequest.StateEnum)Enum.Parse(typeof(deployment_service.Model.UpdateCampaignPatchRequest.StateEnum), updateCampaign.State.ToString());
                var updateCampaignPatchRequest = new deployment_service.Model.UpdateCampaignPatchRequest()
                {
                    Description = updateCampaign.Description,
                    RootManifestId = updateCampaign.RootManifestId,
                    _Object = updateCampaign._Object,
                    When = updateCampaign.When,
                    State = stateEnum,
                    DeviceFilter = updateCampaign.DeviceFilter,
                    Name = updateCampaign.Name
                };
                var response = deploymentApi.UpdateCampaignPartialUpdate(updateCampaign.Id, updateCampaignPatchRequest);
                return mbedCloudSDK.Update.Model.Campaign.UpdateCampaign.Map(response);
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
                deploymentApi.UpdateCampaignDestroy(upateCampaignId);
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
