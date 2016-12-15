using System;
using System.Threading.Tasks;

namespace mbedCloudSDK.Devices
{
	/// <summary>
	/// Async consumer.
	/// </summary>
	public class AsyncConsumer<T>
	{
		AsyncProducerConsumerCollection<T> collection;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:mbedCloudSDK.Devices.AsyncConsumer`1"/> class.
		/// </summary>
		/// <param name="collection">Collection.</param>
		public AsyncConsumer(AsyncProducerConsumerCollection<T> collection)
		{
			this.collection = collection;
		}

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <returns>The value.</returns>
		public async Task<T> GetValue()
		{
			var t = await collection.Take();
			return t;
		}
	}
}
