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
        private string asyncId;
        private AsyncProducerConsumerCollection<T> collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncConsumer{T}"/> class.
        /// </summary>
        /// <param name="asyncId">AsyncId</param>
        /// <param name="collection">Collection.</param>
        public AsyncConsumer(string asyncId, AsyncProducerConsumerCollection<T> collection)
        {
            this.asyncId = asyncId;
            this.collection = collection;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>The value.</returns>
        public async Task<T> GetValue()
        {
            var t = await collection.Take();
            return t;
        }

        /// <summary>
        /// Gets the string representation of the AsyncConsumer.
        /// </summary>
        /// <returns>The AsyncId.</returns>
        public override string ToString()
        {
            return asyncId;
        }
    }
}