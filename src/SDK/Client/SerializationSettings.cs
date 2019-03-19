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
        public static readonly string DateFormatString = "yyyy-MM-dd'T'HH:mm:ss.fffZ";
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
                DateFormatString = SerializationSettings.DateFormatString,
                NullValueHandling = NullValueHandling.Ignore,
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
    }
}