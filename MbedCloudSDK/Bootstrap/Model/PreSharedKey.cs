// <copyright file="PreSharedKey.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Bootstrap.Model
{
    using System;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using Newtonsoft.Json;

    /// <summary>
    /// PreSharedKey
    /// </summary>
    /// <para>
    /// For more information about such keys, have a look at <a href="https://cloud.mbed.com/docs/latest/connecting/mbed-client-lite-security-considerations.html"/>
    /// </para>
    public class PreSharedKey : BaseModel
    {
        /// <summary>
        /// Gets or sets the EndpointName
        /// </summary>
        /// <para>
        /// Note: It has to be 16-64 <a href="https://en.wikipedia.org/wiki/ASCII#Printable_characters">printable</a> (non-control) ASCII characters. It also must be globally unique. Consider using vendor-MAC-ID-device-model.
        /// </para>
        /// <example>
        /// "myEndpoint.host.com"
        /// </example>
        /// <returns>The Endpoint Name</returns>
        public string EndpointName { get; set; }

        /// <summary>
        /// Gets or sets the secret hex
        /// </summary>
        /// <para>
        ///  Note: It is not case sensitive; 4a is same as 4A, and it is allowed with or without 0x in the beginning. The minimum length of the secret is 128 bits and maximum 256 bits.
        /// </para>
        /// <example>
        /// "4a4a4a4a4a4a4a4a4a4a4a4a4a4a4a4a"
        /// </example>
        /// <returns>The Secret hex</returns>
        public string SecretHex { get; set; }

        /// <summary>
        /// Gets created at
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        [JsonProperty]
        public DateTime? CreatedAt { get; private set; }

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
                CreatedAt = key.CreatedAt,
            };
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();
    }
}