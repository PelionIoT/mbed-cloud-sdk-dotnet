// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="UpdateCampaignRepository.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation
{
    using Mbed.Cloud.Common;
    using Mbed.Cloud.Foundation;
    using System.Threading.Tasks;
    using MbedCloudSDK.Exceptions;
    using System.Collections.Generic;
    using System;
    using Mbed.Cloud.RestClient;

    /// <summary>
    /// UpdateCampaignRepository
    /// </summary>
    public class UpdateCampaignRepository : Repository, IUpdateCampaignRepository
    {
        public UpdateCampaignRepository()
        {
        }

        public UpdateCampaignRepository(Config config, Client client = null) : base(config, client)
        {
        }

        public async Task<UpdateCampaign> Archive(string id)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "campaign_id", id }, };
                return await Client.CallApi<UpdateCampaign>(path: "/v3/update-campaigns/{campaign_id}/archive", pathParams: pathParams, method: HttpMethods.POST);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<UpdateCampaign> Create(UpdateCampaign request)
        {
            try
            {
                var bodyParams = new UpdateCampaign { Description = request.Description, DeviceFilter = request.DeviceFilter, Name = request.Name, RootManifestId = request.RootManifestId, When = request.When, };
                return await Client.CallApi<UpdateCampaign>(path: "/v3/update-campaigns/", bodyParams: bodyParams, objectToUnpack: request, method: HttpMethods.POST);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "campaign_id", id }, };
                await Client.CallApi<UpdateCampaign>(path: "/v3/update-campaigns/{campaign_id}/", pathParams: pathParams, method: HttpMethods.DELETE);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public PaginatedResponse<IUpdateCampaignCampaignDeviceMetadataListOptions, CampaignDeviceMetadata> DeviceMetadata(string id, IUpdateCampaignCampaignDeviceMetadataListOptions options = null)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "campaign_id", id }, };
                if (options == null)
                {
                    options = new UpdateCampaignCampaignDeviceMetadataListOptions();
                }

                Func<IUpdateCampaignCampaignDeviceMetadataListOptions, Task<ResponsePage<CampaignDeviceMetadata>>> paginatedFunc = async (IUpdateCampaignCampaignDeviceMetadataListOptions _options) => { var queryParams = new Dictionary<string, object> { { "after", _options.After }, { "include", _options.Include }, { "limit", _options.Limit }, { "order", _options.Order }, }; return await Client.CallApi<ResponsePage<CampaignDeviceMetadata>>(path: "/v3/update-campaigns/{campaign_id}/campaign-device-metadata/", pathParams: pathParams, queryParams: queryParams, method: HttpMethods.GET); };
                return new PaginatedResponse<IUpdateCampaignCampaignDeviceMetadataListOptions, CampaignDeviceMetadata>(paginatedFunc, options);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public PaginatedResponse<IUpdateCampaignUpdateCampaignListOptions, UpdateCampaign> List(IUpdateCampaignUpdateCampaignListOptions options = null)
        {
            try
            {
                if (options == null)
                {
                    options = new UpdateCampaignUpdateCampaignListOptions();
                }

                Func<IUpdateCampaignUpdateCampaignListOptions, Task<ResponsePage<UpdateCampaign>>> paginatedFunc = async (IUpdateCampaignUpdateCampaignListOptions _options) => { var queryParams = new Dictionary<string, object> { { "after", _options.After }, { "include", _options.Include }, { "limit", _options.Limit }, { "order", _options.Order }, { "created_at__in", _options.Filter.GetEncodedValue("created_at", "$in") }, { "created_at__nin", _options.Filter.GetEncodedValue("created_at", "$nin") }, { "created_at__lte", _options.Filter.GetEncodedValue("created_at", "$lte") }, { "created_at__gte", _options.Filter.GetEncodedValue("created_at", "$gte") }, { "description__eq", _options.Filter.GetEncodedValue("description", "$eq") }, { "description__neq", _options.Filter.GetEncodedValue("description", "$neq") }, { "description__in", _options.Filter.GetEncodedValue("description", "$in") }, { "description__nin", _options.Filter.GetEncodedValue("description", "$nin") }, { "device_filter__eq", _options.Filter.GetEncodedValue("device_filter", "$eq") }, { "device_filter__neq", _options.Filter.GetEncodedValue("device_filter", "$neq") }, { "device_filter__in", _options.Filter.GetEncodedValue("device_filter", "$in") }, { "device_filter__nin", _options.Filter.GetEncodedValue("device_filter", "$nin") }, { "finished__in", _options.Filter.GetEncodedValue("finished", "$in") }, { "finished__nin", _options.Filter.GetEncodedValue("finished", "$nin") }, { "finished__lte", _options.Filter.GetEncodedValue("finished", "$lte") }, { "finished__gte", _options.Filter.GetEncodedValue("finished", "$gte") }, { "id__eq", _options.Filter.GetEncodedValue("id", "$eq") }, { "id__neq", _options.Filter.GetEncodedValue("id", "$neq") }, { "id__in", _options.Filter.GetEncodedValue("id", "$in") }, { "id__nin", _options.Filter.GetEncodedValue("id", "$nin") }, { "name__eq", _options.Filter.GetEncodedValue("name", "$eq") }, { "name__neq", _options.Filter.GetEncodedValue("name", "$neq") }, { "name__in", _options.Filter.GetEncodedValue("name", "$in") }, { "name__nin", _options.Filter.GetEncodedValue("name", "$nin") }, { "root_manifest_id__eq", _options.Filter.GetEncodedValue("root_manifest_id", "$eq") }, { "root_manifest_id__neq", _options.Filter.GetEncodedValue("root_manifest_id", "$neq") }, { "root_manifest_id__in", _options.Filter.GetEncodedValue("root_manifest_id", "$in") }, { "root_manifest_id__nin", _options.Filter.GetEncodedValue("root_manifest_id", "$nin") }, { "started_at__in", _options.Filter.GetEncodedValue("started_at", "$in") }, { "started_at__nin", _options.Filter.GetEncodedValue("started_at", "$nin") }, { "started_at__lte", _options.Filter.GetEncodedValue("started_at", "$lte") }, { "started_at__gte", _options.Filter.GetEncodedValue("started_at", "$gte") }, { "state__eq", _options.Filter.GetEncodedValue("state", "$eq") }, { "state__neq", _options.Filter.GetEncodedValue("state", "$neq") }, { "state__in", _options.Filter.GetEncodedValue("state", "$in") }, { "state__nin", _options.Filter.GetEncodedValue("state", "$nin") }, { "updated_at__in", _options.Filter.GetEncodedValue("updated_at", "$in") }, { "updated_at__nin", _options.Filter.GetEncodedValue("updated_at", "$nin") }, { "updated_at__lte", _options.Filter.GetEncodedValue("updated_at", "$lte") }, { "updated_at__gte", _options.Filter.GetEncodedValue("updated_at", "$gte") }, { "when__in", _options.Filter.GetEncodedValue("when", "$in") }, { "when__nin", _options.Filter.GetEncodedValue("when", "$nin") }, { "when__lte", _options.Filter.GetEncodedValue("when", "$lte") }, { "when__gte", _options.Filter.GetEncodedValue("when", "$gte") }, }; return await Client.CallApi<ResponsePage<UpdateCampaign>>(path: "/v3/update-campaigns/", queryParams: queryParams, method: HttpMethods.GET); };
                return new PaginatedResponse<IUpdateCampaignUpdateCampaignListOptions, UpdateCampaign>(paginatedFunc, options);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<UpdateCampaign> Read(string id)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "campaign_id", id }, };
                return await Client.CallApi<UpdateCampaign>(path: "/v3/update-campaigns/{campaign_id}/", pathParams: pathParams, method: HttpMethods.GET);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<UpdateCampaign> Start(string id)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "campaign_id", id }, };
                return await Client.CallApi<UpdateCampaign>(path: "/v3/update-campaigns/{campaign_id}/start", pathParams: pathParams, method: HttpMethods.POST);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<UpdateCampaign> Stop(string id)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "campaign_id", id }, };
                return await Client.CallApi<UpdateCampaign>(path: "/v3/update-campaigns/{campaign_id}/stop", pathParams: pathParams, method: HttpMethods.POST);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public async Task<UpdateCampaign> Update(string id, UpdateCampaign request)
        {
            try
            {
                var pathParams = new Dictionary<string, object> { { "campaign_id", id }, };
                var bodyParams = new UpdateCampaign { Description = request.Description, DeviceFilter = request.DeviceFilter, Name = request.Name, RootManifestId = request.RootManifestId, When = request.When, };
                return await Client.CallApi<UpdateCampaign>(path: "/v3/update-campaigns/{campaign_id}/", pathParams: pathParams, bodyParams: bodyParams, objectToUnpack: request, method: HttpMethods.PUT);
            }
            catch (ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}