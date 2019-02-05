// <copyright file="EnnumerableExtensions.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Extensions
{
    using System.Collections.Generic;

    /// <summary>
    /// EnnumerableExtensions
    /// </summary>
    public static class EnnumerableExtensions
    {
        /// <summary>
        /// To the hash set.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>HashSet</returns>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer = null)
        {
            return new HashSet<T>(source, comparer);
        }

        /// <summary>
        /// Adds the specified value.
        /// </summary>
        /// <typeparam name="T">Type to add</typeparam>
        /// <param name="e">The e.</param>
        /// <param name="value">The value.</param>
        /// <returns>The enumerable</returns>
        public static IEnumerable<T> Add<T>(this IEnumerable<T> e, T value)
        {
            foreach (var cur in e)
            {
                yield return cur;
            }

            yield return value;
        }
    }
}