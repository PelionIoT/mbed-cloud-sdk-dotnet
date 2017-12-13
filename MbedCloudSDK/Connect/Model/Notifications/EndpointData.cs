// <copyright file="EndpointData.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
namespace MbedCloudSDK.Connect.Model.Notifications
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// EndpointData
    /// </summary>
    public class EndpointData
    {
        /// <summary>
        /// Gets the QueueMode
        /// </summary>
        /// <returns>QueueMode</returns>
        public bool? QueueMode { get; private set; }

        /// <summary>
        /// Gets the EndpointType
        /// </summary>
        /// <returns>EndpointType</returns>
        public string EndpointType { get; private set; }

        /// <summary>
        /// Gets the OriginalEndpointType
        /// </summary>
        /// <returns>OriginalEndpointType</returns>
        public string OriginalEndpointType { get; private set; }

        /// <summary>
        /// Gets the Resources
        /// </summary>
        /// <returns>Resources</returns>
        public List<ResourcesData> Resources { get; private set; }

        /// <summary>
        /// Gets the DeviceId
        /// </summary>
        /// <returns>DeviceId</returns>
        public string DeviceId { get; private set; }

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