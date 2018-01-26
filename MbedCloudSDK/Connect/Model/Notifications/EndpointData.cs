// <copyright file="EndpointData.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
namespace MbedCloudSDK.Connect.Model.Notifications
{
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// EndpointData
    /// </summary>
    public class EndpointData
    {
        /// <summary>
        /// Gets or sets the QueueMode
        /// </summary>
        /// <returns>QueueMode</returns>
        [JsonProperty("q")]
        public bool? QueueMode { get; set; }

        /// <summary>
        /// Gets or sets the EndpointType
        /// </summary>
        /// <returns>EndpointType</returns>
        [JsonProperty("ept")]
        public string EndpointType { get; set; }

        /// <summary>
        /// Gets or sets the OriginalEndpointType
        /// </summary>
        /// <returns>OriginalEndpointType</returns>
        [JsonProperty("original-ep")]
        public string OriginalEndpointType { get; set; }

        /// <summary>
        /// Gets or sets the Resources
        /// </summary>
        /// <returns>Resources</returns>
        [JsonProperty("resources")]
        public List<ResourcesData> Resources { get; set; }

        /// <summary>
        /// Gets or sets the DeviceId
        /// </summary>
        /// <returns>DeviceId</returns>
        [JsonProperty("ep")]
        public string DeviceId { get; set; }

        /// <summary>
        /// Maps to EndpointData
        /// </summary>
        /// <param name="data">Mds Endpoint Data</param>
        /// <returns>The EndpointData</returns>
        public static EndpointData Map(mds.Model.EndpointData data)
        {
            var endpointData = new EndpointData
            {
                QueueMode = data.Q,
                EndpointType = data.Ept,
                OriginalEndpointType = data.OriginalEp,
                Resources = data?.Resources?.Select(r => ResourcesData.Map(r))?.ToList(),
                DeviceId = data.Ep,
            };

            return endpointData;
        }
    }
}