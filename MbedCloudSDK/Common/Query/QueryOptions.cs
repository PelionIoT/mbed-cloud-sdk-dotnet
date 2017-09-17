using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using Newtonsoft.Json;

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
        /// Id of the resource.
        /// </summary>
        public string Id { get; set; }

        public MbedCloudSDK.Common.Filter.Filter Filter { get; set; }

        /// <summary>
        /// Gets or sets the include.
        /// </summary>
        /// <value>Comma separate additional data to return. Currently supported: total_count.</value>
        public string Include { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MbedCloudSDK.Common.ListParams"/> class.
        /// </summary>
        /// <param name="limit">Limit.</param>
        /// <param name="order">Order.</param>
        /// <param name="after">After.</param>
        /// <param name="include">Include.</param>
		/// <param name="filterString">Attributes.</param>
        public QueryOptions(int? limit = null, string order = null, string after = null, string include = null, string filterString = null)
		{
			this.Limit = limit;
			this.Order = order;
            this.After = after;
			this.Include = include;
            this.Filter = new MbedCloudSDK.Common.Filter.Filter(filterString);
		} 
	}
}
