// <copyright file="EnumerableExtensions.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Tlv
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Extensions to IEnumerable
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Custom implementation of Aggregate
        /// </summary>
        /// <typeparam name="TSource">Type of source</typeparam>
        /// <typeparam name="TAccumulate">Type of accumalator</typeparam>
        /// <typeparam name="TResult">Type of result</typeparam>
        /// <param name="source">source</param>
        /// <param name="seed">seed</param>
        /// <param name="func">func</param>
        /// <returns>Accumalated value</returns>
        public static TAccumulate Aggregate<TSource, TAccumulate, TResult>(
        this IEnumerable<TSource> source,
        TAccumulate seed,
        Func<TAccumulate, TSource, int, TAccumulate> func)
        {
            var index = 0;
            var result = seed;
            foreach (TSource element in source)
            {
                if (func != null)
                {
                    result = func(result, element, index);
                    index += 1;
                }
            }

            return result;
        }
    }
}