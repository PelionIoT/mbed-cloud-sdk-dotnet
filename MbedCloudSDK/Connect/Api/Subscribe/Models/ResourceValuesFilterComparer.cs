// <copyright file="ResourceValuesFilterComparer.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe.Models
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// ResourceValuesFilterComparer
    /// </summary>
    public class ResourceValuesFilterComparer : IEqualityComparer<ResourceValuesFilter>
    {
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type T to compare.</param>
        /// <param name="y">The second object of type T to compare.</param>
        /// <returns>
        /// true if the specified objects are equal; otherwise, false.
        /// </returns>
        public bool Equals(ResourceValuesFilter x, ResourceValuesFilter y) => x.DeviceId == y.DeviceId && x.ResourcePaths.SequenceEqual(y.ResourcePaths);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public int GetHashCode(ResourceValuesFilter obj) => obj.GetHashCode();
    }
}