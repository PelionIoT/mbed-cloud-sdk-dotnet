// <copyright file="UpdateApi.Campaign.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Api
{
    using System;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Query;
    using MbedCloudSDK.Exceptions;
    using MbedCloudSDK.Update.Model.Campaign;

    /// <summary>
    /// Update Api
    /// </summary>
    public partial class UpdateApi
    {
        /// <summary>
        /// List update campaigns.
        /// </summary>
        /// <param name="options">Query options.</param>
        /// <returns>Paginated Response of Campaigns</returns>
        public PaginatedResponse<Campaign> ListCampaigns(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                return new PaginatedResponse<Campaign>(ListCampaignsFunc, options);
            }
            catch (CloudApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        private ResponsePage<Campaign> ListCampaignsFunc(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                var resp = api.UpdateCampaignList(limit: options.Limit, order: options.Order, after: options.After, filter: options.Filter?.FilterString, include: options.Include);
                var respDevices = new ResponsePage<Campaign>(resp.After, resp.HasMore, resp.Limit, resp.Order.ToString(), resp.TotalCount);
                foreach (var device in resp.Data)
                {
                    respDevices.Data.Add(Campaign.Map(device));
                }

                return respDevices;
            }
            catch (update_service.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// List campaign Device States
        /// </summary>
        /// <param name="options">Query Options</param>
        /// <returns>Paginated Response of Campaign Device States</returns>
        public PaginatedResponse<CampaignDeviceState> ListCampaignDeviceStates(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                return new PaginatedResponse<CampaignDeviceState>(ListCampaignDeviceStatesFunc, options);
            }
            catch (CloudApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        private ResponsePage<CampaignDeviceState> ListCampaignDeviceStatesFunc(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                var resp = api.V3UpdateCampaignsCampaignIdCampaignDeviceMetadataGet(campaignId: options.Id, limit: options.Limit, order: options.Order, after: options.After, include: options.Include);
                var respStates = new ResponsePage<CampaignDeviceState>(after: resp.After, hasMore: resp.HasMore, limit: resp.Limit, order: resp.Order.ToString(), totalCount: resp.TotalCount);
                foreach (var state in resp.Data)
                {
                    respStates.Data.Add(CampaignDeviceState.Map(state));
                }

                return respStates;
            }
            catch (update_service.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get update campaign.
        /// </summary>
        /// <param name="campaignId">Id of the update campaign.</param>
        /// <returns>Campaign</returns>
        public Campaign GetCampaign(string campaignId)
        {
            try
            {
                var resp = api.UpdateCampaignRetrieve(campaignId);
                return Campaign.Map(resp);
            }
            catch (update_service.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Create update campaign.
        /// </summary>
        /// <param name="campaign">Update campaign that will be created.</param>
        /// <returns>Campaign</returns>
        public Campaign AddCampaign(Campaign campaign)
        {
            try
            {
                var resp = api.UpdateCampaignCreate(campaign.CreatePostRequest());
                return Campaign.Map(resp);
            }
            catch (update_service.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Start update campaign.
        /// </summary>
        /// <param name="campaign">Update campaign to be started.</param>
        /// <returns>Campaign</returns>
        public Campaign StartCampaign(Campaign campaign)
        {
            try
            {
                var resp = api.UpdateCampaignUpdate(campaign.Id, campaign.CreatePutRequest());
                return Campaign.Map(resp);
            }
            catch (update_service.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Update update campaign.
        /// </summary>
        /// <param name="campaign">Update campaign to be updated.</param>
        /// <returns>Campaign</returns>
        public Campaign UpdateCampaign(Campaign campaign)
        {
            try
            {
                var stateEnum = (update_service.Model.UpdateCampaignPatchRequest.StateEnum)Enum.Parse(typeof(update_service.Model.UpdateCampaignPatchRequest.StateEnum), campaign.State.ToString());
                var updateCampaignPatchRequest = new update_service.Model.UpdateCampaignPatchRequest
                {
                    Description = campaign.Description,
                    RootManifestId = campaign.ManifestId,
                    _Object = campaign.Object,
                    When = campaign.When,
                    State = stateEnum,
                    DeviceFilter = campaign.DeviceFilter.FilterString,
                    Name = campaign.Name
                };
                var response = api.UpdateCampaignPartialUpdate(campaign.Id, updateCampaignPatchRequest);
                return Campaign.Map(response);
            }
            catch (update_service.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Delete Update campaign.
        /// </summary>
        /// <param name="campaignId">Id of the update campaign.</param>
        public void DeleteCampaign(string campaignId)
        {
            try
            {
                api.UpdateCampaignDestroy(campaignId);
            }
            catch (update_service.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
