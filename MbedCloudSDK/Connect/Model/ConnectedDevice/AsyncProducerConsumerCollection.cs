// <copyright file="AsyncProducerConsumerCollection.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Model.ConnectedDevice
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Async producer consumer collection.
    /// </summary>
    /// <typeparam name="T">Type of AsyncProducerConsumer</typeparam>
    public class AsyncProducerConsumerCollection<T>
    {
        private readonly Queue<T> collection = new Queue<T>();
        private readonly Queue<TaskCompletionSource<T>> waiting =
            new Queue<TaskCompletionSource<T>>();

        /// <summary>
        /// Add the specified item.
        /// </summary>
        /// <param name="item">Item.</param>
        public void Add(T item)
        {
            TaskCompletionSource<T> tcs = null;
            lock (collection)
            {
                if (waiting.Count > 0)
                {
                    tcs = waiting.Dequeue();
                }
                else
                {
                    collection.Enqueue(item);
                }
            }

            if (tcs != null)
            {
                tcs.TrySetResult(item);
            }
        }

        /// <summary>
        /// Take this instance.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<T> Take()
        {
            lock (collection)
            {
                if (collection.Count > 0)
                {
                    return Task.FromResult(collection.Dequeue());
                }
                else
                {
                    var tcs = new TaskCompletionSource<T>();
                    waiting.Enqueue(tcs);
                    return tcs.Task;
                }
            }
        }
    }
}
