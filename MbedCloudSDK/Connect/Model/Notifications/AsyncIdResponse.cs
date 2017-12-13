// <copyright file="AsyncIdResponse.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
namespace MbedCloudSDK.Connect.Model.Notifications
{
    /// <summary>
    /// AsyncIdResponse
    /// </summary>
    public class AsyncIdResponse
    {
        /// <summary>
        /// Gets or sets the Status
        /// </summary>
        /// <returns>Status</returns>
        public int? Status { get; set; }

        /// <summary>
        /// Gets or sets the Payload
        /// </summary>
        /// <returns>Payload</returns>
        public string Payload { get; set; }

        /// <summary>
        /// Gets or sets the MaxAge
        /// </summary>
        /// <returns>MaxAge</returns>
        public string MaxAge { get; set; }

        /// <summary>
        /// Gets or sets the Error
        /// </summary>
        /// <returns>Error</returns>
        public string Error { get; set; }

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        /// <returns>Id</returns>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the ContentType
        /// </summary>
        /// <returns>ContentType</returns>
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
    }
}