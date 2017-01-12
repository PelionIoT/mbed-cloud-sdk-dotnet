using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mbedCloudSDK.Devices.Model
{
	/// <summary>
	/// Async producer consumer collection.
	/// </summary>
	public class AsyncProducerConsumerCollection<T>
	{
		private readonly Queue<T> m_collection = new Queue<T>();
		private readonly Queue<TaskCompletionSource<T>> m_waiting =
			new Queue<TaskCompletionSource<T>>();

		/// <summary>
		/// Add the specified item.
		/// </summary>
		/// <param name="item">Item.</param>
		public void Add(T item)
		{
			TaskCompletionSource<T> tcs = null;
			lock (m_collection)
			{
				if (m_waiting.Count > 0) tcs = m_waiting.Dequeue();
				else m_collection.Enqueue(item);
			}
			if (tcs != null) tcs.TrySetResult(item);
		}

		/// <summary>
		/// Take this instance.
		/// </summary>
		public Task<T> Take()
		{
			lock (m_collection)
			{
				if (m_collection.Count > 0)
				{
					return Task.FromResult(m_collection.Dequeue());
				}
				else
				{
					var tcs = new TaskCompletionSource<T>();
					m_waiting.Enqueue(tcs);
					return tcs.Task;
				}
			}
		}
	}
}
