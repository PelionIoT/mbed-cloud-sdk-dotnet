// <copyright file="PresubscriptionComparer.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Model.Subscription
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// PresubscriptionComparer
    /// </summary>
    public class PresubscriptionComparer : IEqualityComparer<Presubscription>
    {
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type T to compare.</param>
        /// <param name="y">The second object of type T to compare.</param>
        /// <returns>
        /// true if the specified objects are equal; otherwise, false.
        /// </returns>
        public bool Equals(Presubscription x, Presubscription y) => x.DeviceId == y.DeviceId && x.ResourcePaths.SequenceEqual(y.ResourcePaths);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public int GetHashCode(Presubscription obj) => obj.GetHashCode();
    }
}