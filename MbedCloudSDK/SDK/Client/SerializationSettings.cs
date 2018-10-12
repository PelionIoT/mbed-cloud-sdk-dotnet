// <copyright file="SerializationSettings.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloud.SDK.Client
{
    using System;
    using System.Collections.Generic;
    using MbedCloudSDK.Common.CustomSerializers;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// SerializationSettings
    /// </summary>
    public static class SerializationSettings
    {
        /// <summary>
        /// Gets the settings with renames.
        /// </summary>
        /// <param name="renames">The renames.</param>
        /// <returns>Settings</returns>
        public static JsonSerializerSettings GetSettingsWithRenames(Dictionary<Type, Dictionary<string, string>> renames)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new RenameSwitchResolver(renames),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            };

            settings.Converters.Add(new StringEnumConverter());

            return settings;
        }

        /// <summary>
        /// Gets the default settings.
        /// </summary>
        /// <returns>Default settings</returns>
        public static JsonSerializerSettings GetDefaultSettings()
        {
            var settings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            };

            settings.Converters.Add(new StringEnumConverter());

            return settings;
        }
    }
}