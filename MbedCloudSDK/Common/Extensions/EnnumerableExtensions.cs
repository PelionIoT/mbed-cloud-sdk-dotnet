using System.Collections.Generic;

namespace MbedCloudSDK.Common.Extensions
{
    public static class EnnumerableExtensions
    {
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source,IEqualityComparer<T> comparer = null)
        {
            return new HashSet<T>(source, comparer);
        }
    }
}