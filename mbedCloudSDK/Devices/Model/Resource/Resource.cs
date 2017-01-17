using mbedCloudSDK.Devices.Api;
using mbedCloudSDK.Devices.Model.Device;
using System;
using System.Collections.Generic;
using System.Text;

namespace mbedCloudSDK.Devices.Model.Resource
{
	/// <summary>
	/// Resource.
	/// </summary>
	public class Resource
	{
        private DevicesApi api;

        /// <summary>
        /// Id of the device this resource belongs to.
        /// </summary>
        public string DeviceId { get; private set; }

        /// <summary>
        /// Resource&#39;s type
        /// </summary>
        /// <value>Resource&#39;s type</value>
        public string Type { get; set; }
        
        /// <summary>
        /// The content type of the resource. &lt;br/&gt;&lt;br/&gt;&lt;b&gt;Important&lt;/b&gt;&lt;br/&gt; You are encouraged to use the resource types listed in the LWM2M specification: http://technical.openmobilealliance.org/Technical/technical-information/omna/lightweight-m2m-lwm2m-object-registry 
        /// </summary>
        /// <value>The content type of the resource. &lt;br/&gt;&lt;br/&gt;&lt;b&gt;Important&lt;/b&gt;&lt;br/&gt; You are encouraged to use the resource types listed in the LWM2M specification: http://technical.openmobilealliance.org/Technical/technical-information/omna/lightweight-m2m-lwm2m-object-registry </value>
        public string ConentType { get; set; }
        
        /// <summary>
        /// Resource&#39;s url.
        /// </summary>
        /// <value>Resource&#39;s url.</value>
        public string Uri { get; set; }
        
        /// <summary>
        /// Observable determines whether you can subscribe to changes for this resource. It can have values \&quot;true\&quot; or \&quot;false\&quot;. 
        /// </summary>
        /// <value>Observable determines whether you can subscribe to changes for this resource. It can have values \&quot;true\&quot; or \&quot;false\&quot;. </value>
        public bool? Observable { get; set; }
        
		/// <summary>
		/// Gets or sets the queue values.
		/// </summary>
		/// <value>The queue values.</value>
		public AsyncProducerConsumerCollection<String> Queue { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Resource" /> class.
        /// </summary>
        /// <param name="api">Devices api</param>
        /// <param name="options">Dictionary containing properties.</param>
        public Resource(DevicesApi api, string deviceID, IDictionary<string, object> options = null)
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

        public static Resource Map(DevicesApi api, string deviceID, mds.Model.Resource res)
        {
            Resource resource = new Resource(api, deviceID);
            resource.DeviceId = deviceID;
            resource.Type = res.Rt;
            resource.ConentType = res.Type;
            resource.Uri = res.Uri;
            resource.Observable = res.Obs;
            resource.Queue = new AsyncProducerConsumerCollection<string>();
            return resource;
        }

        /// <summary>
        /// Gets the value of the resource.
        /// </summary>
        public AsyncConsumer<string> GetResourceValue()
        {
            return this.api.GetResourceValue(this.DeviceId, this.Uri);
        }

        /// <summary>
        /// Set value of the resource.
        /// </summary>
        /// <param name="resourceValue">Value to set.</param>
        /// <param name="noResponse">Don't get a response.</param>
        /// <returns></returns>
        public AsyncConsumer<string> SetResourceValue(string resourceValue, bool? noResponse = null)
        {
            return this.api.SetResourceValue(this.DeviceId, this.Uri, resourceValue, noResponse);
        }

        /// <summary>
        /// Subscribe to this resource.
        /// </summary>
        /// <returns></returns>
        public AsyncConsumer<String> Subscribe()
        {
            return this.api.Subscribe(this.DeviceId, this);
        }

        /// <summary>
        /// Desubscribe this resource.
        /// </summary>
        /// <returns></returns>
        public void Unsubscribe()
        {
            this.api.Unsubscribe(this.DeviceId, this);
        }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Resource {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Conent Type: ").Append(ConentType).Append("\n");
            sb.Append("  Uri: ").Append(Uri).Append("\n");
            sb.Append("  Obs: ").Append(Observable).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
