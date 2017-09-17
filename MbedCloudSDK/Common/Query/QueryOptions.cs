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

        public Filter.Filter Filter { get; set; }

        /// <summary>
        /// Gets or sets the include.
        /// </summary>
        /// <value>Comma separate additional data to return. Currently supported: total_count.</value>
        public string Include { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryOptions"/> class.
        /// </summary>
        /// <param name="limit">Limit.</param>
        /// <param name="order">Order.</param>
        /// <param name="after">After.</param>
        /// <param name="include">Include.</param>
		/// <param name="filterString">Attributes.</param>
        public QueryOptions(int? limit = null, string order = null, string after = null, string include = null, string filterString = null)
		{
			Limit = limit;
			Order = order;
            After = after;
			Include = include;
            Filter = new MbedCloudSDK.Common.Filter.Filter(filterString);
		}
	}
}
