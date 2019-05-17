// <copyright file="ResponsePage.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace Mbed.Cloud.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MbedCloudSDK.Common.Extensions;

    /// <summary>
    /// Used to access multiple pages of data, either through manually iterating pages or using iterators.
    /// </summary>
    /// <typeparam name="T">Response page</typeparam>
    public class ResponsePage<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponsePage{T}"/> class.
        /// </summary>
        public ResponsePage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponsePage{T}"/> class.
        /// </summary>
        /// <param name="after">The after.</param>
        /// <param name="hasMore">The has more.</param>
        /// <param name="totalCount">The total count.</param>
        public ResponsePage(string after, bool? hasMore, int? totalCount)
        {
            After = after;
            HasMore = hasMore ?? false;
            TotalCount = totalCount;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponsePage{T}"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public ResponsePage(List<T> data)
        {
            Data = data;
        }

        /// <summary>
        /// Gets or sets entity id for fetch after it
        /// </summary>
        /// <value>Entity id for fetch after it</value>
        public string After { get; set; }

        /// <summary>
        /// Gets or sets gets or Sets Data
        /// </summary>
        public IEnumerable<T> Data { get; set; } = new List<T>();

        /// <summary>
        /// Gets or sets a value indicating whether there are more results to display
        /// </summary>
        /// <value>
        /// Whether there are more results to display
        /// </value>
        public bool HasMore { get; set; }

        /// <summary>
        /// Gets or sets total number of records
        /// </summary>
        /// <value>Total number of records</value>
        public int? TotalCount { get; set; }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Add(T item)
        {
            var newData = Data.Add(item);
            Data = newData;
        }

        /// <summary>
        /// Maps the data.
        /// </summary>
        /// <typeparam name="TResponseObject">The type of the response object.</typeparam>
        /// <param name="data">The data.</param>
        /// <param name="mappingFunction">The mapping function.</param>
        public void MapData<TResponseObject>(IEnumerable<TResponseObject> data, Func<TResponseObject, T> mappingFunction)
        {
            Data = data.Select(item => mappingFunction.Invoke(item));
            TotalCount = data.Count();
        }
    }
}