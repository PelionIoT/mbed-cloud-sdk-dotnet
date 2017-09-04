using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace mbedCloudSDK.Common
{
    public class ApiMetadata
    {
        public HttpStatusCode StatusCode { get; set; }
        public Dictionary<string,string> Headers { get; set; }
        public DateTime date { get; set; }
        public string RequestId { get; set; }
        public string Object { get; set; }
        public object Etag { get; set; }
        public string Method{ get; set; }
        public string Url { get; set; }
        public static ApiMetadata Map(IRestResponse response)
        {
            var metadata = new ApiMetadata();
            var content = JObject.Parse(response.Content);
            if (response != null)
            {
                metadata.StatusCode = response.StatusCode;
                metadata.Headers = new Dictionary<string, string>();
                foreach (var header in response.Headers)
                {
                    metadata.Headers.Add(header.Name, header.Value.ToString());
                }
                metadata.date = metadata.Headers.ContainsKey("Date") ? DateTime.Parse(metadata.Headers["Date"]) : DateTime.Now;
                metadata.RequestId = metadata.Headers.ContainsKey("X-Request-ID") ? metadata.Headers["X-Request-ID"] : null;
                metadata.Object = content["object"] != null ? content["object"].Value<string>() : null;
                metadata.Etag = content["etag"] != null ? content["etag"].Value<string>() : null;
                metadata.Method = response.Request.Method.ToString();
                metadata.Url = response.ResponseUri.ToString();
            }
            return metadata;
        }
    }
}