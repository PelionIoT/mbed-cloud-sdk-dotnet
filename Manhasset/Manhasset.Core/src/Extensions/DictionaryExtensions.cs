using System.Collections.Generic;

namespace Manhasset.Core.src.Extensions
{
    public static class DictionaryExtensions
    {
        public static void SafeAdd<Tkey, TValue>(this Dictionary<Tkey, TValue> me, Tkey key, TValue value)
        {
            if (!me.ContainsKey(key))
            {
                me.Add(key, value);
            }
        }
    }
}