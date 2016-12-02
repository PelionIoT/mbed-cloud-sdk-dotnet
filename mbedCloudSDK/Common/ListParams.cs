using System;
using System.ComponentModel;

namespace mbedCloudSDK.Common
{
	/// <summary>
	/// Parameters send with list requests.
	/// </summary>
	public class ListParams
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
		/// Gets or sets the filter.
		/// </summary>
		/// <value>Filter objects in response.</value>
		public string Filter { get; set; }

		/// <summary>
		/// Gets or sets the include.
		/// </summary>
		/// <value>Comma separate additional data to return. Currently supported: total_count.</value>
		public string Include { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:mbedCloudSDK.Common.ListParams"/> class.
		/// </summary>
		/// <param name="limit">Limit.</param>
		/// <param name="order">Order.</param>
		/// <param name="after">After.</param>
		/// <param name="filter">Filter.</param>
		/// <param name="include">Include.</param>
		public ListParams(int? limit = null, string order = null, string after = null, string filter = null, string include = null)
		{
			this.Limit = limit;
			this.Order = order;
			this.After = after;
			this.Filter = filter;
			this.Include = include;
		} 
	}
}
