using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

        public object getEncodedValue(string key)
        {
            var filterItem = filterCollection.FirstOrDefault(f => f.Key == key);

            if (filterItem.Value != null)
            {
                return filterItem.Value;
            }

            return null;
        }
    }
}