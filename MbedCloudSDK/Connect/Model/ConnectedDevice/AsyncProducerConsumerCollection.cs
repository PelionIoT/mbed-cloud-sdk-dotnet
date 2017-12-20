// <copyright file="AsyncProducerConsumerCollection.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Model.ConnectedDevice
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Async producer consumer collection.
    /// </summary>
    /// <typeparam name="T">Type of AsyncProducerConsumer</typeparam>
    public class AsyncProducerConsumerCollection<T>
    {
        private readonly ObservableCollection<T> collection = new ObservableCollection<T>();
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
                    collection.Add(item);
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
                    var first = collection.FirstOrDefault();
                    collection.Remove(first);
                    return Task.FromResult(first);
                }
                else
                {
                    var tcs = new TaskCompletionSource<T>();
                    waiting.Enqueue(tcs);
                    return tcs.Task;
                }
            }
        }

        /// <summary>
        /// Add a handler to consumer
        /// </summary>
        /// <param name="handler">The handler function</param>
        public void AddHandler(Action<object, NotifyCollectionChangedEventArgs> handler)
        {
            if (handler != null)
            {
                collection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(handler);
            }
        }
    }
}
