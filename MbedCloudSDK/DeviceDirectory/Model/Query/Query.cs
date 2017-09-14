using device_directory.Model;
using MbedCloudSDK.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbedCloudSDK.Common.Filter;
using Newtonsoft.Json.Linq;

namespace MbedCloudSDK.DeviceDirectory.Model.Query
{
    /// <summary>
    /// Represents Query from device catalog API.
    /// </summary>
    public class Query
    {
        /// <summary>
        /// The time the object was created
        /// </summary>
        public DateTime? CreatedAt { get; set; }
        
        /// <summary>
        /// The time the object was updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// The device filter
        /// </summary>
        public Filter Filter { get; set; }

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
        public Query() 
        {
            Filter = new Filter();
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
            sb.Append("  Filter: ").Append(Filter).Append("\n");
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
            Query query = new Query();
            query.CreatedAt = data.CreatedAt;
            query.Id = data.Id;
            query.Name = data.Name;
            query.Filter = new MbedCloudSDK.Common.Filter.Filter(data.Query);
            query.UpdatedAt = data.UpdatedAt;
            return query;
        }
    }
}
