// <copyright file="Query.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.DeviceDirectory.Model.Query
{
    using System;
    using System.Text;
    using device_directory.Model;
    using MbedCloudSDK.Common.Filter;

    /// <summary>
    /// Represents Query from device catalog API.
    /// </summary>
    public class Query
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
        /// Gets or sets the time the object was created
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the time the object was updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the device filter
        /// </summary>
        public Filter Filter { get; set; }

        /// <summary>
        /// Gets or sets the ID of the query.
        /// </summary>
        public string Id { get; set; }

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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeviceQueryDetail {\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  Filter: ").Append(Filter).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
