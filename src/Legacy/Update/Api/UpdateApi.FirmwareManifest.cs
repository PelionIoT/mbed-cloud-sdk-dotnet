// <copyright file="UpdateApi.FirmwareManifest.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Api
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Mbed.Cloud.Foundation.Common;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Exceptions;
    using MbedCloudSDK.Update.Model.FirmwareManifest;
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
        public PaginatedResponse<QueryOptions, FirmwareManifest> ListFirmwareManifests(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                return new PaginatedResponse<QueryOptions, FirmwareManifest>(ListFirmwareManifestsFunc, options);
            }
            catch (CloudApiException)
            {
                throw;
            }
        }

        private async Task<ResponsePage<FirmwareManifest>> ListFirmwareManifestsFunc(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                var resp = await Api.FirmwareManifestListAsync(limit: options.Limit, order: options.Order, after: options.After, filter: options.Filter?.FilterString, include: options.Include);
                var responsePage = new ResponsePage<FirmwareManifest>(resp.After, resp.HasMore, resp.TotalCount);
                responsePage.MapData<update_service.Model.FirmwareManifest>(resp.Data, FirmwareManifest.Map);
                return responsePage;
            }
            catch (update_service.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Get manifest with provided manifest_id.
        /// </summary>
        /// <param name="manifestId">Id</param>
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
                return FirmwareManifest.Map(Api.FirmwareManifestRetrieve(manifestId));
            }
            catch (update_service.Client.ApiException ex)
            {
                return HandleNotFound<FirmwareManifest, update_service.Client.ApiException>(ex);
            }
        }

        /// <summary>
        /// Add Firmware Manifest.
        /// </summary>
        /// <param name="manifest">
        /// Entity with all the properties required to create a new firmware manifest.
        /// <see cref="FirmwareManifest.DataFile"/> and <see cref="FirmwareManifest.Name"/>
        /// are mandatory.
        /// </param>
        /// <returns>The newly create firmware manifest.</returns>
        /// <exception cref="CloudApiException">
        /// If the operation cannot be completed because of a server-side error (caused, for example,
        /// by an invalid parameter value).
        /// </exception>
        /// <exception cref="IOException">
        /// If an I/O error occured when reading <c>FirmwareManifestInfo.DataFilePath</c>
        /// or <c>FirmwareManifestInfo.KeyTableFilePath</c>.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">
        /// If current user has not the permission to read file specified in
        /// <c>FirmwareManifestInfo.DataFilePath</c> or <c>FirmwareManifestInfo.KeyTableFilePath</c>.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="manifest"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <see cref="FirmwareManifest.DataFile"/> is a <see langword="null"/> or blank string.
        /// <br/>-Or-<br/>
        /// If <see cref="FirmwareManifest.Name"/> is a <see langword="null"/> or blank string.
        /// </exception>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     return updateApi.AddFirmwareManifest(new FirmwareManifest
        ///     {
        ///         DataFilePath = "path to the file",
        ///         Name = "description of the manifest"
        ///     });
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        public FirmwareManifest AddFirmwareManifest(FirmwareManifest manifest)
        {
            if (manifest == null)
            {
                throw new ArgumentNullException(nameof(manifest));
            }

            if (string.IsNullOrWhiteSpace(manifest.DataFile))
            {
                throw new ArgumentException($"{nameof(FirmwareManifest)}.{nameof(FirmwareManifest.DataFile)} cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(manifest.Name))
            {
                throw new ArgumentException($"{nameof(FirmwareManifest)}.{nameof(FirmwareManifest.Name)} cannot be empty");
            }

            using (var dataFileStream = File.OpenRead(manifest.DataFile))
            {
                var keyTableFileStream = OpenKeyTableStream();
                try
                {
                    var response = Api.FirmwareManifestCreate(dataFileStream, manifest.Name, manifest.Description, keyTableFileStream);
                    return FirmwareManifest.Map(response);
                }
                catch (update_service.Client.ApiException e)
                {
                    throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
                }
                finally
                {
                    keyTableFileStream?.Close();
                }
            }

            FileStream OpenKeyTableStream()
                => string.IsNullOrWhiteSpace(manifest.KeyTableFile) ? null : File.OpenRead(manifest.KeyTableFile);
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
        ///     var manifest = updateApi.AddFirmwareManifest("FirmwareManifest file path", "name of manifest");
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
            return AddFirmwareManifest(new FirmwareManifest
            {
                DataFile = dataFile,
                Name = name,
                Description = description
            });
        }

        /// <summary>
        /// Delete firmware manifest.
        /// </summary>
        /// <param name="manifestId">Id</param>
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
                Api.FirmwareManifestDestroy(manifestId);
            }
            catch (update_service.Client.ApiException e)
            {
                HandleNotFound<FirmwareManifest, update_service.Client.ApiException>(e);
            }
        }
    }
}