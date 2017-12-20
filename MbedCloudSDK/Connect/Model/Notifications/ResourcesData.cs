// <copyright file="ResourcesData.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Model.Notifications
{
    using Newtonsoft.Json;

    /// <summary>
    /// Resources Data
    /// </summary>
    public class ResourcesData
    {
        /// <summary>
        /// Gets or sets the Path
        /// </summary>
        /// <returns>Path</returns>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the ResourceType
        /// </summary>
        /// <returns>ResourceType</returns>
        [JsonProperty("rt")]
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the ContentType
        /// </summary>
        /// <returns>ContentType</returns>
        [JsonProperty("ct")]
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the Observable
        /// </summary>
        /// <returns>Observable</returns>
        [JsonProperty("obs")]
        public bool? Observable { get; set; }

        /// <summary>
        /// Gets or sets the InterfaceDescription
        /// </summary>
        /// <returns>InterfaceDescription</returns>
        [JsonProperty("_if")]
        public string InterfaceDescription { get; set; }

        /// <summary>
        /// Map the resource data
        /// </summary>
        /// <param name="data">The Resources Data</param>
        /// <returns>The Resources Data</returns>
        public static ResourcesData Map(mds.Model.ResourcesData data)
        {
            var resourcesData = new ResourcesData
            {
                Path = data.Path,
                ResourceType = data.Rf,
                ContentType = data.Ct,
                Observable = data.Obs,
                InterfaceDescription = data._If,
            };

            return resourcesData;
        }
    }
}