using device_query_service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Devices.Model.Filter
{
    public class DeviceFilter
    {
        /// <summary>
        /// The description of the object
        /// </summary>
        /// <value>The description of the object</value>
        public string Description { get; set; }
        
        /// <summary>
        /// The time the object was created
        /// </summary>
        /// <value>The time the object was created</value>
        public DateTime? CreatedAt { get; set; }
        
        /// <summary>
        /// The time the object was updated
        /// </summary>
        /// <value>The time the object was updated</value>
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary>
        /// The device query
        /// </summary>
        /// <value>The device query</value>
        public string Query { get; set; }
        
        /// <summary>
        /// The ID of the query
        /// </summary>
        /// <value>The ID of the query</value>
        public string Id { get; set; }
        
        /// <summary>
        /// The name of the query
        /// </summary>
        /// <value>The name of the query</value>
        public string Name { get; set; }

        /// <summary>
        /// Create new Device filter class.
        /// </summary>
        /// <param name="options"></param>
        public DeviceFilter(IDictionary<string, object> options = null)
        {
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
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  Query: ").Append(Query).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        public static DeviceFilter Map(DeviceQueryDetail data)
        {
            DeviceFilter filter = new DeviceFilter();
            filter.CreatedAt = data.CreatedAt;
            filter.Description = data.Description;
            filter.Id = data.Id;
            filter.Name = data.Name;
            filter.Query = data.Query;
            filter.UpdatedAt = data.UpdatedAt;
            return filter;
        }
    }
}
