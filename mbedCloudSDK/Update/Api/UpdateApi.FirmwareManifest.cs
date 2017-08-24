using mbedCloudSDK.Common;
using mbedCloudSDK.Common.Query;
using mbedCloudSDK.Exceptions;
using mbedCloudSDK.Update.Model.FirmwareManifest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Update.Api
{
    public partial class UpdateApi
    {
        /// <summary>
        /// List Firmware Images.
        /// </summary>
        /// <param name="options">Query options.</param>
        /// <returns></returns>
        public PaginatedResponse<FirmwareManifest> ListFirmwareManifests(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }
            try
            {
                return new PaginatedResponse<FirmwareManifest>(ListFirmwareManifestsFun, options);
            }
            catch (CloudApiException e)
            {
                throw e;
            }
        }

        private ResponsePage<FirmwareManifest> ListFirmwareManifestsFun(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }
            try
            {
                var resp = firmwareApi.FirmwareManifestList(options.Limit, options.Order, options.After);
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

        /// <summary>
        /// Get manifest with provided manifest_id.
        /// </summary>
        /// <param name="manifestId">ID of manifest to retrieve.</param>
        public FirmwareManifest GetFirmwareManifest(string manifestId)
        {
            try
            {
                return FirmwareManifest.Map(firmwareApi.FirmwareManifestRetrieve(manifestId));
            }
            catch(firmware_catalog.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Add Firmware Manifest.
        /// </summary>
        /// <param name="dataFile">Stream to the manifest file.</param>
        /// <param name="name">Name of the firmware manifest.</param>
        /// <param name="description">Description for the firmware manifest.</param>
        /// <returns></returns>
        public FirmwareManifest AddFirmwareManifest(Stream dataFile, string name, string description = null)
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

        /// <summary>
        /// Delete firmware manifest.
        /// </summary>
        /// <param name="manifestId">Id of the manifest to be deleted.</param>
        public void DeleteFirmwareManifest(string manifestId)
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
