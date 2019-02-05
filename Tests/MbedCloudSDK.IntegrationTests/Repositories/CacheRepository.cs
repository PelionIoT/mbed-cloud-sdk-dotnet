using System.Collections.Generic;
using System.Linq;

namespace MbedCloudSDK.IntegrationTests.Repositories
{
    public class CacheRepository<T>
    {
        public Dictionary<string, T> Cache { get; set; } = new Dictionary<string, T>();

        public IEnumerable<T> ListItems()
        {
            return Cache.Values.AsEnumerable();
        }

        public T GetItem(string key)
        {
            if (!Cache.ContainsKey(key))
            {
                throw new KeyNotFoundException("no such instance");
            }

            return Cache.FirstOrDefault(i => i.Key == key).Value;
        }

        public void AddItem(string key, T value)
        {
            Cache.Add(key, value);
        }

        public void DeleteItem(string key)
        {
            if (!Cache.ContainsKey(key))
            {
                throw new KeyNotFoundException();
            }

            Cache.Remove(key);
        }

        public void DeleteAll(string key)
        {
            Cache.Clear();
        }
    }
}