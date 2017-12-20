// <copyright file="UpdateApi.FirmwareManifest.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Api
{
    using System.IO;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Query;
    using MbedCloudSDK.Exceptions;
    using MbedCloudSDK.Update.Model.FirmwareManifest;

    /// <summary>
    /// Update Api
    /// </summary>
    public partial class UpdateApi
    {
        /// <summary>
        /// List Firmware Images.
        /// </summary>
        /// <param name="options"><see cref="QueryOptions"/></param>
        /// <returns>Paginated Response of <see cref="FirmwareManifest"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var options = new QueryOptions
        ///     {
        ///         Limit = 5,
        ///     };
        ///     var manifests = updateApi.ListFirmwareManifests(Options);
        ///     foreach (var item in manifests)
        ///     {
        ///         Console.WriteLine(item);
        ///     }
        ///     return manifests;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
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
            catch (CloudApiException)
            {
                throw;
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
                var resp = api.FirmwareManifestList(limit: options.Limit, order: options.Order, after: options.After, filter: options.Filter?.FilterString, include: options.Include);
                var respManifests = new ResponsePage<FirmwareManifest>(resp.After, resp.HasMore, resp.Limit, resp.Order.ToString(), resp.TotalCount);
                foreach (var manifest in resp.Data)
                {
                    respManifests.Data.Add(FirmwareManifest.Map(manifest));
                }

                return respManifests;
            }
            catch (update_service.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get manifest with provided manifest_id.
        /// </summary>
        /// <param name="manifestId"><see cref="FirmwareManifest.Id"/></param>
        /// <returns><see cref="FirmwareManifest"/></returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var manifest = updateApI.GetFirmwareManifest("015baf5f4f04000000000001001003d5");
        ///     return manifest;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public FirmwareManifest GetFirmwareManifest(string manifestId)
        {
            try
            {
                return FirmwareManifest.Map(api.FirmwareManifestRetrieve(manifestId));
            }
            catch (update_service.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Add Firmware Manifest.
        /// </summary>
        /// <param name="dataFile">Path to the manifest file</param>
        /// <param name="name">Name of the firmware manifest.</param>
        /// <param name="description">Description for the firmware manifest.</param>
        /// <returns>Firmware Manifest</returns>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var manifest = updateApI.AddFirmwareManifest("FirmwareManifest file path", "name of manifest");
        ///     return manifest;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public FirmwareManifest AddFirmwareManifest(string dataFile, string name, string description = null)
        {
            try
            {
                using (var fs = File.OpenRead(dataFile))
                {
                    var result = api.FirmwareManifestCreate(fs, name, description);
                    return FirmwareManifest.Map(result);
                }
            }
            catch (update_service.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Delete firmware manifest.
        /// </summary>
        /// <param name="manifestId"><see cref="FirmwareManifest.Id"/></param>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     updateApI.DeleteFirmwareManifest("015baf5f4f04000000000001001003d5");
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public void DeleteFirmwareManifest(string manifestId)
        {
            try
            {
                api.FirmwareManifestDestroy(manifestId);
            }
            catch (update_service.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }
    }
}