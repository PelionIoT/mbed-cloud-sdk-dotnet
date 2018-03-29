// <copyright file="Observer.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe.Observers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Observer
    /// </summary>
    /// <typeparam name="T">Type stored in observer</typeparam>
    /// <seealso cref="MbedCloudSDK.Connect.Api.Subscribe.Observers.IObserver{T}" />
    public abstract class Observer<T> : IObserver<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Observer{T}"/> class.
        /// </summary>
        protected Observer()
        {
            AddHandler();
        }

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <value>
        /// The collection.
        /// </value>
        public ObservableCollection<T> Collection { get; } = new ObservableCollection<T>();

        /// <summary>
        /// Gets the waiting
        /// </summary>
        /// <value>
        /// The waiting
        /// </value>
        public Queue<TaskCompletionSource<T>> Waiting { get; } = new Queue<TaskCompletionSource<T>>();

        /// <summary>
        /// Gets the callbacks.
        /// </summary>
        /// <value>
        /// The callbacks.
        /// </value>
        public List<Action<T>> Callbacks { get; } = new List<Action<T>>();

        /// <summary>
        /// Gets or sets a value indicating whether the observer has been disposed
        /// </summary>
        public bool Disposed { get; set; } = false;

        /// <summary>
        /// Take this instance.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<T> Take()
        {
            lock (Collection)
            {
                if (Collection.Count > 0)
                {
                    var first = Collection.FirstOrDefault();
                    Collection.Remove(first);
                    return Task.FromResult(first);
                }
                else
                {
                    var tcs = new TaskCompletionSource<T>();
                    Waiting.Enqueue(tcs);
                    return tcs.Task;
                }
            }
        }

        /// <summary>
        /// Removes the callback.
        /// </summary>
        /// <param name="callback">The callback.</param>
        public void RemoveCallback(Action<T> callback = null)
        {
            if (callback != null)
            {
                Callbacks.Remove(callback);
            }
            else
            {
                Callbacks.Clear();
            }
        }

        /// <summary>
        /// Adds the callback.
        /// </summary>
        /// <param name="callback">The callback.</param>
        public void AddCallback(Action<T> callback)
        {
            Callbacks.Add(callback);
        }

        /// <summary>
        /// Notifies the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Notify(T data)
        {
            TaskCompletionSource<T> tcs = null;
            lock (Collection)
            {
                if (Waiting.Count > 0)
                {
                    tcs = Waiting.Dequeue();
                }
                else
                {
                    Collection.Add(data);
                }
            }

            if (tcs != null)
            {
                tcs.TrySetResult(data);
                Callbacks.ForEach(c =>
                {
                    if (c != null)
                    {
                        c(data);
                    }
                });
            }
        }

        /// <summary>
        /// Unsubscribes this instance.
        /// </summary>
        public void Unsubscribe()
        {
            RemoveCallback();
        }

        /// <summary>
        /// Add a handler to consumer
        /// </summary>
        private void AddHandler()
        {
            Collection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler((object sender, NotifyCollectionChangedEventArgs e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    var res = Collection.LastOrDefault();
                    if (Callbacks != null)
                    {
                        Callbacks.ForEach(c =>
                        {
                            if (c != null)
                            {
                                c(res);
                            }
                        });
                    }
                }
            });
        }
    }
}