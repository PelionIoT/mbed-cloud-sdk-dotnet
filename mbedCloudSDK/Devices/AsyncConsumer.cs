using System;
using System.Threading.Tasks;

namespace mbedCloudSDK
{
	public class AsyncConsumer<T>
	{
		AsyncProducerConsumerCollection<T> collection;
		public AsyncConsumer(AsyncProducerConsumerCollection<T> collection)
		{
			this.collection = collection;
		}

		public async Task<T> GetValue()
		{
			var t = await collection.Take();
			return t;
		}
	}
}
