// <copyright file="PreSharedKey.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Bootstrap.Model
{
    /// <summary>
    /// PreSharedKey
    /// </summary>
    public class PreSharedKey
    {
        /// <summary>
        /// Gets or sets the EndpointName
        /// </summary>
        /// <returns>The Endpoint Name</returns>
        public string EndpointName { get; set; }

        /// <summary>
        /// Gets or sets the secret hex
        /// </summary>
        /// <returns>The Secret hex</returns>
        public string SecretHex { get; set; }

        /// <summary>
        /// Create a CreateRequest
        /// </summary>
        /// <param name="key">The PreSharedKey</param>
        /// <returns>Generated PSK</returns>
        public static connector_bootstrap.Model.PreSharedKey CreateRequest(PreSharedKey key)
        {
            return new connector_bootstrap.Model.PreSharedKey(EndpointName: key.EndpointName, SecretHex: key.SecretHex);
        }

        /// <summary>
        /// Map generated PSK to PSK
        /// </summary>
        /// <param name="key">The key to map</param>
        /// <returns>PSK</returns>
        public static PreSharedKey Map(connector_bootstrap.Model.PreSharedKeyWithoutSecret key)
        {
            return new PreSharedKey
            {
                EndpointName = key.EndpointName,
            };
        }
    }
}