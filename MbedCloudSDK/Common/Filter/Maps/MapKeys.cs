// <copyright file="MapKeys.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Filter.Maps
{
    using System;

    /// <summary>
    /// Map Keys
    /// </summary>
    public static class MapKeys
    {
        private static string[] mapsFrom = new[] { "alias", "bootstrap_certificate_expiration", "certificate_fingerprint", "certificate_issuer_id", "connector_certificate_expiration", "device_type", "event_date", "type", "finished_at", "manifest_id", "manifest_url", "scheduled_at" };

        private static string[] mapsTo = new[] { "endpoint_name", "bootstrap_expiration_date", "device_key", "ca_id", "connector_expiration_date", "endpoint_type", "date_time", "event_type", "finished", "root_manifest_id", "root_manifest_url", "when" };

        /// <summary>
        /// Map from key to key
        /// </summary>
        /// <param name="input">The key to map</param>
        /// <returns>The mapped key</returns>
        public static string Map(string input)
        {
            var index = Array.IndexOf(mapsFrom, input);
            if (index > -1)
            {
                return mapsTo[index];
            }

            return input;
        }
    }
}