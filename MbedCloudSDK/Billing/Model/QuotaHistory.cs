// <copyright file="QuotaHistory.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Billing.Model
{
    using System;
    using MbedCloudSDK.Common;
    using Newtonsoft.Json;

    /// <summary>
    /// QuotaHistory
    /// </summary>
    /// <seealso cref="MbedCloudSDK.Common.BaseModel" />
    public class QuotaHistory : BaseModel
    {
        /// <summary>
        /// Gets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        [JsonProperty]
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// Gets the delta.
        /// </summary>
        /// <value>
        /// The delta.
        /// </value>
        [JsonProperty]
        public long? Delta { get; private set; }

        /// <summary>
        /// Gets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        [JsonProperty]
        public string AccountId { get; private set; }

        /// <summary>
        /// Gets the name of the campaign.
        /// </summary>
        /// <value>
        /// The name of the campaign.
        /// </value>
        [JsonProperty]
        public string CampaignName { get; private set; }

        /// <summary>
        /// Gets the service package.
        /// </summary>
        /// <value>
        /// The service package.
        /// </value>
        [JsonProperty]
        public ServicePackage ServicePackage { get; private set; }

        /// <summary>
        /// Gets the reason.
        /// </summary>
        /// <value>
        /// The reason.
        /// </value>
        [JsonProperty]
        public string Reason { get; private set; }
    }
}