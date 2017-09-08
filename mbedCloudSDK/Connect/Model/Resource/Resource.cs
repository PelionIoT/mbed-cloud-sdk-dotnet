using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.Connect.Model.ConnectedDevice;
using System;
using System.Collections.Generic;
using System.Text;

namespace MbedCloudSDK.Connect.Model.Resource
{
	/// <summary>
	/// Resource.
	/// </summary>
	public class Resource
	{
        private Connect.Api.ConnectApi _api;

        /// <summary>
        /// Id of the device this resource belongs to.
        /// </summary>
        public string DeviceId { get; private set; }

        /// <summary>
        /// Resource&#39;s type
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// The content type of the resource. You are encouraged to use the resource types listed in the LWM2M specification: http://technical.openmobilealliance.org/Technical/technical-information/omna/lightweight-m2m-lwm2m-object-registry 
        /// </summary>
        public string ConentType { get; set; }
        
        /// <summary>
        /// Resource url.
        /// </summary>
        /// <value>Resource&#39;s url.</value>
        public string Path { get; set; }
        
        /// <summary>
        /// Observable determines whether you can subscribe to changes for this resource. 
        /// </summary>
        public bool? Observable { get; set; }
        
		/// <summary>
		/// Gets or sets the queue values.
		/// </summary>
		public AsyncProducerConsumerCollection<String> Queue { get; set; }

        /// <summary>
        /// Initializes new Resource.
        /// </summary>
        /// <param name="deviceID">Id of the device that the resource belongs to.</param>
        /// <param name="options">Dictionary used to initialize Resource.</param>
        /// <param name="api">DeviceDirectory API.</param>
        public Resource(string deviceID, IDictionary<string, object> options = null, Connect.Api.ConnectApi api = null)
        {
            _api = api;
            DeviceId = deviceID;
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
        /// Map to Resource object.
        /// </summary>
        /// <param name="api"></param>
        /// <param name="deviceID">Id of the devi</param>
        /// <param name="res"></param>
        /// <returns></returns>
        public static Resource Map(string deviceID, mds.Model.Resource res, Connect.Api.ConnectApi api)
        {
            Resource resource = new Resource(deviceID, null, api);
            resource.DeviceId = deviceID;
            resource.Type = res.Rt;
            resource.ConentType = res.Type;
            resource.Path = res.Uri;
            resource.Observable = res.Obs;
            resource.Queue = new AsyncProducerConsumerCollection<string>();
            return resource;
        }

        /// <summary>
        /// Gets the value of the resource.
        /// </summary>
        public string GetResourceValue()
        {
            return this._api.GetResourceValue(this.DeviceId, this.Path);
        }

        /// <summary>
        /// Set value of the resource.
        /// </summary>
        /// <param name="resourceValue">Value to set.</param>
        /// <param name="noResponse">Don't get a response.</param>
        /// <returns></returns>
        public AsyncConsumer<string> SetResourceValue(string resourceValue, bool? noResponse = null)
        {
            return this._api.SetResourceValue(this.DeviceId, this.Path, resourceValue, noResponse);
        }

        /// <summary>
        /// Subscribe to this resource.
        /// </summary>
        /// <returns></returns>
        public AsyncConsumer<String> Subscribe()
        {
            return this._api.AddResourceSubscription(this.DeviceId, this.Path);
        }

        /// <summary>
        /// Desubscribe this resource.
        /// </summary>
        /// <returns></returns>
        public void Unsubscribe()
        {
            this._api.DeleteResourceSubscription(this.DeviceId, this.Path);
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
            sb.Append("  Uri: ").Append(Path).Append("\n");
            sb.Append("  Obs: ").Append(Observable).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}