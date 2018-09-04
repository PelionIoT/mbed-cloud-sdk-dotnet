// <copyright file="SerializationSettings.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Client
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
        /// Gets the default settings.
        /// </summary>
        /// <returns>Settings</returns>
        public static JsonSerializerSettings GetDefaultSettings()
        {
            return GetSettings(new Dictionary<string, string>());
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
                ContractResolver = new RenameSwitchResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategyWithRenaming(renames),
                },
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            };

            settings.Converters.Add(new StringEnumConverter());

            return settings;
        }

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
    }
}