// <copyright file="DeviceEventData.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
namespace MbedCloudSDK.Connect.Model.Notifications
{
    using System.Collections.Generic;
    using System.Linq;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Connect.Api.Subscribe.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// EndpointData
    /// </summary>
    public class DeviceEventData
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
        /// Gets or sets the state
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public DeviceEvent State { get; set; }

        /// <summary>
        /// Maps to EndpointData
        /// </summary>
        /// <param name="data">Mds Endpoint Data</param>
        /// <param name="state">The device state</param>
        /// <returns>The EndpointData</returns>
        public static DeviceEventData Map(mds.Model.EndpointData data, DeviceEvent state)
        {
            var endpointData = new DeviceEventData
            {
                QueueMode = data.Q,
                EndpointType = data.Ept,
                OriginalEndpointType = data.OriginalEp,
                Resources = data?.Resources?.Select(r => ResourcesData.Map(r))?.ToList(),
                DeviceId = data.Ep,
                State = state,
            };

            return endpointData;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { ContractResolver = new LongNameContractResolver() });
        }
    }
}