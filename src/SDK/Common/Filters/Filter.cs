using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Mbed.Cloud.Common.Filters
{
    public class Filter
    {
        private Dictionary<string, FilterItem> filterCollection;

        public Filter()
        {
            filterCollection = new Dictionary<string, FilterItem>();
        }

        public ReadOnlyDictionary<string, FilterItem> FilterCollection
        {
            get
            {
                return new ReadOnlyDictionary<string, FilterItem>(filterCollection);
            }
        }

        public void AddFilterItem(string key, FilterItem item)
        {
            if (!filterCollection.ContainsKey(key))
            {
                filterCollection.Add(key, item);
            }
        }

        public void RemoveFilterItem(string key)
        {
            if (filterCollection.ContainsKey(key))
            {
                filterCollection.Remove(key);
            }
        }
    }
}