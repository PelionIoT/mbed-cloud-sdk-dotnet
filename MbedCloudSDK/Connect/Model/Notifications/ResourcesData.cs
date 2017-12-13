// <copyright file="ResourcesData.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
namespace MbedCloudSDK.Connect.Model.Notifications
{
    /// <summary>
    /// Resources Data
    /// </summary>
    public class ResourcesData
    {
        /// <summary>
        /// Gets the Path
        /// </summary>
        /// <returns>Path</returns>
        public string Path { get; private set; }

        /// <summary>
        /// Gets the ResourceType
        /// </summary>
        /// <returns>ResourceType</returns>
        public string ResourceType { get; private set; }

        /// <summary>
        /// Gets the ContentType
        /// </summary>
        /// <returns>ContentType</returns>
        public string ContentType { get; private set; }

        /// <summary>
        /// Gets the Observable
        /// </summary>
        /// <returns>Observable</returns>
        public bool? Observable { get; private set; }

        /// <summary>
        /// Gets the InterfaceDescription
        /// </summary>
        /// <returns>InterfaceDescription</returns>
        public string InterfaceDescription { get; private set; }

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