// <copyright file="UpdateApi.FirmwareImage.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Api
{
    using System.IO;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Query;
    using MbedCloudSDK.Exceptions;
    using MbedCloudSDK.Update.Model.FirmwareImage;
    using static MbedCloudSDK.Common.Utils;

    /// <summary>
    /// Update Api
    /// </summary>
    public partial class UpdateApi
    {
        /// <summary>
        /// List Firmware Images.
        /// </summary>
        /// <param name="options"><see cref="QueryOptions"/></param>
        /// <returns>Paginated Response of <see cref="FirmwareImage"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var options = new QueryOptions
        ///     {
        ///         Limit = 5,
        ///     };
        ///     var images = updateApi.ListFirmwareImages(Options);
        ///     foreach (var item in images)
        ///     {
        ///         Console.WriteLine(item);
        ///     }
        ///     return images;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public PaginatedResponse<QueryOptions, FirmwareImage> ListFirmwareImages(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                return new PaginatedResponse<QueryOptions, FirmwareImage>(ListFirmwareImagesFun, options);
            }
            catch (CloudApiException)
            {
                throw;
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
                var resp = Api.FirmwareImageList(limit: options.Limit, order: options.Order, after: options.After, filter: options.Filter?.FilterString, include: options.Include);
                var respImages = new ResponsePage<FirmwareImage>(resp.After, resp.HasMore, resp.Limit, resp.Order.ToString(), resp.TotalCount);
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
        /// <param name="imageId"><see cref="FirmwareImage.Id"/></param>
        /// <returns><see cref="FirmwareImage"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var image = updateApI.GetFirmwareImage("015baf5f4f04000000000001001003d5");
        ///     return image;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public FirmwareImage GetFirmwareImage(string imageId)
        {
            try
            {
                return FirmwareImage.Map(Api.FirmwareImageRetrieve(imageId));
            }
            catch (update_service.Client.ApiException e)
            {
                return HandleNotFound<FirmwareImage, update_service.Client.ApiException>(e);
            }
        }

        /// <summary>
        /// Creates the firmware image.
        /// </summary>
        /// <returns>The firmware image.</returns>
        /// <param name="dataFile">Path to the data file</param>
        /// <param name="name">Name of the <see cref="FirmwareImage"/></param>
        /// <param name="description">Description of the <see cref="FirmwareImage"/></param>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var image = updateApI.AddFirmwareImage("FirmwareImage file path", "name of image", "image description");
        ///     return image;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public FirmwareImage AddFirmwareImage(string dataFile, string name, string description = null)
        {
            try
            {
                using (var fs = File.OpenRead(dataFile))
                {
                    var result = FirmwareImage.Map(Api.FirmwareImageCreate(fs, name, description));
                    return result;
                }
            }
            catch (FileNotFoundException e)
            {
                throw new CloudApiException(404, e.Message);
            }
            catch (update_service.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Delete firmware image.
        /// </summary>
        /// <param name="imageId"><see cref="FirmwareImage.Id"/></param>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     updateApI.DeleteFirmwareImage("015baf5f4f04000000000001001003d5");
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public void DeleteFirmwareImage(string imageId)
        {
            try
            {
                Api.FirmwareImageDestroy(imageId);
            }
            catch (update_service.Client.ApiException e)
            {
                HandleNotFound<FirmwareImage, update_service.Client.ApiException>(e);
            }
        }
    }
}