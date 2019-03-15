using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Mbed.Cloud.RestClient;
using Newtonsoft.Json;

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

        public object GetEncodedValue(string key)
        {
            var filterItem = filterCollection.FirstOrDefault(f => f.Key == key);

            if (filterItem.Value != null)
            {
                var filterValue = filterItem.Value.Value;

                if (filterValue == null)
                {
                    return null;
                }

                if (filterValue is bool filterValueBool)
                {
                    return filterValueBool ? "true" : "false";
                }

                if (filterValue is DateTime filterValueDateTime)
                {
                    return filterValueDateTime.ToString(SerializationSettings.DateFormatString);
                }

                if (typeof(IEnumerable<string>).IsAssignableFrom(filterValue.GetType()))
                {
                    var filterValueList = (filterValue as IEnumerable).OfType<string>();
                    return string.Join(",", filterValueList);
                }

                if (filterValue is Entity filterValueEntity)
                {
                    return filterValueEntity.Id;
                }

                if (typeof(IDictionary).IsAssignableFrom(filterValue.GetType()))
                {
                    return JsonConvert.SerializeObject(filterValue);
                }

                return filterItem.Value.Value;
            }

            return null;
        }
    }
}