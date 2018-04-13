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
    /// <typeparam name="F">The type passed into the filter function</typeparam>
    public interface IObserver<T, F>
    {
        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <value>
        /// The collection.
        /// </value>
        ObservableCollection<T> NotificationQueue { get; }

        /// <summary>
        /// Gets the waiting
        /// </summary>
        /// <value>
        /// The waiting
        /// </value>
        Queue<TaskCompletionSource<T>> Waiting { get; }

        /// <summary>
        /// Gets a value indicating whether the observer has been disposed
        /// </summary>
        bool Subscribed { get; }

        /// <summary>
        /// Takes this instance.
        /// </summary>
        /// <returns>Task of T</returns>
        Task<T> Next();

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