using System;
namespace mbedCloudSDK.Devices
{
	/// <summary>
	/// Resource.
	/// </summary>
	public class Resource
	{
		private string path;

		/// <summary>
		/// Gets the path.
		/// </summary>
		/// <value>The path.</value>
		public string Path
		{
			get
			{
				return path;
			}
		}

		/// <summary>
		/// Gets or sets the queue.
		/// </summary>
		/// <value>The queue.</value>
		public AsyncProducerConsumerCollection<String> Queue { get; set;}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:mbedCloudSDK.Devices.Resource"/> class.
		/// </summary>
		/// <param name="path">Path.</param>
		public Resource(string path)
		{
			this.path = path;
			Queue = new AsyncProducerConsumerCollection<string>();
		}
	}
}
