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
        /// <param name="options"><see cref="QueryOptions"/></param>
        /// <returns>Paginated Response of <see cref="Campaign"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var options = new QueryOptions
        ///     {
        ///         Limit = 5,
        ///     };
        ///     var campaigns = updateApi.ListCampaigns(Options);
        ///     foreach (var item in campaigns)
        ///     {
        ///         Console.WriteLine(item);
        ///     }
        ///     return campaigns;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
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
        /// <param name="options"><see cref="Campaign"/></param>
        /// <returns>Paginated Response of <see cref="CampaignDeviceState"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var options = new QueryOptions
        ///     {
        ///         Limit = 5,
        ///     };
        ///     var campaignStates = updateApi.ListCampaignDeviceStates(Options);
        ///     foreach (var item in campaignStates)
        ///     {
        ///         Console.WriteLine(item);
        ///     }
        ///     return campaignStates;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
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
                var respStates = new ResponsePage<CampaignDeviceState>(after: resp.After, hasMore: resp.HasMore, limit: resp.Limit, order: Convert.ToString(resp.Order), totalCount: resp.TotalCount);
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
        /// <param name="campaignId"><see cref="Campaign.Id"/></param>
        /// <returns><see cref="Campaign"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var campaign = updateApi.GetCampaign("015baf5f4f04000000000001001003d5");
        ///     return campaign;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
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
        /// <param name="campaign"><see cref="Campaign"/></param>
        /// <returns><see cref="Campaign"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     // List all queries
        ///     var devicesApi = new DeviceDirectoryApi(config);
        ///     var queries = devicesApi.ListQueries();
        ///     var query = queries.LastOrDefault();
        ///
        ///     var campaign = new Campaign
        ///     {
        ///         Name = "new campaign",
        ///         ManifestId = manifestId,
        ///         DeviceFilter = query.Filter,
        ///     };
        ///     campaign = api.AddCampaign(campaign);
        ///     return campaign;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
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
        /// <param name="campaign"><see cref="Campaign"/></param>
        /// <returns><see cref="Campaign"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var campaign = api.GetCampaign("015baf5f4f04000000000001001003d5");
        ///     var startedCampaign = updateApi.StartCampaign(campaign);
        ///     return startedCampaign;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
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
        /// <param name="campaignId"><see cref="Campaign.Id"/></param>
        /// <param name="campaign"><see cref="Campaign"/></param>
        /// <returns><see cref="Campaign"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var campaign = updateApi.GetCampaign("015baf5f4f04000000000001001003d5");
        ///     var fieldsToUpdate = new Campaign
        ///     {
        ///         Name = "updatedName",
        ///     };
        ///     var updatedCampaign = updateApi.UpdateCampaign(campaign.Id, fieldsToUpdate);
        ///     return updatedCampaign;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public Campaign UpdateCampaign(string campaignId, Campaign campaign)
        {
            try
            {
                var stateEnum = Utils.ParseEnum<update_service.Model.UpdateCampaignPatchRequest.StateEnum>(campaign.State);
                var updateCampaignPatchRequest = new update_service.Model.UpdateCampaignPatchRequest
                {
                    Description = campaign.Description,
                    RootManifestId = campaign.ManifestId,
                    _Object = campaign.Object,
                    When = campaign.When,
                    State = stateEnum,
                    DeviceFilter = campaign?.DeviceFilter?.FilterString,
                    Name = campaign.Name
                };
                var response = api.UpdateCampaignPartialUpdate(campaignId, updateCampaignPatchRequest);
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
        /// <param name="campaignId"><see cref="Campaign.Id"/></param>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     updateApi.DeleteCampaign("015baf5f4f04000000000001001003d5");
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
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
