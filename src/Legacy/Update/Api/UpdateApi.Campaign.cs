﻿// <copyright file="UpdateApi.Campaign.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Api
{
    using System;
    using System.Threading.Tasks;
    using Mbed.Cloud.Common;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Exceptions;
    using MbedCloudSDK.Update.Model.Campaign;
    using update_service.Model;
    using static MbedCloudSDK.Common.Utils;
    using QueryOptions = Common.QueryOptions;

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
        public PaginatedResponse<QueryOptions, Campaign> ListCampaigns(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                return new PaginatedResponse<QueryOptions, Campaign>(ListCampaignsFunc, options);
            }
            catch (CloudApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        private async Task<ResponsePage<Campaign>> ListCampaignsFunc(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                var resp = await Api.UpdateCampaignListAsync(limit: options.Limit, order: options.Order, after: options.After, filter: options.Filter?.FilterString, include: options.Include);
                var responsePage = new ResponsePage<Campaign>(after: resp.After, hasMore: resp.HasMore, totalCount: resp.TotalCount);
                responsePage.MapData<UpdateCampaign>(resp.Data, Campaign.Map);
                return responsePage;
            }
            catch (update_service.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// List campaign Device States
        /// </summary>
        /// <param name="campaignId">The Id of the Campaign to list the states of.</param>
        /// <param name="options"><see cref="QueryOptions"/></param>
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
        ///     var campaignStates = updateApi.ListCampaignDeviceStates("015baf5f4f04000000000001001003d5", options);
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
        public PaginatedResponse<QueryOptions, CampaignDeviceState> ListCampaignDeviceStates(string campaignId, QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            options.Id = campaignId;

            try
            {
                return new PaginatedResponse<QueryOptions, CampaignDeviceState>(ListCampaignDeviceStatesFunc, options);
            }
            catch (CloudApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        private async Task<ResponsePage<CampaignDeviceState>> ListCampaignDeviceStatesFunc(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                var resp = await Api.UpdateCampaignMetadataListAsync(campaignId: options.Id, limit: options.Limit, order: options.Order, after: options.After, include: options.Include);
                var responsePage = new ResponsePage<CampaignDeviceState>(after: resp.After, hasMore: resp.HasMore, totalCount: resp.TotalCount);
                responsePage.MapData<CampaignDeviceMetadata>(resp.Data, CampaignDeviceState.Map);
                return responsePage;
            }
            catch (update_service.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get update campaign.
        /// </summary>
        /// <param name="campaignId">Id</param>
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
                var resp = Api.UpdateCampaignRetrieve(campaignId);
                return Campaign.Map(resp);
            }
            catch (update_service.Client.ApiException e)
            {
                return HandleNotFound<Campaign, update_service.Client.ApiException>(e);
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
                var resp = Api.UpdateCampaignCreate(campaign.CreatePostRequest());
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
        /// <param name="campaignId">Id of the campaign to start</param>
        /// <param name="campaign"><see cref="Campaign"/></param>
        /// <returns><see cref="Campaign"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var campaign = api.GetCampaign("015baf5f4f04000000000001001003d5");
        ///     var startedCampaign = updateApi.StartCampaign(campaign.Id, campaign);
        ///     return startedCampaign;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public Campaign StartCampaign(string campaignId, Campaign campaign)
        {
            try
            {
                campaign.State = CampaignStateEnum.Scheduled;
                var resp = Api.UpdateCampaignUpdate(campaignId, campaign.CreatePutRequest());
                return Campaign.Map(resp);
            }
            catch (update_service.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Stop an update campaign.
        /// </summary>
        /// <param name="campaignId">Id of the campaign to stop.</param>
        /// <param name="campaign"><see cref="Campaign"/></param>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <returns><see cref="Campaign"/></returns>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var campaign = api.GetCampaign("015baf5f4f04000000000001001003d5");
        ///     var startedCampaign = updateApi.StartCampaign(campaign.Id, campaign);
        ///     Thread.Sleep(10000);
        ///     var stoppedCampaign = updateApi.StopCampaign(campaign.Id, startedCampaign);
        ///     return stoppedCampaign;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public Campaign StopCampaign(string campaignId, Campaign campaign)
        {
            try
            {
                campaign.State = CampaignStateEnum.Draft;
                var resp = Api.UpdateCampaignUpdate(campaignId, campaign.CreatePutRequest());
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
        /// <param name="campaignId">Id</param>
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
                var response = Api.UpdateCampaignUpdate(campaignId, campaign.CreatePutRequest());
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
        /// <param name="campaignId">Id</param>
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
                Api.UpdateCampaignDestroy(campaignId);
            }
            catch (update_service.Client.ApiException e)
            {
                HandleNotFound<Campaign, update_service.Client.ApiException>(e);
            }
        }
    }
}
