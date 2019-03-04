// <copyright file="Query.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.DeviceDirectory.Model.Query
{
    using System;
    using System.Text;
    using device_directory.Model;
    using Mbed.Cloud.Common;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using MbedCloudSDK.Common.Filter;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents Query from device catalog API.
    /// </summary>
    public class Query : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Query"/> class.
        /// Default constructor
        /// </summary>
        public Query()
        {
            Filter = new Filter();
        }

        /// <summary>
        /// Gets the time the object was created
        /// </summary>
        [JsonProperty]
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// Gets the time the object was updated
        /// </summary>
        [JsonProperty]
        public DateTime? UpdatedAt { get; private set; }

        /// <summary>
        /// Gets or sets the device filter
        /// </summary>
        public Filter Filter { get; set; }

        /// <summary>
        /// Gets or sets the name of the query.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Map to Query object.
        /// </summary>
        /// <param name="data">device query</param>
        /// <returns>Query</returns>
        public static Query Map(DeviceQuery data)
        {
            var query = new Query
            {
                CreatedAt = data.CreatedAt,
                Id = data.Id,
                Name = data.Name,
                Filter = new Filter(data.Query),
                UpdatedAt = data.UpdatedAt
            };
            return query;
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();
    }
}
