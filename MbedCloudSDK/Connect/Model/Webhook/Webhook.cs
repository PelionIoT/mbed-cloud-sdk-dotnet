// <copyright file="Webhook.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace MbedCloudSDK.Connect.Model.Webhook
{
    /// <summary>
    /// Webhook
    /// </summary>
    public class Webhook
    {
        /// <summary>
        /// The url of the webhook
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets k/V dictionary of any headers
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Webhook"/> class.
        /// Default constructor
        /// </summary>
        public Webhook()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Webhook"/> class.
        /// Create new webhook
        /// </summary>
        public Webhook(string url, Dictionary<string, string> headers = null)
        {
            Url = url;
            Headers = headers;
        }

        /// <summary>
        /// Map from api webhook to webhook
        /// </summary>
        /// <returns></returns>
        public static Webhook Map(mds.Model.Webhook data)
        {
            var webhook = new Webhook
            {
                Url = data.Url,
                Headers = data.Headers
            };
            return webhook;
        }

        /// <summary>
        /// Map to api webhook from webhook
        /// </summary>
        public static mds.Model.Webhook MapToApiWebook(Webhook data)
        {
            var webhook = new mds.Model.Webhook(data.Url)
            {
                Headers = data.Headers
            };
            return webhook;
        }
    }
}