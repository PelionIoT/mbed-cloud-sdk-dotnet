// <copyright file="EnrollmentApi.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Enrollment.Api
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using enrollment.Model;
    using Enrollment.Model;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Query;
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
    public partial class EnrollmentApi : BaseApi
    {
        private enrollment.Api.PublicAPIApi api;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceDirectoryApi"/> class.
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
            var enrollmentConfig = new enrollment.Client.Configuration
            {
                BasePath = config.Host,
                DateTimeFormat = "yyyy-MM-dd",
            };
            enrollmentConfig.AddApiKey("Authorization", config.ApiKey);
            enrollmentConfig.AddApiKeyPrefix("Authorization", config.AuthorizationPrefix);
            enrollmentConfig.CreateApiClient();

            api = new enrollment.Api.PublicAPIApi(enrollmentConfig);
        }

        /// <summary>
        /// Get meta data for the last Mbed Cloud API call
        /// </summary>
        /// <returns><see cref="ApiMetadata"/></returns>
        public static ApiMetadata GetLastApiMetadata()
        {
            return ApiMetadata.Map(enrollment.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault());
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

        private ResponsePage<Enrollment> ListEnrollmentClaimsFunc(QueryOptions options)
        {
            try
            {
                var resp = api.V3DeviceEnrollmentsGet(limit: options.Limit, after: options.After, order: options.Order, include: options.Include);
                var respEnrollments = new ResponsePage<Enrollment>(resp.After, resp.HasMore, resp.Limit, Convert.ToString(resp.Order), resp.TotalCount);
                resp.Data.ForEach(enrollment => respEnrollments.Data.Add(Enrollment.Map(enrollment)));
                return respEnrollments;
            }
            catch (enrollment.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
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
                return Enrollment.Map(await api.V3DeviceEnrollmentsPostAsync(new enrollment.Model.EnrollmentId(claimId)));
            }
            catch (enrollment.Client.ApiException e)
            {
                throw new CloudApiException(e.ErrorCode, e.Message, e.ErrorContent);
            }
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
        /// Get an enrollment clasim
        /// </summary>
        /// <param name="id">The id of the enrollment</param>
        /// <returns>The enrollment</returns>
        public async Task<Enrollment> GetEnrollmentClaimAsync(string id)
        {
            try
            {
                return Enrollment.Map(await api.V3DeviceEnrollmentsIdGetAsync(id));
            }
            catch (enrollment.Client.ApiException e)
            {
                return HandleNotFound<Enrollment, enrollment.Client.ApiException>(e);
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
        /// Delete an enrollment claim
        /// </summary>
        /// <param name="id">The id of the enrollment</param>
        /// <returns></returns>
        public async void DeleteEnrollmentClaimAsync(string id)
        {
            try
            {
                await api.V3DeviceEnrollmentsIdDeleteAsync(id);
            }
            catch (enrollment.Client.ApiException e)
            {
                HandleNotFound<string, enrollment.Client.ApiException>(e);
            }
        }

        /// <summary>
        /// Delete an enrollment claim
        /// </summary>
        /// <param name="id">The id of the enrollment</param>
        /// <returns></returns>
        public void DeleteEnrollmentClaim(string id)
        {
            try
            {
                DeleteEnrollmentClaimAsync(id);
            }
            catch (CloudApiException)
            {
                throw;
            }
        }
    }
}