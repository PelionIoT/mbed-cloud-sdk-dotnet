﻿using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Query;
using MbedCloudSDK.Exceptions;
using MbedCloudSDK.Update.Model.FirmwareImage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MbedCloudSDK.Update.Api
{
    public partial class UpdateApi
    {
        /// <summary>
        /// List Firmware Images.
        /// </summary>
        /// <param name="options">Query optionss.</param>
        /// <returns></returns>
        public PaginatedResponse<FirmwareImage> ListFirmwareImages(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }
            try
            {
                return new PaginatedResponse<FirmwareImage>(ListFirmwareImagesFun, options);
            }
            catch (CloudApiException e)
            {
                throw e;
            }
        }

        private ResponsePage<FirmwareImage> ListFirmwareImagesFun(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }
            try
            {
                var resp = api.FirmwareImageList(options.Limit, options.Order, options.After);
                ResponsePage<FirmwareImage> respImages = new ResponsePage<FirmwareImage>(resp.After, resp.HasMore, resp.Limit, resp.Order.ToString(), resp.TotalCount);
                foreach (var image in resp.Data)
                {
                    respImages.Data.Add(FirmwareImage.Map(image));
                }
                return respImages;
            }
            catch (update_service.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get a firmware image with provided image_id.
        /// </summary>
        /// <param name="imageId">The firmware ID for the image to retrieve.</param>
        public FirmwareImage GetFirmwareImage(string imageId)
        {
            try
            {
                return FirmwareImage.Map(api.FirmwareImageRetrieve(imageId));
            }
            catch (update_service.Client.ApiException e)
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
        public FirmwareImage AddFirmwareImage(string dataFile, string name)
        {
            try
            {
                var fs = File.Open(dataFile,FileMode.Open);
                return FirmwareImage.Map(api.FirmwareImageCreate(fs, name));
            }
            catch (update_service.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Delete firmware image.
        /// </summary>
        /// <param name="firmwareImageId">Id of the firmware image.</param>
        public void DeleteFirmwareImage(string firmwareImageId)
        {
            try
            {
                api.FirmwareImageDestroy(firmwareImageId);
            }
            catch (update_service.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}
