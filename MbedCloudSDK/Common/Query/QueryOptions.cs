// <copyright file="QueryOptions.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Query
{
    /// <summary>
    /// Parameters send with list requests.
    /// </summary>
    public class QueryOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryOptions"/> class.
        /// </summary>
        /// <param name="limit">The number of items returned in each page of query.</param>
        /// <param name="order">Order of the items returned.</param>
        /// <param name="after">The ID of the item to return from.</param>
        /// <param name="include">Comma separated list of fields to include in response.</param>
        /// <param name="filterString">Filter to apply to query.</param>
        /// <param name="id">Used when query requires an ID to be passed</param>
        public QueryOptions(int? limit = null, string order = null, string after = null, string include = null, string filterString = null, string id = null)
        {
            Limit = limit;
            Order = order;
            After = after;
            Include = include;
            Filter = new MbedCloudSDK.Common.Filter.Filter(filterString);
            Id = id;
        }

        /// <summary>
        /// Gets or sets the limit of objects in response.
        /// </summary>
        /// <value>The limit.</value>
        public int? Limit { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order (ASC or DESC, default ASC).</value>
        public string Order { get; set; }

        /// <summary>
        /// Gets or sets the after.
        /// </summary>
        /// <value>Objects after given element.</value>
        public string After { get; set; }

        /// <summary>
        /// Gets or sets id of the resource.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets filter
        /// </summary>
        public Filter.Filter Filter { get; set; }

        /// <summary>
        /// Gets or sets the include.
        /// </summary>
        /// <value>Comma separate additional data to return. Currently supported: total_count.</value>
        public string Include { get; set; }

        public int? PageSize { get; set; }

        public int? MaxResults { get; set; }
    }
}
