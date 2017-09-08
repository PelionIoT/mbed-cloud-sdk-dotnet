using System;
using System.Threading.Tasks;

namespace MbedCloudSDK.Connect.Model.ConnectedDevice
{
	/// <summary>
	/// Async consumer.
	/// </summary>
	public class AsyncConsumer<T>
	{
        string AsyncId;
        AsyncProducerConsumerCollection<T> collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MbedCloudSDK.DeviceDirectory.AsyncConsumer`1"/> class.
        /// </summary>
        /// <param name="asyncId">AsyncId</param>
        /// <param name="collection">Collection.</param>
        public AsyncConsumer(string asyncId, AsyncProducerConsumerCollection<T> collection)
		{
            AsyncId = asyncId;
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

        /// <summary>
        /// Gets the string representation of the AsyncConsumer.
        /// </summary>
        /// <returns>The AsyncId.</returns>
        public override string ToString()
		{
            return AsyncId;
        }
	}
}