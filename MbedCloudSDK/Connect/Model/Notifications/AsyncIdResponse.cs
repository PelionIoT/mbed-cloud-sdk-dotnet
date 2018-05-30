// <copyright file="AsyncIdResponse.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Model.Notifications
{
    using MbedCloudSDK.Common;
    using Newtonsoft.Json;

    /// <summary>
    /// AsyncIdResponse
    /// </summary>
    public class AsyncIdResponse
    {
        /// <summary>
        /// Gets or sets the Status
        /// </summary>
        /// <returns>Status</returns>
        [JsonProperty("status")]
        public int? Status { get; set; }

        /// <summary>
        /// Gets or sets the Payload
        /// </summary>
        /// <returns>Payload</returns>
        [JsonProperty("payload")]
        public string Payload { get; set; }

        /// <summary>
        /// Gets or sets the MaxAge
        /// </summary>
        /// <returns>MaxAge</returns>
        [JsonProperty("max-age")]
        public string MaxAge { get; set; }

        /// <summary>
        /// Gets or sets the Error
        /// </summary>
        /// <returns>Error</returns>
        [JsonProperty("error")]
        public string Error { get; set; }

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        /// <returns>Id</returns>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the ContentType
        /// </summary>
        /// <returns>ContentType</returns>
        [JsonProperty("ct")]
        public string ContentType { get; set; }

        /// <summary>
        /// Map to AsyncIdResponse
        /// </summary>
        /// <param name="response">Response</param>
        /// <returns>The AsyncIdResponse</returns>
        public static AsyncIdResponse Map(mds.Model.AsyncIDResponse response)
        {
            var asyncIdResponse = new AsyncIdResponse
            {
                Status = response.Status,
                Payload = response.Payload,
                MaxAge = response.MaxAge,
                Error = response.Error,
                Id = response.Id,
                ContentType = response.Ct,
            };

            return asyncIdResponse;
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();
    }
}