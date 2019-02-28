// <copyright file="SerializationSettings.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace Mbed.Cloud.RestClient
{
    using System;
    using System.Collections.Generic;
    using Mbed.Cloud.Common;
    using Mbed.Cloud.Common.CustomSerializers;
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
        /// <returns>Settings</returns>
        public static JsonSerializerSettings GetSerializationSettings()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new RenameSwitchResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            };

            settings.Converters.Add(new StringEnumConverter());

            return settings;
        }

        /// <summary>
        /// Gets the deserialization settings.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>Serializer Settings</returns>
        public static JsonSerializerSettings GetDeserializationSettings(Config config)
        {
            var settings = GetSerializationSettings();
            settings.Converters.Clear();
            settings.Converters.Add(new TolerantEnumConverter());
            settings.Converters.Add(new EntityConverter(config));
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