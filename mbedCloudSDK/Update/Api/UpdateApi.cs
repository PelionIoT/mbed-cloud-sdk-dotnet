using System;
using mbedCloudSDK.Common;
using firmware_catalog.Client;
using System.Collections.Generic;
using mbedCloudSDK.Exceptions;
using System.IO;
using deployment_service.Model;
using mbedCloudSDK.Update.Model;
using mbedCloudSDK.Update.Model.Campaign;
using mbedCloudSDK.Update.Model.FirmwareImage;
using mbedCloudSDK.Update.Model.FirmwareManifest;

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
                ResponsePage<UpdateCampaign> respDevices = new ResponsePage<UpdateCampaign>(resp.After, resp.HasMore, resp.Limit, resp.Order, resp.TotalCount);
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

        public UpdateCampaign GetUpdateCampaign(string campaignId)
        {
            try
            {
                var resp = updateApi.UpdateCampaignRetrieve(campaignId);
                return UpdateCampaign.Map(resp);
            }
            catch(device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

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

        public UpdateCampaign AddUpdateCampaign(UpdateCampaign updateCampaign)
        {
            try
            {
                WriteUpdateCampaignSerializer serializer = new WriteUpdateCampaignSerializer(updateCampaign.Name, null, null, null, updateCampaign.RootManifestId, null,
                    null, null, null, null, updateCampaign.DeviceFilter, updateCampaign.Description);
                var resp = updateApi.UpdateCampaignCreate(serializer);
                return UpdateCampaign.Map(resp);
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public UpdateCampaign StartUpdateCampaign(UpdateCampaign updateCampaign)
        {
            try
            {
                WriteUpdateCampaignSerializer serializer = new WriteUpdateCampaignSerializer(updateCampaign.Name, WriteUpdateCampaignSerializer.StateEnum.Scheduled, updateCampaign.UpdatingUserId,
                    null, updateCampaign.RootManifestId, updateCampaign.CampaignId, updateCampaign.UpdatingApiKey, updateCampaign.When, updateCampaign.Finished, updateCampaign.UpdatingAccountId,
                    updateCampaign.DeviceFilter, updateCampaign.Description);
                var resp = updateApi.UpdateCampaignUpdate(updateCampaign.Id, serializer);
                return UpdateCampaign.Map(resp);
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

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

        /// <summary>
        /// List Firmware Images.
        /// </summary>
        /// <param name="listParams">List of parameters.</param>
        /// <returns></returns>
        public PaginatedResponse<FirmwareImage> ListFirmwareImages(ListParams listParams = null)
        {
            if (listParams == null)
            {
                listParams = new ListParams();
            }
            try
            {
                return new PaginatedResponse<FirmwareImage>(ListFirmwareImagesFun, listParams);
            }
            catch (CloudApiException e)
            {
                throw e;
            }
        }

        private ResponsePage<FirmwareImage> ListFirmwareImagesFun(ListParams listParams = null)
        {
            if (listParams == null)
            {
                listParams = new ListParams();
            }
            try
            {
                var resp = firmwareApi.FirmwareImageList(listParams.Limit, listParams.Order, listParams.After);
                ResponsePage<FirmwareImage> respImages = new ResponsePage<FirmwareImage>(resp.After, resp.HasMore, resp.Limit, resp.Order, resp.TotalCount);
                foreach (var image in resp.Data)
                {
                    respImages.Data.Add(FirmwareImage.Map(image));
                }
                return respImages;
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
        public FirmwareImage AddFirmwareImage(Stream dataFile, string name)
        {
            var api = new firmware_catalog.Api.DefaultApi(config.Host);
            try
            {
                return FirmwareImage.Map(api.FirmwareImageCreate(dataFile, name));
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public void DeleteFirmwareImage(int firmwareImageId)
        {
            try
            {
                firmwareApi.FirmwareImageDestroy(firmwareImageId);
      
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// List Firmware Images.
        /// </summary>
        /// <param name="listParams">List of parameters.</param>
        /// <returns></returns>
        public PaginatedResponse<FirmwareManifest> ListFirmwareManifests(ListParams listParams = null)
        {
            if (listParams == null)
            {
                listParams = new ListParams();
            }
            try
            {
                return new PaginatedResponse<FirmwareManifest>(ListFirmwareManifestsFun, listParams);
            }
            catch (CloudApiException e)
            {
                throw e;
            }
        }

        private ResponsePage<FirmwareManifest> ListFirmwareManifestsFun(ListParams listParams = null)
        {
            if (listParams == null)
            {
                listParams = new ListParams();
            }
            try
            {
                var resp = firmwareApi.FirmwareManifestList(listParams.Limit, listParams.Order, listParams.After);
                ResponsePage<FirmwareManifest> respManifests = new ResponsePage<FirmwareManifest>(resp.After, resp.HasMore, resp.Limit, resp.Order, resp.TotalCount);
                foreach (var manifest in resp.Data)
                {
                    respManifests.Data.Add(FirmwareManifest.Map(manifest));
                }
                return respManifests;
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public FirmwareManifest AddFirmwareManifest(Stream dataFile, string name, string description = null )
        {
            try
            {
                return FirmwareManifest.Map(firmwareApi.FirmwareManifestCreate(dataFile, name, description));
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        public void DeleteFirmwareManifest(int manifestId)
        {
            try
            {
                firmwareApi.FirmwareManifestDestroy(manifestId);

            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }


    }
}
