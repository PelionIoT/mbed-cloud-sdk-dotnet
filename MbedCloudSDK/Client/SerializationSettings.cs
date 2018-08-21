// <copyright file="SerializationSettings.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Client
{
    using System.Collections.Generic;
    using MbedCloudSDK.Common.CustomSerializers;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// SerializationSettings
    /// </summary>
    public static class SerializationSettings
    {
        /// <summary>
        /// Gets the default settings.
        /// </summary>
        /// <returns>Settings</returns>
        public static JsonSerializerSettings GetDefaultSettings()
        {
            return new JsonSerializerSettings();
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <param name="renames">The renames.</param>
        /// <returns>Settings</returns>
        public static JsonSerializerSettings GetSettings(Dictionary<string, string> renames)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategyWithRenaming(renames),
                },
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            };

            return settings;
        }
    }
}