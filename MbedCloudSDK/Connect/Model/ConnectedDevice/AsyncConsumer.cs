// <copyright file="AsyncConsumer.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Model.ConnectedDevice
{
    using System.Threading.Tasks;

    /// <summary>
    /// Async consumer.
    /// </summary>
    /// <typeparam name="T">Type of Async Consumer</typeparam>
    public class AsyncConsumer<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncConsumer{T}"/> class.
        /// </summary>
        /// <param name="asyncId">AsyncId</param>
        /// <param name="collection">Collection.</param>
        public AsyncConsumer(string asyncId, AsyncProducerConsumerCollection<T> collection)
        {
            AsyncId = asyncId;
            Collection = collection;
        }

        /// <summary>
        /// Gets or sets the AsyncId
        /// </summary>
        /// <returns>The Async Id</returns>
        public string AsyncId { get; set; }

        /// <summary>
        /// Gets or sets the AsyncProducerConsumerCollection
        /// </summary>
        /// <returns>The AsyncProducerConsumercollection</returns>
        public AsyncProducerConsumerCollection<T> Collection { get; set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>The value.</returns>
        public async Task<T> GetValue()
        {
            var t = await Collection.Take();
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