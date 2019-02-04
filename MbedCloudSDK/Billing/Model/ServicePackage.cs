// <copyright file="ServicePackage.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Billing.Model
{
    using System;
    using Mbed.Cloud.Foundation.Common;
    using MbedCloudSDK.Common;
    using Newtonsoft.Json;

    /// <summary>
    /// ServicePackage
    /// </summary>
    public class ServicePackage : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServicePackage"/> class.
        /// </summary>
        /// <param name="state">The state.</param>
        public ServicePackage(string state = null)
        {
            State = state;
        }

        /// <summary>
        /// Gets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        [JsonProperty]
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// Gets the expires at.
        /// </summary>
        /// <value>
        /// The expires at.
        /// </value>
        [JsonProperty]
        public DateTime? ExpiresAt { get; private set; }

        /// <summary>
        /// Gets the ends at.
        /// </summary>
        /// <value>
        /// The ends at.
        /// </value>
        [JsonProperty]
        public DateTime? EndsAt { get; private set; }

        /// <summary>
        /// Gets the firmware update count.
        /// </summary>
        /// <value>
        /// The firmware update count.
        /// </value>
        [JsonProperty]
        public int? FirmwareUpdateCount { get; private set; }

        /// <summary>
        /// Gets the grace period.
        /// </summary>
        /// <value>
        /// The grace period.
        /// </value>
        [JsonProperty]
        public bool? GracePeriod { get; private set; }

        /// <summary>
        /// Gets the modified at.
        /// </summary>
        /// <value>
        /// The modified at.
        /// </value>
        [JsonProperty]
        public DateTime? ModifiedAt { get; private set; }

        /// <summary>
        /// Gets the starts at.
        /// </summary>
        /// <value>
        /// The starts at.
        /// </value>
        [JsonProperty]
        public DateTime? StartsAt { get; private set; }

        /// <summary>
        /// Gets the next identifier.
        /// </summary>
        /// <value>
        /// The next identifier.
        /// </value>
        [JsonProperty]
        public string NextId { get; private set; }

        /// <summary>
        /// Gets the previous identifier.
        /// </summary>
        /// <value>
        /// The previous identifier.
        /// </value>
        [JsonProperty]
        public string PreviousId { get; private set; }

        /// <summary>
        /// Gets the reason.
        /// </summary>
        /// <value>
        /// The reason.
        /// </value>
        [JsonProperty]
        public string Reason { get; private set; }

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        [JsonProperty]
        public string State { get; private set; }
    }
}