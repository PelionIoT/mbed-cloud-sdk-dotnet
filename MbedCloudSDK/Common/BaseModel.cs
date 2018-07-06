// <copyright file="BaseModel.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common
{
    using Newtonsoft.Json;

    /// <summary>
    /// BaseModel
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty]
        public string Id { get; internal set; }
    }
}