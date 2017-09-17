// <copyright file="ApiMetadata.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace MbedCloudSDK.Common
{
    /// <summary>
    /// Api meta data
    /// </summary>
    public class ApiMetadata
    {
        /// <summary>
        /// Gets or sets hTTP Status code of the API response
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets any error message returned
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets headers in the API response
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Gets or sets date of the API response
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets request ID of the transaction
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets or sets object type of the returned data
        /// </summary>
        public string Object { get; set; }

        /// <summary>
        /// Gets or sets etag of the returned data
        /// </summary>
        public object Etag { get; set; }

        /// <summary>
        /// Gets or sets method of the API request
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets uRL of the API request
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Map an IRestResponse to an ApiMetadata object
        /// </summary>
        /// <returns></returns>
        public static ApiMetadata Map(IRestResponse response)
        {
            var metadata = new ApiMetadata();
            var content = JObject.Parse(response.Content);
            if (response != null)
            {
                metadata.StatusCode = response.StatusCode;
                metadata.ErrorMessage = response.ErrorMessage;
                metadata.Headers = new Dictionary<string, string>();
                foreach (var header in response.Headers)
                {
                    metadata.Headers.Add(header.Name, header.Value.ToString());
                }

                metadata.Date = metadata.Headers.ContainsKey("Date") ? DateTime.Parse(metadata.Headers["Date"]) : DateTime.Now;
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
