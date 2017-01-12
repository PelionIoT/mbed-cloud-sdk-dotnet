using System;
using System.Collections.Generic;

namespace mbedCloudSDK.Devices.Model
{
	/// <summary>
	/// Endpoint.
	/// </summary>
	public class Endpoint
	{
		private string name;

		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get
			{
				return name;
			}
		}

		/// <summary>
		/// Gets or sets the resources.
		/// </summary>
		/// <value>The resources.</value>
		public Dictionary<string, Resource> Resources { get; set;}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:mbedCloudSDK.Devices.Endpoint"/> class.
		/// </summary>
		/// <param name="name">Name.</param>
		public Endpoint(string name)
		{
			this.name = name;
			Resources = new Dictionary<string, Resource>();
		}
	}
}
