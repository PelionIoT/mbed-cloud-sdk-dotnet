using device_directory.Model;
using mbedCloudSDK.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mbedCloudSDK.DeviceDirectory.Model.Query
{
    /// <summary>
    /// Represents Query from device catalog API.
    /// </summary>
    public class Query
    {
        /// <summary>
        /// Prefix for custom attributes.
        /// </summary>
        public static readonly string CustomAttributesPrefix = "custom_attributes__";
        
        /// <summary>
        /// The time the object was created
        /// </summary>
        public DateTime? CreatedAt { get; set; }
        
        /// <summary>
        /// The time the object was updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        private string queryString;

        /// <summary>
        /// The device query
        /// </summary>
        [NameOverride(Name="filter")]
        [JsonProperty]
        public string QueryString {
            get {
                if (this.queryString != null)
                {
                    try
                    {
                        var attributeDictionary = Utils.ParseAttributeString(this.queryString);
                        var queryString = String.Join("&", attributeDictionary.Select(q => $"{q.Key}{q.Value.GetSuffix()}={q.Value.Value}"));
                        return queryString;
                    }
                    catch (Exception e)
                    {
                        return queryString;
                    }
                }
                return null;
            }
            set {
                queryString = value;
                // Set attributes and custom attributes
                /* 
                Attributes = new Dictionary<string, string>();
                CustomAttributes = new Dictionary<string, string>();
                string[] substrings = queryString.Split('&');
                if (substrings != null)
                {
                    foreach (var substring in substrings)
                    {
                        string[] att = substring.Split('=');
                        if (att.Length == 2)
                        {
                            if (att[0].StartsWith(Query.CustomAttributesPrefix))
                            {
                                CustomAttributes.Add(att[0].Replace(Query.CustomAttributesPrefix, string.Empty), att[1]);
                            }
                            else
                            {
                                Attributes.Add(att[0], att[1]);
                            }
                        }
                    }
                }
                */
            }
        }

        /// <summary>
        /// Attributes associated with Query.
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }

        /// <summary>
        /// Custom Attributes associated with Query.
        /// </summary>
        public Dictionary<string, string> CustomAttributes { get; set; }

        /// <summary>
        /// The ID of the query.
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// The name of the query.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Query() {}

        /// <summary>
        /// Create new Query class.
        /// </summary>
        /// <param name="options"></param>
        public Query(IDictionary<string, object> options = null)
        {
            this.Attributes = new Dictionary<string, string>();
            this.CustomAttributes = new Dictionary<string, string>();
            if (options != null)
            {
                foreach (KeyValuePair<string, object> item in options)
                {
                    var property = this.GetType().GetProperty(item.Key);
                    if (property != null)
                    {
                        property.SetValue(this, item.Value, null);
                    }
                }
            }
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeviceQueryDetail {\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  Filter: ").Append(QueryString).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Map to Query object.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Query Map(DeviceQuery data)
        {
            Query filter = new Query();
            filter.CreatedAt = data.CreatedAt;
            filter.Id = data.Id;
            filter.Name = data.Name;
            filter.QueryString = data.Query;
            filter.UpdatedAt = data.UpdatedAt;
            return filter;
        }
    }
}
