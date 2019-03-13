// <copyright file="EnrollmentApi.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Enrollment.Api
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using enrollment.Api;
    using enrollment.Model;
    using Enrollment.Model;
    using Mbed.Cloud.Common;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.DeviceDirectory.Api;
    using MbedCloudSDK.Exceptions;
    using static MbedCloudSDK.Common.Utils;

    /// <summary>
    /// Exposing functionality from the following underlying services:
    /// - Enrollment
    /// </summary>
    /// <example>
    /// This API is intialized with a <see cref="Config"/> object.
    /// <code>
    /// using MbedCloudSDK.Common;
    /// var config = new config(apiKey);
    /// var enrollmentApi = new EnrollmentApi(config);
    /// </code>
    /// </example>
    public partial class EnrollmentApi : Api
    {
        private PublicAPIApi api;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnrollmentApi"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
        /// <example>
        /// This API is intialized with a <see cref="Config"/> object.
        /// <code>
        /// using MbedCloudSDK.Common;
        /// var config = new config(apiKey);
        /// var enrollmentApi = new EnrollmentApi(config);
        /// </code>
        /// </example>
        public EnrollmentApi(Config config)
            : base(config)
        {
            SetUpApi(config);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnrollmentApi"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="enrollmentConfig">The enrollment configuration.</param>
        internal EnrollmentApi(Config config, enrollment.Client.Configuration enrollmentConfig = null)
            : base(config)
        {
            SetUpApi(config, enrollmentConfig);
        }

        /// <summary>
        /// Gets or sets the API.
        /// </summary>
        /// <value>
        /// The API.
        /// </value>
        internal PublicAPIApi Api { get => api; set => api = value; }

        /// <summary>
        /// Get meta data for the last Mbed Cloud API call
        /// </summary>
        /// <returns><see cref="ApiMetadata"/></returns>
        public static ApiMetadata GetLastApiMetadata()
        {
            return ApiMetadata.Map(enrollment.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault());
        }

        /// <summary>
        /// Add an enrollment claim
        /// </summary>
        /// <param name="claimId">The enrollment id</param>
        /// <returns>The created enrollment</returns>
        public Enrollment AddEnrollmentClaim(string claimId)
        {
            try
            {
                return AddEnrollmentClaimAsync(claimId).Result;
            }
            catch (CloudApiException)
            {
                throw;
            }
        }

        /// <summary>
        /// Add an enrollment claim
        /// </summary>
        /// <param name="claimId">The enrollment id</param>
        /// <returns>The created enrollment</returns>
        public async Task<Enrollment> AddEnrollmentClaimAsync(string claimId)
        {
            try
            {
                return Enrollment.Map(await Api.CreateDeviceEnrollmentAsync(new enrollment.Model.EnrollmentId(claimId)));
            }
            catch (enrollment.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        /// <summary>
        /// Delete an enrollment claim
        /// </summary>
        /// <param name="id">The id of the enrollment</param>
        public void DeleteEnrollmentClaim(string id)
        {
            try
            {
                DeleteEnrollmentClaimAsync(id).Wait();
            }
            catch (CloudApiException)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete an enrollment claim
        /// </summary>
        /// <param name="id">The id of the enrollment</param>
        /// <returns>Task</returns>
        public async Task DeleteEnrollmentClaimAsync(string id)
        {
            try
            {
                await Api.DeleteDeviceEnrollmentAsync(id);
            }
            catch (enrollment.Client.ApiException e)
            {
                HandleNotFound<string, enrollment.Client.ApiException>(e);
            }
        }

        /// <summary>
        /// Get an enrollment clasim
        /// </summary>
        /// <param name="id">The id of the enrollment</param>
        /// <returns>The enrollment</returns>
        public Enrollment GetEnrollmentClaim(string id)
        {
            try
            {
                return GetEnrollmentClaimAsync(id).Result;
            }
            catch (CloudApiException)
            {
                throw;
            }
        }

        /// <summary>
        /// Get an enrollment clasim
        /// </summary>
        /// <param name="id">The id of the enrollment</param>
        /// <returns>The enrollment</returns>
        public async Task<Enrollment> GetEnrollmentClaimAsync(string id)
        {
            try
            {
                return Enrollment.Map(await Api.GetDeviceEnrollmentAsync(id));
            }
            catch (enrollment.Client.ApiException e)
            {
                return HandleNotFound<Enrollment, enrollment.Client.ApiException>(e);
            }
        }

        /// <summary>
        /// List all the enrollment claims
        /// </summary>
        /// <param name="options">Query options</param>
        /// <returns>A paginated response with the enrollments</returns>
        public PaginatedResponse<QueryOptions, Enrollment> ListEnrollmentClaims(QueryOptions options = null)
        {
            if (options == null)
            {
                options = new QueryOptions();
            }

            try
            {
                return new PaginatedResponse<QueryOptions, Enrollment>(ListEnrollmentClaimsFunc, options);
            }
            catch (CloudApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        private async Task<ResponsePage<Enrollment>> ListEnrollmentClaimsFunc(QueryOptions options)
        {
            try
            {
                var resp = await Api.GetDeviceEnrollmentsAsync(limit: options.Limit, after: options.After, order: options.Order, include: options.Include);
                var responsePage = new ResponsePage<Enrollment>(after: resp.After, hasMore: resp.HasMore, totalCount: resp.TotalCount);
                responsePage.MapData<EnrollmentIdentity>(resp.Data, Enrollment.Map);
                return responsePage;
            }
            catch (enrollment.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
        }

        private void SetUpApi(Config config, enrollment.Client.Configuration enrollmentConfig = null)
        {
            if (enrollmentConfig == null)
            {
                enrollmentConfig = new enrollment.Client.Configuration
                {
                    BasePath = config.Host,
                    DateTimeFormat = "yyyy-MM-dd",
                    UserAgent = UserAgent,
                };
                enrollmentConfig.AddApiKey("Authorization", config.ApiKey);
                enrollmentConfig.AddApiKeyPrefix("Authorization", config.AuthorizationPrefix);
                enrollmentConfig.CreateApiClient();
            }

            Api = new enrollment.Api.PublicAPIApi(enrollmentConfig);
        }
    }
}