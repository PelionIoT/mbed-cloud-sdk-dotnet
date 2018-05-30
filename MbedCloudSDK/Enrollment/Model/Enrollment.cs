// <copyright file="Enrollment.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Enrollment.Model
{
    using System;
    using MbedCloudSDK.Common;
    using Newtonsoft.Json;

    /// <summary>
    /// Enrollment
    /// </summary>
    public class Enrollment : BaseModel
    {
        /// <summary>
        /// Gets the id of the device in the device directory once it has been registered
        /// </summary>
        [JsonProperty]
        public string DeviceId { get; private set; }

        /// <summary>
        /// Gets the time the enrollment identity was created
        /// </summary>
        [JsonProperty]
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// Gets the time of claiming the device to the account
        /// </summary>
        [JsonProperty]
        public DateTime? ClaimedAt { get; private set; }

        /// <summary>
        /// Gets the id of the claim
        /// </summary>
        [JsonProperty]
        public string ClaimId { get; private set; }

        /// <summary>
        /// Gets the id of the account
        /// </summary>
        [JsonProperty]
        public string AccountId { get; private set; }

        /// <summary>
        /// Gets the enrollment claim expiration time
        /// </summary>
        [JsonProperty]
        public DateTime? ExpiresAt { get; private set; }

        /// <summary>
        /// Map api EnrollmentIdentity to Enrollment
        /// </summary>
        /// <param name="from">api EnrollmentIdentity</param>
        /// <returns>Enrollment</returns>
        public static Enrollment Map(enrollment.Model.EnrollmentIdentity from)
        {
            return new Enrollment
            {
                Id = from.Id,
                DeviceId = from.DeviceId,
                CreatedAt = from.CreatedAt,
                ClaimId = from._EnrollmentIdentity,
                AccountId = from.AccountId,
                ExpiresAt = from.ExpiresAt,
            };
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();
    }
}