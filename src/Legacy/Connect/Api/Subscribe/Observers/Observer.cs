// <copyright file="Observer.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe.Observers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using MbedCloudSDK.Connect.Api.Subscribe.Collections;
    using Nito.AsyncEx;

    /// <summary>
    /// Observer
    /// </summary>
    /// <typeparam name="T">Type stored in observer</typeparam>
    /// <typeparam name="F">The type passed into the filter function</typeparam>
    public abstract class Observer<T, F>
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

        /// <summary>
        /// UnsubscribedRaiser
        /// </summary>
        /// <param name="id">The identifier.</param>
        public delegate void UnsubscribedRaiser(string id);

        /// <summary>
        /// The OnNotify event
        /// </summary>
        public event NotifyRaiser OnNotify;

        /// <summary>
        /// Occurs when [on unsubscribed].
        /// </summary>
        public event UnsubscribedRaiser OnUnsubscribed;

        /// <summary>
        /// Gets the list containing the functions used for filtering
        /// </summary>
        /// <returns>List of filter functions</returns>
        public FilterFunctionCollection<F> FilterFuncs { get; } = new FilterFunctionCollection<F>();

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; }

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <value>
        /// The collection.
        /// </value>
        public AsyncCollection<T> NotificationQueue { get; } = new AsyncCollection<T>();

        /// <summary>
        /// Gets a value indicating whether the observer is subscribed
        /// </summary>
        public bool Subscribed { get; private set; } = true;

        /// <summary>
        /// Take this instance.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<T> NextAsync()
        {
            return NotificationQueue.TakeAsync();
        }

        /// <summary>
        /// Nexts this instance.
        /// </summary>
        /// <returns>The next value</returns>
        public T Next()
        {
            return NotificationQueue.Take();
        }

        /// <summary>
        /// Notifies the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public virtual async Task NotifyAsync(T data)
        {
            if (Subscribed)
            {
                OnNotify?.Invoke(data);
                await NotificationQueue.AddAsync(data);
            }
        }

        /// <summary>
        /// Notifies the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public virtual void Notify(T data)
        {
            if (Subscribed)
            {
                OnNotify?.Invoke(data);
                NotificationQueue.Add(data);
            }
        }

        /// <summary>
        /// Unsubscribes this instance.
        /// </summary>
        public void Unsubscribe()
        {
            Subscribed = false;
            OnUnsubscribed?.Invoke(Id);
        }
    }
}