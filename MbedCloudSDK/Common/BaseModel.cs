// <copyright file="BaseModel.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// BaseModel
    /// </summary>
    // [Obsolete("No longer being maintained. Please use the newer entity based models under MbedCloud.SDK.Entities")]
    public abstract class BaseModel
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty]
        public string Id { get; set; }
    }
}