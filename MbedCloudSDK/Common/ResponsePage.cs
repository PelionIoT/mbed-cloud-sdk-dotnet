﻿// <copyright file="ResponsePage.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common
{
    using System.Collections.Generic;

    /// <summary>
    /// Used to access multiple pages of data., either through manually iterating pages or using iterators.
    /// </summary>
    /// <typeparam name="T">Response page</typeparam>
    public class ResponsePage<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponsePage{T}"/> class.
        /// Create new instance of response page.
        /// </summary>
        /// <param name="data">data</param>
        public ResponsePage(List<T> data)
        {
            Data = data;
            TotalCount = data.Count;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponsePage{T}"/> class.
        /// Create new instance of response page.
        /// </summary>
        /// <param name="after">after</param>
        /// <param name="hasMore">has more</param>
        /// <param name="limit">limit</param>
        /// <param name="order">order</param>
        /// <param name="totalCount">count</param>
        public ResponsePage(string after, bool? hasMore, int? limit, string order, int? totalCount)
        {
            Data = new List<T>();
            After = after;
            HasMore = hasMore;
            Limit = limit;
            Order = order;
            TotalCount = totalCount;
        }

        /// <summary>
        /// Gets or sets whether there are more results to display
        /// </summary>
        /// <value>Whether there are more results to display</value>
        public bool? HasMore { get; set; }

        /// <summary>
        /// Gets or sets total number of records
        /// </summary>
        /// <value>Total number of records</value>
        public int? TotalCount { get; set; }

        /// <summary>
        /// Gets or sets entity id for fetch after it
        /// </summary>
        /// <value>Entity id for fetch after it</value>
        public string After { get; set; }

        /// <summary>
        /// Gets or sets the number of results to return
        /// </summary>
        /// <value>The number of results to return</value>
        public int? Limit { get; set; }

        /// <summary>
        /// Gets or sets gets or Sets Data
        /// </summary>
        public List<T> Data { get; set; }

        /// <summary>
        /// Gets or sets order of returned records
        /// </summary>
        /// <value>Order of returned records</value>
        public string Order { get; set; }
    }
}