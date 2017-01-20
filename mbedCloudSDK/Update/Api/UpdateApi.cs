using System;
using mbedCloudSDK.Common;
using firmware_catalog.Client;
using System.Collections.Generic;
using mbedCloudSDK.Exceptions;
using System.IO;
using deployment_service.Model;
using mbedCloudSDK.Update.Model;

namespace mbedCloudSDK.Update.Api
{
    /// <summary>
    /// Exposing functionality from: Update service, Update campaigns and Manifest management
    /// </summary>
    public class UpdateApi: BaseApi
    {
        private deployment_service.Api.DefaultApi updateApi;
        private firmware_catalog.Api.DefaultApi firmwareApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.Update"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
        public UpdateApi(Config config) : base(config)
        {
            if (config.Host != string.Empty)
            {
                Configuration.Default.ApiClient = new ApiClient(config.Host);
            }
            this.updateApi = new deployment_service.Api.DefaultApi(config.Host);
            this.updateApi.Configuration.ApiKey["Authorization"] = config.ApiKey;
            this.updateApi.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;

            this.firmwareApi = new firmware_catalog.Api.DefaultApi(config.Host);
            this.firmwareApi.Configuration.ApiKey["Authorization"] = config.ApiKey;
            this.firmwareApi.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
        }

        public PaginatedResponse<UpdateCampaign> ListUpdateCampaigns(ListParams listParams = null)
        {
            if (listParams == null)
            {
                listParams = new ListParams();
            }
            try
            {
                return new PaginatedResponse<UpdateCampaign>(ListUpdateCampaignsFunc, listParams);
            }
            catch (CloudApiException e)
            {
                throw e;
            }
        }

        private ResponsePage<UpdateCampaign> ListUpdateCampaignsFunc(ListParams listParams = null)
        {
            if (listParams == null)
            {
                listParams = new ListParams();
            }
            try
            {
                var resp = updateApi.UpdateCampaignList(listParams.Limit, listParams.Order, listParams.After, listParams.Filter, listParams.Include);
                ResponsePage<UpdateCampaign> respDevices = new ResponsePage<UpdateCampaign>(null, resp.HasMore, resp.Limit, resp.Order, resp.TotalCount);
                foreach (var device in resp.Data)
                {
                    respDevices.Data.Add(UpdateCampaign.Map(device));
                }
                return respDevices;
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Lists the firmware images.
        /// </summary>
        /// <returns>The firmware images.</returns>
        /// <param name="listParams">List parameters.</param>
        public List<firmware_catalog.Model.FirmwareImageSerializerData> ListFirmwareImages(ListParams listParams = null)
        {
            if (listParams == null)
            {
                listParams = new ListParams();
            }
            var api = new firmware_catalog.Api.DefaultApi(config.Host);
            try
            {
                return api.FirmwareImageList(listParams.Limit, listParams.Order, listParams.After).Data;
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
        
        /// <summary>
        /// Creates the firmware image.
        /// </summary>
        /// <returns>The firmware image.</returns>
        /// <param name="dataFile">Data file.</param>
        /// <param name="name">Name.</param>
        public firmware_catalog.Model.FirmwareImageSerializerData CreateFirmwareImage(Stream dataFile, string name)
        {
            var api = new firmware_catalog.Api.DefaultApi(config.Host);
            try
            {
                return api.FirmwareImageCreate(dataFile, name);
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
