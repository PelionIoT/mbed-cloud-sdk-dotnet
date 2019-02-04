// <copyright file="HttpMethods.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace Mbed.Cloud.Foundation.RestClient
{
    /// <summary>
    /// HttpMethods
    /// </summary>
    public enum HttpMethods
    {
        /// <summary>
        /// The get
        /// </summary>
        GET = 0,

        /// <summary>
        /// The post
        /// </summary>
        POST = 1,

        /// <summary>
        /// The put
        /// </summary>
        PUT = 2,

        /// <summary>
        /// The delete
        /// </summary>
        DELETE = 3,

        /// <summary>
        /// The head
        /// </summary>
        HEAD = 4,

        /// <summary>
        /// The options
        /// </summary>
        OPTIONS = 5,

        /// <summary>
        /// The patch
        /// </summary>
        PATCH = 6,

        /// <summary>
        /// The merge
        /// </summary>
        MERGE = 7,

        /// <summary>
        /// The copy
        /// </summary>
        COPY = 8
    }
}