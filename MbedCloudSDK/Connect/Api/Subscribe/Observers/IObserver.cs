// <copyright file="IObserver.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe.Observers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    /// <summary>
    /// Observer
    /// </summary>
    /// <typeparam name="T">Type stored</typeparam>
    public interface IObserver<T>
    {
        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <value>
        /// The collection.
        /// </value>
        ObservableCollection<T> Collection { get; }

        /// <summary>
        /// Gets the waiting
        /// </summary>
        /// <value>
        /// The waiting
        /// </value>
        Queue<TaskCompletionSource<T>> Waiting { get; }

        /// <summary>
        /// Gets the callbacks.
        /// </summary>
        /// <value>
        /// The callbacks.
        /// </value>
        List<Action<T>> Callbacks { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the observer has been disposed
        /// </summary>
        bool Disposed { get; set; }

        /// <summary>
        /// Takes this instance.
        /// </summary>
        /// <returns>Task of T</returns>
        Task<T> Take();

        /// <summary>
        /// Removes the callback.
        /// </summary>
        /// <param name="callback">The callback.</param>
        void RemoveCallback(Action<T> callback = null);

        /// <summary>
        /// Adds the callback.
        /// </summary>
        /// <param name="callback">The callback.</param>
        void AddCallback(Action<T> callback);

        /// <summary>
        /// Notifies the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        void Notify(T data);

        /// <summary>
        /// Unsubscribes this instance.
        /// </summary>
        void Unsubscribe();
    }
}