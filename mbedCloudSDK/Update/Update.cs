using System;
using mbedCloudSDK.Common;
using firmware_catalog.Client;
using System.Collections.Generic;
using mbedCloudSDK.Exceptions;

namespace mbedCloudSDK
{
    /// <summary>
    /// Exposing functionality from: Update service, Update campaigns and Manifest management
    /// </summary>
    public class UpdateApi: BaseApi
    {
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
            Configuration.Default.ApiKey["Authorization"] = config.ApiKey;
            Configuration.Default.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
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
        public List<firmware_catalog.Model.FirmwareImageSerializerData> CreateFirmwareImage(string dataFile, string name)
        {
            var api = new firmware_catalog.Api.DefaultApi(config.Host);
            try
            {
                return api.FirmwareImageCreate(dataFile, name).Data;
            }
            catch (device_catalog.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
