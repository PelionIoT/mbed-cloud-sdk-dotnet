using mds.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MbedCloudSDK.Connect.Model.ConnectedDevice
{
    public class ConnectedDevice
    {
        private Connect.Api.ConnectApi api;

        /// <summary>
        /// Id of the endpoint.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Queue mode (default value is false).
        /// </summary>
        /// <value>Queue mode (default value is false).</value>
        public bool? QueueMode { get; set; }
        
        /// <summary>
        /// Endpoint type.
        /// </summary>
        /// <value>Endpoint type.</value>
        public string Type { get; set; }
       
        /// <summary>
        /// Possible values ACTIVE, STALE.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectedDevice" /> class.
        /// </summary>
        /// <param name="options">Dictionary containing properties.</param>
        /// <param name="api">Connect Api.</param>
        public ConnectedDevice(IDictionary<string, object> options = null, Connect.Api.ConnectApi api = null)
        {
            this.api = api;
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
        /// Map to Device object.
        /// </summary>
        /// <param name="endpoint">Endpoint response object.</param>
        /// <param name="api">optional DeviceDirectoryApi.</param>
        /// <returns></returns>
        public static ConnectedDevice Map(Endpoint endpoint, Connect.Api.ConnectApi api = null)
        {
            var device = new ConnectedDevice(null, api);
            device.Id = endpoint.Name;
            device.Status = endpoint.Status;
            device.QueueMode = endpoint.Q;
            device.Type = endpoint.Type;
            return device;
        }

        /// <summary>
        /// List resources for this device.
        /// </summary>
        /// <returns></returns>
        public List<Resource.Resource> ListResources()
        {
            return this.api.GetResources(this.Id);
        }

        /// <summary>
        /// Delete Resource.
        /// </summary>
        /// <param name="resourcePath">Path to the resource.</param>
        /// <param name="noResponse"></param>
        public void DeleteResource(string resourcePath, bool? noResponse = null)
        {
            this.api.DeleteResource(this.Id, resourcePath, noResponse);
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeviceDetail {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  QueueMode: ").Append(QueueMode.ToString()).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
