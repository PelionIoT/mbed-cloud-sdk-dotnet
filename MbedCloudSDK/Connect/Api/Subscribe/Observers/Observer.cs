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
    /// <typeparam name="F">The type passed into the filter function</typeparam>
    /// <seealso cref="MbedCloudSDK.Connect.Api.Subscribe.Observers.IObserver{T, F}" />
    public abstract class Observer<T, F> : IObserver<T, F>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Observer{T, F}"/> class.
        /// </summary>
        protected Observer()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Delegate used for the OnNotify event
        /// </summary>
        /// <param name="data">The data to pass to event handler</param>
        public delegate void NotifyRaiser(T data);

        public delegate void UnsubscribedRaiser(string Id);

        public string Id { get; set; }

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <value>
        /// The collection.
        /// </value>
        public ObservableCollection<T> NotificationQueue { get; } = new ObservableCollection<T>();

        /// <summary>
        /// Gets the waiting
        /// </summary>
        /// <value>
        /// The waiting
        /// </value>
        public Queue<TaskCompletionSource<T>> Waiting { get; } = new Queue<TaskCompletionSource<T>>();

        /// <summary>
        /// Gets the list containing the functions used for filtering
        /// </summary>
        /// <returns>List of filter functions</returns>
        public List<Func<F, bool>> FilterFuncs { get; } = new List<Func<F, bool>>();

        /// <summary>
        /// The OnNotify event
        /// </summary>
        public event NotifyRaiser OnNotify;

        public event UnsubscribedRaiser OnUnsubscribed;

        /// <summary>
        /// Gets a value indicating whether the observer is subscribed
        /// </summary>
        public bool Subscribed { get; private set; } = true;

        /// <summary>
        /// Take this instance.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<T> Next()
        {
            lock (NotificationQueue)
            {
                if (NotificationQueue.Count > 0)
                {
                    var first = NotificationQueue.FirstOrDefault();
                    NotificationQueue.Remove(first);
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
        /// Notifies the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Notify(T data)
        {
            if (Subscribed)
            {
                if (OnNotify != null)
                {
                    OnNotify(data);
                }

                TaskCompletionSource<T> tcs = null;
                lock (NotificationQueue)
                {
                    if (Waiting.Count > 0)
                    {
                        tcs = Waiting.Dequeue();
                    }
                    else
                    {
                        NotificationQueue.Add(data);
                    }
                }

                if (tcs != null)
                {
                    tcs.TrySetResult(data);
                }
            }
        }

        /// <summary>
        /// Unsubscribes this instance.
        /// </summary>
        public void Unsubscribe()
        {
            Subscribed = false;
            OnUnsubscribed(Id);
        }
    }
}